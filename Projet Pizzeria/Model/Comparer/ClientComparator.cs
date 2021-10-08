using System;
using System.Collections.Generic;

namespace Projet_Pizzeria.Model.Comparer
{
    // Enumerable.Except Méthode Exemples
    // https://docs.microsoft.com/fr-fr/dotnet/api/system.linq.enumerable.except

    public class ClientComparer : IEqualityComparer<Client>
    {
        public bool Equals(Client x, Client y)
        {
            //Check whether the compared objects reference the same data.
            if (ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (x is null || y is null)
                return false;

            //Check whether the products' properties are equal.
            return x.Nom == y.Nom && x.Prenom == y.Prenom;
        }

        public int GetHashCode(Client obj)
        {
            return HashCode.Combine(obj.Nom, obj.Prenom);
        }
    }
}
