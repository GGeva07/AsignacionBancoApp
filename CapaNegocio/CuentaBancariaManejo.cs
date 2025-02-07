using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class CuentaBancariaManejo
    {
        private CuentaBancariaData cuenta = new CuentaBancariaData();

        public void CrearCuenta(CuentaBancaria cuentaBancaria)
        {
            cuenta.CrearCuenta(cuentaBancaria);
        }

        public void Depositar(string numeroCuenta, decimal monto)
        {
            cuenta.Depositar(numeroCuenta, monto);
        }

        public bool Retirar(string numeroCuenta, decimal monto)
        {
            return cuenta.Retirar(numeroCuenta, monto);
        }

        public decimal MostrarSaldo(string numeroCuenta)
        {
            return cuenta.MostrarSaldo(numeroCuenta);
        }
    }
}