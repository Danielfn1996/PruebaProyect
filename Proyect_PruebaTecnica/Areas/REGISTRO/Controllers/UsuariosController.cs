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
		public ActionResult RegistrarUsuario(PersonaDTO model)
		{

			var id = _context.Personas.Any(x => x.NumDocumento == model.NumDocumento);
			if (id)
			{
				ViewBag.codigo = 1;
				return View();

			}
			else
			{
				try
				{
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


					foreach (InfoContactoDTO info in model.InfoContacto)
					{
						var infoContacto = new ContactoPersona();
						{
							infoContacto.NumeroTelefono1 = info.numeroTelefono;
							infoContacto.DireccionResidencia1 = info.direccionResidencia;
							infoContacto.CorreoElectronico1 = info.correo;
							infoContacto.IdPersona = idPerson.Id;
						};
						_context.ContactoPersonas.Add(infoContacto);
						_context.SaveChanges();

					}

					return View(ViewBag.codigo = 0);
				}
				catch
				{
					return View(ViewBag.codigo = -9);
				}

			}


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
