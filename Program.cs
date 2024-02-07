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
        //Test1 t = new Test1();
        //Console.BackgroundColor = ConsoleColor.Red;
        /*Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("[033[0;30m]" +"\t Hello, World!");
        Console.ForegroundColor = ConsoleColor.White;
        t.fct();*/
        //Player p = new Player();

        string nameplayer;
        string[] nameCharacter=new string[6];
        int lpmax = 100, mpmax=80, def_stat=10;
        int[] lifepoint= new int[6], magicPoint=new int[6], level=new int[6];   

        nameCharacter[0] = "Neos";  nameCharacter[1] = "Burstinatrix";  nameCharacter[2] = "Airman";    
        nameCharacter[3] = "Annapelera";    nameCharacter[4] = "Sakuretsu"; nameCharacter[5] = "Clayman";

        lifepoint[0] = 40;  lifepoint[1] = 34;  lifepoint[2] = 45;
        lifepoint[3] = 76;  lifepoint[4] = 54;  lifepoint[5] = 23;

        magicPoint[0] = 23; magicPoint[1] = 13; magicPoint[2] = 45;
        magicPoint[3] = 10; magicPoint[4] = 39; magicPoint[5] =5;

        level[0] = 10; level[1] = 20;  level[2] = 20;
        level[3] = 30; level[4] = 40;  level[5] = 50;

        Competence competence = new Competence();
        Character character1 = new Character(nameCharacter[0], lifepoint[0], lpmax, magicPoint[0], mpmax, def_stat, level[0]," P ",);
       
        LinkedList<Competence> competences = new LinkedList<Competence>();
        LinkedList<Character> st = new LinkedList<Character>();


        do
        {
            Console.Write("Entrez un nom d'utilisatuer : ");
            nameplayer = Console.ReadLine();
        } while (nameplayer == "");


        Character character = new Character("Neos", " P "), ennemy = new Character("Ennemy", " E ");
        Player p = new Player(Name);
        Sauvegarde savePlayer = new Sauvegarde(p.getPlayerName());
        MapGame map = new MapGame(" + ", 10, 10);

        string description = "";
        map.addElement(character.getRepresentation(), character.getPositionX(), character.getPositionY());
        ennemy.setPositionX(0, map); ennemy.setPositionY(1, map);
        map.addElement(ennemy.getRepresentation(), ennemy.getPositionX(), ennemy.getPositionY());
        p.displayInfo();
        map.displayMap();
        map.displayDescription();
        map.indicationManip();
        //keyInfo = Console.ReadKey();

        //Process.Start("cmd.exe","/c cls"); //pour executer une commande cmd <=> Console.Clear()

        ConsoleKeyInfo keyInfo;

        // Boucle while qui continue à lire une touche jusqu'à ce que 'Q' soit pressé
        while (true)
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
            else if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                character.move(character.getPosition() - 1 /*+ map.getNbColonne()*/ , map);
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
            else if (keyInfo.Key == ConsoleKey.F)
            {
                if (map.getCase((character.getPosition() + 1)) == " E "
                    || map.getCase((character.getPosition() + 1)) == " M ")
                {
                    Console.Clear();
                    character.fight(ennemy);//fonctionne pas comme prevu
                    Console.ReadKey();
                }
                else
                {
                    description = "Rapprochez vous d'un ennemi pour combattre";
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
                description = "Inventaire : cette fonctionnalite n'est pas encore disponible";
            }
            else if (keyInfo.Key == ConsoleKey.C)
            {
                description = "Map : cette fonctionnalite n'est pas encore disponible";
            }
            else if (keyInfo.Key == ConsoleKey.S)
            {
                description = "Sauvegarde : cette fonctionnalite n'est pas encore disponible";
            }
            else if (keyInfo.Key == ConsoleKey.L)
            {
                description = "Legende de la map: cette fonctionnalite n'est pas encore disponible";
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
        Console.WriteLine(p.toString());
        savePlayer.saveMap2(p,map) ;
    }
}
