using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Restaurante.Models;

public partial class Mesa
{
    [Key]

    [Display(Name = "Número de Mesa")]
    public int? MesaId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    [Required(ErrorMessage ="Requiere Nombre")]
    public string? Nombre { get; set; }

    public int? PrinciId { get; set; }

    public int? ProteId { get; set; }

    public int? SopaId { get; set; }

    public int? EnsalaId { get; set; }

    public int? BebiId { get; set; }

    public int? AdicionId { get; set; }

    public int? EspecialId { get; set; }

    public int? EjeId { get; set; }

    [Display(Name = "Activa / No Activa")]
    public int? BHABILITADO { get; set; }

    [ForeignKey("AdicionId")]
    [InverseProperty("Mesas")]
    public virtual Adicionale? Adicion { get; set; }

    [ForeignKey("BebiId")]
    [InverseProperty("Mesas")]
    public virtual Bebida? Bebi { get; set; }

    [ForeignKey("EjeId")]
    [InverseProperty("Mesas")]
    public virtual Ejecutivo? Eje { get; set; }

    [ForeignKey("EnsalaId")]
    [InverseProperty("Mesas")]
    public virtual Ensalada? Ensala { get; set; }

    [ForeignKey("EspecialId")]
    [InverseProperty("Mesas")]
    public virtual Especiale? Especial { get; set; }

    [InverseProperty("Mesa")]
    public virtual ICollection<Factura> Facturas { get; } = new List<Factura>();

    [ForeignKey("PrinciId")]
    [InverseProperty("Mesas")]
    public virtual Principio? Princi { get; set; }

    [ForeignKey("ProteId")]
    [InverseProperty("Mesas")]
    public virtual Proteina? Prote { get; set; }

    [ForeignKey("SopaId")]
    [InverseProperty("Mesas")]
    public virtual Sopa? Sopa { get; set; }


    public List<Pedido> Pedido { get; set; }
    //[InverseProperty("MesaId")]
    //public virtual ICollection<Pedido> Pedidos { get; } = new List<Pedido>();
}
