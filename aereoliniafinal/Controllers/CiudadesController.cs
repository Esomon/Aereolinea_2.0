using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aereoliniafinal.Models;

namespace aereoliniafinal.Controllers
{
    public class CiudadesController : Controller
    {
        private readonly MyDbContext _context;

        public CiudadesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Ciudades
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Ciudades.Include(c => c.Pais);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Ciudades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudades = await _context.Ciudades
                .Include(c => c.Pais)
                .FirstOrDefaultAsync(m => m.CiudadesID == id);
            if (ciudades == null)
            {
                return NotFound();
            }

            return View(ciudades);
        }

        // GET: Ciudades/Create
        public IActionResult Create()
        {
            ViewData["PaisID"] = new SelectList(_context.Pais, "PaisID", "Nombre");
            return View();
        }

        // POST: Ciudades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CiudadesID,Nombre,PaisID")] Ciudades ciudades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ciudades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaisID"] = new SelectList(_context.Pais, "PaisID", "Nombre", ciudades.PaisID);
            return View(ciudades);
        }

        // GET: Ciudades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudades = await _context.Ciudades.FindAsync(id);
            if (ciudades == null)
            {
                return NotFound();
            }
            ViewData["PaisID"] = new SelectList(_context.Pais, "PaisID", "Nombre", ciudades.PaisID);
            return View(ciudades);
        }

        // POST: Ciudades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CiudadesID,Nombre,PaisID")] Ciudades ciudades)
        {
            if (id != ciudades.CiudadesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ciudades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CiudadesExists(ciudades.CiudadesID))
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
            ViewData["PaisID"] = new SelectList(_context.Pais, "PaisID", "Nombre", ciudades.PaisID);
            return View(ciudades);
        }

        // GET: Ciudades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudades = await _context.Ciudades
                .Include(c => c.Pais)
                .FirstOrDefaultAsync(m => m.CiudadesID == id);
            if (ciudades == null)
            {
                return NotFound();
            }

            return View(ciudades);
        }

        // POST: Ciudades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ciudades = await _context.Ciudades.FindAsync(id);
            _context.Ciudades.Remove(ciudades);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CiudadesExists(int id)
        {
            return _context.Ciudades.Any(e => e.CiudadesID == id);
        }
    }
}
