using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class CuentaBancaria
    {
        public string NumeroCuenta { get; private set; }
        public decimal Saldo { get; private set; }
        public Propietario Propietario { get; private set; }

        public CuentaBancaria(string numeroCuenta, Propietario propietario)
        {
            NumeroCuenta = numeroCuenta;
            Propietario = propietario;
            Saldo = 0;
        }
    }
}