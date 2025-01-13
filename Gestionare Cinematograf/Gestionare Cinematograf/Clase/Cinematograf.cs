using System.Globalization;
using System.Runtime.CompilerServices;

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
public void AfisareIstoricRezervari()
     {
         if (Rezervari.Count == 0)
         {
             Console.WriteLine("Nu exista rezervari efectuate!");
         }
         Console.WriteLine("Istoric Rezervari:");
         foreach (var rezervare in Rezervari)
         {
             Console.WriteLine(rezervare);
             foreach (var rezervare in Rezervari)
             {
                 Console.WriteLine("Client:" + rezervare.Client.Nume + " " + rezervare.Client.Username);
                 Console.WriteLine("Film" + rezervare.Film.Titlu);
                 Console.WriteLine("Data Inceput: " + rezervare.Data_Inceput.ToShortDateString());
                 Console.WriteLine("Data final" + rezervare.Data_Final.ToShortDateString());
                 Console.WriteLine("Durata Rezervare" + rezervare.Durata_Rezervare + "de zile");
                 Console.WriteLine("Pret" + rezervare.Pret + "Ron");
             }
         }
     }

public void ModificareRezervare(Client client)
{
    if (client.Istoric_Rezervari == null)
    {
        Console.WriteLine("Nu exista rezervari efectuate!");
        return;
    }

    Console.WriteLine("Istoric Rezervari:");
    int contor = 1; //variabila care afiseaza numarul rezervarii pentru a putea clientul sa selecteze rezervarea
    foreach (var rezervare in istoric_Rezervari)
    {
        Console.WriteLine(
            contor + "Film:" + rezervare.Film.Titlu + " Durata: " + rezervare.Data_Inceput.ToShortDateString() "-" +
            rezervare.Data_Final.ToShortDateString());
        contor++;
    }

    Console.WriteLine("Selecteaza rezervarea pentru modificare:");
    int contor_client; //reprezinta variabila care tine minte numarul rezervarii selectate
    string alegere = Console.ReadLine();
    if (int.TryParse(alegere, out contor_client))
    {
        if (contor_client >= 0 && contor_client < Rezervari.Count)
        {
            Console.WriteLine("S-a selectat");

        }
        else
        {
            Console.WriteLine("Interval invalid");
        }
        else
    {
        Console.WriteLine("Optiune invalida");
    }
    }
    var rezervareNoua=RezervariClient[contor_client-1];

DataTime dataInceputNoua = DataTime.MinValue;
bool valid = false;
do
{Console.WriteLine("Introduce noua data de inceput:");
valid=DataTime.TryParse(Console.ReadLine(), out dataInceputNoua);
if (!valid)
{
    Console.WriteLine("Optiune invalida");
}
} while (!valid);

DataTime dataFinalNoua = DataTime.MaxValue;
bool valid2 = false;
do
{   Console.WriteLine("Introduce noua data de final:");
    valid=DataTime.TryParse(Console.ReadLine(), out dataFinalNoua);
    if (!valid2)
    {
        Console.WriteLine("Optiune invalida");
    }
} while (!valid);

}



