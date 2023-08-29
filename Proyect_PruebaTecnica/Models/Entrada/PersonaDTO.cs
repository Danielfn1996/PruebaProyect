using System.ComponentModel.DataAnnotations;

namespace Models.Entrada
{
    public class PersonaDTO
    {
        
        [Required(ErrorMessage = "Este campo es obligatorio")]
		[RegularExpression(@"^([a-zA-Z]+)*$", ErrorMessage = "Verifique los caracteres ingresados")]

		public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo es obligatorio")]
		[RegularExpression(@"^([a-zA-Z]+)*$", ErrorMessage = "Verifique los caracteres ingresados")]
		public string Apellido { get; set; } = string.Empty;

		[Required(ErrorMessage = "Este campo es obligatorio")]
		[RegularExpression(@"^(^[a-zA-Z0-9]+$){1,8}$", ErrorMessage = "El número de identificación solo acepta valores alfanuméricos ")]
		public string NumDocumento { get; set; } = string.Empty;

		[Required(ErrorMessage = "Este campo es obligatorio")]
        public string FechaNacimiento{ get; set; } = string.Empty;

	
		[RegularExpression(@"^(^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]+$){2,}", ErrorMessage = "El formato del correo electrónico no es válido.")]
		public string correo { get; set; } = string.Empty;
		public string numeroTelefono { get; set; } = string.Empty;
		public string direccionResidencia { get; set; } = string.Empty;

		public List<InfoContactoDTO> InfoContacto { get; set; }

    }
}
