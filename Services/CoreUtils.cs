namespace CSharpShell.Services;

public static class CoreUtils
{
    private static string _currentWorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

    public static void CurrentWorkingDirectory()
    {
        Console.WriteLine(_currentWorkingDirectory);
    }
    public static void ChangeDirectory(string directory)
    {
        // TODO: String builder and foreach loop?
        if (directory == ".") return;
        string temp = _currentWorkingDirectory + "\\" + directory;
        temp = temp.Replace("\\..","");
        if (directory == "..")
        {
            int parentIndex = temp.LastIndexOf('\\');
            int count = temp.Length - parentIndex;
            temp = temp.Remove(parentIndex, count);
        }
        if (!Directory.Exists(temp))
        {
            Console.WriteLine($"This directory doesn't exist: {temp}");
            return;
        }
        _currentWorkingDirectory = temp;
    }
    public static void ListDirectory()
    {
        var EDirectories = Directory.EnumerateFileSystemEntries(_currentWorkingDirectory);
        foreach (string item in EDirectories)
        {
            Console.WriteLine(Path.GetFileName(item));
        }
    }
}