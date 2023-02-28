using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Restaurante.Models;

public partial class Pedido
{
    [Key]
    public int PedidoId { get; set; }

    //public int MesaId { get; set; }
    [ForeignKey("Mesa")]
    public int? MesaId { get; set; }
    public  Mesa Mesas { get; set; }
}
