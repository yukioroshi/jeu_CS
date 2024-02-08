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
        int lifepoint = 100, lpmax = 100, magicPoint = 100, mpmax=100, def_stat=10;
        int[] levelCharacter=new int[6];
        int[] pos = new int[6];
        int levelComp = 18, puissanceComp=50;

        nameCharacter[0] = "Neos";  nameCharacter[1] = "Burstinatrix";  nameCharacter[2] = "Airman";    
        nameCharacter[3] = "Annapelera";    nameCharacter[4] = "Sakuretsu"; nameCharacter[5] = "Clayman";

        levelCharacter[0] = 10; levelCharacter[1] = 20; levelCharacter[2] = 20;
        levelCharacter[3] = 30; levelCharacter[4] = 40; levelCharacter[5] = 50;

        pos[0] = 0; pos[1] = 65; pos[2] = 23; pos[3] = 90; pos[4] = 6; pos[5] = 30;

        Competence competence1 = new Competence("Coup de poing",levelComp,puissanceComp,TypePerso.Guerrier);

        LinkedList<Competence> list_comp = new LinkedList<Competence>();
        list_comp.AddFirst(competence1);
        Character chara = new Character(nameCharacter[0], lifepoint, lpmax, magicPoint, mpmax, def_stat, levelCharacter[0], pos[3], " P ", list_comp);
            //(nameCharacter[0], lifepoint[0], lpmax, magicPoint[0], mpmax, def_stat, levelCharacter[0],pos[0]+" P ",list_comp);
       
        LinkedList<Character> st = new LinkedList<Character>();


        do
        {
            Console.Write("Entrez un nom d'utilisateur : ");
            nameplayer = Console.ReadLine();
        } while (nameplayer == "");


        Character  ennemy = new Character("Ennemy", " E ");
        Player p = new Player(nameplayer);
        Sauvegarde savePlayer = new Sauvegarde(p.getPlayerName());
        MapGame map = new MapGame(" + ", 10, 10);

        string description = "";
        map.addElement(chara.getRepresentation(), chara.getPositionX(), chara.getPositionY());
        ennemy.setRandomPositionX(map); 
        ennemy.setRandomPositionY(map); 
        map.addElement(ennemy.getRepresentation(), ennemy.getPositionX(), ennemy.getPositionY());
        
        Console.Clear();
        p.displayInfo();
        map.displayMapWithColor();
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
                chara.move(chara.getPosition() - 1 /*+ map.getNbColonne()*/ , map);
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                chara.move(chara.getPosition() + map.getNbColonne(), map);
            }
            else if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                chara.move(chara.getPosition() - map.getNbColonne(), map);
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                chara.move(chara.getPosition() + 1 /*map.getNbColonne()*/, map);
            }
            else if (keyInfo.Key == ConsoleKey.F)
            {
                if (map.getCase((chara.getPosition() + 1)) == " E "
                    || map.getCase((chara.getPosition() + 1)) == " M "
                    || map.getCase((chara.getPosition() - 1)) == " E "
                    || map.getCase((chara.getPosition() - 1)) == " M ")
                {
                    Console.Clear();
                    chara.fight(ennemy);//fonctionne pas comme prevu
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
                if (map.getCase((chara.getPosition() + 1)) == " N ")
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
                if (map.getCase((chara.getPosition() + 1)) == " C ")
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
                // description = "Inventaire : cette fonctionnalite n'est pas encore disponible";
                p.displayInventaire();
            }
            else if (keyInfo.Key == ConsoleKey.C)
            {
                description = "Map : cette fonctionnalite n'est pas encore disponible";
            }
            else if (keyInfo.Key == ConsoleKey.S)
            {
                // description = "Sauvegarde : cette fonctionnalite n'est pas encore disponible";
                description=savePlayer.saveMap2(p, map);
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
            map.displayMapWithColor();
            map.displayDescription(description);
            map.indicationManip();
            //keyInfo = Console.ReadKey();
        }
      
    }
}
