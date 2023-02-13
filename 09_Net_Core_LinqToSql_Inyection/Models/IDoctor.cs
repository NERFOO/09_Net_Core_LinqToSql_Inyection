namespace _09_Net_Core_LinqToSql_Inyection.Models
{
    public interface IDoctor
    {
        string HospitalCod { get; set; }
        string DoctorNum { get; set; }
        string Apellido { get; set; }
        string Especialidad { get; set; }
        int Salario { get; set; }

        List<Doctor> GetDoctores();
    }
}
