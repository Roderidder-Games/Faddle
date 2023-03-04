using System;
using System.IO;

namespace FaddleEngine
{
    public static class FileSystem
    {
        public static string ToResourcePath(string path)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", path);
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
