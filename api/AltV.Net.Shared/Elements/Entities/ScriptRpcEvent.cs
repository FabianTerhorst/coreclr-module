using System.Runtime.InteropServices;
using AltV.Net.Native;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Shared.Elements.Entities;

public class ScriptRpcEvent : IScriptRPCEvent
{
    private readonly ushort _answerId;
    private readonly bool _clientSide;

    public ScriptRpcEvent(ISharedCore core, IntPtr clientScriptRPCNativePointer, ushort answerId, bool clientSide)
    {
        _answerId = answerId;
        _clientSide = clientSide;
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

        if (_clientSide)
        {
            if (Core.UnansweredClientRpcRequest.Contains(_answerId))
            {
                Core.UnansweredClientRpcRequest.Remove(_answerId);
            }
        }
        else
        {
            if (Core.UnansweredServerRpcRequest.Contains(_answerId))
            {
                Core.UnansweredServerRpcRequest.Remove(_answerId);
            }
        }

        return result;
    }

    public bool AnswerWithError(string error)
    {
        var errorPtr = MemoryUtils.StringToHGlobalUtf8(error);

        bool result;
        unsafe
        {
            result = Core.Library.Shared.Event_ScriptRPCEvent_AnswerWithError (ScriptRPCNativePointer, errorPtr) == 1;
        }
        Marshal.FreeHGlobal(errorPtr);

        if (_clientSide)
        {
            if (Core.UnansweredClientRpcRequest.Contains(_answerId))
            {
                Core.UnansweredClientRpcRequest.Remove(_answerId);
            }
        }
        else
        {
            if (Core.UnansweredServerRpcRequest.Contains(_answerId))
            {
                Core.UnansweredServerRpcRequest.Remove(_answerId);
            }
        }

        return result;
    }
}