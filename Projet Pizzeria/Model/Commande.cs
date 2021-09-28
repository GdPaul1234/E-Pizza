
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Commande {

    public Commande() {
    }

    private long NumeroCommande;

    private Date DateHeureCommande;

    private string EtatCommande;

    private double MontantTotal;


    private Commis Commis;

    private HashSet<AItem> Items;

    /// <summary>
    /// @param p
    /// </summary>
    public void Add(IProduit p) {
        // TODO implement here
    }

    /// <summary>
    /// @param p
    /// </summary>
    public void Del(IProduit p) {
        // TODO implement here
    }

    /// <summary>
    /// @return
    /// </summary>
    public List<IProduit> Get() {
        // TODO implement here
        return null;
    }

}