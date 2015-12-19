using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Abel.Shell
{
    public partial class WindowsAPI
    {
        [DllImport( "USER32.DLL" )]
        public static extern int GetSystemMenu( int hwnd, int bRevert );

        [DllImport( "USER32.DLL" )]
        public static extern int RemoveMenu( int hMenu, int nPosition, int wFlags );

        [DllImport( "user32.dll" )]
        public static extern bool ShowWindowAsync( IntPtr hWnd, int nCmdShow );

        [DllImport( "user32.dll" )]
        public static extern bool SetForegroundWindow( IntPtr hWnd );

        [DllImport( "user32.dll" )]
        public static extern bool IsIconic( IntPtr hWnd );

        [DllImport( "user32.dll" )]
        public static extern bool IsZoomed( IntPtr hWnd );

        [DllImport( "user32.dll" )]
        public static extern IntPtr GetForegroundWindow();

        [DllImport( "user32.dll" )]
        public static extern IntPtr GetWindowThreadProcessId( IntPtr hWnd, IntPtr ProcessId );

        [DllImport( "user32.dll" )]
        public static extern IntPtr AttachThreadInput( IntPtr idAttach, IntPtr idAttachTo, int fAttach );

        [DllImport( "user32.dll" )]
        public static extern int GetWindowText( int hWnd, StringBuilder title, int size );

        [DllImport( "user32.dll" )]
        public static extern int GetWindowModuleFileName( int hWnd, StringBuilder title, int size );

        [DllImport( "user32.dll" )]
        public static extern int EnumWindows( EnumWindowsProc ewp, int lParam );

        [DllImport( "user32.dll" )]
        public static extern bool IsWindowVisible( int hWnd );
    }
}
