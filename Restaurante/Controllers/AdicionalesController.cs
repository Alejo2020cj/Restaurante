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
    public class AdicionalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdicionalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Adicionales
        public async Task<IActionResult> Index()
        {
              return View(await _context.Adicionales.ToListAsync());
        }

        // GET: Adicionales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Adicionales == null)
            {
                return NotFound();
            }

            var adicionale = await _context.Adicionales
                .FirstOrDefaultAsync(m => m.AdicionId == id);
            if (adicionale == null)
            {
                return NotFound();
            }

            return View(adicionale);
        }

        // GET: Adicionales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adicionales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdicionId,Nombre,Porciones,Precio,BHABILITADO")] Adicionale adicionale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adicionale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adicionale);
        }

        // GET: Adicionales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Adicionales == null)
            {
                return NotFound();
            }

            var adicionale = await _context.Adicionales.FindAsync(id);
            if (adicionale == null)
            {
                return NotFound();
            }
            return View(adicionale);
        }

        // POST: Adicionales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdicionId,Nombre,Porciones,Precio,BHABILITADO")] Adicionale adicionale)
        {
            if (id != adicionale.AdicionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adicionale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdicionaleExists(adicionale.AdicionId))
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
            return View(adicionale);
        }

        // GET: Adicionales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Adicionales == null)
            {
                return NotFound();
            }

            var adicionale = await _context.Adicionales
                .FirstOrDefaultAsync(m => m.AdicionId == id);
            if (adicionale == null)
            {
                return NotFound();
            }

            return View(adicionale);
        }

        // POST: Adicionales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Adicionales == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Adicionales'  is null.");
            }
            var adicionale = await _context.Adicionales.FindAsync(id);
            if (adicionale != null)
            {
                _context.Adicionales.Remove(adicionale);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdicionaleExists(int id)
        {
          return _context.Adicionales.Any(e => e.AdicionId == id);
        }
    }
}
