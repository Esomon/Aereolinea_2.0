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
    public class EmpleadosController : Controller
    {
        private readonly MyDbContext _context;

        public EmpleadosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index(string nombre)
        {
            var myDbContext = _context.Empleados.Include(e => e.TipoEmpleado);
            var filter = _context.Empleados.Where(s => s.Nombre.Contains(nombre));
            if (nombre != null)
            {
                return View(filter);
            }
            return View(await myDbContext.ToListAsync());
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.Empleados
                .Include(e => e.TipoEmpleado)
                .FirstOrDefaultAsync(m => m.EmpleadosID == id);
            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            ViewData["TipoEmpleadoID"] = new SelectList(_context.TipoEmpleado, "TipoEmpleadoID", "Nombre");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpleadosID,TipoEmpleadoID,Nombre,Apellido,Direccion,Edad")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoEmpleadoID"] = new SelectList(_context.TipoEmpleado, "TipoEmpleadoID", "Nombre", empleados.TipoEmpleadoID);
            return View(empleados);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.Empleados.FindAsync(id);
            if (empleados == null)
            {
                return NotFound();
            }
            ViewData["TipoEmpleadoID"] = new SelectList(_context.TipoEmpleado, "TipoEmpleadoID", "Nombre", empleados.TipoEmpleadoID);
            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpleadosID,TipoEmpleadoID,Nombre,Apellido,Direccion,Edad")] Empleados empleados)
        {
            if (id != empleados.EmpleadosID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadosExists(empleados.EmpleadosID))
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
            ViewData["TipoEmpleadoID"] = new SelectList(_context.TipoEmpleado, "TipoEmpleadoID", "Nombre", empleados.TipoEmpleadoID);
            return View(empleados);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.Empleados
                .Include(e => e.TipoEmpleado)
                .FirstOrDefaultAsync(m => m.EmpleadosID == id);
            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleados = await _context.Empleados.FindAsync(id);
            _context.Empleados.Remove(empleados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadosExists(int id)
        {
            return _context.Empleados.Any(e => e.EmpleadosID == id);
        }
    }
}
