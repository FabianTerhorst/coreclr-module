namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IRmlDocument : IRmlElement
    {
        IntPtr RmlDocumentNativePointer { get; }
        IRmlElement Body { get; }
        string SourceUrl { get; }
        bool IsModal { get; }
        bool IsVisible { get; }
        string Title { get; set; }
        IRmlElement CreateElement(string tag);
        IRmlElement CreateTextNode(string text);
        void Hide();
        void Show(bool isModal = false, bool focused = true);
        void Update();
    }
}