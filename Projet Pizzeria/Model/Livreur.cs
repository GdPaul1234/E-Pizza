using System.ComponentModel.DataAnnotations;

namespace Projet_Pizzeria.Model
{
    public class Livreur
    {
        [Key]
        public long NoLivreur { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }

        public int NbLivraisonEffectue { get; set; }

        public void LivrerCommande()
        {
            // TODO implement here
        }
    }
}