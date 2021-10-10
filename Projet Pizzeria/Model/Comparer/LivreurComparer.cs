using System;
using System.Collections.Generic;

namespace Projet_Pizzeria.Model.Comparer
{
    public class LivreurComparer : IEqualityComparer<Livreur>
    {
        public bool Equals(Livreur x, Livreur y)
        {
            //Check whether the compared objects reference the same data.
            if (ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (x is null || y is null)
                return false;

            //Check whether the products' properties are equal.
            return x.Nom == y.Nom && x.Prenom == y.Prenom;
        }

        public int GetHashCode(Livreur obj)
        {
            return HashCode.Combine(obj.Nom, obj.Prenom);
        }
    }
}