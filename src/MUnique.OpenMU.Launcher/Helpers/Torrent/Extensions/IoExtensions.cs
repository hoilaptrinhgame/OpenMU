﻿using System.IO;
using DefensiveProgrammingFramework;

namespace MUnique.OpenMU.Launcher.Helpers.Torrent.Extensions
{
    /// <summary>
    ///     The input / output extensions.
    /// </summary>
    public static class IoExtensions
    {
        #region Public Methods

        /// <summary>
        ///     Deletes the directory recursively.
        /// </summary>
        /// <param name="directoryPath">The directory path.</param>
        /// <param name="deleteOnlyDirectoryContents">if set to <c>true</c> delete only directory contents.</param>
        public static void DeleteDirectoryRecursively(this string directoryPath, bool deleteOnlyDirectoryContents = false)
        {
            directoryPath.MustBeValidDirectoryPath();

            if (Directory.Exists(directoryPath))
            {
                // delete files
                foreach (var file in Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories))
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }

                // delete subdirectories
                foreach (var subDirectory in Directory.GetDirectories(directoryPath)) DeleteDirectoryRecursively(subDirectory);

                if (!deleteOnlyDirectoryContents)
                {
                    // delete root directory
                    Directory.Delete(directoryPath, true);
                }
            }
        }

        #endregion Public Methods
    }
}