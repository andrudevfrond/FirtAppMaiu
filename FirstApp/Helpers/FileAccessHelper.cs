namespace FirstApp.Helpers
{
    public class FileAccessHelper
    {
        public static string GetPathFile(string path) {
            string directory = GetAppDirectory();
            return System.IO.Path.Combine(directory, path);
         }

        public static string GetAppDirectory() 
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            if (!System.IO.File.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            return path;
        } 
    }
}
