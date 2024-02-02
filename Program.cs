// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
/*dotnet new console -n titre => creer une solution de nom titre */

using System.Diagnostics;
using System.Drawing;

public class HelloWorld
{
    public static void Main(string[] argv)
    {
        string Name = Console.ReadLine();


        //Test1 t = new Test1();
        //Console.BackgroundColor = ConsoleColor.Red;
        /*Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("[033[0;30m]" +"\t Hello, World!");
        Console.ForegroundColor = ConsoleColor.White;
        t.fct();*/
        //Player p = new Player();
        Player p = new Player(Name);
        MapGame m = new MapGame(" + ", 10, 10);
        m.addElement(" M ", 4, 7);
        p.displayInfo();
        m.displayMap();
        m.displayDescription();
        m.indicationManip();
        //Process.Start("cmd.exe","/c cls"); //pour executer une commande cmd


        // Boucle while qui continue à lire une touche jusqu'à ce que 'Q' soit pressé
        while (true)
        {
            // Lire la touche
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            // Afficher la touche pressée
            //Console.WriteLine("\nTouche pressée: " + keyInfo.Key);

            // Vérifier si la touche 'Q' a été pressée pour quitter la boucle
            if (keyInfo.Key == ConsoleKey.Q)
            {
                //Console.WriteLine("Vous avez appuyé sur 'Q'. Sortie de la boucle.");
                break;
            }
            else
            {
                //Console.WriteLine("Appuyez sur une autre touche. Appuyez sur 'Q' pour quitter.");
            }
        }
    }
}
