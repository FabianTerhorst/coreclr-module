using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net.FunctionParser
{
    public delegate void ServerEventParser<in TFunc>(MValueConst[] mValueArray, TFunc func);
}