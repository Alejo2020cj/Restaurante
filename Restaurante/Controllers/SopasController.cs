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
    public class SopasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SopasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sopas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Sopas.ToListAsync());
        }

        // GET: Sopas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sopas == null)
            {
                return NotFound();
            }

            var sopa = await _context.Sopas
                .FirstOrDefaultAsync(m => m.SopaId == id);
            if (sopa == null)
            {
                return NotFound();
            }

            return View(sopa);
        }

        // GET: Sopas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sopas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SopaId,Nombre,Porciones,Precio,BHABILITADO")] Sopa sopa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sopa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sopa);
        }

        // GET: Sopas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sopas == null)
            {
                return NotFound();
            }

            var sopa = await _context.Sopas.FindAsync(id);
            if (sopa == null)
            {
                return NotFound();
            }
            return View(sopa);
        }

        // POST: Sopas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SopaId,Nombre,Porciones,Precio,BHABILITADO")] Sopa sopa)
        {
            if (id != sopa.SopaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sopa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SopaExists(sopa.SopaId))
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
            return View(sopa);
        }

        // GET: Sopas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sopas == null)
            {
                return NotFound();
            }

            var sopa = await _context.Sopas
                .FirstOrDefaultAsync(m => m.SopaId == id);
            if (sopa == null)
            {
                return NotFound();
            }

            return View(sopa);
        }

        // POST: Sopas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sopas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Sopas'  is null.");
            }
            var sopa = await _context.Sopas.FindAsync(id);
            if (sopa != null)
            {
                _context.Sopas.Remove(sopa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SopaExists(int id)
        {
          return _context.Sopas.Any(e => e.SopaId == id);
        }
    }
}
