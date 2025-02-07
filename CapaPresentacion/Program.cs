using System;
using System.Collections.Generic;
using CapaNegocio;
using CapaEntidades;

namespace CapaPresentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            UsuarioManejo usuarioM = new UsuarioManejo();
            CuentaBancariaManejo cuenta_manejo = new CuentaBancariaManejo();

            while (true)
            {
                Console.WriteLine("Bienvenido al sistema de gestión de cuentas bancarias.");
                Console.WriteLine("1. Registrarse");
                Console.WriteLine("2. Iniciar Sesión");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarUsuario(usuarioM);
                        break;
                    case "2":
                        if (IniciarSesion(usuarioM, out Usuario usuario))
                        {
                            GestionarCuentasBancarias(cuenta_manejo, usuario);
                        }
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Opción invalida");
                        break;
                }
            }
        }

        static void RegistrarUsuario(UsuarioManejo usuarioM)
        {
            Console.Write("Correo electrónico: ");
            string correo = Console.ReadLine();
            Console.Write("Nombre completo: ");
            string nombre = Console.ReadLine();
            Console.Write("Carrera: ");
            string carrera = Console.ReadLine();
            Console.Write("Contraseña: ");
            string contrasenia = Console.ReadLine();

            Usuario usuario = new Usuario
            {
                Email = correo,
                Nombre = nombre,
                Carrera = carrera,
                Contrasenia = contrasenia
            };

            usuarioM.RegistrarUsuario(usuario);
            Console.WriteLine("Usuario registrado");
        }

        static bool IniciarSesion(UsuarioManejo usuario1, out Usuario usuario)
        {
            Console.Write("Correo electrónico: ");
            string correo = Console.ReadLine();
            Console.Write("Contraseña: ");
            string contrasenia = Console.ReadLine();

            usuario = usuario1.IniciarSesion(correo, contrasenia);
            if (usuario != null)
            {
                Console.WriteLine("Inicio de sesión exitoso.");
                return true;
            }
            else
            {
                Console.WriteLine("Credenciales incorrectas. Intente de nuevo.");
                return false;
            }
        }

        static void GestionarCuentasBancarias(CuentaBancariaManejo cuentaManejo, Usuario usuario)
        {
            while (true)
            {
                Console.WriteLine("Gestión de Cuentas Bancarias");
                Console.WriteLine("1. Crear Cuenta");
                Console.WriteLine("2. Depositar");
                Console.WriteLine("3. Retirar");
                Console.WriteLine("4. Mostrar Saldo");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CrearCuenta(cuentaManejo, usuario);
                        break;
                    case "2":
                        Depositar(cuentaManejo, usuario);
                        break;
                    case "3":
                        Retirar(cuentaManejo, usuario);
                        break;
                    case "4":
                        MostrarSaldo(cuentaManejo, usuario);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        static void CrearCuenta(CuentaBancariaManejo cuentaManejo, Usuario usuario)
        {
            Console.Write("Número de cuenta: ");
            string numeroCuenta = Console.ReadLine();

            Propietario propietario = new Propietario
            {
                NumeroDocumento = usuario.Id.ToString(),
                Nombre = usuario.Nombre
            };

            CuentaBancaria cuentaBancaria = new CuentaBancaria(numeroCuenta, propietario);
            cuentaManejo.CrearCuenta(cuentaBancaria);
            Console.WriteLine("Cuenta creada exitosamente.");
        }

        static void Depositar(CuentaBancariaManejo cuentaManejo, Usuario usuario)
        {
            Console.Write("Número de cuenta: ");
            string numeroCuenta = Console.ReadLine();
            Console.Write("Monto a depositar: ");
            decimal monto = decimal.Parse(Console.ReadLine());

            cuentaManejo.Depositar(numeroCuenta, monto);
            Console.WriteLine("Depósito exitoso.");
        }

        static void Retirar(CuentaBancariaManejo cuentaManejo, Usuario usuario)
        {
            Console.Write("Número de cuenta: ");
            string numeroCuenta = Console.ReadLine();
            Console.Write("Monto a retirar: ");
            decimal monto = decimal.Parse(Console.ReadLine());

            if (cuentaManejo.Retirar(numeroCuenta, monto))
            {
                Console.WriteLine("Retiro exitoso.");
            }
            else
            {
                Console.WriteLine("Fondos insuficientes.");
            }
        }

        static void MostrarSaldo(CuentaBancariaManejo cuentaManejo, Usuario usuario)
        {
            Console.Write("Número de cuenta: ");
            string numeroCuenta = Console.ReadLine();

            decimal saldo = cuentaManejo.MostrarSaldo(numeroCuenta);
            Console.WriteLine($"El saldo de la cuenta es: {saldo}");
        }
    }
}