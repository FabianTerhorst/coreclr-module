namespace AltV.Net.Client
{
    public class UnhandledExceptionHandingOptions
    {
        public bool ShowStacktrace { get; set; } = true;
        public bool ShowExceptionBasicInfo { get; set; } = true;
        public string CustomMessage { get; set; } = null;
        public bool ShowLinkToDocs { get; set; } = true;
        public bool ShowOpenLogsFolderButton { get; set; } = true;
        public bool ShowCopyStacktraceButton { get; set; } = true;
    }
}