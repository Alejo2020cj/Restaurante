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
    public class EnsaladasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnsaladasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ensaladas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Ensaladas.ToListAsync());
        }

        // GET: Ensaladas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ensaladas == null)
            {
                return NotFound();
            }

            var ensalada = await _context.Ensaladas
                .FirstOrDefaultAsync(m => m.EnsalaId == id);
            if (ensalada == null)
            {
                return NotFound();
            }

            return View(ensalada);
        }

        // GET: Ensaladas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ensaladas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnsalaId,Nombre,Porciones,Precio,BHABILITADO")] Ensalada ensalada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ensalada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ensalada);
        }

        // GET: Ensaladas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ensaladas == null)
            {
                return NotFound();
            }

            var ensalada = await _context.Ensaladas.FindAsync(id);
            if (ensalada == null)
            {
                return NotFound();
            }
            return View(ensalada);
        }

        // POST: Ensaladas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnsalaId,Nombre,Porciones,Precio,BHABILITADO")] Ensalada ensalada)
        {
            if (id != ensalada.EnsalaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ensalada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnsaladaExists(ensalada.EnsalaId))
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
            return View(ensalada);
        }

        // GET: Ensaladas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ensaladas == null)
            {
                return NotFound();
            }

            var ensalada = await _context.Ensaladas
                .FirstOrDefaultAsync(m => m.EnsalaId == id);
            if (ensalada == null)
            {
                return NotFound();
            }

            return View(ensalada);
        }

        // POST: Ensaladas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ensaladas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Ensaladas'  is null.");
            }
            var ensalada = await _context.Ensaladas.FindAsync(id);
            if (ensalada != null)
            {
                _context.Ensaladas.Remove(ensalada);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnsaladaExists(int id)
        {
          return _context.Ensaladas.Any(e => e.EnsalaId == id);
        }
    }
}
