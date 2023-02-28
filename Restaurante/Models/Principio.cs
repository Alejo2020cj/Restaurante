using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Restaurante.Models;

public partial class Principio
{
    [Key]
    public int PrinciId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    [Required(ErrorMessage = "Requiere Nombre")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "Requiere Número de porciones")]
    public int? Porciones { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    [Required(ErrorMessage = "Requiere precio")]
    public decimal? Precio { get; set; }

    public int? BHABILITADO { get; set; }

    [InverseProperty("Princi")]
    public virtual ICollection<Mesa> Mesas { get; } = new List<Mesa>();
}
