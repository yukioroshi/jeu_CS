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
        Character chara1 = new Character(nameCharacter[0], lifepoint, lpmax, magicPoint, mpmax, def_stat, levelCharacter[0], pos[3], " P ", list_comp);
        Character chara2 = new Character(nameCharacter[1], lifepoint, lpmax, magicPoint, mpmax, def_stat, levelCharacter[1], pos[3], " P ", list_comp);
        Character chara3 = new Character(nameCharacter[2], lifepoint, lpmax, magicPoint, mpmax, def_stat, levelCharacter[2], pos[3], " P ", list_comp);
        Character chara4 = new Character(nameCharacter[3], lifepoint, lpmax, magicPoint, mpmax, def_stat, levelCharacter[3], pos[3], " P ", list_comp);
        Character chara5 = new Character(nameCharacter[4], lifepoint, lpmax, magicPoint, mpmax, def_stat, levelCharacter[4], pos[3], " P ", list_comp);
        Character chara6 = new Character(nameCharacter[5], lifepoint, lpmax, magicPoint, mpmax, def_stat, levelCharacter[5], pos[3], " P ", list_comp);


        LinkedList<Character> st = new LinkedList<Character>();
        st.AddFirst(chara1);
        st.AddFirst(chara2);
        st.AddFirst(chara3);
        st.AddFirst(chara4);
        st.AddFirst(chara5);
        st.AddFirst(chara6);
        Objet obj1 = new Objet("Epee Divine");
        Objet obj2 = new Objet("Dague Empoisonner");
        Objet obj3 = new Objet("fiole de Sante");
        LinkedList<Objet> list_obj = new LinkedList<Objet>();
        list_obj.AddFirst(obj1);
        list_obj.AddFirst(obj2);
        list_obj.AddFirst(obj3);



        do
        {
            Console.Write("Entrez un nom d'utilisateur : ");
            nameplayer = Console.ReadLine();
        } while (nameplayer == "");


        Character  ennemy = new Character("Barbaros", " E ");
        Player p = new Player(nameplayer,st,list_obj);
        Sauvegarde savePlayer = new Sauvegarde(p.getPlayerName());
        MapGame map = new MapGame(" + ", 10, 10);

        string description = "";
        map.addElement(p.getCurrentCharacter().getRepresentation(), p.getCurrentCharacter().getPositionX(), p.getCurrentCharacter().getPositionY());
        ennemy.setRandomPositionX(map); 
        ennemy.setRandomPositionY(map); 
        map.addElement(ennemy.getRepresentation(), ennemy.getPositionX(), ennemy.getPositionY());
        
        Console.Clear();
        p.displayInfo(p.getCurrentCharacter());
        map.displayMapWithColor();
        map.displayDescription();
        map.indicationManip();
       
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
                p.getCurrentCharacter().move(p.getCurrentCharacter().getPosition() - 1 /*+ map.getNbColonne()*/ , map);
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                p.getCurrentCharacter().move(p.getCurrentCharacter().getPosition() + map.getNbColonne(), map);
            }
            else if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                p.getCurrentCharacter().move(p.getCurrentCharacter().getPosition() - map.getNbColonne(), map);
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                p.getCurrentCharacter().move(p.getCurrentCharacter().getPosition() + 1 /*map.getNbColonne()*/, map);
            }
            else if (keyInfo.Key == ConsoleKey.F)
            {
                if (map.getCase((p.getCurrentCharacter().getPosition() + 1)) == " E "
                    || map.getCase((p.getCurrentCharacter().getPosition() + 1)) == " M "
                    || map.getCase((p.getCurrentCharacter().getPosition() - 1)) == " E "
                    || map.getCase((p.getCurrentCharacter().getPosition() - 1)) == " M ")
                {
                    Console.Clear();
                    description=p.fight(ennemy);
                    //p.getCurrentCharacter().fight(ennemy);//fonctionne pas comme prevu
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
                if (map.getCase((p.getCurrentCharacter().getPosition() + 1)) == " N ")
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
                if (map.getCase((p.getCurrentCharacter().getPosition() + 1)) == " C ")
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
            else if (keyInfo.Key == ConsoleKey.P)
            {
                p.selectPerso(p.getCurrentCharacter(),map);
            }
            else if (keyInfo.Key == ConsoleKey.L)
            {
                description = "Legende :\n"+
                    "\tP => le personnage actif du joueur\r\n \tC => coffre\r\n \tO => objet\r\n \tE => Ennemi\r\n \tM => monstre\r\n \tN => NPC";
            }
            else
            {
                description = "Commande incorecte";
            }

            Console.Clear();
            p.displayInfo(p.getCurrentCharacter());
            map.displayMapWithColor();
            map.displayDescription(description);
            map.indicationManip();
            //keyInfo = Console.ReadKey();
        }
      
    }
}
