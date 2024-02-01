/*Classe qui represente la map, dans celle-ci on retrouve
 * " P " => le personnage actif du joueur
 * " C " => coffre
 * " O " => objet
 * " E " => Ennemi
 * " M " => monstre
 * " N " => NPC
 * */
public class MapGame
{
    private int ligne;
    private int colonne;
    private string[] mapAscii; /*matrice de string de 3 caracter ascii*/
    // private string description; 

    public MapGame()
    {
        this.ligne = 0;
        this.colonne = 0;
        this.mapAscii = new string[0];
        //   this.description = "";
    }
    /*s est de taille 3*/
    public MapGame(string s, int ligne, int colonne)
    {
        this.ligne = ligne;
        this.colonne = colonne;
        this.mapAscii = new string[ligne * colonne];
        // this.description = "";

        for (int i = 0; i < ligne; i++)
        {
            for (int j = 0; j < colonne; j++)
            {
                mapAscii[i * colonne + j] = s;
            }
        }
    }

    public int getNbLigne() { return ligne; }
    public int getNbColonne() { return colonne; }
    public string[] getMap() { return mapAscii; }

    /*affiche la map dans le terminale*/
    public void displayMap()
    {
        int largeur = 30;
        for (int i = 0; i < largeur; i++)
        {
            Console.Write("___");
            if (i == largeur - 1)
                Console.Write("\n");

        }

        for (int i = 0; i < ligne; i++)
        {
            for (int j = 0; j < colonne; j++)
            {
                Console.Write("\t" + mapAscii[i * colonne + j]);
            }
            Console.Write("\n\n");
        }

    }

    /*Zone qui affiche la description de ce qui se passe dans la map quand le joueur interagi*/
    public void displayDescription(string descr = "Rien a signaler\n")
    {
        int largeur = 30, hauteur = 4;

        //Console.Write(" ___");
        for (int i = 0; i < largeur; i++)
        {
            Console.Write("___");
            if (i == largeur - 1)
                Console.Write("\n");

        }

        Console.WriteLine("Description :\n");
        Console.WriteLine("-> " + descr);
        for (int i = 0; i < hauteur; i++)
        {
            Console.Write("\n");
        }

        for (int i = 0; i < largeur; i++)
        {
            Console.Write("___");
            if (i == largeur - 1)
                Console.Write("\n");

        }

    }

    public void indicationManip()
    {
        int largeur = 17;
        for (int i = 0; i < largeur; i++)
        {
            Console.Write("===");
            if (i == largeur - 1)
                Console.Write("\n");

        }

        Console.Write("[fleches] : deplacement\t");
        Console.Write(" [i] : interagir/parler\n");
        Console.Write("[o] : ouvrir coffre\t");
        Console.Write(" [f] : combattre\n");
        Console.Write("[v] : voir inventaire\t");
        Console.Write(" [c] : changer de map \n");
        Console.Write("[s] : sauvegarder\t");
        Console.WriteLine(" [q] : quitter");

        for (int i = 0; i < largeur; i++)
        {
            Console.Write("===");
            if (i == largeur - 1)
                Console.Write("\n");

        }
    }

    /*ajoute un element(perso,coffre, objet...) dans la map*/
    public void addElement(string s, int x, int y)
    {
        if ((x < 0) || (x > ligne))
        {
            Console.WriteLine("Erreur : position x invalide pour addElement");
            return;
        }
        if ((y < 0) || (y > colonne))
        {
            Console.WriteLine("Erreur : position y invalide pour addElement");
            return;
        }
        else
        {
            int tmpx = x - 1, tmpy = y - 1;
            mapAscii[tmpx * colonne + tmpy] = s;
        }
    }

    /*change une partie de la map*/
    public void changeField(int i, int j, int k, int l)
    {

    }

    /*augmente le nombre de ligne dans la map*/
    public void resizeLigne(int l)
    {
        //pour plus tard
    }

    /*augmente le nombre de colonne dans la map*/
    public void resizeColonne(int c)
    {
        //pour plus tard
    }


}