/*classe pour les npc*/
public class Npc
{

    private string name_npc;
    private string dialogue;
    private int pos;

    public Npc()
    {
        name_npc = ""; dialogue = "";pos=0 ;
    }

    public Npc(string name, string dialogue="")
    {
        this.name_npc = name; ;
        this.dialogue = dialogue;
        pos = 0;
    }


    public string getNameNpc() { return name_npc; }
    public string getDialogue() { return dialogue; }
    public int getPosition() { return pos; }

    public void setNameNpc(string n) { name_npc=n; }
    public void setDialogue(string d) { dialogue=d; }
    public void setPosition(int p,MapGame m) { 
        if(p<0 || p > m.size())
        {
            Console.WriteLine("Erreur: poisition NPC dans setposition\n");
            Environment.Exit(1);
        }
        else
        {
            pos = p;
            m.changeCase(" N ", pos);
        }

    }

    public void setRandomPosition(MapGame m)
    {
        Random random = new Random();
        do
        {
            pos = random.Next(m.size());
            if (m.getCase(pos) == m.getField())
            {
                break;
            }
        } while (m.getCase(pos) != m.getField());

        m.changeCase(" N ", pos);
    }


}