using System;
using System.Reflection;
using AltV.Net.Elements.Entities;

namespace AltV.Net.FunctionParser
{
    public class ScriptFunction
    {
        private static void WrongType(MethodInfo methodInfo, Type expected, Type got)
        {
            Console.WriteLine(
                $"{methodInfo} Expected {expected} param, but got {got}");
        }

        private static void WrongLength(MethodInfo methodInfo, int expected, int got)
        {
            Console.WriteLine(
                $"{methodInfo} Expected {expected} parameters, but got {got}");
        }

        private struct ScriptFunctionParameter
        {
            public readonly bool BaseObjectCheck;

            public readonly Type ParameterType;

            public ScriptFunctionParameter(bool baseObjectCheck, Type parameterType)
            {
                BaseObjectCheck = baseObjectCheck;
                ParameterType = parameterType;
            }
        }

        public static ScriptFunction Create(Delegate @delegate, Type[] types)
        {
            var parameters = @delegate.Method.GetParameters();
            if (parameters.Length != types.Length)
            {
                WrongLength(@delegate.Method, types.Length, parameters.Length);
                return null;
            }

            var scriptFunctionParameters = new ScriptFunctionParameter[types.Length];

            for (int i = 0, length = types.Length; i < length; i++)
            {
                var type = types[i];
                if (typeof(IBaseObject).IsAssignableFrom(type))
                {
                    if (type.IsAssignableFrom(parameters[i].ParameterType))
                    {
                        scriptFunctionParameters[i] = new ScriptFunctionParameter(true, type);
                        continue;
                    }

                    WrongType(@delegate.Method, type, parameters[i].ParameterType);
                    return null;
                }

                if (type == parameters[i].ParameterType)
                {
                    scriptFunctionParameters[i] = new ScriptFunctionParameter(false, type);
                    continue;
                }

                WrongType(@delegate.Method, type, parameters[i].ParameterType);
                return null;
            }

            return new ScriptFunction(@delegate, scriptFunctionParameters);
        }

        private readonly object[] args;

        private readonly Delegate @delegate;

        private readonly ScriptFunctionParameter[] scriptFunctionParameters;

        private bool valid = true;

        private int currentIndex = 0;

        private ScriptFunction(Delegate @delegate, ScriptFunctionParameter[] scriptFunctionParameters)
        {
            args = new object[scriptFunctionParameters.Length];
            this.@delegate = @delegate;
            this.scriptFunctionParameters = scriptFunctionParameters;
        }

        public void Set(object value)
        {
            //if (!valid) return;
            var index = currentIndex++;
            /*var scriptFunctionParameter = scriptFunctionParameters[index];
            if (scriptFunctionParameter.BaseObjectCheck)
            {
                if (!value.GetType().IsAssignableFrom(scriptFunctionParameter.ParameterType))
                {
                    valid = false;
                    WrongType(@delegate.Method, scriptFunctionParameter.ParameterType, value.GetType());
                    return;
                }
            }*/

            args[index] = value;
        }

        public void Call()
        {
            valid = true;
            currentIndex = 0;
            if (!valid) return;
            try
            {
                @delegate.DynamicInvoke(args);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}