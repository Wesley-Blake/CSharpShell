using CSharpShell.Services;
class Program
{
    static void Main()
    {
        string? userInput = null;
        do 
        {
            string[]? args = userInput?.Split(" ");
            if (args != null) BuiltIns.Execute(args);
            Console.Write(">> ");
        } while ((userInput = Console.ReadLine()) != "exit");
    }
}