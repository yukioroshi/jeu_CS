
public abstract class Magic
{

    private string spell_name;
    private int level_spell;

    public Magic()
    {
        spell_name = "";
        level_spell = 0;
    }
    public Magic(string spell_name)
    {
        this.spell_name = spell_name;
    }

    public string getSpellName()
    {
        return spell_name;
    }

    public abstract void spellEffect();

    public void LvlRequired(Character c)
    {
        //if(c.getLevel()<level_atk)
        //console.writeLine("niveau insuffisant")
        //else Attack tmp=this;
        //     c.addAtk(tmp)
    }

}