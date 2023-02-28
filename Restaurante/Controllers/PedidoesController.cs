using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurante.Datos;
using Restaurante.Models;
using Restaurante.ViewModels;

namespace Restaurante.Controllers
{
    public class PedidoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PedidoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pedidoes
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Pedidos.ToListAsync());
        //}
        [HttpGet]
        public IActionResult Index()
        {
            List<Pedido> listaPedidos = _context.Pedidos.ToList();
            return View(listaPedidos);
        }

        // GET: Pedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidoes/Create
        public IActionResult Create()
        {
            PedidosVM pedidoVM = new PedidosVM()
            {
                Pedido = new Pedido(),



                //PedidoSopa = _context.Sopas.Select(c => new
                //SelectListItem
                //{
                //    Text = c.Nombre,
                //    Value = c.SopaId.ToString()

                //}),

                PedidoMesa = _context.Mesas.Select(c => new
                SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.MesaId.ToString()

                })

            };

            return View(pedidoVM);
        }

        // POST: Pedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoId")] Pedido pedido)
        {
            //if (!ModelState.IsValid || pedido.PedidoId == null)
            //{
            //    PedidosVM pedidosVM = new PedidosVM();
            //    pedidosVM.PedidoMesa = _context.Mesas.Select(i =>
            //    new SelectListItem
            //    {
            //        Text = i.Nombre,
            //        Value = i.MesaId.ToString(),

            //    });
            //    return View(pedidosVM);
            //}
            int nveses = 0;
            nveses = _context.Pedidos.Where(p => p.PedidoId == pedido.PedidoId).Count();

            if (!ModelState.IsValid || nveses >= 1 || pedido.PedidoId == null)
            {

                PedidosVM pedidosVM = new PedidosVM();
                pedidosVM.PedidoMesa = _context.Mesas.Select(i =>
                new SelectListItem
                {
                    Value = i.MesaId.ToString(),

                });
                return View(pedidosVM);

            }

            else if (ModelState.IsValid)
            {

                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }

        // GET: Pedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoId")] Pedido pedido)
        {
            if (id != pedido.PedidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.PedidoId))
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
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pedidos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pedidos'  is null.");
            }
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
          return _context.Pedidos.Any(e => e.PedidoId == id);
        }
    }
}
