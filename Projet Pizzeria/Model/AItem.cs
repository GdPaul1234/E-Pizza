namespace Projet_Pizzeria.Model
{
    public abstract class AItem
    {
        public int Id { get; set; }

        public string Nom { get; set; }
        public double Prix { get; set; }
    }
}