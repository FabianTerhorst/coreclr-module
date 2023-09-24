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

    public bool Answer(params object[] args)
    {
        var size = args.Length;
        var mValues = new MValueConst[size];
        Alt.Core.CreateMValues(mValues, args);

        var mValuePointers = new IntPtr[size];
        for (var i = 0; i < size; i++)
        {
            mValuePointers[i] = mValues[i].nativePointer;
        }
        bool result;

        unsafe
        {
            result = Core.Library.Server.Event_ClientScriptRPCEvent_Answer(ClientScriptRPCNativePointer, Core.NativePointer, mValuePointers, size) == 1;
        }

        for (var i = 0; i < size; i++)
        {
            mValues[i].Dispose();
        }

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