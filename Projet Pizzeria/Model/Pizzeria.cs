
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Pizzeria : IImportExportEffectif {

    public Pizzeria() {
    }

    private String Nom;

    private HashSet<Client> ListClient;

    private HashSet<Commis> ListCommis;

    private HashSet<Livreur> ListLivreur;

}