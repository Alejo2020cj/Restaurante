using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurante.Datos;
using Restaurante.Models;

namespace Restaurante.Controllers
{
    public class EjecutivoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EjecutivoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ejecutivoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Ejecutivos.ToListAsync());
        }

        // GET: Ejecutivoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ejecutivos == null)
            {
                return NotFound();
            }

            var ejecutivo = await _context.Ejecutivos
                .FirstOrDefaultAsync(m => m.EjeId == id);
            if (ejecutivo == null)
            {
                return NotFound();
            }

            return View(ejecutivo);
        }

        // GET: Ejecutivoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ejecutivoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EjeId,Nombre,Cantidades,Precio,BHABILITADO")] Ejecutivo ejecutivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ejecutivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ejecutivo);
        }

        // GET: Ejecutivoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ejecutivos == null)
            {
                return NotFound();
            }

            var ejecutivo = await _context.Ejecutivos.FindAsync(id);
            if (ejecutivo == null)
            {
                return NotFound();
            }
            return View(ejecutivo);
        }

        // POST: Ejecutivoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EjeId,Nombre,Cantidades,Precio,BHABILITADO")] Ejecutivo ejecutivo)
        {
            if (id != ejecutivo.EjeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ejecutivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EjecutivoExists(ejecutivo.EjeId))
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
            return View(ejecutivo);
        }

        // GET: Ejecutivoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ejecutivos == null)
            {
                return NotFound();
            }

            var ejecutivo = await _context.Ejecutivos
                .FirstOrDefaultAsync(m => m.EjeId == id);
            if (ejecutivo == null)
            {
                return NotFound();
            }

            return View(ejecutivo);
        }

        // POST: Ejecutivoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ejecutivos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Ejecutivos'  is null.");
            }
            var ejecutivo = await _context.Ejecutivos.FindAsync(id);
            if (ejecutivo != null)
            {
                _context.Ejecutivos.Remove(ejecutivo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EjecutivoExists(int id)
        {
          return _context.Ejecutivos.Any(e => e.EjeId == id);
        }
    }
}
