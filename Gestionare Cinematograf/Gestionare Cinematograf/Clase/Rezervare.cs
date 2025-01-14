namespace Gestionare_Cinematograf.Clase
{
    public class Rezervare
    {
        public Client Client { get; set; }
        public Film Film { get; set; }
        public DateTime Data_Inceput { get; set; }
        public DateTime Data_Final { get; set; }
        public int Durata_Rezervare { get; set; }
        public double Pret { get; private set; }
       

        public Rezervare(Client client, Film film, DateTime data_Inceput, DateTime data_Final)
        {
            Client = client;
            Film = film;
            Data_Inceput = data_Inceput;
            Data_Final = data_Final;
            
            Durata_Rezervare = (int)(Data_Final - Data_Inceput).TotalDays;
            Pret = CalculPret();
            
        }
        public int CalculPret()
        {
            return 50 * Durata_Rezervare; 
        }


        public override string ToString()
        {
            return $"Rezervare pentru clientul: {Client.Nume} {Client.Username}" +
                   $"\nFilm: {Film.Titlu}" +
                   $"\nData început: {Data_Inceput:dd.MM.yyyy}" +
                   $"\nData final: {Data_Final:dd.MM.yyyy}" +
                   $"\nDurata rezervării: {Durata_Rezervare} zile" +
                   $"\nPreț total: {Pret} RON";
        }



    }
}
