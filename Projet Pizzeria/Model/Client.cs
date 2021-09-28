
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Client {

    public Client() {
    }

    public long NoClient { get; set; };
    public string Nom { get; set; };
    public string Prenom { get; set; };
    public string NoTelephone { get; set; };
    public Date DatePremiereCommande { get; set; };

    public HashSet<Commande> Commandes { get; set; };



    private Adresse Adresse;

    /// <summary>
    /// @return
    /// </summary>
    public Commande CreerNouvelleCommande() {
        // TODO implement here
        return null;
    }

    /// <summary>
    /// @return
    /// </summary>
    public int GetNbCommandes() {
        // TODO implement here
        return 0;
    }

}