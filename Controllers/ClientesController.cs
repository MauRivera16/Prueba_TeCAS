using Microsoft.AspNetCore.Mvc;
using Prueba_TeCAS.Data;
using Prueba_TeCAS.Models;
using Prueba_TeCAS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_TeCAS.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IUnitOfWork unidadtrabajo;
        public ClientesController(IUnitOfWork unit)
        {
            unidadtrabajo = unit;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Listar()
        {

            return Json(new
            {
                Data = unidadtrabajo.CRepo.GetAll()
            }); 

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Insert(Clientes cli)
        {
            if (ModelState.IsValid)
            {
                unidadtrabajo.CRepo.Add(cli);
                unidadtrabajo.save();
                return RedirectToAction("Index");
            }
            return View("Create");
            
        }
        [HttpDelete]
        public IActionResult Eliminar(int id)
        {

            Clientes cli = unidadtrabajo.CRepo.Get(id);
            if (cli == null)
            {
                return Json(new { success = false, message = "La categoria no existe" });
            }
            unidadtrabajo.CRepo.remove(cli);
            unidadtrabajo.save();
            return Json(new { success = true, message = "Categoria eliminada" });
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Clientes cli = unidadtrabajo.CRepo.Get(id.Value);
            if (cli == null)
            {
                return NotFound();
            }
            return View(cli);
        }
        public IActionResult Update(Clientes cli)
        {
            if (ModelState.IsValid)
            {
                unidadtrabajo.CRepo.Update(cli);
                unidadtrabajo.save();
                return RedirectToAction("Index");

            }
            return View("Edit", cli);
        }

    }
}
