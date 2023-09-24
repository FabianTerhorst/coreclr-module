using System;
using System.Linq;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

namespace AltV.Net.Data;

public class ClientScriptRPCEvent : IClientScriptRPCEvent
{
    public ClientScriptRPCEvent(ICore core, IntPtr clientScriptRPCNativePointer)
    {
        ClientScriptRPCNativePointer = clientScriptRPCNativePointer;
        Core = core;
    }

    public IntPtr ClientScriptRPCNativePointer { get; }
    public ICore Core { get; }

    public bool WillAnswer()
    {
        unsafe
        {
            return Core.Library.Server.Event_ClientScriptRPCEvent_WillAnswer(ClientScriptRPCNativePointer) == 1;
        }
    }

    public bool Answer(object answer)
    {
        Core.CreateMValue(out var mValue, answer);
        bool result;
        unsafe
        {
            result = Core.Library.Server.Event_ClientScriptRPCEvent_Answer(ClientScriptRPCNativePointer, mValue.nativePointer) == 1;
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
            result = Core.Library.Server.Event_ClientScriptRPCEvent_AnswerWithError(ClientScriptRPCNativePointer, errorPtr) == 1;
        }
        Marshal.FreeHGlobal(errorPtr);

        return result;
    }
}