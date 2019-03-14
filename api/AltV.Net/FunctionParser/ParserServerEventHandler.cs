using System;
using AltV.Net.Native;

namespace AltV.Net.FunctionParser
{
    public interface IParserServerEventHandler
    {
        void Call(ref MValueArray mValueArray);
    }

    public class ParserServerEventHandler<TFunc> : IParserServerEventHandler where TFunc : Delegate
    {
        private readonly TFunc @delegate;

        private readonly ServerEventParser<TFunc> serverEventParser;

        public ParserServerEventHandler(TFunc @delegate, ServerEventParser<TFunc> serverEventParser)
        {
            this.@delegate = @delegate;
            this.serverEventParser = serverEventParser;
        }

        public void Call(ref MValueArray mValueArray)
        {
            serverEventParser(ref mValueArray, @delegate);
        }
    }
}