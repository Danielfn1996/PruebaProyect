using System;
using System.Collections.Generic;

namespace Proyect_PruebaTecnica.Models.DB;

public partial class Persona
{
    public int Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;
	public string? NumDocumento { get; set; } = null!;


	public DateTime FechaNacimiento { get; set; }

    public virtual ICollection<ContactoPersona> ContactoPersonas { get; set; } = new List<ContactoPersona>();
}
