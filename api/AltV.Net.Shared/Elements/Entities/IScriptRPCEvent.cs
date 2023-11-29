namespace AltV.Net.Shared.Elements.Entities;

public interface IScriptRPCEvent
{
    IntPtr ScriptRPCNativePointer { get; }
    bool WillAnswer();
    bool Answer(object answer);
    bool AnswerWithError(string error);
}