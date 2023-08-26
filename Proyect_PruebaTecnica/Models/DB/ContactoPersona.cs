using System;
using System.Collections.Generic;

namespace Proyect_PruebaTecnica.Models.DB;

public partial class ContactoPersona
{
    public int Id { get; set; }

    public int? IdPersona { get; set; }

    public string NumeroTelefono1 { get; set; } = null!;

    public string? NumeroTelefono2 { get; set; }

    public string DireccionResidencia1 { get; set; } = null!;

    public string? DireccionResidencia2 { get; set; }

    public string CorreoElectronico1 { get; set; } = null!;

    public string? CorreoElectronico2 { get; set; }

    public virtual Persona? IdPersonaNavigation { get; set; }
}
