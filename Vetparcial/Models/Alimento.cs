using System;
using System.Collections.Generic;

namespace Vetparcial.Models;

public partial class Alimento
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Precio { get; set; }

    public virtual ICollection<Mascota> Mascota { get; set; } = new List<Mascota>();
}
