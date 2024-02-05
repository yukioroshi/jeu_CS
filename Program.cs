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
        Sauvegarde savePlayer= new Sauvegarde(p.getPlayerName());
        MapGame map = new MapGame(" + ", 10, 10);
        Character character = new Character(" P "), ennemy = new Character(" E ");
        string description = "";
        map.addElement(character.getRepresentation(),character.getPositionX() ,character.getPositionY());
        ennemy.setPositionX(0,map); ennemy.setPositionY(1,map);
        map.addElement(ennemy.getRepresentation(), ennemy.getPositionX(),ennemy.getPositionY());
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
            else if(keyInfo.Key == ConsoleKey.LeftArrow)
            {
               character.move(character.getPosition()-1 /*+ map.getNbColonne()*/ , map);
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
               character.move(character.getPosition() + map.getNbColonne(), map);
            }
            else if (keyInfo.Key == ConsoleKey.UpArrow)
            {
               character.move(character.getPosition() - map.getNbColonne(), map); 
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow)
            {
               character.move(character.getPosition() + 1 /*map.getNbColonne()*/, map);              
            }
            else if(keyInfo.Key == ConsoleKey.F)
            {
                if(map.getCase((character.getPosition()+1)) == " E " 
                    || map.getCase((character.getPosition() + 1)) == " M ")
                {
                    description = "Vous avez rencontrer un ennemi ! Voulez-vous le combattre ?\n" +
                                  "[y]: Combattre\n[n]:Plus tard\n";
                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Y)
                    {
                       Console.Clear();
                       character.fight(ennemy);//fonctionne pas comme prevu
                    }
                    if (keyInfo.Key == ConsoleKey.N) { break; }

                }
                else { description = "Rapprochez vous d'un ennemi pour combattre";
                    //Console.ReadKey();
                }
            }
            else if (keyInfo.Key == ConsoleKey.I)
            {
                if (map.getCase((character.getPosition() + 1)) == " N ")
                {
                    description = "dialogue avec un pnj";
                    //Console.ReadKey();
                }
                else
                {
                    description = "Rapprochez vous d'un personnage pour parler";
                    //Console.ReadKey();
                }
            }
            else if (keyInfo.Key == ConsoleKey.O)
            {
                if (map.getCase((character.getPosition() + 1)) == " C ")
                {
                   description = "Vous avez trouver un coffre";
                        //Console.ReadKey();
                }
                else
                {
                   description = "il n'y a pas de coffre ici. Cherchez ailleurs.";
                        //Console.ReadKey();
                }
            }
            else if (keyInfo.Key == ConsoleKey.V)
            {
               description = "Inventaire : cette fonctionnaliter n'est pas encore disponible";
            }
            else if (keyInfo.Key == ConsoleKey.C)
            {
              description = "Map : cette fonctionnaliter n'est pas encore disponible";
            }
            else if (keyInfo.Key == ConsoleKey.S)
            {
              description = "Sauvegarde : cette fonctionnaliter n'est pas encore disponible";
            }
            else if (keyInfo.Key == ConsoleKey.L)
            {
                description = "Legende de la map: cette fonctionnaliter n'est pas encore disponible";
            }
            else
            {
                description = "Commande incorecte";
            }

            Console.Clear();
            p.displayInfo();
            map.displayMap();
            map.displayDescription(description);
            map.indicationManip();
            //keyInfo = Console.ReadKey();
        }

        Console.WriteLine(map.getElementMap(24));

        savePlayer.saveMap2(map);
    } 
 }
