namespace Projet_Pizzeria.Model
{
    public class Adresse
    {
        public int AdresseId { get; set; }

        public string Rue { get; set; }
        public string Ville { get; set; }
        public string Cp { get; set; }

        public override string ToString()
        {
            return $"{Rue} {Cp} {Ville}";
        }
    }
}