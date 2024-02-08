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
    private string field;   //caractere ascii utiliser pour la matrice
    // private string description; 

    public MapGame()
    {
        this.ligne = 0;
        this.colonne = 0;
        this.mapAscii = new string[0];
        this.field = "";
        //   this.description = "";
    }
    /*s est de taille 3*/
    public MapGame(string s, int ligne, int colonne)
    {   
        this.field = s;
        this.ligne = ligne;
        this.colonne = colonne;
        this.mapAscii = new string[ligne * colonne];
        // this.description = "";

        for (int i = 0; i < ligne; i++)
        {
            for (int j = 0; j < colonne; j++)
            {
                mapAscii[i * colonne + j] = this.field;
            }
        }
    }

    public int size() {  return this.mapAscii.Length; }
    public int getNbLigne() { return ligne; }
    public int getNbColonne() { return colonne; }
    public string getField(){ return field; }

    public string getElementMap(int index)
    {
        if (index < 0 || index > ligne * colonne)
        {
            Console.WriteLine("Erreur: index en dehors pour getElementMap");
            Environment.Exit(1);
        }

        return this.mapAscii[index];
    }
    public string[] getMap() {
        return mapAscii;
    }


    public string toString()
    {
        string res = "";
        res += ligne + "\n" + colonne + "\n";
        for (int i = 0;i < size(); i++)
        {
            res += mapAscii[i];
        }
        return res;
    }



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

    /*affiche la map dans le terminale, avec les couleurs*/
    public void displayMapWithColor()
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
                if (mapAscii[i*colonne + j] == " P ")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\t" + mapAscii[i * colonne + j]);
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else if(mapAscii[i * colonne + j] == " E ")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\t" + mapAscii[i * colonne + j]);
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else if (mapAscii[i * colonne + j] == " C ")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\t" + mapAscii[i * colonne + j]);
                    Console.ForegroundColor = ConsoleColor.White;
                    //Console.ResetColor();

                }
                else if (mapAscii[i * colonne + j] == " N ")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\t" + mapAscii[i * colonne + j]);
                    Console.ForegroundColor = ConsoleColor.White;
                    //Console.ResetColor();

                }
                else
                {
                    Console.Write("\t" + mapAscii[i * colonne + j]);
                }
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
        Console.Write(" [l] : voir la legende\n");
        Console.Write("[q] : quitter\t\t");
        Console.WriteLine(" [p] : changer de perso\n");


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
            Environment.Exit(1);
        }
        if ((y < 0) || (y > colonne))
        {
            Console.WriteLine("Erreur : position y invalide pour addElement");
            Environment.Exit(1);
            
        }
        else
        {
            int tmpx = x, tmpy = y ;
            mapAscii[tmpx * colonne + tmpy] = s;
        }
    }

    public void changeCase(string s,int index) {
        if (index < 0 || index > ligne*colonne)
        {
            index = 0;
            mapAscii[index] = s;
        }
        else
            mapAscii[index] = s; 
    }

    /*change une partie de la map*/
    public void changeField(int i, int j, int k, int l)
    {

    }

    public string getCase(int x, int y)
    {
        if((x<0) || (x>ligne) )
        {
            Console.WriteLine("Erreur : index de ligne de case pour getCase");
            Environment.Exit(1);
        } 
        if((y<0) || (y > colonne))
        {
            Console.WriteLine("Erreur : index de colonne case pour getCase");
            Environment.Exit(1);
        }
        return mapAscii[x * colonne + y];
    }

    public string getCase(int index)
    {
        if ((index < 0) || (index > ligne*colonne))
        {
            Console.WriteLine("Erreur : index de case pour getCase");
            Environment.Exit(1);
        }
        
        return mapAscii[index];
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