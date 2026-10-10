using System;
using System.Collections.Generic;

namespace mi_primer_api.Models;

public partial class Empleado
{
    public int IdEmpleados { get; set; }

    public int IdPuesto { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public virtual Puesto IdPuestoNavigation { get; set; } = null!;
}
