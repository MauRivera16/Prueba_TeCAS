using Microsoft.AspNetCore.Mvc;
using Prueba_TeCAS.Models;
using Prueba_TeCAS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_TeCAS.Controllers
{
    public class CuentaAhorroController : Controller
    {
        private readonly IUnitOfWork unidadtrabajo;
        public CuentaAhorroController(IUnitOfWork ut)
        {
            unidadtrabajo = ut;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            //llenar las listas
            ModeloPadre modelo = new ModeloPadre()
            {
                cuenta = new CuentasAhorro(),
                ListaClientes = unidadtrabajo.CRepo.GetListaCliente(),

            };
            return View(modelo);
        }
        [HttpPost]
        public IActionResult Insert(ModeloPadre mp)
        {
            if (ModelState.IsValid)
            {
                mp.cuenta.Saldo = 0;
                unidadtrabajo.CueRepo.Add(mp.cuenta);
                unidadtrabajo.save();
                return RedirectToAction("Index");

            }
            mp.ListaClientes = unidadtrabajo.CRepo.GetListaCliente();
            return View("Index", mp);
        }
        [HttpGet]
        public IActionResult Listar()
        {
            return Json(new
            {
                Data = unidadtrabajo.CueRepo.GetCuentasDetail()
            });
        }
        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            CuentasAhorro cue = unidadtrabajo.CueRepo.Get(id);
            if (cue == null)
            {
                return Json(new { success = false, message = "La categoria no existe" });
            }
            unidadtrabajo.CueRepo.remove(cue);
            unidadtrabajo.save();
            return Json(new { success = true, message = "Categoria eliminada" });
        }

        [HttpGet]
        public IActionResult Deposito(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CuentasAhorro cu = unidadtrabajo.CueRepo.Get(id.Value);
            if (cu == null)
            {
                return NotFound();
            }

            return View();
        }
        [HttpPost]
        public IActionResult UpdateDep(CuentasAhorro cue, ModeloPadre mp)
        {
            if (ModelState.IsValid)
            {

                //Actualizar saldo
                int idCuenta = cue.ID;
                CuentasAhorro cuentaahorro = unidadtrabajo.CueRepo.Get(idCuenta);
                if (cue.Saldo >= 0)
                {
                    cuentaahorro.Saldo += cue.Saldo;
                    unidadtrabajo.CueRepo.Update(cuentaahorro);
                    //guardar en la BD
                    unidadtrabajo.CueRepo.Update(cuentaahorro);
                    unidadtrabajo.save();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }


            }
            return View("Index");
        }
        [HttpGet]
        public IActionResult Retiro(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CuentasAhorro cu = unidadtrabajo.CueRepo.Get(id.Value);
            if (cu == null)
            {
                return NotFound();
            }

            return View();
        }
        [HttpPost]
        public IActionResult UpdateRet(CuentasAhorro cue, ModeloPadre mp)
        {
            if (ModelState.IsValid)
            {

                //Actualizar saldo
                int idCuenta = cue.ID;
                CuentasAhorro cuentaahorro = unidadtrabajo.CueRepo.Get(idCuenta);
                if (cue.Saldo >= 0 && cue.Saldo <= cuentaahorro.Saldo)
                {
                        cuentaahorro.Saldo -= cue.Saldo;
                        unidadtrabajo.CueRepo.Update(cuentaahorro);
                        //guardar en la BD
                        unidadtrabajo.CueRepo.Update(cuentaahorro);
                        unidadtrabajo.save();
                        return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }
            }
            return View("Index");
        }
    }
}
