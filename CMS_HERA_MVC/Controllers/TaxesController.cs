using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMS_HERA_MVC.Data;
using CMS_HERA_MVC.Models;
using CMS_HERA_MVC.Interfaces;

namespace CMS_HERA_MVC.Controllers
{
    public class TaxesController : Controller
    {
       
        private readonly ITaxesRepository _taxeRepository;
        public TaxesController(ITaxesRepository taxeRepository)
        {
            _taxeRepository = taxeRepository;
        }

        // GET: Taxes
        public async Task<IActionResult> Index(
            
            string searchString,
            string currentFilter,
            int? pageNumber
            )
        {
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            
            IEnumerable<Taxe> taxes = _taxeRepository.GetTaxes(searchString);
            int pageSize = 2;
            return View(await PaginatedList<Taxe>.CreateAsync((IQueryable<Taxe>)taxes, pageNumber ?? 1, pageSize));
            
        }

        // GET: Taxes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Taxe taxe = _taxeRepository.GetTaxeById((int)id);
            if (taxe == null)
            {
                return NotFound();
            }

            return View(taxe);
        }

        // GET: Taxes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Taxes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom_Taxe,Valeur_Taxe,Status_Taxe,Taxe_Col")] Taxe taxe)
        {
            if (ModelState.IsValid)
            {
                _taxeRepository.AddTaxe(taxe);
                return RedirectToAction(nameof(Index));
            }
            return View(taxe);
        }

        // GET: Taxes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Taxe taxe = _taxeRepository.GetTaxeById((int)id);
            if (taxe == null)
            {
                return NotFound();
            }
            return View(taxe);
        }

        // POST: Taxes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom_Taxe,Valeur_Taxe,Status_Taxe,Taxe_Col")] Taxe taxe)
        {
            if (id != taxe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _taxeRepository.UpdateTaxe(taxe);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxeExists(taxe.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(taxe);
        }

        // GET: Taxes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Taxe taxe = _taxeRepository.GetTaxeById((int)id);

            if (taxe == null)
            {
                return NotFound();
            }

            return View(taxe);
        }

        // POST: Taxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Taxe taxe = _taxeRepository.GetTaxeById((int)id);
            _taxeRepository.DeleteTaxe(taxe);

            return RedirectToAction(nameof(Index));
        }

        private bool TaxeExists(int id)
        {
            return _taxeRepository.TaxeExists(id);
        }
    }
}
