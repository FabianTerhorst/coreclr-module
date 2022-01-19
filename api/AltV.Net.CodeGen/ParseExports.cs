using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AltV.Net.CodeGen
{
    public static class ParseExports
    {
        public struct CMethod
        {
            public string ReturnType;

            public string Name;

            public CMethodParam[] Params;
        }

        public struct CMethodParam
        {
            public string Type;
            public string Name;
        }

        // header parser

        private const string ExportExpression = "EXPORT ";

        private const string SemicolonExpression = ";";

        // method parser

        private const string BlankExpression = " ";

        private const string OpenedBracketExpression = "(";

        private const string ClosedBracketExpression = ")";

        // method params parser

        private const string CommaExpression = ",";

        private const string AndExpression = "&";

        private const string MultiplicationExpression = "*";

        // param namen sind getrennt mit '*' oder '&' oder ' ' der kleinste index > 0 wird genommen von hinten nach vorne, also  erst string reversen
        private static CMethod ParseMethod(ReadOnlySpan<char> span)
        {
            var methodReturnTypeEndBlank = span.IndexOf(BlankExpression);
            if (methodReturnTypeEndBlank == -1)
            {
                methodReturnTypeEndBlank = int.MaxValue;
            }
            var methodReturnTypeEndNewLine = span.IndexOf(Environment.NewLine);
            if (methodReturnTypeEndNewLine == -1)
            {
                methodReturnTypeEndNewLine = int.MaxValue;
            }
            
            var firstOpenedBracketIndex = span.IndexOf(OpenedBracketExpression);
            bool foundString = false;
            int methodNameStartIndex = -1;
            while (firstOpenedBracketIndex > 0)
            {
                var currentChar = span[firstOpenedBracketIndex];
                if (foundString)
                {
                    if (currentChar == ' ')
                    {
                        methodNameStartIndex = firstOpenedBracketIndex;
                        break;
                    }
                } else if (currentChar != ' ')
                {
                    foundString = true;
                }
                firstOpenedBracketIndex--;
            }

            var methodReturnTypeEnd = Math.Max(methodNameStartIndex, Math.Min(methodReturnTypeEndBlank, methodReturnTypeEndNewLine));
            
            if (methodReturnTypeEnd == -1)
            {
                throw new ArgumentException("Wrong c method:" + span.ToString());
            }

            var methodReturnType = span.Slice(0, methodReturnTypeEnd).ToString();
            var methodNameAndParamsSpan = span.Slice(methodReturnTypeEnd + BlankExpression.Length);
            var openedBracketIndex = methodNameAndParamsSpan.IndexOf(OpenedBracketExpression);
            if (openedBracketIndex == -1)
            {
                throw new ArgumentException("Wrong c method:" + span.ToString());
            }

            var methodName = methodNameAndParamsSpan.Slice(0, openedBracketIndex).ToString();
            var closedBracketIndex = methodNameAndParamsSpan.IndexOf(ClosedBracketExpression);
            if (closedBracketIndex == -1)
            {
                throw new ArgumentException("Wrong c method:" + span.ToString());
            }

            var methodParams = methodNameAndParamsSpan.Slice(openedBracketIndex + OpenedBracketExpression.Length,
                closedBracketIndex - (openedBracketIndex + OpenedBracketExpression.Length));

            var methodParameters = new LinkedList<CMethodParam>();

            int commaIndex;
            do
            {
                commaIndex = methodParams.IndexOf(CommaExpression);
                ReadOnlySpan<char> paramSpan;
                if (commaIndex == -1)
                {
                    if (methodParams.Length == 0) break;
                    paramSpan = methodParams.Slice(0, methodParams.Length);
                    methodParams.Slice(methodParams.Length);
                }
                else
                {
                    paramSpan = methodParams.Slice(0, commaIndex);
                    methodParams = methodParams.Slice(commaIndex + 1);
                }

                var trimmedParam = paramSpan.Trim();

                var blankIndex = trimmedParam.LastIndexOf(BlankExpression);
                var andIndex = trimmedParam.LastIndexOf(AndExpression);
                var multiplicationIndex = trimmedParam.LastIndexOf(MultiplicationExpression);
                var paramNameStart = Math.Max(blankIndex, Math.Max(andIndex, multiplicationIndex));
                var paramType = trimmedParam.Slice(0, paramNameStart + 1); //.Trim();
                var paramName = trimmedParam.Slice(paramNameStart + 1); //.Trim();

                if (!trimmedParam.ToString().Equals(paramType.ToString() + paramName.ToString()))
                {
                    throw new ArgumentException("Wrong converted:" + trimmedParam.ToString());
                }

                paramType = paramType.Trim();
                paramName = paramName.Trim();

                var paramTypeString = paramType.ToString();
                var paramNameString = paramName.ToString();
                
                if (paramNameString.EndsWith("[]"))
                {
                    paramNameString = paramNameString.Replace("[]", "");
                    paramTypeString += "[]";
                }

                methodParameters.AddLast(new CMethodParam {Type = paramTypeString, Name = paramNameString});
            } while (commaIndex != -1);


            return new CMethod {ReturnType = methodReturnType, Name = methodName.Replace("\n", "").Replace("\r", ""), Params = methodParameters.ToArray()};
        }

        private static string RemoveComments(string text)
        {
            var blockComments = @"/\*(.*?)\*/";
            var lineComments = @"//(.*?)\r?\n";
            var strings = @"""((\\[^\n]|[^""\n])*)""";
            var verbatimStrings = @"@(""[^""]*"")+";
            return Regex.Replace(text,
                blockComments + "|" + lineComments + "|" + strings + "|" + verbatimStrings,
                me => {
                    if (me.Value.StartsWith("/*") || me.Value.StartsWith("//"))
                        return me.Value.StartsWith("//") ? Environment.NewLine : "";
                    // Keep the literal strings
                    return me.Value;
                },
                RegexOptions.Singleline);
        }

        public static CMethod[] Parse(string text)
        {
            var methods = new LinkedList<CMethod>();
            var span = RemoveComments(text).AsSpan();
            int index;
            while ((index = span.IndexOf(ExportExpression)) != -1)
            {
                span = span.Slice(index + ExportExpression.Length);
                var nextSemicolon = span.IndexOf(SemicolonExpression);
                if (nextSemicolon != -1)
                {
                    var methodSpan = span.Slice(0, nextSemicolon);
                    methods.AddLast(ParseMethod(methodSpan));
                }
            }

            return methods.ToArray();
        }
    }
}