using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Abel.Shell
{
    public partial class WindowsAPI
    {
        [DllImport( "shell32.dll", CharSet = CharSet.Auto )]
        public static extern IntPtr SHGetFileInfo( string pszPath, int dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags );

        [DllImport( "shell32.dll", EntryPoint = "#727" )]
        public extern static int SHGetImageList( int iImageList, ref Guid riid, ref IImageList ppv );

        [DllImport( "shell32.dll", EntryPoint = "ShellExecute" )]
        public static extern IntPtr ShellExecute( IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd );
    }
}
