namespace Gestionare_Cinematograf.Clase;

public class Client
{
    public string Nume { get; set; }
    public string Username { get; set; }
    public List<string>Istoric_Rezervari{ get; set; }  //lista pt rezervari per client

    public Client(string nume, string username)
    {
        Nume = nume;
        Username = username;
        Istoric_Rezervari = new List<string>();
    }
    public void AdaugaRezervare(string detaliiRezervare)
    {
        Istoric_Rezervari.Add(detaliiRezervare);
    }
    
    public override string ToString()
    {
        return Nume+ " " + Username + " " + Istoric_Rezervari;
    }
    
    
}