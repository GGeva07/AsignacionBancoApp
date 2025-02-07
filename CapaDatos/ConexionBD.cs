using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class ConexionBD : IDisposable
    {
        private readonly string URLConexion;
        private SqlConnection conexion;

        public ConexionBD() 
        {
            URLConexion = "Server=CHIKIBABY;Database=BancoApp2;TrustServerCertificate=True;";
        }

        public SqlConnection ObtenerConexion()
        {
            if (conexion == null)
            {
                conexion = new SqlConnection(URLConexion);
            }

            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }

            return conexion;
        }

        public void Dispose()
        {
            if (conexion != null && conexion.State != System.Data.ConnectionState.Closed)
            {
                conexion.Close();
                conexion.Dispose();
            }
        }
    }
}