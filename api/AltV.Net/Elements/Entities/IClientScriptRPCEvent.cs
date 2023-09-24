using System;

namespace AltV.Net.Elements.Entities;

public interface IClientScriptRPCEvent
{
    IntPtr ClientScriptRPCNativePointer { get; }
    ICore Core { get; }
    bool WillAnswer();
    bool Answer(params object[] args);
    bool AnswerWithError(string error);
}