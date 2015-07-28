namespace T3.Utilities
{
    using System;
    using System.IO;

    public static class FileUtils
    {
        public static string GetExtension(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("No path specified.");
            }

            int lastDotIndex = path.LastIndexOf(".");
            if (lastDotIndex == -1)
            {
                return string.Empty;
            }

            string extension = path.Substring(lastDotIndex + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("No path specified.");
            }

            int lastDotIndex = path.LastIndexOf(".");
            if (lastDotIndex == -1)
            {
                return path;
            }

            string fileNameWithoutExtension = path.Substring(0, lastDotIndex);
            return fileNameWithoutExtension;
        }
    }
}
