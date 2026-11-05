namespace CSharpShell.Services;
public static class BuiltIns
{
    readonly static Dictionary<string, Action<string[]>> _BuiltInCommands = new()
    {
        { "ls", _ => List() },
        { "cd", args => ChangeDirectory(args) },
        { "pwd", _ => PresentWorkingDirectory() },
        { "clear", _ => Console.Clear() },
        { "exit", _ => Environment.Exit(0) }
    };
    public static bool Execute(string[] args)
    {
        if (_BuiltInCommands.TryGetValue(args[0], out Action<string[]>? func))
        {
            func(args);
            return true;
        }
        Console.WriteLine($"Command Not Found: {args[0]}");
        return false;
    }
    private static string CurrentWorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    private static void List(string[] args)
    {
        try {
            string path = (args.Length > 1) ? args[1] : CurrentWorkingDirectory;
            foreach (string item in Directory.GetFileSystemEntries(path))
            {
                Console.WriteLine(item);
            }
        } catch (Exception)
        {
            Console.WriteLine($"Current path is bad: {CurrentWorkingDirectory}");
        }
    }
    private static void ChangeDirectory(string[] args)
    {
        if (args.Length > 1 && Directory.Exists(args[1])) CurrentWorkingDirectory = args[1];
        if (Directory.Exists(CurrentWorkingDirectory + args)) CurrentWorkingDirectory += args;
    }
    private static void PresentWorkingDirectory()
    {
        Console.WriteLine(CurrentWorkingDirectory);
    }
}