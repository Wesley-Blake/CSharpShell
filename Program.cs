//using CSharpShell.Services;
namespace CSharpShell;

class Program
{
    static void Main()
    {
        string? userInput = null;
        do
        {
            var args = userInput?.Split(" ") ?? Array.Empty<string>();
            Parser.ParseCommand(args);
        }
        while ((userInput = Console.ReadLine()) != "exit");
    }

}
