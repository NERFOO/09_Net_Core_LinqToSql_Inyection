using _09_Net_Core_LinqToSql_Inyection.Models;
using System.Data;
using System.Data.SqlClient;

namespace _09_Net_Core_LinqToSql_Inyection.Repositories
{
    public class RepositoryDoctores : IRepositoryDoctor
    {
        //Linq
        private DataTable tablaDoctor;

        //SqlServer
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public RepositoryDoctores()
        {
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2022";

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

        public void InsertarDoctor(string hospitalcod, string doctornum, string apellido, string especialidad, int salario)
        {
            string sql = "INSERT INTO DOCTOR VALUES (@hospitalcod, @doctornum, @apellido, @especialidad, @salario)";

            SqlParameter pamhos = new SqlParameter("@HOSPITALCOD", hospitalcod);
            SqlParameter pamdoc = new SqlParameter("@DOCTORNUM", doctornum);
            SqlParameter pamape = new SqlParameter("@APELLIDO", apellido);
            SqlParameter pamespe = new SqlParameter("@ESPECIALIDAD", especialidad);
            SqlParameter pamsalar = new SqlParameter("@SALARIO", salario);
            this.command.Parameters.Add(pamhos);
            this.command.Parameters.Add(pamdoc);
            this.command.Parameters.Add(pamape);
            this.command.Parameters.Add(pamespe);
            this.command.Parameters.Add(pamsalar);

            this.command.CommandType = CommandType.Text;
            this.command.CommandText = sql;

            this.connection.Open();
            this.command.ExecuteNonQuery();

            this.connection.Close();
            this.command.Parameters.Clear();
        }

        public void InsertarDoctor(string hospitalcod, string apellido, string especialidad, int salario)
        {
            throw new NotImplementedException();
        }
    }
}
