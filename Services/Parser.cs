using CSharpShell.Services;

static class Parser
{
    public static void ParseCommand(string[]? arguments)
    {
        if (arguments == null || arguments.Length < 1)
        {
            Console.Write("$");
            return;
        }
        switch (arguments[0])
        {
            // Directory navigation.
            case "ls":
                CoreUtils.ListDirectory();
                break;
            case "cwd":
                CoreUtils.CurrentWorkingDirectory();
                break;
            case "cd":
                if (arguments.Length < 2) break;
                CoreUtils.ChangeDirectory(arguments[1]);
                break;
            default:
                Console.WriteLine($"Couldn't parse that command: {arguments}");
                break;
        }
        Console.Write("$");
    }
}