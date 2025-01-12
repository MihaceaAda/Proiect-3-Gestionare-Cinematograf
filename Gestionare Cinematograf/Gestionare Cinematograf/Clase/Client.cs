namespace Gestionare_Cinematograf.Clase;

public class Client
{
    public string Nume { get; set; }
    public string Username { get; set; }
    public List<string>Istoric_Rezervari{ get; set; }

    public Client(string nume, string username)
    {
        Nume = nume;
        Username = username;
        Istoric_Rezervari = new List<string>();
    }
    
    
    
    
}