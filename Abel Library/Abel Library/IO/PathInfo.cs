using System;
using System.Collections.Generic;
using System.Text;

namespace Abel.IO
{
    /// <summary>
    /// Provider path operate
    /// </summary>
    public static class PathInfo
    {
        public static bool IsFile( string path )
        {
            return System.IO.File.Exists( path );
        }

        public static bool IsDirectory( string path )
        {
            return System.IO.Directory.Exists( path );
        }

        /// <summary>
        /// Get full path of parent directory
        /// </summary>
        /// <param name="path">File or directory path</param>
        /// <returns>Parent path</returns>
        public static string GetParent( string path )
        {
            if ( IsDirectory( path ) )
                return System.IO.Directory.GetParent( path ).FullName;
            else if ( IsFile( path ) )
                return new System.IO.FileInfo( path ).Directory.FullName;
            else
                return string.Empty;
        }
    }
}
