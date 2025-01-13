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

    public bool SuntAdministrator(string username)
    {
        return username == "admin";
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
    
    public Client InregistrareClient(string nume, string username)
    {
        var client= new Client(nume, username);
        Clienti.Add(client);
        return client;
    }

    public void AdaugareFilm()
    {
        Console.WriteLine("Introduceti titlul filmului: ");
        string titlu = Console.ReadLine();
        ///


        Console.WriteLine("Introduceti regizorul filmului: ");
        string regizor = Console.ReadLine();
        Console.WriteLine("Introduceti genul filmului(Actiune/Drama");
        string gen=Console.ReadLine();
        Console.WriteLine("Introduceti anul lansarii filmului: ");
        string an_lansare = Console.ReadLine();
        Console.WriteLine("Introduceti durata filmului(in minute)");
        string durata = Console.ReadLine();
        
        Program_filme.Add(new Film(titlu, regizor, gen, an_lansare, durata));
        Console.WriteLine("Film adaugat cu succes!");
    }

    public void AfisareFilmeDisponibile()
    {
        //
    }

    public void CreeareRezervare(Client client)
    {
        AfisareFilmeDisponibile();

        Console.WriteLine("");
    }
    
    
}