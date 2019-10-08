using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.FunctionParser
{
    public interface IParserClientEventHandler
    {
        void Call(IPlayer player, ref MValueArray mValueArray);
    }

    //TODO: make event handler a struct
    public class ParserClientEventHandler<TFunc> : IParserClientEventHandler where TFunc : Delegate
    {
        private readonly TFunc @delegate;

        private readonly ClientEventParser<TFunc> clientEventParser;

        public ParserClientEventHandler(TFunc @delegate, ClientEventParser<TFunc> clientEventParser)
        {
            this.@delegate = @delegate;
            this.clientEventParser = clientEventParser;
        }

        public void Call(IPlayer player, ref MValueArray mValueArray)
        {
            clientEventParser(player, ref mValueArray, @delegate);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ParserClientEventHandler<TFunc> parserClientEventHandler)) return false;
            if (parserClientEventHandler.@delegate != @delegate) return false;
            if (parserClientEventHandler.clientEventParser != clientEventParser) return false;
            return true;
        }
    }
}