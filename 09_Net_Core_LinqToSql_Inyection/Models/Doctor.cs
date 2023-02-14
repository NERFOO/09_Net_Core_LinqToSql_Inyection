using _09_Net_Core_LinqToSql_Inyection.Repositories;

namespace _09_Net_Core_LinqToSql_Inyection.Models
{
    public class Doctor
    {
        public string HospitalCod { get; set; }
        public string DoctorNum { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public int Salario { get; set; }
    }
}
