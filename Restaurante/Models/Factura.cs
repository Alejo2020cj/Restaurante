using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Restaurante.Models;

[Table("Factura")]
public partial class Factura
{
    [Key]
    public int FacturaId { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FechaFac { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Opservaciones { get; set; }

    public int? MesaId { get; set; }

    public int? UsuarioId { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? ValTotal { get; set; }

    public int? BHABILITADO { get; set; }

    [ForeignKey("MesaId")]
    [InverseProperty("Facturas")]
    public virtual Mesa? Mesa { get; set; }
}
