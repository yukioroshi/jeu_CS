/*classe pour les attaques*/
public abstract class Competence
{
    private string name_comp;
    private int level_comp;
    private int puissance;
    private TypePerso type_perso_comp; //attack pour les guerrier, ou les voleur,ou les sorcier etc..

    public Competence()
    {
        name_comp = "";
        level_comp = 0;
        puissance = 0;
        type_perso_comp = 0;
    }

    public Competence(string name, int level,int p, TypePerso t)
    {
        name_comp = name;
        level_comp = level;
        puissance=p;
        type_perso_comp = t;
    }
    public string GetNameCompetence()
    {
        return name_comp;
    }

    public int GetLevelComp() { return level_comp; }
    public TypePerso getTypePersoComp() { return type_perso_comp; }
    public int getPuissance() { return puissance; }
    public int getTypePersoComp_Int() { return ((int)type_perso_comp); }
    public void setLevelComp(int lvl)
    {
        level_comp = lvl;
    }
    public void setTypePerso(int i)
    {
        TypePerso t = TypePerso.Android;
        switch (i)
        {
            case 0: type_perso_comp=TypePerso.Guerrier; break;
            case 1: type_perso_comp= TypePerso.Sorcier; break;
            case 3: type_perso_comp= TypePerso.Archer; break;
            case 4: type_perso_comp= TypePerso.Voleur; break;
            case 5: type_perso_comp= TypePerso.Roi_Demon; break;
            default:
                 type_perso_comp = TypePerso.Guerrier; break;

        }
    }

    public void setPuissance(int i) { puissance = i; }

    public string toString()
    {
        string res = "";
        res += name_comp + "\n" + level_comp + "\npuissance" + "\ntypeInt" + ((int)type_perso_comp);
        return res;
    }
    public int degat() { return 0; }
    public abstract void effectCompetence();
    public void LvlRequired(Character c)
    {
        if (c.getLevel() < level_comp)
            Console.WriteLine("niveau insuffisant");
        else
        {
            Competence tmp = this;
            c.addAtk(tmp);
        }
    }

}
