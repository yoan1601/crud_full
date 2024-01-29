using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crud_full.Data;
using crud_full.Models;

namespace crud_full.Controllers
{
    public class EmployesController : Controller
    {
        private readonly crud_fullContext _context;

        public EmployesController(crud_fullContext context)
        {
            _context = context;
        }

        // GET: Employes
        public async Task<IActionResult> Index()
        {
              return _context.Employe != null ? 
                          View(await _context.Employe.ToListAsync()) :
                          Problem("Entity set 'crud_fullContext.Employe'  is null.");
        }

        // GET: Employes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employe == null)
            {
                return NotFound();
            }

            var employe = await _context.Employe
                .FirstOrDefaultAsync(m => m.idemploye == id);
            if (employe == null)
            {
                return NotFound();
            }

            Console.WriteLine(">>>>>>>>>>>> emp detail");

            return View(employe);
        }

        // GET: Employes/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> CreateNew(string nom, string datenaissance) {

                Employe employe = new Employe();
                employe.nom = nom;
                employe.datenaissance = DateTime.SpecifyKind(DateTime.Parse(datenaissance), DateTimeKind.Utc);
                _context.Add(employe);
                Console.WriteLine(">>>>>>>>>>>> emp inserted");
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

        }

        // GET: Employes/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employe == null)
            {
                return NotFound();
            }

            var employe = await _context.Employe.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }
            return View(employe);
        }

        // POST: Employes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> EditYou(string idemploye, string nom, string datenaissance)
        {
            Employe employe = new Employe();
            employe.idemploye = int.Parse(idemploye);
            employe.nom = nom;
            employe.datenaissance = DateTime.SpecifyKind(DateTime.Parse(datenaissance), DateTimeKind.Utc);

                try
                {
                    _context.Update(employe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeExists(employe.idemploye))
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

        // GET: Employes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employe == null)
            {
                return NotFound();
            }

            var employe = await _context.Employe
                .FirstOrDefaultAsync(m => m.idemploye == id);
            if (employe == null)
            {
                return NotFound();
            }

            return View(employe);
        }

        // POST: Employes/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employe == null)
            {
                return Problem("Entity set 'crud_fullContext.Employe'  is null.");
            }
            var employe = await _context.Employe.FindAsync(id);
            if (employe != null)
            {
                _context.Employe.Remove(employe);
            }

            Console.WriteLine(">>>>>>>>>>>> emp deleted");
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeExists(int id)
        {
          return (_context.Employe?.Any(e => e.idemploye == id)).GetValueOrDefault();
        }
    }
}
