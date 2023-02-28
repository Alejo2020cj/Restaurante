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
    public class PrincipiosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrincipiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Principios
        public async Task<IActionResult> Index()
        {
              return View(await _context.Principios.ToListAsync());
        }

        // GET: Principios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Principios == null)
            {
                return NotFound();
            }

            var principio = await _context.Principios
                .FirstOrDefaultAsync(m => m.PrinciId == id);
            if (principio == null)
            {
                return NotFound();
            }

            return View(principio);
        }

        // GET: Principios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Principios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrinciId,Nombre,Porciones,Precio,BHABILITADO")] Principio principio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(principio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(principio);
        }

        // GET: Principios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Principios == null)
            {
                return NotFound();
            }

            var principio = await _context.Principios.FindAsync(id);
            if (principio == null)
            {
                return NotFound();
            }
            return View(principio);
        }

        // POST: Principios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrinciId,Nombre,Porciones,Precio,BHABILITADO")] Principio principio)
        {
            if (id != principio.PrinciId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(principio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrincipioExists(principio.PrinciId))
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
            return View(principio);
        }

        // GET: Principios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Principios == null)
            {
                return NotFound();
            }

            var principio = await _context.Principios
                .FirstOrDefaultAsync(m => m.PrinciId == id);
            if (principio == null)
            {
                return NotFound();
            }

            return View(principio);
        }

        // POST: Principios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Principios == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Principios'  is null.");
            }
            var principio = await _context.Principios.FindAsync(id);
            if (principio != null)
            {
                _context.Principios.Remove(principio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrincipioExists(int id)
        {
          return _context.Principios.Any(e => e.PrinciId == id);
        }
    }
}
