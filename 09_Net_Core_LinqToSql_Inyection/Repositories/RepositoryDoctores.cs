using _09_Net_Core_LinqToSql_Inyection.Models;
using System.Data;
using System.Data.SqlClient;

namespace _09_Net_Core_LinqToSql_Inyection.Repositories
{
    public class RepositoryDoctores
    {
        //Linq
        private DataTable tablaDoctor;

        //SqlServer
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public RepositoryDoctores()
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2022";

            //Linq
            string consulta = "SELECT * FROM DOCTOR";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, connectionString);
            this.tablaDoctor = new DataTable();
            adapter.Fill(tablaDoctor);

            //SqlServer
            this.connection = new SqlConnection(connectionString);
            this.command = new SqlCommand();
            this.command.Connection = this.connection;
        }

        public List<Doctor> GetDoctores()
        {
            var consulta = from datos in this.tablaDoctor.AsEnumerable()
                           select datos;

            List <Doctor> doctores = new List<Doctor>();

            foreach(var row in consulta)
            {
                Doctor doctor = new Doctor
                {
                    HospitalCod = row.Field<string>("HOSPITAL_COD"),
                    DoctorNum = row.Field<string>("DOCTOR_NO"),
                    Apellido = row.Field<string>("APELLIDO"),
                    Especialidad = row.Field<string>("ESPECIALIDAD"),
                    Salario = row.Field<int>("SALARIO")
                };

                doctores.Add(doctor);
            }

            return doctores;
        }
    }
}
