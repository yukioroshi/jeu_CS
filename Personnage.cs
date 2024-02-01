
/*classe qui represente les personnages du jeu*/
public class Character
{
    private string name;    //nom du perso 
    private int lifePoint;  //ses pv
    private int magicPoint;
    private int atk_stat;   //moy de ses atk
    private int def_stat;   //moy de ses def
    private int level;      //niveau d'exp
    int posX, posY;         //position dans la map
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
        atk = new LinkedList<Attack>();
        this.magic = new LinkedList<Magic>();
    }

    public Character(string name, int lifePoint, int magicPoint, int atk_stat, int def_stat, int level, int posX, int posY, LinkedList<Attack> atk, LinkedList<Magic> magic)
    {
        this.name = name;
        this.lifePoint = lifePoint;
        this.magicPoint = magicPoint;
        this.atk_stat = atk_stat;
        this.def_stat = def_stat;
        this.level = level;
        this.posX = posX;
        this.posY = posY;
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
    }

    public string getName()
    {
        return name;
    }
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
    public LinkedList<Attack> getAtk() { return atk; }
    public LinkedList<Magic> getMagic() { return magic; }

    public bool isAlive()
    {
        return lifePoint == 0;
    }
}