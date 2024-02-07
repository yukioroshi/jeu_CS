public class Coup : Competence
{
    public Coup() :base() { }

    public Coup(string name, int level, int p, TypePerso t):base(name, level, p, t) { }

    public override void effectCompetence()
    {
        setPuissance(getPuissance()+10);
    }

}