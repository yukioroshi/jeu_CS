// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
/*dotnet new console -n titre => creer une solution de nom titre */
/*dotnet new nunit -n Titre.Tests => pour creer un dossier test unitaire pour le projet
 Console.ResetColor pour reset la couleur*/

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
        MapGame map = new MapGame(" + ", 10, 10);
        Character character = new Character(" P ");

        map.addElement(character.getRepresentation(),character.getPositionX() ,character.getPositionY());
        p.displayInfo();
        map.displayMap();
        map.displayDescription();
        map.indicationManip();
        //keyInfo = Console.ReadKey();

        //Process.Start("cmd.exe","/c cls"); //pour executer une commande cmd <=> Console.Clear()

        ConsoleKeyInfo keyInfo ;

        // Boucle while qui continue à lire une touche jusqu'à ce que 'Q' soit pressé
        while(true)
        {
            // Lire la touche
            keyInfo = Console.ReadKey();

            // Afficher la touche pressée
            //Console.WriteLine("\nTouche pressée: " + keyInfo.Key);

            // Vérifier si la touche 'Q' a été pressée pour quitter la boucle
            if (keyInfo.Key == ConsoleKey.Q)
            {
                break;
            }
           if(keyInfo.Key == ConsoleKey.LeftArrow)
            {
               character.move(character.getPosition()-1 /*+ map.getNbColonne()*/ , map);
            }
            if (keyInfo.Key == ConsoleKey.DownArrow)
            {
               character.move(character.getPosition() + map.getNbColonne(), map);
            }
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
               character.move(character.getPosition() - map.getNbColonne(), map); 
            }
            if (keyInfo.Key == ConsoleKey.RightArrow)
            {
               character.move(character.getPosition() + 1 /*map.getNbColonne()*/, map);              
            }

            Console.Clear();
            p.displayInfo();
            map.displayMap();
            map.displayDescription();
            map.indicationManip();
             //keyInfo = Console.ReadKey();
        } 
    }
}
