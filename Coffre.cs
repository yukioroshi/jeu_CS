/*des objets dedans, une position dans la map et d'autres... */
public class Coffre
{
    string id_coffre;
    LinkedList<Objet> objCoffre;
    private int pos;

    public Coffre()
    {
        id_coffre = "";
        objCoffre = new LinkedList<Objet>();
        pos = 0;
    }
    public Coffre(string coffre, LinkedList<Objet> obj)
    {
        id_coffre = coffre;
        objCoffre = obj;
        pos = 0;
    }
    public Coffre(Coffre c)
    {
        id_coffre = c.getIdCoffre();
        objCoffre = c.getObjCoffre();
    }

    public string getIdCoffre() { return id_coffre; }
    public LinkedList<Objet> getObjCoffre() { return objCoffre; }
    public int getPos() { return pos; }
    public void setPos(int pos,MapGame m) {
        if (pos < 0 || pos > m.size())
        {
            Console.WriteLine("Erreur: position coffre dans setPos");
            Environment.Exit(1);
        }
        else
        {
            this.pos = pos;
            m.changeCase(" C ", this.pos);
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

        m.changeCase(" C ", pos);
    }

    public void addObjet(Objet obj) { this.objCoffre.AddFirst(obj); }

}