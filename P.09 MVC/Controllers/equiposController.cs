using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using P._09_MVC.Models;

namespace P._09_MVC.Controllers
{
    public class equiposController : Controller
    {
        private readonly equiposDbcontex _equiposDbcontex;

        public equiposController(equiposDbcontex equiposDbcontex)
        {
            _equiposDbcontex = equiposDbcontex;
        }

        public IActionResult Index()
        {
            var listaDeMarcas = (from m in _equiposDbcontex.marcas
                                 select m).ToList();
            ViewData["listadoDeMarcas"] = new SelectList(listaDeMarcas, "id_marcas", "nombre_marca");

            var listadoDeEquipos = (from e in _equiposDbcontex.equipos
                                    join m in _equiposDbcontex.marcas on e.marca_id equals m.id_marcas
                                    select new
                                    {
                                        nombre = e.nombre,
                                        descripcion = e.descripcion,
                                        marca_id = e.marca_id,
                                        marca_nombre = m.nombre_marca
                                    }).ToList();

            ViewData["listadoEquipo"] = listadoDeEquipos;

            return View();
        }

        public IActionResult CrearEquipos(equipos nuevoEquipo)
        {
            _equiposDbcontex.Add(nuevoEquipo);
            _equiposDbcontex.SaveChanges(); 

            return RedirectToAction("Index");
        }
    }
}  

