using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class CuentaBancariaData
    {
        ConexionBD conexion = new ConexionBD();

        public void CrearCuenta(CuentaBancaria cuentaBancaria)
        {
            using (conexion)
            {
                SqlConnection conexion2 = conexion.ObtenerConexion();
                string consulta = "INSERT INTO CuentasBancarias (NumeroCuenta, Saldo, NumeroDocumentoPropietario, NombrePropietario) VALUES (@NumeroCuenta, @Saldo, @NumeroDocumentoPropietario, @NombrePropietario)";
                SqlCommand consulta2 = new SqlCommand(consulta, conexion2);

                consulta2.Parameters.AddWithValue("@NumeroCuenta", cuentaBancaria.NumeroCuenta);
                consulta2.Parameters.AddWithValue("@Saldo", cuentaBancaria.Saldo);
                consulta2.Parameters.AddWithValue("@NumeroDocumentoPropietario", cuentaBancaria.Propietario.NumeroDocumento);
                consulta2.Parameters.AddWithValue("@NombrePropietario", cuentaBancaria.Propietario.Nombre);

                consulta2.ExecuteNonQuery();
            }
        }

        public void Depositar(string numeroCuenta, decimal monto)
        {
            using (conexion)
            {
                SqlConnection conexion2 = conexion.ObtenerConexion();
                string consulta = "UPDATE CuentasBancarias SET Saldo = Saldo + @Monto WHERE NumeroCuenta = @NumeroCuenta";
                SqlCommand consulta2 = new SqlCommand(consulta, conexion2);

                consulta2.Parameters.AddWithValue("@Monto", monto);
                consulta2.Parameters.AddWithValue("@NumeroCuenta", numeroCuenta);

                consulta2.ExecuteNonQuery();
            }
        }

        public bool Retirar(string numeroCuenta, decimal monto)
        {
            using (conexion)
            {
                SqlConnection conexion2 = conexion.ObtenerConexion();
                string consulta = "UPDATE CuentasBancarias SET Saldo = Saldo - @Monto WHERE NumeroCuenta = @NumeroCuenta AND Saldo >= @Monto";
                SqlCommand consulta2 = new SqlCommand(consulta, conexion2);

                consulta2.Parameters.AddWithValue("@Monto", monto);
                consulta2.Parameters.AddWithValue("@NumeroCuenta", numeroCuenta);

                int filas = consulta2.ExecuteNonQuery();
                return filas > 0;
            }
        }

        public decimal MostrarSaldo(string numeroCuenta)
        {
            using (conexion)
            {
                SqlConnection conexion2 = conexion.ObtenerConexion();
                string consulta = "SELECT Saldo FROM CuentasBancarias WHERE NumeroCuenta = @NumeroCuenta";
                SqlCommand consulta2 = new SqlCommand(consulta, conexion2);

                consulta2.Parameters.AddWithValue("@NumeroCuenta", numeroCuenta);

                object resultado = consulta2.ExecuteScalar();
                return resultado != null ? (decimal)resultado : 0;
            }
        }
    }
}