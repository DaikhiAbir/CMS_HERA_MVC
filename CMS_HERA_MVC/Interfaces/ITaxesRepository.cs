using CMS_HERA_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_HERA_MVC.Interfaces
{
    public interface ITaxesRepository
    {
        IEnumerable<Taxe> GetTaxes(string searchString);
        Taxe GetTaxeById(int id);
        IEnumerable<Taxe> GetTaxeByName(string name);
        IEnumerable<Taxe> GetTaxeByValeur(int valeur);
        IEnumerable<Taxe> GetTaxeByStatus(int status);
        void AddTaxe(Taxe t);
        void UpdateTaxe(Taxe t);
        void DeleteTaxe(Taxe t);
        bool TaxeExists(int id);
    }
}
