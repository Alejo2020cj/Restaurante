using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Restaurante.Models;

public partial class Ejecutivo
{
    [Key]
    public int EjeId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    [Required(ErrorMessage ="Ingrese nombre")]
    public string? Nombre { get; set; }

    public int? Cantidades { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Precio { get; set; }

    public int? BHABILITADO { get; set; }

    [InverseProperty("Eje")]
    public virtual ICollection<Mesa> Mesas { get; } = new List<Mesa>();
}
