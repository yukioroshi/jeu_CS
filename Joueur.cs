
/*class qui represente l'utilisateur(le joueur)*/
using System.ComponentModel.DataAnnotations;

public class Player
{
    //id du joueur, qu'on pourra aussi utiliser en tant que nom de sauvegarde d'un fichier
    private string id_name;
    //le personnage qui sera sur la map 
    Character current;
    //liste des personnage avec lequel le joueur fera ses combats
    private LinkedList<Character> active_perso;
    //liste totale des personnages posseder par le joueur
    private LinkedList<Character> stored_perso;
    //liste des objets posseder par le joueur
    private LinkedList<Objet> obj;

    /*constructeur par defaut*/
    public Player()
    {
        id_name = "idPlayer";
        current = new Character();
        active_perso = new LinkedList<Character>(); ;
        stored_perso = new LinkedList<Character>(); ;
        obj = new LinkedList<Objet>();
    }

    /*constructeur*/
    public Player(string id_name)
    {
        this.id_name = id_name;
        current = new Character();
        active_perso = new LinkedList<Character>(); ;
        stored_perso = new LinkedList<Character>(); ;
        obj = new LinkedList<Objet>();
    }
    
    public Player(string name, LinkedList<Character> stored_c, LinkedList<Objet> o)
    {
        stored_perso = stored_c;
        active_perso = new LinkedList<Character>();
        for(int i = 0; i < stored_perso.Count(); i++)
        {
            if (i < 3)
                active_perso.AddFirst(stored_perso.ElementAt(i));
            else
                break;
        }
        obj = o;
        
       
        current = active_perso.ElementAt<Character>(0);
        id_name = name;

    }

    public string getPlayerName()
    {
        return id_name;
    }

    public Character getCurrentCharacter()
    {
        //current = active_perso.First();
        return current;
    }
    public LinkedList<Character> getActiveCharacter()
    {
        return active_perso;
    }
    public LinkedList<Character> getStoredPerso()
    {
        return stored_perso;
    }
    public LinkedList<Objet> getCharaObjet()
    {
        return obj;
    }


    /*renvoi le nombre de personnage actif posseder par le joueur*/
    public int getNbActiveCharacter()
    {
        int count = 0;
        foreach (Character p in active_perso)
        {
            if (p.isAlive())
                count++;
        }

        return count;
    }

    /*renvoi le nombre de personnage actif posseder par le joueur*/
    public int getNbStoredCharacter()
    {
        return stored_perso.Count();
    }

    /*renvoi le nombre d'objets posseder par le joueur*/
    public int getNbObjet()
    {
        return obj.Count();
    }

    public void setCurrentCharacter(Character c)
    {
        current = c;
    }
    public string toString()
    {
        string res = "";
        res += id_name + "\n";
        foreach (Character p in active_perso)
        {
            res += p.toString() + "\n";
        }
        foreach (Character p in stored_perso)
        {
            res += p.toString() + "\n";
        }
        foreach (Objet o in obj)
        {
            res += o.toString() + "\n";
        }
        return res;
    }

    /*ajoute un perso a la liste des personnage du joueur*/
    public void addCharacter(Character c)
    {
        stored_perso.AddFirst(c);
    }
    /*fixe les personnages (3) que le joueur va utiliser dans ces combats*/
    public void setActiveCharacter(int un, int deux, int trois)
    {
        if ((un < 0) || (un > stored_perso.Count())
           || (deux < 0) || (deux > stored_perso.Count()) || (trois < 0)
           || (trois > stored_perso.Count()))
        {
            Console.WriteLine("Erreur index : setActiveCharacter dans Joueur.cs");
            return;
        }
        active_perso.AddLast(stored_perso.ElementAt<Character>(un));
        active_perso.AddLast(stored_perso.ElementAt<Character>(deux));
        active_perso.AddLast(stored_perso.ElementAt<Character>(trois));

    }

    public void addObjet(Objet objet)
    {
        obj.AddFirst(objet);
    }
    public void displayInfo(Character c)
    {
        Console.WriteLine("id: " + id_name);
        Console.Write("[" + c.getName() + "]"
            + " PV:" + c.getLife()
            + " PM:" + c.getMagicPoint()
            + " Lvl:" + c.getLevel() + "\n"
            + "team:" + this.getNbActiveCharacter() + "/3\n");

    }

    public void displayInventaire()
    {
        Console.Clear();
        Console.WriteLine("Equipe active:");
        foreach (Character character in active_perso)
        {
            Console.WriteLine("\t["+character.getName()+"]:  PV:"+character.getLifeMax()+"  PM:"+character.getMagicPointMax()+
                "  lvl:"+character.getLevel()+"  Atk:"+character.getAtkStat());
            Console.WriteLine("");
        }
        Console.WriteLine("\nGalerie:");
        foreach (Character character in stored_perso)
        {
            Console.WriteLine("\t[" + character.getName() + "]:  PV:" + character.getLifeMax() + "  PM:" + character.getMagicPointMax() +
                "  lvl:" + character.getLevel() + "  Atk:" + character.getAtkStat());
            Console.WriteLine("");
        }
        Console.WriteLine("\nObjets:");
        for (int i=0;i< obj.Count();i++)
        {
            Console.WriteLine("\t[" + obj.ElementAt<Objet>(i).getNameObj()+"]");
            
            Console.WriteLine("");
        }
        Console.WriteLine("\nappuyez sur une touche pour revenir en arriere");
        Console.ReadKey();

    }

    public void selectPerso(Character c,MapGame m)
    {
        ConsoleKeyInfo key;
       
        Console.Clear();
        Console.WriteLine("Selectionnez un personnage\n");
        Console.WriteLine("[a] : " + active_perso.ElementAt(0).getName() + "\n");
        Console.WriteLine("[b] : " + active_perso.ElementAt(1).getName() + "\n");
        Console.WriteLine("[c] : " + active_perso.ElementAt(2).getName() + "\n");
        Console.WriteLine("[g] : Choisir un personnage dans la galerie\n");

        key = Console.ReadKey();

        if (key.Key == ConsoleKey.A)
        {
            current=active_perso.ElementAt(0);
        }
        else if (key.Key == ConsoleKey.B)
        {
            current = active_perso.ElementAt(1);


        }
        else if (key.Key == ConsoleKey.C)
        {
            current = active_perso.ElementAt(2);
        }
        else if (key.Key == ConsoleKey.G)
        {
            changeEquipe();
        }
        current.setPositionX(c.getPositionX(), m);
        current.setPositionY(c.getPositionY(), m);
        current.setPosition(c.getPosition(), m);
    }

    public void changeEquipe()
    {
        int i = 0;
        int[] choix=new int[3];
        string[] perso = new string[3];
        perso[0] = "[Vide]"; perso[1] = "[Vide]"; perso[2] = "[Vide]";
        LinkedList<Character> newTeam = new LinkedList<Character>();
        do
        {
            Console.Clear();
            Console.WriteLine("Galerie\n");

            foreach (Character character in stored_perso)
            {
                Console.WriteLine("(" + i + ")\t[" + character.getName() + "]:  PV:" + character.getLifeMax() + "  PM:" + character.getMagicPointMax() +
                    "  lvl:" + character.getLevel() + "  Atk:" + character.getAtkStat());
                Console.WriteLine(""); 
                
                if (i == stored_perso.Count()-1)
                    i = 1;
                else
                    i++;
            }

    
            Console.WriteLine("Composez votre equipe de 3 personnages");
            choix[0] =  int.Parse(Console.ReadLine());
            if (choix[0] >= 0 && choix[0] < stored_perso.Count())
            {
                if (!newTeam.Contains(stored_perso.ElementAt(choix[0])))
                {
                    newTeam.AddFirst(stored_perso.ElementAt(choix[0]));
                }
            }
            else
            {
                Console.WriteLine("Choix incorrect votre choix est : " + choix[0]);
                Console.ReadKey();
            }

            choix[1] =  int.Parse(Console.ReadLine());
            if (choix[1] >= 0 && choix[1] < stored_perso.Count())
            {
                if (!newTeam.Contains(stored_perso.ElementAt(choix[1])))
                {
                    newTeam.AddFirst(stored_perso.ElementAt(choix[1]));
                }
            }
            else
            {
                Console.WriteLine("Choix incorrect votre chois est : " + choix[1]);
                Console.ReadKey();
            }

            choix[2] =  int.Parse(Console.ReadLine());
            if (choix[2] >= 0 && choix[2] < stored_perso.Count())
            {
                if (!newTeam.Contains(stored_perso.ElementAt(choix[2])))
                {
                    newTeam.AddFirst(stored_perso.ElementAt(choix[2]));
                }
            }
            else
            {
                Console.WriteLine("Choix incorrect votre chois est : " + choix[2]);
                Console.ReadKey();
            }
           

        } while (newTeam.Count < 3);

        Console.WriteLine("Votre equipe :\n");
        Console.Write("   " + newTeam.ElementAt(0).getName());
        Console.Write("   " + newTeam.ElementAt(1).getName());
        Console.Write("   " + newTeam.ElementAt(2).getName());
    
        active_perso = newTeam;
        Console.WriteLine("\n\nAppuyer sur une touche pour revenir en arriere...");
        Console.ReadKey();


    }
    public string fight(Character ennemy)
    {
        if((getNbActiveCharacter() > 0))
        {
            int i = 0;
            Character tmp;
            while (getNbActiveCharacter() > 0)
            {
                if (i < active_perso.Count())
                {
                   tmp = active_perso.ElementAt(i);
                   if (tmp.isAlive() && ennemy.isAlive())
                   {
                       tmp.fight(ennemy);
                       if (!ennemy.isAlive())
                       {
                           break;
                       }
                        else
                        {
                            break;
                        }
                    }
                   
                   else
                   {
                       i++;
                   }
                }
                
            }
            return "";
        }
        else { return "Vos personnages ne sont pas en etat de combattre !"; }

    }

    /*fonction de sauvegarde*/
    public void save()
    {
        //ecriture dans un ficher;
    }

    /*fonction de de chargement*/
    public void load()
    {
        //lecture dans un fichier
    }


}