using System.Data;

namespace WebApiNetCoreVideoClub
{
    public class clsGenero
    {
        public int idgenero { get; set; }
        public String nombre { get; set; }
        public String descripcion { get; set;}

        clsDatos con = new clsDatos();
        public clsGenero()
        { 
        
        }

        public bool Insertar()
        {
            try
            {
                string sql = "insert into tgenero values('" + this.nombre + "','" + this.descripcion + "')";
                return this.con.Ejecutar(sql);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Actualizar()
        {
            try
            {
                string sql = "update tgenero set nombre='" + this.nombre + "',descripcion='" + this.descripcion + "'";
                sql += " where idgenero=" + this.idgenero;
                return this.con.Ejecutar(sql);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Eliminar()
        {
            try
            {
                
                String sql = " delete from tgenero where idgenero=" + this.idgenero;
                return this.con.Ejecutar(sql);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool BuscarPorId()
        {
            string sql = "select * from tgenero where idgenero=" + this.idgenero;
            try
            {
                DataTable dt = this.con.Listado(sql);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    this.idgenero = Convert.ToInt32(dr["idgenero"]);
                    this.nombre = Convert.ToString(dr["nombre"]);
                    this.descripcion = Convert.ToString(dr["descripcion"]);

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

            
            
        }

        public DataTable ListadoCompleto()
        {
            string sql = "select * from tgenero order by nombre";
            return this.con.Listado(sql);
        }

    }
}
