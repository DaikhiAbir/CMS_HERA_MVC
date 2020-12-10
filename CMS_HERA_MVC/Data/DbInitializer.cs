using CMS_HERA_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_HERA_MVC.Data
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Taxes.Any())
            {
                return;   // DB has been seeded
            }

            var taxes = new Taxe[]
            {
            new Taxe{Nom_Taxe="taxe1",Valeur_Taxe=1,Status_Taxe=1, Taxe_Col="taxe1"},
            new Taxe{Nom_Taxe="taxe2",Valeur_Taxe=1,Status_Taxe=1, Taxe_Col="taxe2"},
            new Taxe{Nom_Taxe="taxe3",Valeur_Taxe=1,Status_Taxe=1, Taxe_Col="taxe3"}
            };
            foreach (Taxe s in taxes)
            {
                context.Taxes.Add(s);
            }
            context.SaveChanges();
    }
}
}
