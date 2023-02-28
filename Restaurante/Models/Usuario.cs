using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Restaurante.Models;

[Table("Usuario")]
public partial class Usuario
{
    [Key]
    public int UsuarioId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    [Required(ErrorMessage = "Requiere Nombre")]
    public string? Nombre { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    [Required(ErrorMessage = "Requiere Apellido")]
    public string? Apellido { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    [Required(ErrorMessage = "Requiere Dirección")]
    public string? Direccion { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    [Required(ErrorMessage = "Requiere celular")]
    public string? Celular { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Ciudad { get; set; }

    public int? MesaId { get; set; }

    public int? BHABILITADO { get; set; }
}
