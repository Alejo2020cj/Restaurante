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
    public class MesasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MesasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mesas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Mesas/*.Include(m => m.Adicion).Include(m => m.Bebi).Include(m => m.Eje).Include(m => m.Ensala).Include(m => m.Especial).Include(m => m.Princi).Include(m => m.Prote).Include(m => m.Sopa)*/;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Mesas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mesas == null)
            {
                return NotFound();
            }

            var mesa = await _context.Mesas
                //.Include(m => m.Adicion)
                //.Include(m => m.Bebi)
                //.Include(m => m.Eje)
                //.Include(m => m.Ensala)
                //.Include(m => m.Especial)
                //.Include(m => m.Princi)
                //.Include(m => m.Prote)
                //.Include(m => m.Sopa)
                .FirstOrDefaultAsync(m => m.MesaId == id);
            if (mesa == null)
            {
                return NotFound();
            }

            return View(mesa);
        }

        // GET: Mesas/Create
        public IActionResult Create()
        {
            //ViewData["AdicionId"] = new SelectList(_context.Adicionales, "AdicionId", "AdicionId");
            //ViewData["BebiId"] = new SelectList(_context.Bebidas, "BebiId", "BebiId");
            //ViewData["EjeId"] = new SelectList(_context.Ejecutivos, "EjeId", "EjeId");
            //ViewData["EnsalaId"] = new SelectList(_context.Ensaladas, "EnsalaId", "EnsalaId");
            //ViewData["EspecialId"] = new SelectList(_context.Especiales, "EspecialId", "EspecialId");
            //ViewData["PrinciId"] = new SelectList(_context.Principios, "PrinciId", "PrinciId");
            //ViewData["ProteId"] = new SelectList(_context.Proteinas, "ProteId", "ProteId");
            //ViewData["SopaId"] = new SelectList(_context.Sopas, "SopaId", "SopaId");
            return View();
        }

        // POST: Mesas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //Esto va despues de Nombre en crear
        /*,PrinciId,ProteId,SopaId,EnsalaId,BebiId,AdicionId,EspecialId,EjeId*/
        public async Task<IActionResult> Create([Bind("MesaId,Nombre,BHABILITADO")] Mesa mesa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mesa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AdicionId"] = new SelectList(_context.Adicionales, "AdicionId", "AdicionId", mesa.AdicionId);
            //ViewData["BebiId"] = new SelectList(_context.Bebidas, "BebiId", "BebiId", mesa.BebiId);
            //ViewData["EjeId"] = new SelectList(_context.Ejecutivos, "EjeId", "EjeId", mesa.EjeId);
            //ViewData["EnsalaId"] = new SelectList(_context.Ensaladas, "EnsalaId", "EnsalaId", mesa.EnsalaId);
            //ViewData["EspecialId"] = new SelectList(_context.Especiales, "EspecialId", "EspecialId", mesa.EspecialId);
            //ViewData["PrinciId"] = new SelectList(_context.Principios, "PrinciId", "PrinciId", mesa.PrinciId);
            //ViewData["ProteId"] = new SelectList(_context.Proteinas, "ProteId", "ProteId", mesa.ProteId);
            //ViewData["SopaId"] = new SelectList(_context.Sopas, "SopaId", "SopaId", mesa.SopaId);
            return View(mesa);
        }

        // GET: Mesas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mesas == null)
            {
                return NotFound();
            }

            var mesa = await _context.Mesas.FindAsync(id);
            if (mesa == null)
            {
                return NotFound();
            }
            //ViewData["AdicionId"] = new SelectList(_context.Adicionales, "AdicionId", "AdicionId", mesa.AdicionId);
            //ViewData["BebiId"] = new SelectList(_context.Bebidas, "BebiId", "BebiId", mesa.BebiId);
            //ViewData["EjeId"] = new SelectList(_context.Ejecutivos, "EjeId", "EjeId", mesa.EjeId);
            //ViewData["EnsalaId"] = new SelectList(_context.Ensaladas, "EnsalaId", "EnsalaId", mesa.EnsalaId);
            //ViewData["EspecialId"] = new SelectList(_context.Especiales, "EspecialId", "EspecialId", mesa.EspecialId);
            //ViewData["PrinciId"] = new SelectList(_context.Principios, "PrinciId", "PrinciId", mesa.PrinciId);
            //ViewData["ProteId"] = new SelectList(_context.Proteinas, "ProteId", "ProteId", mesa.ProteId);
            //ViewData["SopaId"] = new SelectList(_context.Sopas, "SopaId", "SopaId", mesa.SopaId);
            return View(mesa);
        }

        // POST: Mesas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Esto va en Edit despues de Nombre
        //PrinciId,ProteId,SopaId,EnsalaId,BebiId,AdicionId,EspecialId,EjeId,

        public async Task<IActionResult> Edit(int id, [Bind("MesaId,Nombre,BHABILITADO")] Mesa mesa)
        {
            if (id != mesa.MesaId)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(mesa);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!MesaExists(mesa.MesaId))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["AdicionId"] = new SelectList(_context.Adicionales, "AdicionId", "AdicionId", mesa.AdicionId);
            //ViewData["BebiId"] = new SelectList(_context.Bebidas, "BebiId", "BebiId", mesa.BebiId);
            //ViewData["EjeId"] = new SelectList(_context.Ejecutivos, "EjeId", "EjeId", mesa.EjeId);
            //ViewData["EnsalaId"] = new SelectList(_context.Ensaladas, "EnsalaId", "EnsalaId", mesa.EnsalaId);
            //ViewData["EspecialId"] = new SelectList(_context.Especiales, "EspecialId", "EspecialId", mesa.EspecialId);
            //ViewData["PrinciId"] = new SelectList(_context.Principios, "PrinciId", "PrinciId", mesa.PrinciId);
            //ViewData["ProteId"] = new SelectList(_context.Proteinas, "ProteId", "ProteId", mesa.ProteId);
            //ViewData["SopaId"] = new SelectList(_context.Sopas, "SopaId", "SopaId", mesa.SopaId);
            return View(mesa);
        }

        // GET: Mesas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mesas == null)
            {
                return NotFound();
            }

            var mesa = await _context.Mesas
                //.Include(m => m.Adicion)
                //.Include(m => m.Bebi)
                //.Include(m => m.Eje)
                //.Include(m => m.Ensala)
                //.Include(m => m.Especial)
                //.Include(m => m.Princi)
                //.Include(m => m.Prote)
                //.Include(m => m.Sopa)
                .FirstOrDefaultAsync(m => m.MesaId == id);
            if (mesa == null)
            {
                return NotFound();
            }

            return View(mesa);
        }

        // POST: Mesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mesas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Mesas'  is null.");
            }
            var mesa = await _context.Mesas.FindAsync(id);
            if (mesa != null)
            {
                _context.Mesas.Remove(mesa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MesaExists(int id)
        {
          return _context.Mesas.Any(e => e.MesaId == id);
        }
    }
}
