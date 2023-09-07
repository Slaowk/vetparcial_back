using System;
using System.Collections.Generic;

namespace Vetparcial.Models;

public partial class Dueno
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Cedula { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Mascota> Mascota { get; set; } = new List<Mascota>();
}
