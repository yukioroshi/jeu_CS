/*classe pour les objets*/
public abstract class Objet
{
    private string name;

    public Objet()
    {
        name = "";
    }

    public Objet(string name)
    {
        this.name = name;
    }

    public string getNameObj() { return name; }
    public abstract void effect();
    public string toString() { return "objet:"+name; }
}