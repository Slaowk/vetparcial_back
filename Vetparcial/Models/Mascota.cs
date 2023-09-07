using System;
using System.Collections.Generic;

namespace Vetparcial.Models;

public partial class Mascota
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? TipoAnim { get; set; }

    public string? Edad { get; set; }

    public int? IdDueno { get; set; }

    public int? IdAlim { get; set; }

    public virtual Alimento? IdAlimNavigation { get; set; }

    public virtual Dueno? IdDuenoNavigation { get; set; }
}
