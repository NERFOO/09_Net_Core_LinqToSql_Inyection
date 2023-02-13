using _09_Net_Core_LinqToSql_Inyection.Models;
using _09_Net_Core_LinqToSql_Inyection.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _09_Net_Core_LinqToSql_Inyection.Controllers
{
    public class DoctorController : Controller
    {
        private IDoctor doctor;

        public DoctorController(IDoctor doctor)
        {
            this.doctor = doctor;
        }

        public IActionResult Index()
        {
            return View(this.doctor);
        }
    }
}
