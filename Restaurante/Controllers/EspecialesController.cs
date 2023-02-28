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
    public class EspecialesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EspecialesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Especiales
        public async Task<IActionResult> Index()
        {
              return View(await _context.Especiales.ToListAsync());
        }

        // GET: Especiales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Especiales == null)
            {
                return NotFound();
            }

            var especiale = await _context.Especiales
                .FirstOrDefaultAsync(m => m.EspecialId == id);
            if (especiale == null)
            {
                return NotFound();
            }

            return View(especiale);
        }

        // GET: Especiales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Especiales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EspecialId,Nombre,Porciones,Precio,BHABILITADO")] Especiale especiale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especiale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especiale);
        }

        // GET: Especiales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Especiales == null)
            {
                return NotFound();
            }

            var especiale = await _context.Especiales.FindAsync(id);
            if (especiale == null)
            {
                return NotFound();
            }
            return View(especiale);
        }

        // POST: Especiales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EspecialId,Nombre,Porciones,Precio,BHABILITADO")] Especiale especiale)
        {
            if (id != especiale.EspecialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especiale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecialeExists(especiale.EspecialId))
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
            return View(especiale);
        }

        // GET: Especiales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Especiales == null)
            {
                return NotFound();
            }

            var especiale = await _context.Especiales
                .FirstOrDefaultAsync(m => m.EspecialId == id);
            if (especiale == null)
            {
                return NotFound();
            }

            return View(especiale);
        }

        // POST: Especiales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Especiales == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Especiales'  is null.");
            }
            var especiale = await _context.Especiales.FindAsync(id);
            if (especiale != null)
            {
                _context.Especiales.Remove(especiale);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspecialeExists(int id)
        {
          return _context.Especiales.Any(e => e.EspecialId == id);
        }
    }
}
