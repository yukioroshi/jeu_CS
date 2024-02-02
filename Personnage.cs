
/*classe qui represente les personnages du jeu*/
public class Character
{
    private string name;    //nom du perso 
    private int lifePoint;  //ses pv
    private int magicPoint;
    private int atk_stat;   //moy de ses atk
    private int def_stat;   //moy de ses def
    private int level;      //niveau d'exp
    private int posX, posY,pos;         //position dans la map
    private string representation;  //caractere Ascii sur la map
    private LinkedList<Attack> atk; //list de ces atk
    private LinkedList<Magic> magic;    //list de ses sort agic
    //private Element weeakness;
    //private Element strength;

    public Character()
    {
        this.name = "CharacterName";
        this.lifePoint = 0;
        this.magicPoint = 0;
        this.atk_stat = 0;
        this.def_stat = 0;
        this.level = 0;
        this.posX = 0;
        this.posY = 0;
        this.pos = 0;
        this.representation = "";
        atk = new LinkedList<Attack>();
        this.magic = new LinkedList<Magic>();
    }

    public Character(string p)
    {
        this.name = "CharacterName";
        this.lifePoint = 0;
        this.magicPoint = 0;
        this.atk_stat = 0;
        this.def_stat = 0;
        this.level = 0;
        this.posX = 0;
        this.posY = 0;
        this.pos = 0;
        this.representation = p;
        atk = new LinkedList<Attack>();
        this.magic = new LinkedList<Magic>();
    }

    public Character(string name, int lifePoint, int magicPoint, int atk_stat, int def_stat, int level, int posX, int posY, string r, LinkedList<Attack> atk, LinkedList<Magic> magic)
    {
        this.name = name;
        this.lifePoint = lifePoint;
        this.magicPoint = magicPoint;
        this.atk_stat = atk_stat;
        this.def_stat = def_stat;
        this.level = level;
        this.posX = posX;
        this.posY = posY;
        this.representation = r;
        this.atk = atk;
        this.magic = magic;
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
        this.magic = c.getMagic();
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

    public int getMagicPoint() { return magicPoint; }
    public int getAtkStat() { return atk_stat; }
    public int getDefStat() { return def_stat; }
    public int getLevel() { return level; }
    public int getPositionX() { return posX; }
    public int getPositionY() { return posY; }
    public int getPosition() { return pos; }    
    public void setPositionX(int x, MapGame m) {
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

    public void setPositionY(int y,MapGame m) {  
        if ((y < 0) || (y > m.getNbColonne())){
            Console.WriteLine("Erreur : position y invalide pour setPosition");
            Environment.Exit(1);
        }
        else
        {
            posY = y;
        }
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
        if ((newpos < 0) || (newpos >= ((m.getNbLigne()*m.getNbColonne())) - 1))
        {
            // this.pos = 0;
            //Console.WriteLine("Erreur : position x invalide setPosition");
            //Environment.Exit(1);

            /*efface la position ancienne et lui affecte le champ 'field' de la map*/
            m.changeCase(m.getField(), this.pos);
            /*ne bouge pas la position du perso*/
            newpos=this.pos ;
            /*Change une case de la map*/
            m.changeCase(representation,newpos);


        }
       
        else
        {
            /*efface la position ancienne et lui affecte le champ 'field' de la map*/
            m.changeCase(m.getField(),this.pos);
            /*bouge la position du perso*/
            this.pos = newpos;
            /*Change une case de la map*/
            m.changeCase(representation, newpos);
        }
    }

    /*PAS TRES FONCTIONNELLE*/
    public void move(int x,int y, MapGame m)
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

    public LinkedList<Attack> getAtk() { return atk; }
    public LinkedList<Magic> getMagic() { return magic; }

    public bool isAlive()
    {
        return lifePoint == 0;
    }
}