using AltV.Net.Native;

namespace AltV.Net.FunctionParser
{
    public delegate void ServerEventParser<in TFunc>(ref MValueArray mValueArray, TFunc func);
}