
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
    public Player(string name, LinkedList<Character> stored_c, LinkedList<Objet> o)
    {
        stored_perso = new LinkedList<Character>();
        active_perso = new LinkedList<Character>();
        obj = new LinkedList<Objet>();
        foreach (Character tmp in stored_c)
        {//Rpl : le foreach ne permet que de lire, pas de modifier
            stored_perso.AddLast(tmp);
        }
        setActiveCharacter(0, 1, 2);
        foreach (Objet tmp2 in o)
        {
            obj.AddLast(tmp2);
        }
        current = new Character(active_perso.ElementAt<Character>(0));
        id_name = name;

    }

    public string getPlayerName()
    {
        return id_name;
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

    public Character getCurrentCharacter()
    {
        return current;
    }
    public void displayInfo()
    {
        Console.WriteLine("id: " + id_name);
        Console.Write("[" + current.getName() + "]"
            + " PV:" + current.getLife()
            + " PM:" + current.getMagicPoint()
            + " Lvl:" + current.getLevel() + "\n"
            + "team:" + this.getNbActiveCharacter() + "/3\n");

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