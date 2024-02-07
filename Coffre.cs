/*des objets dedans, une position dans la map et d'autres... */
public class Coffre
{
    string id_coffre;
    LinkedList<Objet> objCoffre;

    public Coffre()
    {
        id_coffre = "";
        objCoffre = new LinkedList<Objet>();
    }
    public Coffre(string coffre, LinkedList<Objet> obj)
    {
        id_coffre = coffre;
        objCoffre = obj;
    }
    public Coffre(Coffre c)
    {
        id_coffre = c.getIdCoffre();
        objCoffre = c.getObjCoffre();
    }

    public string getIdCoffre() { return id_coffre; }
    public LinkedList<Objet> getObjCoffre() { return objCoffre; }
    
    public void addObjet(Objet obj) { this.objCoffre.AddFirst(obj); }

}