using System;

namespace AltV.Net.FunctionParser
{
    public class ScriptFunction
    {
        public static ScriptFunction Create(int argsLength, Delegate @delegate)
        {
            return new ScriptFunction(argsLength, @delegate);
        }

        public readonly object[] Args;

        private readonly Delegate @delegate;

        private ScriptFunction(int argsLength, Delegate @delegate)
        {
            Args = new object[argsLength];
            this.@delegate = @delegate;
        }

        public void Call()
        {
            @delegate.DynamicInvoke(Args);
        }
    }
}