namespace CSharpShell.Services;
public static class BuiltIns
{
    private static string _CurrentWorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    public static bool List()
    {
        try {
            foreach (string item in Directory.GetFileSystemEntries(_CurrentWorkingDirectory))
            {
                Console.WriteLine(item);
            }
        } catch (Exception)
        {
            return false;
        }
        return true;
    }
}