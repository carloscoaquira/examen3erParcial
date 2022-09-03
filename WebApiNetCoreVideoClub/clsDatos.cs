using System.Data;
using System.Data.SqlClient;

namespace WebApiNetCoreVideoClub
{
    public class clsDatos
    {
        String CadenaConexion = @"Data Source=DESKTOP-6V1PQJN\SQL2019V2;Initial Catalog=bdvideoclub;User ID=sa;Password=Axon2021";

        public SqlConnection conexion { get; set;}
        public clsDatos()
        {
            this.conexion = new SqlConnection(this.CadenaConexion);
            this.conexion.Open();
        }

        public Boolean Ejecutar(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, this.conexion);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        
        }
        private void CerrarConexion()
        {

            this.conexion.Close();
        }

        public DataTable Listado(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("", this.conexion);
            da.SelectCommand.CommandText = sql;
            da.Fill(dt);
            return dt;
        }
    }
}
