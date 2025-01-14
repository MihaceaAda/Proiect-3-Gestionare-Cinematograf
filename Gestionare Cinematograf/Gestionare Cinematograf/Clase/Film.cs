namespace Gestionare_Cinematograf.Clase;

public abstract class Film
{
    public string Titlu { get; set; }
    protected string Regizor { get; set; }
    public string Gen { get; set; }
    protected int An_lansare  { get; set; }
    protected int Durata { get; set; }

    public bool Disponibilitate { get; set; }

    public Film(string titlu, string regizor, string gen, int an_lansare, int durata)
    {
        Titlu = titlu;
        Regizor = regizor;
        Gen = gen;
        An_lansare = an_lansare;
        Durata = durata;
        Disponibilitate = true;
    }

    public override string ToString()
    {
        return Titlu + " " + Regizor + " " + Gen + " " + An_lansare + " " + Durata+" "+ Disponibilitate;
    }
}