using System;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Async;

public class AsyncScriptRpcEvent : IScriptRPCEvent
{
    private readonly IPlayer _target;
    private readonly ushort _answerId;

    public AsyncScriptRpcEvent(IPlayer target, ushort answerId)
    {
        _target = target;
        _answerId = answerId;
    }

    public IntPtr ScriptRPCNativePointer { get; }

    public bool WillAnswer()
    {
        return true;
    }

    public bool Answer(object answer)
    {
        _target.EmitRPCAnswer(_answerId, answer, "");
        return true;
    }

    public bool AnswerWithError(string error)
    {
        _target.EmitRPCAnswer(_answerId, null, error);
        return true;
    }
}