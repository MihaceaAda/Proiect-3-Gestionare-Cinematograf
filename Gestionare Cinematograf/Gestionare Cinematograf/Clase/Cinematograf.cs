namespace Gestionare_Cinematograf.Clase;

public class Cinematograf
{
    public string Nume { get; set; }
    public string Adresa { get; set; }
    public List<Film>Program_filme { get; private set; }
    public List<Client>Clienti { get; private set; }
    public List<Rezervare>Rezervari{get; private set;}
    private const string IstoricRezervari = "IstoricRezervari.txt";

    public Cinematograf(string nume, string adresa)
    {
        Nume = nume;
        Adresa = adresa;
        Program_filme = new List<Film>();
        Clienti = new List<Client>();
        Rezervari = new List<Rezervare>();
        
        if (!File.Exists(IstoricRezervari))
        {
            File.Create(IstoricRezervari).Dispose();
        }
    }

    public Client AutentificareClient(string username)
    {
        foreach (var client in Clienti)
        {
            if (client.Username == username)
            {
                return client;
            }
        }
        return null;
    }
    
    
    
    
}