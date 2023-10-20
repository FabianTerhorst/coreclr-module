using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using AltV.Net.CApi;
using AltV.Net.Client.Elements.Data;

namespace AltV.Net.Client.WinApi
{
    internal class ErrorDialog
    {
        [Flags]
        public enum TaskDialogFlags
        {
            EnableHyperlinks = 0x0001,
            UseHICONMain = 0x0002,
            UseHICONFooter = 0x0004,
            AllowDialogCancellation = 0x0008,
            UseCommandLinks = 0x0010,
            UseCommandLinksNoIcon = 0x0020,
            ExpandFooterArea = 0x0040,
            ExpandedByDefault = 0x0080,
            VerificationFlagChecked = 0x0100,
            ShowProgressBar = 0x0200,
            ShowMarqueeProgressBar = 0x0400,
            CallbackTimer = 0x0800,
            PositionRelativeToWindow = 0x1000,
            RTLLayout = 0x2000,
            NoDefaultRadioButton = 0x4000,
            CanBeMinimized = 0x8000,
            NoSetForeground = 0x00010000,
            SizeToContent = 0x01000000,
        }

        [Flags]
        public enum TaskDialogCommonButtonFlags
        {
            OK = 0x0001,
            Yes = 0x0002,
            No = 0x0004,
            Cancel = 0x0008,
            Retry = 0x0010,
            Close = 0x0020
        }

        public enum TaskDialogNotification : uint
        {
            Created = 0,
            Navigated = 1,
            ButtonClicked = 2,
            HyperlinkClicked = 3,
            Timer = 4,
            Destroyed = 5,
            RadioButtonClicked = 6,
            DialogConstructed = 7,
            VerificationClicked = 8,
            Help = 9,
            ExpendOButtonClicked = 10
        }

        public delegate long PFTASKDIALOGCALLBACK(IntPtr hwnd,
            [MarshalAs(UnmanagedType.U4)] TaskDialogNotification msg,
            IntPtr wParam, IntPtr lParam,
            IntPtr lpRefData);


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
        public struct TaskDialogConfig
        {
            public uint StructSize;
            public IntPtr ParentWindowHandle;
            public IntPtr InstanceHandle;
            public TaskDialogFlags Flags;
            public TaskDialogCommonButtonFlags CommonButtons;
            public string WindowTitle;
            public IntPtr MainIconHandle;
            public string MainInstruction;
            public string Content;
            public uint ButtonsCount;
            public IntPtr ButtonsArray;
            public int DefaultButton;
            public uint RadioButtonsCount;
            public IntPtr RadioButtonsArray;
            public int DefaultRadioButton;
            public string VerificationText;
            public string ExpandedInformation;
            public string ExpandedControlText;
            public string CollapsedControlText;
            public IntPtr FooterIconHandle;
            public string Footer;
            [MarshalAs(UnmanagedType.FunctionPtr)] public PFTASKDIALOGCALLBACK Callback;
            public IntPtr CallbackData;
            public uint Width;
        }

        private delegate long TaskDialogIndirectDelegate(ref TaskDialogConfig pTaskConfig, out int pnButton,
            out int pnRadioButton,
            [MarshalAs(UnmanagedType.Bool)] out bool pfVerificationFlagChecked);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
        public struct TaskDialogButton
        {
            public int ButtonID;
            public string ButtonText;

            public TaskDialogButton(int buttonId, string buttonText)
            {
                ButtonID = buttonId;
                ButtonText = buttonText;
            }
        }

        private static TaskDialogIndirectDelegate _taskDialogIndirectAction;

        private static void LoadTaskDialog(ICApiCore core)
        {
            unsafe
            {
                _taskDialogIndirectAction = Marshal.GetDelegateForFunctionPointer<TaskDialogIndirectDelegate>(core.Library.Client.Win_GetTaskDialog());
            }
        }

        private static long TaskDialogIndirect(ICore core, ref TaskDialogConfig taskConfig, out int button, out int radioButton,
            [MarshalAs(UnmanagedType.Bool)] out bool verificationFlagChecked)
        {
            if (_taskDialogIndirectAction == null) LoadTaskDialog(core);
            if (_taskDialogIndirectAction == null) throw new Exception("Failed to load TaskDialogIndirect");
            return _taskDialogIndirectAction(ref taskConfig, out button, out radioButton, out verificationFlagChecked);
        }

        internal const int WM_USER = 0x0400;

        internal enum TaskDialogMessages : uint
        {
            NavigatePage = WM_USER + 101,
            ClickButton = WM_USER + 102,
            SetMarqueeProgressBar = WM_USER + 103,
            SetProgressBarState = WM_USER + 104,
            SetProgressBarRange = WM_USER + 105,
            SetProgressBarPos = WM_USER + 106,
            SetProgressBarMarquee = WM_USER + 107,
            SetElementText = WM_USER + 108,
            ClickRadioButton = WM_USER + 110,
            EnableButton = WM_USER + 111,
            EnableRadioButton = WM_USER + 112,
            ClickVerification = WM_USER + 113,
            UpdateElementText = WM_USER + 114,
            SetButtonElevationRequiredState = WM_USER + 115,
            UpdateIcon = WM_USER + 116,
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern long SendMessage(IntPtr hWnd, TaskDialogMessages Msg, IntPtr wParam, IntPtr lParam);

        internal TaskDialogConfig Config;
        private readonly ICore core;

        public enum TaskDialogIconType
        {
            Main,
            Footer
        }

        internal ErrorDialog(ICore core, UnhandledExceptionHandingOptions options, Exception e)
        {
            this.core = core;
            var resourceName = Alt.Resource?.Name ?? "unknown";
            Config.WindowTitle = "Exception in \"" + resourceName + "\"";
            Config.MainInstruction = "Unhandled C# exception";
            Config.Content = "There was an unhandled exception in resource \"" + resourceName + "\".";

            if (options.ShowExceptionBasicInfo)
            {
                if (e == null) Config.Content += "\r\nException is null.";
                else Config.Content += "\r\n" + e.GetType().FullName + ": " + e.Message;
            }

            if (options.CustomMessage != null)
            {
                Config.Content += "\r\n" + options.CustomMessage;
            }

            Config.Content += "\r\nThe game will be closed.";

            if (options.ShowStacktrace)
            {
                Config.ExpandedInformation = e?.ToString() ?? "No stacktrace available";
                Config.ExpandedControlText = "Show stacktrace";
            }

            Config.CommonButtons = TaskDialogCommonButtonFlags.OK;
            Config.Flags |= TaskDialogFlags.SizeToContent;

            if (options.ShowLinkToDocs)
            {
                Config.Footer = "<a href=\"docs\">C# module documentation</a>";
                Config.FooterIconHandle = new IntPtr(unchecked((ushort) -3));
                Config.Flags |= TaskDialogFlags.EnableHyperlinks;
            }

            var buttons = new List<TaskDialogButton>();

            if (options.ShowOpenLogsFolderButton)
            {
                buttons.Add(new TaskDialogButton(1000, "Open logs folder"));
                Config.Flags |= TaskDialogFlags.UseCommandLinks;
            }

            if (options.ShowCopyStacktraceButton && core.GetPermissionState(Permission.ClipboardAccess))
            {
                buttons.Add(new TaskDialogButton(1001, "Copy stacktrace"));
                Config.Flags |= TaskDialogFlags.UseCommandLinks;
            }

            if (buttons.Count > 0) Buttons = buttons.ToArray();

            // -7 is shield red bar
            Config.MainIconHandle = new IntPtr(unchecked((ushort) -7));
            Config.StructSize = (uint) Marshal.SizeOf(Config);
            Config.Callback = (hwnd, msg, wParam, lParam, _) =>
            {
                Console.WriteLine("got callback " + msg);
                switch (msg)
                {
                    case TaskDialogNotification.Created:
                    {
                        Console.WriteLine("sending");
                        var res = SendMessage(hwnd, TaskDialogMessages.UpdateIcon, new IntPtr((int) TaskDialogIconType.Main), new IntPtr(unchecked((ushort) -2)));
                        Console.WriteLine("sent " + res);
                        break;
                    }
                    case TaskDialogNotification.HyperlinkClicked:
                    {
                        Process.Start("explorer", "https://docs.altv.mp/cs/articles/index.html");
                        break;
                    }
                    case TaskDialogNotification.ButtonClicked:
                    {
                        if ((int) wParam == 1000)
                        {
                            unsafe
                            {
                                var size = 0;
                                var path = core.PtrToStringUtf8AndFree(core.Library.Client.Core_GetClientPath(core.NativePointer, &size), size);
                                Process.Start("explorer", Path.Combine(path, "logs"));
                            }
                        }
                        else if ((int) wParam == 1001)
                        {
                            try
                            {
                                core.CopyToClipboard(e == null ? "Exception is null" : e.ToString());
                            }
                            catch (Exception e)
                            {
                                // ignore
                            }
                        }
                        break;
                    }
                }
                return 0;
            };
        }

        public TaskDialogButton[] Buttons { get; set; }

        public void Show()
        {
            if (Buttons != null)
            {
                var buttonStructSize = sizeof(int) + IntPtr.Size;
                var buttonsPtr = Marshal.AllocHGlobal(buttonStructSize * Buttons.Length);
                var offset = buttonsPtr;
                foreach (var b in Buttons)
                {
                    Marshal.WriteInt32(offset, b.ButtonID);
                    offset += 4;
                    Marshal.WriteIntPtr(offset, Marshal.StringToHGlobalUni(b.ButtonText));
                    offset += IntPtr.Size;
                }

                Config.ButtonsArray = buttonsPtr;
                Config.ButtonsCount = (uint) Buttons.Length;
            }

            Config.ParentWindowHandle = IntPtr.Zero;

            var hr = TaskDialogIndirect(core, ref Config, out var button, out var radioButton, out var verificationFlag);

            if (Config.ButtonsArray != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(Config.ButtonsArray);
                Config.ButtonsArray = IntPtr.Zero;
                Config.ButtonsCount = 0;
            }

            if (hr != 0) throw new Exception($"Failed to execute TaskDialogIndirect: {hr}");
        }
    }
}