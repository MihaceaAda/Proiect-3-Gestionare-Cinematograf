using System.ComponentModel.Design;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Gestionare_Cinematograf.Clase;
public class Cinematograf
{
    public string Nume { get; set; }
    public string Adresa { get; set; }
    public List<Film> Program_filme { get; private set; } //lista filmelor disponibile(add de admin)
    public List<Client> Clienti { get; private set; }
    public List<Rezervare> Rezervari { get; private set; } //lista pentru rezervari totale
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

    public bool SuntAdministrator(string username, string password)
    {
        string usernameCorect = "admin";
        string passwordCorect = "1234";
        if (username == usernameCorect && password == passwordCorect)
        {
            return true;
        }
        else
        {
            Console.WriteLine("Numele de utilizator sau parola sunt incorecte!");
            return false;
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
    public Client InregistrareClient(string nume, string username)
    {
        var client = new Client(nume, username);
        Clienti.Add(client);
        return client;
    }
    public void AdaugareFilm()
    {
        Console.WriteLine("Introduceti titlul filmului: ");
        string titlu = Console.ReadLine();
        bool existaFilm = false;
        foreach (var film in Program_filme)
        {
            if (film.Titlu == titlu)
            {
                existaFilm = true;
                break;
            }
        }

        if (existaFilm)
        {
            Console.WriteLine("Filmul exista deja.\n");
            return;
        }

        Console.WriteLine("Introduceti regizorul filmului: ");
        string regizor = Console.ReadLine();
        Console.WriteLine("Introduceti genul filmului(Actiune/Drama)");
        string gen = Console.ReadLine();
        Console.WriteLine("Introduceti anul lansarii filmului: ");
        int an_lansare = int.Parse(Console.ReadLine());
        Console.WriteLine("Introduceti durata filmului(in minute)");
        int durata = int.Parse(Console.ReadLine());

        if (gen == "Drama")
        {
            Program_filme.Add(new Drama(titlu, regizor, gen, an_lansare, durata));
        }
        else if (gen == "Actiune")
        {
            Program_filme.Add(new Actiune(titlu, regizor, gen, an_lansare, durata));
        }

        Console.WriteLine("Film adaugat cu succes!");
    }
    public void StergereFilm()
    {
        Console.WriteLine("Introduceti titlul filmului pentru sters: ");
        string titlu = Console.ReadLine();
        Film film = null;

        foreach (var f in Program_filme)
        {
            if (f.Titlu == titlu)
            {
                film = f;
                break;
            }
        }
        if (film == null)
        {
            Console.WriteLine("Filmul nu exista!\n");
        }
        else
        {
            Program_filme.Remove(film);
            Console.WriteLine("Filmul a fost sters cu succes!\n");
        }
    }
    public void StergereClient()
    {
        Console.WriteLine("Introduceti numele clientului pentru sters: ");
        string username = Console.ReadLine();
        Client client = null;

        foreach (var c in Clienti)
        {
            if (c.Username == username)
            {
                client = c;
                break;
            }
        }
        if (client == null)
        {
            Console.WriteLine("Clientul nu exista!\n");
        }
        else
        {
            Clienti.Remove(client);
            Console.WriteLine("Clientul a fost sters cu succes!\n");
        }
    }
    public void VizualizareCastiguriTotale()
    {
        int total = 0;
        foreach (var rezervare in Rezervari)
        {
            total = total + rezervare.CalculPret();
        }
        Console.WriteLine("Castiguri totale: " + total + " Lei \n");
    }
    public void VizualizareFilmeDisponibile()
    {
        Console.WriteLine("Filme disponibile: ");
        foreach (var film in Program_filme)
        {
            if (film.Disponibilitate)
            {
                Console.WriteLine(film);
            }
            else
            {
                Console.WriteLine("Nu exista filme disponibile!\n");
            }
        }
    }

    public void CreeareRezervare(Client client)
    {

        if (client == null)
        {
            Console.WriteLine("Clientul nu a fost gasit!\n");
            return;
        }

        try
        {
            VizualizareFilmeDisponibile();

            Console.WriteLine("Introduceti filmul dorit: ");
            string titlu = Console.ReadLine();
            Film film = null;

            foreach (var f in Program_filme)
            {
                if (f.Titlu == titlu)
                {
                    film = f;
                    break;
                }
            }

            if (film == null || !film.Disponibilitate)
            {
                Console.WriteLine("Film indisponibil");
                return;
            }

            DateTime dataInceput, dataSfarsit;
            while (true)
            {
                try
                {
                    Console.WriteLine("Introduceti data de inceput (yyyy/mm/dd): ");
                    dataInceput = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Data introdusa este invalida");
                }
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("Introduceti data de sfarsit(yyyy/mm/dd): ");
                    dataSfarsit = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Data introdusa este invalida");
                }
            }


            int durataRezervare = (dataSfarsit - dataInceput).Days;
            if ((film.Gen == "Actiune" && durataRezervare > 3) || (film.Gen == "Drama" && durataRezervare > 7))
            {
                Console.WriteLine("S-a depasit limita permisa de rezervare!\n");
                return;
            }

            Rezervare rezervare = new Rezervare(client, film, dataInceput, dataSfarsit);
            Rezervari.Add(rezervare);
            client.AdaugaRezervare(rezervare.ToString());
            SalvareRezervareFisier(rezervare);
            Console.WriteLine("Rezervarea a fost facuta cu succes!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine("A aparut o eroare la introducerea datei");
        }
    }

    private void SalvareRezervareFisier(Rezervare rezervare)
    {
        File.AppendAllText(IstoricRezervari, rezervare.ToString() + "\n");
    }


    
    
    
    



   public void AfisareIstoricRezervari()
    {
        if (Rezervari.Count == 0)
        {
            Console.WriteLine("Nu exista rezervari efectuate!");
            return;
        }

        Console.WriteLine("Istoric Rezervari:");
        foreach (var rezervare in Rezervari)
        {
            Console.WriteLine("Client: " + rezervare.Client.Nume + " " + rezervare.Client.Username);
            Console.WriteLine("Film: " + rezervare.Film.Titlu);
            Console.WriteLine("Data Inceput: " + rezervare.Data_Inceput.ToShortDateString());
            Console.WriteLine("Data final: " + rezervare.Data_Final.ToShortDateString());
            Console.WriteLine("Durata Rezervare: " + rezervare.Durata_Rezervare + " de zile");
            Console.WriteLine("Pret: " + rezervare.Pret + " Ron");
        }
    }

    public void ModificareRezervare()
    {
        if (Rezervari.Count == 0)
        {
            Console.WriteLine("Nu exista rezervari efectuate!");
            return;
        }

        Console.WriteLine("Istoric Rezervari: ");
        int contor = 1; //variabila care afiseaza numarul rezervarii pentru a putea clientul sa selecteze rezervarea
        foreach (var rezervare in Rezervari)
        {
            Console.WriteLine(contor + " Film: " + rezervare.Film.Titlu + " Durata: " + rezervare.Data_Inceput.ToShortDateString() +
             " - " + rezervare.Data_Final.ToShortDateString());
            contor++;
        }
        
        Console.WriteLine("Selecteaza rezervarea pentru modificare: ");
        int contor_client; //reprezinta variabila care tine minte numarul rezervarii selectate
        string alegere = Console.ReadLine();
        if (!int.TryParse(alegere, out contor_client) || contor_client < 0 || contor_client > Rezervari.Count)
            {
                Console.WriteLine("Optiune invalida.");
                return;
            }
        
            if (contor_client == 0)
            {
                Console.WriteLine("Modificarea a fost anulata.");
                return;
            }

        var rezervareNoua = Rezervari[contor_client - 1];

        DateTime dataInceputNoua = DateTime.MinValue;
        bool valid = false;
        do
        {
            Console.WriteLine("Introduce noua data de inceput: (format: yyyy-MM-dd)");
            valid = DateTime.TryParse(Console.ReadLine(), out dataInceputNoua);
            if (!valid)
            {
                Console.WriteLine("Optiune invalida");
            }
        } while (!valid);

        DateTime dataFinalNoua = DateTime.MaxValue;
        bool valid2 = false;
        do
        {
            Console.WriteLine("Introduce noua data de final: (format: yyyy-MM-dd)");
            valid2 = DateTime.TryParse(Console.ReadLine(), out dataFinalNoua);
            if (!valid2)
            {
                Console.WriteLine("Optiune invalida");
            }
        } while (!valid2);
         rezervareNoua.Data_Inceput = dataInceputNoua;
         rezervareNoua.Data_Final = dataFinalNoua;
         Console.WriteLine("Rezervarea a fost modificata cu succes!");
    }


public void VizualizareCastiguriPeoPerioada()
    {
        if (Rezervari.Count == 0)
            {
                Console.WriteLine("Nu exista rezervari efectuate");
                return;
             }
        DateTime dataInceput;
        DateTime dataFinal;
        bool valid;
          
        do
             {  Console.WriteLine("Introduce data de inceput: (format: yyyy-MM-dd)");
                valid=DateTime.TryParse(Console.ReadLine(), out dataInceput);
                if(!valid)
                    {
                       Console.WriteLine("Data invalida.Te rugam sa incerci din nou.");
                    }
             }while(!valid);
        do {
              Console.WriteLine("Introduce data de final: (format: yyyy-MM-dd)");
              valid=DateTime.TryParse(Console.ReadLine(), out dataFinal);
              if (!valid)
                    {
                      Console.WriteLine("Data invalida. Te rugam sa incerci din nou.");
                    }
              }while(!valid);
          
          int castig=0;
          foreach ( var rezervare in Rezervari)
              {
                  if (rezervare.Data_Inceput>=dataInceput && rezervare.Data_Final<=dataFinal)
           {
                  castig=castig + rezervare.CalculPret();
               }
           }
                  Console.WriteLine("Castigurile totale intre datele: " + dataInceput.ToShortDateString() + " si " + dataFinal.ToShortDateString() + " sunt: " + castig + " de lei ");
                  
}


/*public void ModificareRezervareClient(Client client)
    {
        if (Rezervari.Count==0)
            {
                Console.WriteLine("Nu exista rezervari efectuate!");
                     return;
            }
        Console.WriteLine("Istoric rezervari:");
        int contor=1;
        foreach (var rezervare in client.Istoric_Rezervari)
            {
                Console.WriteLine(contor + "Film: "+ rezervare.Film.Titlu + " Durata: " + rezervare.Data_Inceput.ToShortDateString() + rezervare.Data_Final.ToShortDateString());
                contor++;
            }
        Console.WriteLine("Selecteaza numarul rezervarii pe care doresti sa o modifici.");
        if (!int.TryParse(Console.ReadLine(), out int optiune))
            {
                Console.WriteLine("Optiune Invalida");
                return;
            }
        var RezervareNoua=client.Istoric_Rezervari[optiune-1];
        
        DateTime dataInceputN;
        bool valid;
        do
           {
              Console.WriteLine("Introdu noua data de inceput (format (format: yyyy-MM-dd):");
              valid=DateTime.TryParse(Console.ReadLine(), out dataInceputN);
              if (!valid)
                  {
                      Console.WriteLine("Data invalida. Te rugam sa incerci din nou.");
                  }
           }while(!valid);
           
         DateTime dataFinalN;
         bool valid2;
         do
             {
                 Console.WriteLine("Introdu noua data de final (format (format: yyyy-MM-dd):");
                 valid2=DateTime.TryParse(Console.ReadLine(), out dataFinalN);
                 valid2=false;
             }while (!valid);
             
            RezervareNoua.Data_Inceput = dataInceputN;
            RezervareNoua.Data_Final = dataFinalN;

                      }*/
 

public void AnulareRezervare()
    {
        if(Rezervari.Count==0)
            {
                Console.WriteLine("Nu exista rezervari efectuate.");
                return;
             }
        Console.WriteLine("istoric rezervari:");
        int contor=1;
        
        foreach (var rezervare in Rezervari)
            {
                Console.WriteLine(contor + " " +  rezervare); 
                contor++;
            }
        Console.WriteLine("Selectează numărul rezervării pe care dorești să o anulezi:");
        if (!int.TryParse(Console.ReadLine(), out int optiune))
            {
                Console.WriteLine("Optiune Invalida");
                return;
            }
            
        Rezervari.RemoveAt(optiune-1);
        Console.WriteLine("Rezervarea a fost anulata cu succes!");
            }
    }