using System;

namespace AltV.Net.Elements.Entities;

public interface IClientScriptRPCEvent
{
    IntPtr ClientScriptRPCNativePointer { get; }
    ICore Core { get; }
    bool WillAnswer();
    bool Answer(object answer);
    bool AnswerWithError(string error);
}