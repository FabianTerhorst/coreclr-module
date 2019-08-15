using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using AltV.Net.Native;
using HarmonyLib;

namespace AltV.Net.Mock2
{
    public class Mock
    {
        public Mock()
        {
            //var harmony = HarmonyInstance.Create("AltV.Net");
            var harmony = new Harmony("AltV.Net");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            var bla = AltNative.Player.Player_GetID(IntPtr.Zero);
            Console.WriteLine(bla);
        }
    }

    [HarmonyPatch(typeof(AltNative.Player))]
    [HarmonyPatch("Player_GetID")]
    [HarmonyPatch(new Type[] {typeof(IntPtr)})]
    //[SuppressMessage("ReSharper", "RedundantAssignment")]
    //[SuppressMessage("ReSharper", "InconsistentNaming")]
    class Patch
    {
        [HarmonyPrefix]
        static bool Prefix(IntPtr entityPointer, ref ushort __result)
        {
            __result = 1337;
            return false;
        }
    }
}