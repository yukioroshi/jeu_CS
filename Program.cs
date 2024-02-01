// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
/*dotnet new console -n titre => creer une solution de nom titre */

//using System.Diagnostics;
//using System.Drawing;

public class HelloWorld
{
    public static void Main(string[] argv)
    {
        //Test1 t = new Test1();
        //Console.BackgroundColor = ConsoleColor.Red;
        /*Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("[033[0;30m]" +"\t Hello, World!");
        Console.ForegroundColor = ConsoleColor.White;
        t.fct();*/
        Player p = new Player();
        MapGame m = new MapGame(" + ", 10, 10);
        m.addElement(" M ", 4, 7);
        p.displayInfo();
        m.displayMap();
        m.displayDescription();
        m.indicationManip();
        //Process.Start("cmd.exe","/c cls"); //pour executer une commande cmd
    }
}
