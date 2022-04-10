using System.Numerics;

namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IRmlElement : IBaseObject
    {
        IntPtr RmlElementNativePointer { get; }
        float AbsoluteLeft { get; }
        float AbsoluteTop { get; }
        Vector2 AbsoluteOffset { get; }
        float Baseline { get; }
        float ChildCount { get; }
        IRmlElement[] ChildNodes { get; }
        float ClientTop { get; }
        float ClientLeft { get; }
        float ClientWidth { get; }
        float ClientHeight { get; }
        Vector2 ContainingBlockSize { get; }
        IRmlElement FirstChild { get; }
        IRmlElement FocusedElement { get; }
        bool HasChildren { get; }
        string Id { get; set; }
        string InnerRml { get; set; }
        bool IsOwned { get; }
        bool IsVisible { get; }
        IRmlElement LastChild { get; }
        IRmlElement NextSibling { get; }
        IRmlElement PreviousSibling { get; }
        float OffsetTop { get; }
        float OffsetLeft { get; }
        float OffsetWidth { get; }
        float OffsetHeight { get; }
        IRmlDocument OwnerDocument { get; }
        IRmlElement Parent { get; }
        float ScrollHeight { get; }
        float ScrollWidth { get; }
        float ScrollTop { get; set; }
        float ScrollLeft { get; set; }
        string TagName { get; }
        float ZIndex { get; }
        void AddClass(string name);
        void AddPseudoClass(string name);
        void AppendChild(IRmlElement element);
        void Blur();
        void Click();
        IRmlElement GetClosest(string selector);
        void Focus();
        string GetAttribute(string name);
        Dictionary<string, string> GetAttributes();
        string[] GetClassList();
        IRmlElement GetElementById(string id);
        IRmlElement[] GetElementsByClassName(string className);
        IRmlElement[] GetElementsByTagName(string tagName);
        string GetLocalProperty(string key);
        string GetProperty(string key);
        float GetPropertyAbsoluteValue(string key);
        string[] GetPseudoClassList();
        bool HasAttribute(string attribute);
        bool HasClass(string className);
        bool HasLocalProperty(string key);
        bool HasProperty(string key);
        bool HasPseudoClass(string className);
        void InsertBefore(IRmlElement child, IRmlElement adjacent);
        bool IsPointWithinElement(Vector2 point);
        IRmlElement QuerySelector(string selector);
        IRmlElement[] QuerySelectorAll(string selector);
        bool RemoveAttribute(string attribute);
        void RemoveChild(IRmlElement child);
        bool RemoveClass(string className);
        bool RemoveProperty(string key);
        bool RemovePseudoClass(string className);
        void ReplaceChild(IRmlElement newChild, IRmlElement oldChild);
        void ScrollIntoView(bool alignWithTop = true);
        void SetAttribute(string attribute, string value);
        void SetOffset(IRmlElement element, Vector2 offset, bool isFixed = false);
        void SetProperty(string key, string value);
    }
}