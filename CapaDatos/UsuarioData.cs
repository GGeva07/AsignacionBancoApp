using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class UsuarioData
    {
        ConexionBD conexion = new ConexionBD();
        public void RegistrarUsuario(Usuario usuario)
        {
            using (conexion)
            {
                SqlConnection conexion2 = conexion.ObtenerConexion();
                string consulta = "INSERT INTO Usuarios (Email, Nombre, Carrera, Contrasenia) VALUES (@Email, @Nombre, @Carrera, @Contrasenia)";
                SqlCommand consulta2 = new SqlCommand(consulta, conexion2);

                consulta2.Parameters.AddWithValue("@Email", usuario.Email);
                consulta2.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                consulta2.Parameters.AddWithValue("@Carrera", usuario.Carrera);
                consulta2.Parameters.AddWithValue("@Contrasenia", usuario.Contrasenia);

                consulta2.ExecuteNonQuery();
            }
        }

        public Usuario IniciarSesion(string email, string contrasenia)
        {
            using (conexion)
            {
                SqlConnection conexion2 = conexion.ObtenerConexion();
                string consulta = "SELECT * FROM Usuarios WHERE Email = @Email AND Contrasenia = @Contrasenia";
                SqlCommand consulta2 = new SqlCommand(consulta, conexion2);

                consulta2.Parameters.AddWithValue("@Email", email);
                consulta2.Parameters.AddWithValue("@Contrasenia", contrasenia);

                SqlDataReader lector = consulta2.ExecuteReader();

                if (lector.Read())
                {
                    return new Usuario
                    {
                        Id = (int)lector["Id"],
                        Email = (string)lector["Email"],
                        Nombre = (string)lector["Nombre"],
                        Carrera = (string)lector["Carrera"],
                        Contrasenia = (string)lector["Contrasenia"]
                    };
                }
            }
            return null;
        }
    }
}