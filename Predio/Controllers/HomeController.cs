using Predio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Predio.Controllers
{
    public class HomeController : Controller
    {
        PredioEntities2 cnx;

        public HomeController()
        {
            cnx = new PredioEntities2();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Mantenedor()
        {
            return View();
        }

        public ActionResult Guardar(int codigo, string nombre, string sexo, string raza, string promedio)
        {
            Vaca listado = new Vaca()
            {
                Codigo = codigo,
                Nombre = nombre,
                Sexo = sexo,
                Raza = raza,
                Promedio = promedio
            };
            cnx.Vacas.Add(listado);
            cnx.SaveChanges();

            return View("Listado", cnx.Vacas.ToList());
        }

        public ActionResult Listado()
        {

            return View(cnx.Vacas.ToList());
        }

        public ActionResult Ficha(int codigo)
        {
     
            return View(cnx.Vacas.Where(x => x.Codigo == codigo).First());
        }

    }
}