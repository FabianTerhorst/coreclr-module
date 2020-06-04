using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using AltV.Net.Native;
using HarmonyLib;

namespace AltV.Net.Mock2
{
    public class Mock
    {
        public Mock()
        {
            //var harmony = HarmonyInstance.Create("AltV.Net");
            var methodBase = AccessTools.Method(typeof(AltNative.Player),"Player_GetID", new []{typeof(IntPtr)});
            Console.WriteLine("methodbase:" + methodBase);
            MethodBase getIdMethodBase = typeof(Mock).GetMethod("GetId");
            var originalInstructions2 = PatchProcessor.GetCurrentInstructions(methodBase);
            var originalInstructions = PatchProcessor.GetCurrentInstructions(getIdMethodBase);
            Console.WriteLine(originalInstructions.ToString());
            Console.WriteLine(originalInstructions.Count);
            foreach (var instruction in originalInstructions)
            {
                Console.WriteLine(instruction);
            }
            
            Console.WriteLine(originalInstructions2.ToString());
            Console.WriteLine(originalInstructions2.Count);
            foreach (var instruction in originalInstructions2)
            {
                Console.WriteLine(instruction);
            }
            var harmony = new Harmony("AltV.Net");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            var bla = AltNative.Player.Player_GetID(IntPtr.Zero);
            Console.WriteLine(bla);
        }

        public static ushort GetId(IntPtr intPtr)
        {
            Console.WriteLine(intPtr);
            return 1337;
        }
    }

    //[HarmonyPatch]
    [HarmonyPatch(typeof(AltNative.Player))]
    [HarmonyPatch("Player_GetID")]
    [HarmonyPatch(new Type[] {typeof(IntPtr)})]
    //[SuppressMessage("ReSharper", "RedundantAssignment")]
    //[SuppressMessage("ReSharper", "InconsistentNaming")]
    class Patch
    {
        /*[HarmonyPrefix]
        static bool Prefix(IntPtr entityPointer, ref ushort __result)
        {
            __result = 1337;
            return false;
        }*/
        /*static MethodBase TargetMethod() => AccessTools.Method(typeof(AltNative.Player),"Player_GetID", new []{typeof(IntPtr)});
        [HarmonyTranspiler]
        static IEnumerable<CodeInstruction> Transpiler(IntPtr entityPointer, ref ushort __result)
        {
            Console.WriteLine("Test");
            //__result = 1337;
            ushort id = 1337;
            var codeInstructions = new CodeInstruction[2];//2s
            //codeInstructions[0] = new CodeInstruction(OpCodes.Ldnull);
            //codeInstructions[0] = new CodeInstruction(OpCodes.Ldc_I4_S, id);
            codeInstructions[0] = new CodeInstruction(OpCodes.Ldc_I4, id);
            codeInstructions[1] = new CodeInstruction(OpCodes.Ret);
            return codeInstructions;
        }*/
        
        //static MethodBase TargetMethod() => AccessTools.Method(typeof(AltNative.Player),"Player_GetID", new []{typeof(IntPtr)});
        /*[HarmonyTranspiler]
        static IEnumerable<CodeInstruction> Transpiler(IntPtr entityPointer, ref ushort __result)
        {
            __result = 1337;
            Console.WriteLine("Transpiler");
            var codeInstructions = new CodeInstruction[2];//2s
            //codeInstructions[0] = new CodeInstruction(OpCodes.Ldnull);
            //codeInstructions[0] = new CodeInstruction(OpCodes.Ldc_I4_S, id);
            codeInstructions[0] = new CodeInstruction(OpCodes.Ldc_I4, 1337);
            codeInstructions[1] = new CodeInstruction(OpCodes.Ret);
            return codeInstructions;
        }*/
        
        [HarmonyTranspiler]
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            Console.WriteLine("Transpiler");
            /*var codeInstructions = new CodeInstruction[2];//2s
            //codeInstructions[0] = new CodeInstruction(OpCodes.Ldnull);
            //codeInstructions[0] = new CodeInstruction(OpCodes.Ldc_I4_S, id);
            //codeInstructions[0] = new CodeInstruction(OpCodes.Ldc_I4, 1337);
            codeInstructions[1] = new CodeInstruction(OpCodes.Ret);
            return codeInstructions;*/
            foreach (var instruction in instructions)
            {
                Console.WriteLine(instruction);
            }
            /*var codeInstructions = new CodeInstruction[2];
            codeInstructions[0] = new CodeInstruction(OpCodes.Ldnull);
            codeInstructions[1] = new CodeInstruction(OpCodes.Ret);
            return codeInstructions;*/
            return Enumerable.Empty<CodeInstruction>();
        }
    }
}