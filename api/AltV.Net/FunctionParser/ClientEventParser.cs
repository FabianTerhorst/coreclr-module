using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.FunctionParser
{
    public delegate void ClientEventParser<in TFunc>(IPlayer player, MValueConst[] mValueArray, TFunc func);
}