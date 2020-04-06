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
    public class TipoSexoesController : Controller
    {
        private readonly MyDbContext _context;

        public TipoSexoesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: TipoSexoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoSexo.ToListAsync());
        }

        // GET: TipoSexoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoSexo = await _context.TipoSexo
                .FirstOrDefaultAsync(m => m.TipoSexoID == id);
            if (tipoSexo == null)
            {
                return NotFound();
            }

            return View(tipoSexo);
        }

        // GET: TipoSexoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoSexoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoSexoID,Sexo")] TipoSexo tipoSexo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoSexo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoSexo);
        }

        // GET: TipoSexoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoSexo = await _context.TipoSexo.FindAsync(id);
            if (tipoSexo == null)
            {
                return NotFound();
            }
            return View(tipoSexo);
        }

        // POST: TipoSexoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoSexoID,Sexo")] TipoSexo tipoSexo)
        {
            if (id != tipoSexo.TipoSexoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoSexo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoSexoExists(tipoSexo.TipoSexoID))
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
            return View(tipoSexo);
        }

        // GET: TipoSexoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoSexo = await _context.TipoSexo
                .FirstOrDefaultAsync(m => m.TipoSexoID == id);
            if (tipoSexo == null)
            {
                return NotFound();
            }

            return View(tipoSexo);
        }

        // POST: TipoSexoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoSexo = await _context.TipoSexo.FindAsync(id);
            _context.TipoSexo.Remove(tipoSexo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoSexoExists(int id)
        {
            return _context.TipoSexo.Any(e => e.TipoSexoID == id);
        }
    }
}
