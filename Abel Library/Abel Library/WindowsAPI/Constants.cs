using System;
using System.Collections.Generic;
using System.Text;

namespace Abel.Shell
{
    public partial class WindowsAPI
    {
        /// <summary>
        /// SHGetImageList's iImageList parameter. The image size is normally 32x32 pixels. However, if the Use large icons option is selected from the Effects section of the Appearance tab in Display Properties, the image is 48x48 pixels.
        /// </summary>
        public const int SHIL_LARGE = 0x0;

        /// <summary>
        /// These images are the Shell standard small icon size of 16x16, but the size can be customized by the user.
        /// </summary>
        public const int SHIL_SMALL = 0x1;

        /// <summary>
        /// These images are the Shell standard extra-large icon size. This is typically 48x48, but the size can be customized by the user.
        /// </summary>
        public const int SHIL_EXTRALARGE = 0x2;

        /// <summary>
        /// These images are the size specified by GetSystemMetrics called with SM_CXSMICON and GetSystemMetrics called with SM_CYSMICON.
        /// </summary>
        public const int SHIL_SYSSMALL = 0x3;

        /// <summary>
        /// SHGetImageList's iImageList parameter. The image is normally 256x256 pixels. Windows Vista and later. 
        /// </summary>
        public const int SHIL_JUMBO = 0x4;


        [Flags]
        public enum FileInfoFlags : int
        {
            SHGFI_ICON = 0x000000100,     // get icon
            SHGFI_DISPLAYNAME = 0x000000200,     // get display name
            SHGFI_TYPENAME = 0x000000400,     // get type name
            SHGFI_ATTRIBUTES = 0x000000800,     // get attributes
            SHGFI_ICONLOCATION = 0x000001000,     // get icon location
            SHGFI_EXETYPE = 0x000002000,     // return exe type
            /// <summary>
            /// get system icon index
            /// </summary>
            SHGFI_SYSICONINDEX = 0x000004000,
            SHGFI_LINKOVERLAY = 0x000008000,     // put a link overlay on icon
            SHGFI_SELECTED = 0x000010000,     // show icon in selected state
            SHGFI_ATTR_SPECIFIED = 0x000020000,     // get only specified attributes
            SHGFI_LARGEICON = 0x000000000,     // get large icon
            SHGFI_SMALLICON = 0x000000001,     // get small icon
            SHGFI_OPENICON = 0x000000002,     // get open icon
            SHGFI_SHELLICONSIZE = 0x000000004,     // get shell size icon
            SHGFI_PIDL = 0x000000008,     // pszPath is a pidl
            SHGFI_USEFILEATTRIBUTES = 0x000000010,     // use passed dwFileAttribute
            SHGFI_ADDOVERLAYS = 0x000000020,     // apply the appropriate overlays
            SHGFI_OVERLAYINDEX = 0x000000040,     // Get the index of the overlay in 
            // the upper 8 bits of the iIcon
        }

        public const string IID_IImageList = "46EB5926-582E-4017-9FDF-E8998DAA0950";
        public const int S_OK = 0;


        /// <summary>
        /// Flags used by ImageList_Draw and ImageList_GetIcon.
        /// </summary>
        [Flags]
        public enum ILD_FLAGS : int
        {
            ILD_NORMAL = 0x00000000,
            ILD_TRANSPARENT = 0x00000001,
            ILD_BLEND25 = 0x00000002,
            ILD_FOCUS = 0x00000002,
            ILD_BLEND50 = 0x00000004,
            ILD_SELECTED = 0x00000004,
            ILD_BLEND = 0x00000004,
            ILD_MASK = 0x00000010,
            ILD_IMAGE = 0x00000020,
            ILD_ROP = 0x00000040,
            ILD_OVERLAYMASK = 0x00000F00,
            ILD_PRESERVEALPHA = 0x00001000,
            ILD_SCALE = 0x00002000,
            ILD_DPISCALE = 0x00004000,
            ILD_ASYNC = 0x00008000
        }

        /// <summary>
        /// 窗体关闭按钮
        /// </summary>
        public const int MF_BYCOMMAND = 0x400;

        /// <summary>
        /// Win32 API Constants for ShowWindowAsync()
        /// </summary>
        public const int SW_HIDE = 0;
        public const int SW_SHOWNORMAL = 1;
        public const int SW_SHOWMINIMIZED = 2;
        public const int SW_SHOWMAXIMIZED = 3;
        public const int SW_SHOWNOACTIVATE = 4;
        public const int SW_RESTORE = 9;
        public const int SW_SHOWDEFAULT = 10;
    }
}
