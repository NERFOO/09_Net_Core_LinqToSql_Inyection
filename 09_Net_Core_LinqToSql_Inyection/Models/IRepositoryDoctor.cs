namespace _09_Net_Core_LinqToSql_Inyection.Models
{
    public interface IRepositoryDoctor
    {
        List<Doctor> GetDoctores();
        void InsertarDoctor(string hospitalcod, string doctornum, string apellido, string especialidad, int salario);
        void InsertarDoctor(string hospitalcod, string apellido, string especialidad, int salario);
    }
}
