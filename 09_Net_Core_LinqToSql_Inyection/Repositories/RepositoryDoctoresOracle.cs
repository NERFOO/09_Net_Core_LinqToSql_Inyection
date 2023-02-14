using _09_Net_Core_LinqToSql_Inyection.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.SqlClient;

namespace _09_Net_Core_LinqToSql_Inyection.Repositories
{
    public class RepositoryDoctoresOracle : IRepositoryDoctor
    {
        private OracleCommand command;
        private OracleConnection connection;
        private OracleDataAdapter adapter;
        private DataTable tablaDoctores;

        public RepositoryDoctoresOracle()
        {
            string connectionString = @"DATA SOURCE=LOCALHOST:1521/XE;PERSIST SECURITY INFO=True;USER ID=system; PASSWORD=ORACLE";

            string consulta = "SELECT * FROM DOCTOR";
            this.adapter = new OracleDataAdapter(consulta, connectionString);
            this.tablaDoctores = new DataTable();
            this.adapter.Fill(this.tablaDoctores);

            this.connection = new OracleConnection(connectionString);
            this.command = new OracleCommand();
            this.command.Connection = this.connection;
        }

        public List<Doctor> GetDoctores()
        {
            var consulta = from datos in this.tablaDoctores.AsEnumerable()
                           select new Doctor {
                               HospitalCod = datos.Field<int>("HOSPITAL_COD").ToString(),
                               DoctorNum= datos.Field<int>("DOCTOR_NO").ToString(),
                               Apellido = datos.Field<string>("APELLIDO"),
                               Especialidad = datos.Field<string>("ESPECIALIDAD"),
                               Salario = datos.Field<int>("SALARIO")
                           };

            return consulta.ToList();
        }

        private int GetMaxDoctor()
        {
            var maximo = (from datos in this.tablaDoctores.AsEnumerable()
                          select datos).Max(x => x.Field<int>("DOCTOR_NO")) + 1;
            return maximo;
        }

        public void InsertarDoctor(string hospitalcod, string apellido, string especialidad, int salario)
        {
            string consulta = "INSERT INTO DOCTOR VALUES (@HOSPITALCOD, @DOCTORNUM, @APELLIDO, @ESPECIALIDAD, @SALARIO)";

            int maximo = this.GetMaxDoctor();

            OracleParameter pamhos = new OracleParameter("@HOSPITALCOD", hospitalcod);
            OracleParameter pamdoc = new OracleParameter("@DOCTORNUM", maximo);
            OracleParameter pamape = new OracleParameter("@APELLIDO", apellido);
            OracleParameter pamespe = new OracleParameter("@ESPECIALIDAD", especialidad);
            OracleParameter pamsalar = new OracleParameter("@SALARIO", salario);
            this.command.Parameters.Add(pamhos);
            this.command.Parameters.Add(pamdoc);
            this.command.Parameters.Add(pamape);
            this.command.Parameters.Add(pamespe);
            this.command.Parameters.Add(pamsalar);

            this.command.CommandType = CommandType.Text;
            this.command.CommandText = consulta;

            this.connection.Open();
            this.command.ExecuteNonQuery();

            this.connection.Close();
            this.command.Parameters.Clear();
        }

        public void InsertarDoctor(string hospitalcod, string doctornum, string apellido, string especialidad, int salario)
        {
            string sql = "INSERT INTO DOCTOR VALUES (:hospitalcod, :doctornum, :apellido, :especialidad, :salario)";

            int maximo = this.GetMaxDoctor();

            OracleParameter pamhos = new OracleParameter(":HOSPITALCOD", hospitalcod);
            OracleParameter pamdoc = new OracleParameter(":DOCTORNUM", maximo);
            OracleParameter pamape = new OracleParameter(":APELLIDO", apellido);
            OracleParameter pamespe = new OracleParameter(":ESPECIALIDAD", especialidad);
            OracleParameter pamsalar = new OracleParameter(":SALARIO", salario);
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
    }
}
