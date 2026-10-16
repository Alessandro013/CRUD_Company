using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace CRUD_Company.Respository
{
   
    enum CrudType : int
    {
        All = 0,
        Create = 1,
        Update = 2,
        View = 4,
        Delete = 8
    }
    
    public class UserRepository
    {
        private readonly string conexionString = ConfigurationManager.ConnectionStrings["SqlConexion"].ConnectionString;

        // OBTENER TODO
        public DataTable ObtenerProductos()
        {
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CRUD", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", CrudType.All);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // CREAR
        public void Create(string name = null, string description = null, int price = 0, int stock = 0)
        {
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CRUD", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", CrudType.Create);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Stock", stock);

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ACTUALIZAR
        public void Update(int id, string name = null, string description = null, int price = 0, int stock = 0)
        {
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CRUD", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", CrudType.Update);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Stock", stock);

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // VISUALIZAR
        public void Detail(int id)
        {
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CRUD", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", CrudType.View);
                    cmd.Parameters.AddWithValue("@Id", id);

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ELIMINAR
        public void Delete(int id)
        {
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CRUD", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", CrudType.Delete);
                    cmd.Parameters.AddWithValue("@Id", id);

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
