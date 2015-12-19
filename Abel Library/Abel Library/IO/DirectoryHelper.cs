using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Abel.IO
{
    /// <summary>
    /// Provider directory operate
    /// </summary>
    public static class DirectoryHelper
    {
        /// <summary>
        /// Copy directory
        /// </summary>
        /// <param name="sourcePath">Directory path want to copy</param>
        /// <param name="destinationPath">Destination directory path</param>
        public static void CopyDirectory( string sourcePath, string destinationPath )
        {
            DirectoryInfo info = new DirectoryInfo( sourcePath );

            if ( !Directory.Exists( destinationPath ) )
                Directory.CreateDirectory( destinationPath );

            foreach ( var file in info.GetFiles() )
            {
                File.Copy( file.FullName, Path.Combine( destinationPath, file.Name ), true );
            }

            foreach ( var dir in info.GetDirectories() )
            {
                CopyDirectory( dir.FullName, Path.Combine( destinationPath, dir.Name ) );
            }
        }

    }
}
