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
    public class ProteinasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProteinasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Proteinas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Proteinas.ToListAsync());
        }

        // GET: Proteinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Proteinas == null)
            {
                return NotFound();
            }

            var proteina = await _context.Proteinas
                .FirstOrDefaultAsync(m => m.ProteId == id);
            if (proteina == null)
            {
                return NotFound();
            }

            return View(proteina);
        }

        // GET: Proteinas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proteinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProteId,Nombre,Porciones,Precio,BHABILITADO")] Proteina proteina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proteina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proteina);
        }

        // GET: Proteinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Proteinas == null)
            {
                return NotFound();
            }

            var proteina = await _context.Proteinas.FindAsync(id);
            if (proteina == null)
            {
                return NotFound();
            }
            return View(proteina);
        }

        // POST: Proteinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProteId,Nombre,Porciones,Precio,BHABILITADO")] Proteina proteina)
        {
            if (id != proteina.ProteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proteina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProteinaExists(proteina.ProteId))
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
            return View(proteina);
        }

        // GET: Proteinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Proteinas == null)
            {
                return NotFound();
            }

            var proteina = await _context.Proteinas
                .FirstOrDefaultAsync(m => m.ProteId == id);
            if (proteina == null)
            {
                return NotFound();
            }

            return View(proteina);
        }

        // POST: Proteinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Proteinas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Proteinas'  is null.");
            }
            var proteina = await _context.Proteinas.FindAsync(id);
            if (proteina != null)
            {
                _context.Proteinas.Remove(proteina);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProteinaExists(int id)
        {
          return _context.Proteinas.Any(e => e.ProteId == id);
        }
    }
}
