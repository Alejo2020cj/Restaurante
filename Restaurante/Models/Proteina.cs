using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Restaurante.Models;

public partial class Proteina
{
    [Key]
    public int ProteId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    [Required(ErrorMessage = "Requiere Nombre")]
    public string? Nombre { get; set; }
    [Required(ErrorMessage = "Requiere cantidad de porciones")]
    public int? Porciones { get; set; }

    [Column(TypeName = "decimal(18, 0)")]

    [Required(ErrorMessage = "Requiere precio")]
    public decimal? Precio { get; set; }

    public int? BHABILITADO { get; set; }

    [InverseProperty("Prote")]
    public virtual ICollection<Mesa> Mesas { get; } = new List<Mesa>();
}
