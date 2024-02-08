/*classe pour les objets*/
public class Objet
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
    public void effect() { return; }
    public string toString() { return "objet:"+name; }
}