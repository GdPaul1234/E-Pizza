namespace Projet_Pizzeria.Model
{
    public class Boisson : AItem
    {
        public double Volume { get; set; }

        public override string ToString() => $"{base.ToString()} ({Volume} L)";

    }
}