using System;
using System.IO;

namespace FaddleEngine
{
    public static class FileSystem
    {
        public static string ToResourcePath(string path, bool errorIfNotExists = true)
        {
            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", path);

            if (errorIfNotExists && !File.Exists(path))
            {
                Log.Error($"File {path} does not exist.");
                return "";
            }

            return path;
        }

        public static string LoadTextFile(string path)
        {
            string filePath = ToResourcePath(path);

            try
            {
                using (StreamReader reader = new(new FileStream(filePath, FileMode.Open, FileAccess.Read)))
                {
                    return reader.ReadToEnd();
                };
            }
            catch (FileNotFoundException e)
            {
                Log.Error(e);
                return null;
            }
        }
    }
}
