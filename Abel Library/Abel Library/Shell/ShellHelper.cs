using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Abel.Shell
{
    /// <summary>
    /// 图标大小的枚举
    /// </summary>
    public enum IconType
    {
        /// <summary>
        /// The image size is normally 32x32 pixels. However, if the Use large icons option is selected from the Effects section of the Appearance tab in Display Properties, the image is 48x48 pixels.
        /// </summary>
        SHIL_LARGE = WindowsAPI.SHIL_LARGE,

        /// <summary>
        /// These images are the Shell standard small icon size of 16x16.
        /// </summary>
        SHIL_SMALL = WindowsAPI.SHIL_SMALL,

        /// <summary>
        /// These images are the Shell standard extra-large icon size. This is typically 48x48.
        /// </summary>
        SHIL_EXTRALARGE = WindowsAPI.SHIL_EXTRALARGE,

        /// <summary>
        /// These images are the size specified by GetSystemMetrics called with SM_CXSMICON and GetSystemMetrics called with SM_CYSMICON.
        /// </summary>
        SHIL_SYSSMALL = WindowsAPI.SHIL_SYSSMALL,

        /// <summary>
        /// SHGetImageList's iImageList parameter. The image is normally 256x256 pixels. Windows Vista and later. 
        /// </summary>
        SHIL_JUMBO = WindowsAPI.SHIL_JUMBO
    }


    public static class ShellHelper
    {
        /// <summary>
        /// 获取图标
        /// </summary>
        /// <param name="path">文件或目录路径</param>
        /// <param name="type">指定获取的图标大小</param>
        /// <returns>图标句柄</returns>
        public static IntPtr GetIconPtr( string path, IconType type )
        {
            SHFILEINFO sfi = new SHFILEINFO();
            WindowsAPI.SHGetFileInfo( path, -1, ref sfi, ( uint )Marshal.SizeOf( sfi ), ( int )WindowsAPI.FileInfoFlags.SHGFI_SYSICONINDEX );

            IImageList imageList = null;

            Guid g = new Guid( WindowsAPI.IID_IImageList );
            var hResult = WindowsAPI.SHGetImageList( ( int )type, ref g, ref imageList );

            if ( hResult == WindowsAPI.S_OK )
            {
                IntPtr hIcon = new IntPtr();
                hResult = imageList.GetIcon( sfi.iIcon, ( int )WindowsAPI.ILD_FLAGS.ILD_TRANSPARENT, ref hIcon );
                if ( hResult == WindowsAPI.S_OK )
                    return hIcon;
            }

            return IntPtr.Zero;
        }

        /// <summary>
        /// 禁用窗体“关闭”按钮
        /// </summary>
        /// <param name="windowHandle">窗体句柄</param>
        public static bool DisableWindowCloseButton( IntPtr windowHandle )
        {
            int iSysMenu = WindowsAPI.GetSystemMenu( windowHandle.ToInt32(), 0 );
            return WindowsAPI.RemoveMenu( iSysMenu, 6, WindowsAPI.MF_BYCOMMAND ) != 0;
        }

        /// <summary>
        /// 将程序锁定到任务栏
        /// </summary>
        /// <param name="fileLnk">指向文件的快捷方式的路径（例：C:\abc.lnk）</param>
        /// <returns>应用程序句柄</returns>
        public static IntPtr PinToTaskbar( string fileLnk )
        {
            return WindowsAPI.ShellExecute( IntPtr.Zero, "TaskbarPin", fileLnk, null, null, 5 );
        }

        /// <summary>
        /// 将程序从任务栏取消锁定
        /// </summary>
        /// <param name="fileLnk">指向文件的快捷方式的路径（例：C:\abc.lnk）</param>
        /// <returns>应用程序句柄</returns>
        public static IntPtr UnPinFromTaskbar( string fileLnk )
        {
            return WindowsAPI.ShellExecute( IntPtr.Zero, "TaskbarUnPin", fileLnk, null, null, 5 );
        }
    }
}
