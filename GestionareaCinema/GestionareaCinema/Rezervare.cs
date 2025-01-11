namespace GestionareaCinema;

class Rezervare
{
    public Client Client { get; set; }
    public Film Film { get; set; }
    public DateTime DataInceput { get; set; }
    public DateTime DataFinal { get; set; }
    public int Durata => (DataFinal - DataInceput).Days;
}
