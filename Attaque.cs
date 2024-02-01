/*classe pour les attaques*/
public abstract class Competence
{
    private string name_comp;
    private int level_comp;
    private TypePerso type_perso_comp; //attack pour les guerrier, ou les voleur,ou les sorcier etc..

    public Compentence()
    {
        name_comp = "";
        level_comp = 0;
        type_perso_comp = 0;
    }

    public Competence(string name,int level, TypePerso t)
    {
        name_comp = name;
        level_comp = level;
        type_perso_comp = t;
    }
    public string GetNameCompetence()
    {
        return name_comp;
    }
    public TypePerso getTypePersoComp() { return type_perso_comp; }       
    public int degat() { return -1; }
    public abstract void effectCompetence();
    public void LvlRequired(Character c) {
        if (c.getLevel() < level_atk)
            console.writeLine("niveau insuffisant");
        else
        {
            Attack tmp = this;
            c.addAtk(tmp);
        }

}