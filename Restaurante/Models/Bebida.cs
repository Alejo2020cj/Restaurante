﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Restaurante.Models;

public partial class Bebida
{
    [Key]
    public int BebiId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    public int? Porciones { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Precio { get; set; }

    public int? BHABILITADO { get; set; }

    [InverseProperty("Bebi")]
    public virtual ICollection<Mesa> Mesas { get; } = new List<Mesa>();
}
