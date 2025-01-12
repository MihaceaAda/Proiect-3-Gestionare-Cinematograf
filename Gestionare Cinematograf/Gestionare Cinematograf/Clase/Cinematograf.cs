namespace Gestionare_Cinematograf.Clase;

public class Cinematograf
{
    public string Nume { get; set; }
    public string Adresa { get; set; }
    public List<string>Program_filme { get; set; }

    public Cinematograf(string nume, string adresa)
    {
        Nume = nume;
        Adresa = adresa;
        Program_filme = new List<string>();
    }
    
    
    
    
}