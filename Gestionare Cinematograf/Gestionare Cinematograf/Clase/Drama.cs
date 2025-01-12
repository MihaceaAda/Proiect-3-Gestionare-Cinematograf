namespace Gestionare_Cinematograf.Clase;

public class Drama:Film
{
    public Drama(string titlu, string regizor, string gen, int an_lansare, int durata, int interval) : base(titlu, regizor, gen,
        an_lansare, durata, interval) { }
    public override void Validare_Interval()
    {
        if (Interval>7)  
            throw new ArgumentException("Rezervarea nu se poate face pentru mai mult de 7 zile!");
    }
}