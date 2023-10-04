namespace AltV.Net.Shared.Elements.Entities;

public interface IScriptRPCEvent
{
    IntPtr ScriptRPCNativePointer { get; }
    ISharedCore Core { get; }
    bool WillAnswer();
    bool Answer(object answer);
    bool AnswerWithError(string error);
}