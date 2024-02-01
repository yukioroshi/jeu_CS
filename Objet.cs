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
    public void effect() { }
}