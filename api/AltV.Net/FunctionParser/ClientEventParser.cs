using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.FunctionParser
{
    public delegate void ClientEventParser<in TFunc>(IPlayer player, ref MValueArray mValueArray, TFunc func);
}