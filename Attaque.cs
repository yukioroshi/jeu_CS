/*classe pour les attaques*/
public abstract class Attack
{
    private string name_atk;
    private int level_atk;
    private TypePerso type_perso_atk; //attack pour les guerrier, ou les voleur,ou les sorcier etc..

    public Attack()
    {
        name_atk = "";
        level_atk = 0;
        type_perso_atk = 0;
    }

    public Attack(string name, int level, TypePerso t)
    {
        name_atk = name;
        level_atk = level;
        type_perso_atk = t;
    }
    public string GetNameAtk()
    {
        return name_atk;
    }
    public TypePerso getTypePersoAtk() { return type_perso_atk; }
    public int degat() { return -1; }
    public abstract void effect_atk();
    public void LvlRequired(Character c)
    {
        //if(c.getLevel()<level_atk)
        //console.writeLine("niveau insuffisant")
        //else Attack tmp=this;
        //     c.addAtk(tmp)
    }
}