using System;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Entities;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Async;

public class AsyncScriptRpcEvent : IScriptRPCEvent
{
    public AsyncScriptRpcEvent(IntPtr clientScriptRPCNativePointer)
    {
        ScriptRPCNativePointer = clientScriptRPCNativePointer;
    }

    public IntPtr ScriptRPCNativePointer { get; }

    public bool WillAnswer()
    {
        unsafe
        {
            return Alt.Core.Library.Shared.Event_ScriptRPCEvent_WillAnswer(ScriptRPCNativePointer) == 1;
        }
    }

    public bool Answer(object answer)
    {
        MValueConstLockedNoRefs.CreateFromObjectLocked(answer, out MValueConst mValue);
        bool result;
        unsafe
        {
            result = Alt.Core.Library.Shared.Event_ScriptRPCEvent_Answer(ScriptRPCNativePointer, mValue.nativePointer) == 1;
        }
        mValue.Dispose();

        return result;
    }

    public bool AnswerWithError(string error)
    {
        var errorPtr = MemoryUtils.StringToHGlobalUtf8(error);

        bool result;
        unsafe
        {
            result = Alt.Core.Library.Shared.Event_ScriptRPCEvent_AnswerWithError(ScriptRPCNativePointer, errorPtr) == 1;
        }
        Marshal.FreeHGlobal(errorPtr);

        return result;
    }
}