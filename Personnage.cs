using System;
/*classe qui represente les personnages du jeu*/
public class Character
{
    private string name;    //nom du perso 
    private int lifePoint;  //ses pv
    private int lifePointMax;  //ses pv
    private int magicPoint;
    private int magicPointMax;
    private int atk_stat;   //moy de ses atk
    private int def_stat;   //moy de ses def
    private int level;      //niveau d'exp
    private int posX, posY, pos;         //position dans la map
    private string representation;  //caractere Ascii sur la map
    private LinkedList<Competence> atk; //list de ces atk
    //private Element weeakness;
    //private Element strength;

    public Character()
    {
        this.name = "TEST";
        this.lifePoint = 10;
        this.lifePointMax = 10;
        this.magicPoint = 10;
        this.magicPointMax = 10;
        this.atk_stat = 0;
        this.def_stat = 0;
        this.level = 1;
        this.posX = 0;
        this.posY = 0;
        this.pos = 0;
        this.representation = "";
        atk = new LinkedList<Competence>();
    }

    public Character(string name, string p)
    {
        this.name = name;
        this.lifePoint = 10;
        this.lifePointMax = 10;
        this.magicPoint = 100;
        this.magicPointMax = 100;
        this.atk_stat = 0;
        this.def_stat = 0;
        this.level = 1;
        this.posX = 0;
        this.posY = 0;
        this.pos = 0;
        this.representation = p;
        atk = new LinkedList<Competence>();
    }

    public Character(string name, int lifePoint, int lpMax, int magicPoint, int mpMax, int def_stat, int level, int posX, int posY, string r, LinkedList<Competence> atk)
    {
        this.name = name;
        this.lifePoint = lifePoint;
        this.lifePointMax = lpMax;
        this.magicPoint = magicPoint;
        this.magicPointMax = mpMax;
        this.def_stat =
        this.level = level;
        this.posX = posX;
        this.posY = posY;
        this.representation = r;
        this.atk = atk;
        this.atk_stat = statAtk();
    }

    public Character(string name, int lifePoint, int lpMax, int magicPoint, int mpMax, int def_stat, int level, int pos, string r, LinkedList<Competence> atk)
    {
        this.name = name;
        this.lifePoint = lifePoint;
        this.lifePointMax = lpMax;
        this.magicPoint = magicPoint;
        this.magicPointMax = mpMax;
        this.def_stat =
        this.level = level;
        this.posX = 0;
        this.posY = 0;
        this.representation = r;
        this.atk = atk;
        this.atk_stat = statAtk();
    }

    public Character(Character c)
    {
        this.name = c.getName();
        this.lifePoint = c.getLife();
        this.magicPoint = c.getMagicPoint();
        this.atk_stat = c.getAtkStat();
        this.def_stat = c.getDefStat();
        this.level = c.getLevel();
        this.posX = c.getPositionX();
        this.posY = c.getPositionY();
        this.atk = c.getAtk();
        this.representation = c.getRepresentation();
    }

    public string getName()
    {
        return name;
    }

    public string getRepresentation() { return this.representation; }
    public int getLife()
    {
        return lifePoint;
    }

    public int getLifeMax()
    {
        return lifePointMax;
    }

    public LinkedList<Competence> getAtkList() { return atk; }

    public int getMagicPoint() { return magicPoint; }
    public int getMagicPointMax() { return magicPointMax; }
    public int getAtkStat() { return atk_stat; }
    public int getDefStat() { return def_stat; }
    public int getLevel() { return level; }
    public int getPositionX() { return posX; }
    public int getPositionY() { return posY; }
    public int getPosition() { return pos; }
    public void setPositionX(int x, MapGame m)
    {
        if ((x < 0) || (x > m.getNbLigne()))
        {
            Console.WriteLine("Erreur : position x invalide setPosition");
            Environment.Exit(1);
        }
        else
        {
            posX = x;
        }
    }

    public void setPositionY(int y, MapGame m)
    {
        if ((y < 0) || (y > m.getNbColonne()))
        {
            Console.WriteLine("Erreur : position y invalide pour setPosition");
            Environment.Exit(1);
        }
        else
        {
            posY = y;
        }
    }
    
    public void setPosition(int p,MapGame m)
    {
        if (p < 0 || p > m.size())
        {
            Console.WriteLine("Erreur position p dans setPosition");
            Environment.Exit(1);
        }
        else { pos = p; }
    } 

    public void setRandomPosition(MapGame m)
    {
        Random random=new Random();
        pos = random.Next(m.size());
    }
    public void setRandomPositionX(MapGame m)
    {
        Random random = new Random();
        do
        {
            posX = random.Next(m.getNbLigne());
            if (m.getCase(posX) == m.getField()){
                break;
            }
        }while(m.getCase(posX)!=m.getField());

    }
    public void setRandomPositionY(MapGame m)
    {

        Random random = new Random();
        do
        {
            posY = random.Next(m.getNbColonne());
            if (m.getCase(posX) == m.getField()){
                break;
            }
        } while (m.getCase(posX) != m.getField());

    }
    

    public string toString()
    {
        string res = "";
        res+=name+"\nLifepoint:"+lifePoint+"\nlifepoitmax:"+lifePointMax + "\nmp:" +magicPoint + "\nmpmax:" +magicPointMax + "\natkstat:" +
            atk_stat + "\ndefsata:" +def_stat + "\nlvl:" +level + "\npx:" +posX + "\npy:" +posY + "\npos:" +pos + "\nrep:"+representation+"\natk:";
        foreach(Competence a in atk)
        {
            res += "atk:"+a.toString()+"\n";
        }
        return res;
    }

    public int statAtk()
    {
        int moy,somme = 0;
        if (atk.Count() == 0)
        {
            moy = 0;
        }
        else
        {
            foreach (Competence a in atk)
            {
                somme += a.getPuissance();
            }
            moy = (somme / atk.Count()) + 1;
        }
        return moy;
    }


    public void moveX(int x, MapGame m)
    {
        if ((x < 0) || (x > m.getNbLigne()))
        {
            Console.WriteLine("Erreur : position x invalide setPosition");
            Environment.Exit(1);
        }
        else
        {
            posX += x;
        }
    }

    
    public void move(int newpos, MapGame m)
    {
        if ((newpos < 0) || (newpos > ((m.getNbLigne() * m.getNbColonne())) - 1)
            || m.getField() != m.getCase(newpos))
        {
            // this.pos = 0;
            //Console.WriteLine("Erreur : position x invalide setPosition");
            //Environment.Exit(1);

            /*efface la position ancienne et lui affecte le champ 'field' de la map*/
            m.changeCase(m.getField(), this.pos);
            /*ne bouge pas la position du perso*/
            newpos = this.pos;
            /*Change une case de la map*/
            m.changeCase(representation, newpos);


        }
        //else if (m.getField() != m.getCase(newpos))
        else
        {
            /*efface la position ancienne et lui affecte le champ 'field' de la map*/
            m.changeCase(m.getField(), this.pos);
            /*bouge la position du perso*/
            this.pos = newpos;
            /*Change une case de la map*/
            m.changeCase(representation, newpos);
        }
    }

    /*PAS TRES FONCTIONNELLE*/
    public void move(int x, int y, MapGame m)
    {
        if ((x < 0) || (x > m.getNbLigne()))
        {
            Console.WriteLine("Erreur : position x invalide setPosition");
            Environment.Exit(1);
        }
        if ((y < 0) || (y > m.getNbColonne()))
        {
            Console.WriteLine("Erreur : position y invalide pour setPosition");
            Environment.Exit(1);
        }
        else
        {
            /*efface la position ancienne et lui affecte le champ 'field' de la map*/
            m.addElement(m.getField(), getPositionX(), getPositionY());
            /*bouge la position du perso*/
            posX = x; posY = y;
            /**/
            m.addElement(representation, posX, posY);
        }
    }


    public void moveY(int y, MapGame m)
    {
        if ((y < 0) || (y > m.getNbColonne()))
        {
            Console.WriteLine("Erreur : position y invalide pour setPosition");
            Environment.Exit(1);
        }
        else
        {
            posY += y;

        }
    }

    public LinkedList<Competence> getAtk() { return atk; }

    public void addAtk(Competence competence)
    {
        atk.AddFirst(competence);
    }
    public bool isAlive()
    {
        return lifePoint != 0;
    }

    public void fightscreen(Character ennemy)
    {
        int ligne = 10;

        Console.Clear();

        Console.WriteLine("\n[" + ennemy.name + "]" + "  PV:" + ennemy.lifePoint + "/" + ennemy.lifePointMax + "  Lvl:" + ennemy.level);
        for (int i = 0; i < ennemy.lifePoint; i++)
        {
            Console.Write("-----");
        }

        Console.WriteLine("\n\n\n\n  ");
        Console.WriteLine("[" + name + "]" + "  Lvl:" + level);
        Console.WriteLine("Pv:" + lifePoint + "/" + lifePointMax + "  PM:" + magicPoint + "/" + magicPointMax);

        for (int i = 0; i < lifePoint; i++)
        {
            Console.Write("--");
        }
        Console.Write("\n\n");
        for (int i = 0; i < ligne; i++)
        {
            Console.Write("===");
            if (i == ligne - 1)
                Console.Write("\n");

        }

        Console.Write("[a] : coup de poing {puissance : 1, cout : 0}\n");
        Console.Write("[z] : eclat spectral {puissance : 2, cout : 18}\n");
        Console.Write("[e] : rafale de feuilles {puissance : 3, cout : 30}\n");
        Console.Write("[r] : cryo-laser {puissance : 3, cout : 38}\n");
        Console.Write("[t] : bombe aqueuse {puissance : 4, cout : 42}\n");
        Console.Write("[y] : tornade de sable {puissance : 5, cout : 54}\n");
        Console.Write("[u] : fulguro-frappe {puissance : 5, cout : 63}\n");
        Console.Write("[i] : inferno {puissance : 6, cout : 77}\n");
        Console.Write("[o] : trancher absolu {puissance : 6, cout : 67}\n");
        Console.WriteLine("[p] : ire draconique {puissance : 7, cout : 80}");
        Console.Write("[q] : quitter le combat\n");

        for (int i = 0; i < ligne; i++)
        {
            Console.Write("===");
            if (i == ligne - 1)
                Console.Write("\n");

        }
    }

    public void fight(Character ennemy)
    {
        ConsoleKeyInfo action;
        Random rnd = new Random();

        while (this.isAlive() && ennemy.isAlive())
        {
            fightscreen(ennemy);

            action = Console.ReadKey();
            if (action.Key == ConsoleKey.A)
            {
                ennemy.lifePoint -= 1;
                fightscreen(ennemy);
                Console.WriteLine("Vous donnez un coup de poing");
            }
            else if (action.Key == ConsoleKey.Z && this.magicPoint >= 18)
            {
                ennemy.lifePoint -= 2;
                this.magicPoint -= 18;
                fightscreen(ennemy);
                Console.WriteLine("Vous lancez un eclat spectral");
            }
            else if (action.Key == ConsoleKey.E && this.magicPoint >= 30)
            {
                ennemy.lifePoint -= 3;
                this.magicPoint -= 30;
                fightscreen(ennemy);
                Console.WriteLine("Vous invoquez une rafale de feuilles");
            }
            else if (action.Key == ConsoleKey.R && this.magicPoint >= 38)
            {
                ennemy.lifePoint -= 3;
                this.magicPoint -= 38;
                fightscreen(ennemy);
                Console.WriteLine("Vous tirez un cryo-laser");
            }
            else if (action.Key == ConsoleKey.T && this.magicPoint >= 42)
            {
                ennemy.lifePoint -= 4;
                this.magicPoint -= 42;
                fightscreen(ennemy);
                Console.WriteLine("Vous envoyez une bombe aqueuse");
            }
            else if (action.Key == ConsoleKey.Y && this.magicPoint >= 54)
            {
                ennemy.lifePoint -= 5;
                this.magicPoint -= 54;
                fightscreen(ennemy);
                Console.WriteLine("Vous invoquez une tornade de sable");
            }
            else if (action.Key == ConsoleKey.U && this.magicPoint >= 63)
            {
                ennemy.lifePoint -= 5;
                this.magicPoint -= 63;
                fightscreen(ennemy);
                Console.WriteLine("Vous lancez une fulguro-frappe");
            }
            else if (action.Key == ConsoleKey.I && this.magicPoint >= 77)
            {
                ennemy.lifePoint -= 6;
                this.magicPoint -= 77;
                fightscreen(ennemy);
                Console.WriteLine("Vous utilisez inferno");
            }
            else if (action.Key == ConsoleKey.O && this.magicPoint >= 67)
            {
                ennemy.lifePoint -= 6;
                this.magicPoint -= 67;
                fightscreen(ennemy);
                Console.WriteLine("Vous utilisez le trancher absolu");
            }
            else if (action.Key == ConsoleKey.P && this.magicPoint >= 80)
            {
                ennemy.lifePoint -= 7;
                this.magicPoint -= 80;
                fightscreen(ennemy);
                Console.WriteLine("Vous dechainez l'ire draconique");
            }
            else if (action.Key == ConsoleKey.Q)
            {
                return;
            }
            else
            {
                Console.WriteLine("Vous n'attaquez pas");
            }

            int actionennemy = rnd.Next(1, 4);
            if (actionennemy == 1)
            {
                this.lifePoint -= 1;
                Console.WriteLine(ennemy.getName()+" vous donne un coup de poing");
            }
            else if (actionennemy == 2)
            {
                this.lifePoint -= 2;
                Console.WriteLine(ennemy.getName() + " vous donne un coup de pied");
            }
            else
            {
                this.lifePoint -= 3;
                Console.WriteLine(ennemy.getName() + " vous charge");
            }
            Console.ReadKey();
            this.magicPoint += 2;
        }
        Console.Clear();
        if (this.isAlive())
        {
            Console.WriteLine(ennemy.name + " est K.O.");
        }
        else
        {
            Console.WriteLine(this.name + " est K.O.");
        }
    }

}