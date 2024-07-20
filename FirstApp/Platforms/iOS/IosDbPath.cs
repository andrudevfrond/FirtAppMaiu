namespace FirstApp;

public class DbPath : IPath
{
    public string GetDatabasePath(string filename)
    {
        return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filename);
    }
}
