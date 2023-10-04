using System.Runtime.InteropServices;
using AltV.Net.Native;

namespace AltV.Net.Shared.Elements.Entities;

public class ScriptRpcEvent : IScriptRPCEvent
{
    public ScriptRpcEvent(ISharedCore core, IntPtr clientScriptRPCNativePointer)
    {
        ScriptRPCNativePointer = clientScriptRPCNativePointer;
        Core = core;
    }

    public IntPtr ScriptRPCNativePointer { get; }
    public ISharedCore Core { get; }

    public bool WillAnswer()
    {
        unsafe
        {
            return Core.Library.Shared.Event_ScriptRPCEvent_WillAnswer(ScriptRPCNativePointer) == 1;
        }
    }

    public bool Answer(object answer)
    {
        Core.CreateMValue(out var mValue, answer);
        bool result;
        unsafe
        {
            result = Core.Library.Shared.Event_ScriptRPCEvent_Answer(ScriptRPCNativePointer, mValue.nativePointer) == 1;
        }
        mValue.Dispose();

        return result;
    }

    public bool AnswerWithError(string error)
    {
        var errorPtr = AltNative.StringUtils.StringToHGlobalUtf8(error);

        bool result;
        unsafe
        {
            result = Core.Library.Shared.Event_ScriptRPCEvent_AnswerWithError (ScriptRPCNativePointer, errorPtr) == 1;
        }
        Marshal.FreeHGlobal(errorPtr);

        return result;
    }
}