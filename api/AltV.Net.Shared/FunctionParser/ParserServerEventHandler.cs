using System;
using System.Collections.Generic;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net.FunctionParser
{
    internal interface IParserServerEventHandler
    {
        void Call(MValueConst[] mValueArray);
    }

    internal class ParserServerEventHandler<TFunc> : IParserServerEventHandler where TFunc : Delegate
    {
        private readonly TFunc @delegate;

        private readonly ServerEventParser<TFunc> serverEventParser;

        public ParserServerEventHandler(TFunc @delegate, ServerEventParser<TFunc> serverEventParser)
        {
            this.@delegate = @delegate;
            this.serverEventParser = serverEventParser;
        }

        public void Call(MValueConst[] mValueArray)
        {
            serverEventParser(mValueArray, @delegate);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ParserServerEventHandler<TFunc> parserServerEventHandler)) return false;
            if (parserServerEventHandler.@delegate != @delegate) return false;
            return parserServerEventHandler.serverEventParser == serverEventParser;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<TFunc>.Default.GetHashCode(@delegate) * 397) ^ (serverEventParser != null ? serverEventParser.GetHashCode() : 0);
            }
        }
    }
}