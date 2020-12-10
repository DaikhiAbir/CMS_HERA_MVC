using CMS_HERA_MVC.Data;
using CMS_HERA_MVC.Interfaces;
using CMS_HERA_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_HERA_MVC.Repository
{
    public class TaxeRepository : ITaxesRepository
    {
        private readonly DataContext _context;

        public TaxeRepository(DataContext context)
        {
            _context = context;
        }

        void ITaxesRepository.AddTaxe(Taxe t)
        {
            _context.Add(t);
            _context.SaveChangesAsync();
        }

        void ITaxesRepository.DeleteTaxe(Taxe t)
        {
            _context.Taxes.Remove(t);
        }

        Taxe ITaxesRepository.GetTaxeById(int id)
        {

            return  _context.Taxes
                .FirstOrDefault(m => m.Id == id); 
        }

        IEnumerable<Taxe> ITaxesRepository.GetTaxeByName(string name)
        {
            var taxes = from s in _context.Taxes
                        select s;
            taxes = taxes.Where(s => s.Nom_Taxe.Contains(name));
            
            return taxes;
        }

        IEnumerable<Taxe> ITaxesRepository.GetTaxeByStatus(int status)
        {
            return (IEnumerable<Taxe>)_context.Taxes
                .FirstOrDefault(m => m.Status_Taxe == status);
        }

        IEnumerable<Taxe> ITaxesRepository.GetTaxeByValeur(int valeur)
        {
            return (IEnumerable<Taxe>)_context.Taxes
                .FirstOrDefault(m => m.Valeur_Taxe == valeur);
        }

        IEnumerable<Taxe> ITaxesRepository.GetTaxes(string searchString)
        {
            var taxes = from s in _context.Taxes
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                taxes = taxes.Where(s => s.Nom_Taxe.Contains(searchString)
                                       || s.Valeur_Taxe.ToString().Contains(searchString)
                                       || s.Status_Taxe.ToString().Contains(searchString));
            }
            
            return taxes;
            
        }

        void ITaxesRepository.UpdateTaxe(Taxe t)
        {
            _context.Update(t);
            _context.SaveChangesAsync();
        }

        public bool TaxeExists(int id)
        {
            return _context.Taxes.Any(e => e.Id == id);
        }
    }
}
