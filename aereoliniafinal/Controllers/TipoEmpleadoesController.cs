﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aereoliniafinal.Models;

namespace aereoliniafinal.Controllers
{
    public class TipoEmpleadoesController : Controller
    {
        private readonly MyDbContext _context;

        public TipoEmpleadoesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: TipoEmpleadoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoEmpleado.ToListAsync());
        }

        // GET: TipoEmpleadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEmpleado = await _context.TipoEmpleado
                .FirstOrDefaultAsync(m => m.TipoEmpleadoID == id);
            if (tipoEmpleado == null)
            {
                return NotFound();
            }

            return View(tipoEmpleado);
        }

        // GET: TipoEmpleadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoEmpleadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoEmpleadoID,Nombre")] TipoEmpleado tipoEmpleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEmpleado);
        }

        // GET: TipoEmpleadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEmpleado = await _context.TipoEmpleado.FindAsync(id);
            if (tipoEmpleado == null)
            {
                return NotFound();
            }
            return View(tipoEmpleado);
        }

        // POST: TipoEmpleadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoEmpleadoID,Nombre")] TipoEmpleado tipoEmpleado)
        {
            if (id != tipoEmpleado.TipoEmpleadoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEmpleadoExists(tipoEmpleado.TipoEmpleadoID))
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
            return View(tipoEmpleado);
        }

        // GET: TipoEmpleadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEmpleado = await _context.TipoEmpleado
                .FirstOrDefaultAsync(m => m.TipoEmpleadoID == id);
            if (tipoEmpleado == null)
            {
                return NotFound();
            }

            return View(tipoEmpleado);
        }

        // POST: TipoEmpleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoEmpleado = await _context.TipoEmpleado.FindAsync(id);
            _context.TipoEmpleado.Remove(tipoEmpleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEmpleadoExists(int id)
        {
            return _context.TipoEmpleado.Any(e => e.TipoEmpleadoID == id);
        }
    }
}
