using System;
using System.Collections.Generic;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.FunctionParser
{
    internal interface IParserClientEventHandler
    {
        void Call(IPlayer player, MValueConst[] mValueArray);
    }

    //TODO: make event handler a struct
    internal class ParserClientEventHandler<TFunc> : IParserClientEventHandler where TFunc : Delegate
    {
        private readonly TFunc @delegate;

        private readonly ClientEventParser<TFunc> clientEventParser;

        public ParserClientEventHandler(TFunc @delegate, ClientEventParser<TFunc> clientEventParser)
        {
            this.@delegate = @delegate;
            this.clientEventParser = clientEventParser;
        }

        public void Call(IPlayer player, MValueConst[] mValueArray)
        {
            clientEventParser(player, mValueArray, @delegate);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ParserClientEventHandler<TFunc> parserClientEventHandler)) return false;
            if (parserClientEventHandler.@delegate != @delegate) return false;
            return parserClientEventHandler.clientEventParser == clientEventParser;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<TFunc>.Default.GetHashCode(@delegate) * 397) ^ (clientEventParser != null ? clientEventParser.GetHashCode() : 0);
            }
        }
    }
}