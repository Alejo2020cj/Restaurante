using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurante.Models;
namespace Restaurante.ViewModels
{
    public class PedidosVM
    {
        public Pedido Pedido { get; set; }

        public IEnumerable<SelectListItem> PedidoMesa { get; set; }
        //public IEnumerable<SelectListItem> PedidoSopa { get; set; }


    }
}
