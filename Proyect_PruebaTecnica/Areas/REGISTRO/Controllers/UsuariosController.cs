using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models.Entrada;
using Proyect_PruebaTecnica.Models.DB;
using System;
using System.Security.Cryptography.Pkcs;

namespace Proyect_PruebaTecnica.Areas.REGISTRO.Controllers
{

	[Area("REGISTRO")]
	public class UsuariosController : Controller
	{

		private readonly RegistrosContext _context;

		public UsuariosController(RegistrosContext context)
		{
			_context = context;
		}

		public ActionResult RegistrarUsuario()
		{
			return View();
		}

		[HttpPost]
		public JsonResult RegistrarUsuario(PersonaDTO model)
		{
			var result = new
			{
				Success = true,
				Message = "",
				Codigo = -9

			};

			if (ModelState.IsValid)
			{
				var id = _context.Personas.Any(x => x.NumDocumento == model.NumDocumento);
				if (id)
				{
					result =new
					{
						Success = false,
						Message = "Ya existe un usuario registrado con el número de identificación",
						Codigo = 1
					};

				}
				else
				{
					try {
						var persona = new Persona();
						persona.NumDocumento = model.NumDocumento;
						persona.Nombres = model.Nombre;
						persona.Apellidos = model.Apellido;
						persona.FechaNacimiento = DateTime.Parse(model.FechaNacimiento);
						_context.Personas.Add(persona);
						_context.SaveChanges();
						var idPerson = _context.Set<Persona>()
															.OrderByDescending(t => t.Id)
															.FirstOrDefault();

						var infoContacto = new ContactoPersona();
						{
							infoContacto.NumeroTelefono1 = model.numeroTelefono;
							infoContacto.DireccionResidencia1 = model.direccionResidencia;
							infoContacto.CorreoElectronico1 = model.correo;
							infoContacto.IdPersona = idPerson.Id;
						};
						_context.ContactoPersonas.Add(infoContacto);
						_context.SaveChanges();

						result = new
						{
							Success = true,
							Message = "Se registro correctamente el usuario",
							Codigo = 0
						};
					}
					catch
					{
						result = new
						{
							Success = false,
							Message = "Ocurrio un error inesperado intente mas tarde",
							Codigo =-9
						};
					}
				
				}
			}
			else
			{
				result = new
				{
					Success = false,
					Message = "Faltan campos por diligenciar",
					Codigo = -9
				};
			}
			return Json(result);

		}


		// GET: UsuariosController/Details/5
		public ActionResult Details(int id)
		{
			return View();

		}

		// GET: UsuariosController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: UsuariosController/Create
	

		// GET: UsuariosController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: UsuariosController/Edit/5
	

		// GET: UsuariosController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: UsuariosController/Delete/5

	}
}
