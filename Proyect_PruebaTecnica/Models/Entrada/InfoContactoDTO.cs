using System.ComponentModel.DataAnnotations;

namespace Models.Entrada
{
    public class InfoContactoDTO
    {
		[RegularExpression(@"^(^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]+$){2,}", ErrorMessage = "El formato del correo electrónico no es válido.")]
		public string correo { get; set; } = string.Empty;
		public string numeroTelefono { get; set; } = string.Empty;
		public string direccionResidencia { get; set; } = string.Empty;

	}
}
