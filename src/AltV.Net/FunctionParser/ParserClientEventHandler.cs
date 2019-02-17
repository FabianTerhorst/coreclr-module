using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.FunctionParser
{
    public interface IParserEventHandler
    {
        void Call(IPlayer player, ref MValueArray mValueArray);
    }

    public class ParserClientEventHandler<TFunc> : IParserEventHandler where TFunc : Delegate
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
    }
}