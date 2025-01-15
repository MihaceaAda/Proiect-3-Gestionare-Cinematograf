using Gestionare_Cinematograf.Clase;

namespace Gestionare_Cinematograf;

class Program
{
    static void Main(string[] args)
    {
        Cinematograf cinema = new Cinematograf("CineTim", "Strada Lalelelor 13");
        Console.WriteLine("Bine ati venit la "+cinema.Nume);

        while (true)
        {
            Console.WriteLine("1.Autentificare/Inregistrare");
            Console.WriteLine("0.Iesire");
            Console.WriteLine("Alegeti optiunea dorita: ");
            string optiune1 = Console.ReadLine();
            

            switch (optiune1)
            {
                case "1":
                    Console.WriteLine("1.Administrator");
                    Console.WriteLine("2.Client");
                    Console.WriteLine("0.Inapoi");
                    Console.WriteLine("Alegeti optiunea dorita: ");
                    string optiune2 = Console.ReadLine();
                    switch (optiune2)
                    {
                        case "1":
                            MeniuAdmin(cinema);
                            break;
                        case "2":
                            MeniuClient(cinema);
                            break;
                        case "3":
                            return;
                        default:
                            Console.WriteLine("Alegeti o optiune valida!");
                            Console.ReadKey();
                            break;
                    }
                    break;
                
                case "0":
                    return;
                default:
                    Console.WriteLine("Optiune invalida. Alegeti una din optiunile disponibile");
                    Console.ReadKey();
                    break;
            }
            
            
            
        }
    }

   private static void MeniuAdmin(Cinematograf cinema)
    {
        
        Console.WriteLine("Introduceti numele de utilizator: ");
        string username = Console.ReadLine();
        Console.WriteLine("Introduceti parola: ");
        string password = Console.ReadLine();

        if (!cinema.SuntAdministrator(username, password))
        {
            Console.WriteLine("Doar administratorul are permisiunea de a face modificari!");
            return;
        }

        while (true)
        {
            Console.WriteLine("Meniu administrator: ");
            Console.WriteLine("1.Adaugare film");
            Console.WriteLine("2.Stergere film");
            Console.WriteLine("3.Modificare interval rezervare film");
            Console.WriteLine("4.Stergere client");
            Console.WriteLine("5.Vizualizare istoric inchirieri filme");
            Console.WriteLine("6.Vizualizare istoric inchirieri filme per client");
            Console.WriteLine("7.Vizualizare castiguri totale");
            Console.WriteLine("8.Vizualizare castiguri pentru o anumita perioada");
            Console.WriteLine("0.Inapoi");
            Console.WriteLine("Alegeti optiunea dorita: ");
            string optiune=Console.ReadLine();

            switch (optiune)
            {
                case "1":
                    cinema.AdaugareFilm();
                    break;
                case "2":
                    cinema.StergereFilm();
                    break;
                case "3":
                    cinema.ModificareRezervare();
                    break;
                case "4":
                    cinema.StergereClient();
                    break;
                case "5": Console.WriteLine("Vizualizare castiguri totale");
                   cinema.AfisareIstoricRezervari();
                    break;
                case "6":
                    
                    break;
                case "7":
                    cinema.VizualizareCastiguriTotale();
                    break;
                case "8":
                    cinema.VizualizareCastiguriPeoPerioada();
                    
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Optiune invalida. Alegeti o optiune disponibila!");
                    Console.ReadKey();
                    break;
            }
            
        }
        
    }

    private static void MeniuClient(Cinematograf cinema)
    {
        
        Console.WriteLine("Introduceti numele de utilizator: ");
        string username = Console.ReadLine();

        Client client = cinema.AutentificareClient(username);
        if (client == null)
        {
            Console.Clear();
            Console.WriteLine("Utilizatorul nu exista. Doriti sa va inregistrati?(Da/Nu)");
            string raspuns=Console.ReadLine();
            if (raspuns == "Da")
            {
                Console.WriteLine("Introduceti numele complet: ");
                string nume=Console.ReadLine();
                client=cinema.InregistrareClient(nume,username);
                Console.WriteLine("Cont creat!");
            }
            else
            {
                return;
            }
        }

        while (true)
        {
            Console.WriteLine("1.Vizualizare filme disponibile pentru inchiriat");
            Console.WriteLine("2.Creeare rezervare");
            Console.WriteLine("3.Modificare rezervare");
            Console.WriteLine("4.Anulare rezervare");
            Console.WriteLine("0.Iesire");
            string optiune=Console.ReadLine();

            switch (optiune)
            {
                case "1":
                    cinema.VizualizareFilmeDisponibile();
                    break;
                case "2":
                    cinema.CreeareRezervare(client);
                    break;
                case "3":
                    
                    break;
                case "4":
                    
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Optiune invalida. Alegeti o optiune disponibila!");
                    Console.ReadKey();
                    break;
            }
            
            
        }


    }
   
    
    
    
    
}