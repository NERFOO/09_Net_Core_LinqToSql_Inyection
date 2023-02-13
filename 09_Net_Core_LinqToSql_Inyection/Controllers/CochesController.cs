using _09_Net_Core_LinqToSql_Inyection.Models;
using Microsoft.AspNetCore.Mvc;

namespace _09_Net_Core_LinqToSql_Inyection.Controllers
{
    public class CochesController : Controller
    {

        private ICoche car;

        public CochesController(ICoche car)
        {
            this.car = car;
        }

        public IActionResult Index()
        {
            return View(this.car);
        }

        [HttpPost]
        public IActionResult Index(string accion)
        {
            if(accion.ToLower() == "acelerar")
            {
                this.car.Acelerar();
            }
            else
            {
                this.car.Frenar();
            }

            return View(this.car);
        }
    }
}
