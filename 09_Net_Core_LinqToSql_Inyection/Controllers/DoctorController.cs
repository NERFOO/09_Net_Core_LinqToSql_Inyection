using _09_Net_Core_LinqToSql_Inyection.Models;
using _09_Net_Core_LinqToSql_Inyection.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _09_Net_Core_LinqToSql_Inyection.Controllers
{
    public class DoctorController : Controller
    {
        private IRepositoryDoctor irepo;

        public DoctorController(IRepositoryDoctor doctor)
        {
            this.irepo = doctor;
        }

        public IActionResult Index()
        {
            List<Doctor> doctores = this.irepo.GetDoctores();
            return View(doctores);
        }

        public IActionResult Insertar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insertar(string hospitalcod, string doctornum, string apellido, string especialidad, int salario)
        {
            this.irepo.InsertarDoctor(hospitalcod, doctornum, apellido, especialidad, salario);
            return RedirectToAction("Index");
        }
    }
}
