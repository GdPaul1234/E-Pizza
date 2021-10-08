namespace Projet_Pizzeria.Model
{
    public class Pizza : AItem
    {
        public string Taille { get; set; }
        public string Type { get; set; }

        public override string ToString() => $"{base.ToString()}: {Type} ({Taille})";
    }
}