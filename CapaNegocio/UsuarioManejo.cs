using System.Collections.Generic;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class UsuarioManejo
    {
        private UsuarioData usuario1 = new UsuarioData();

        public void RegistrarUsuario(Usuario usuario)
        {
            usuario1.RegistrarUsuario(usuario);
        }

        public Usuario IniciarSesion(string email, string contrasenia)
        {
            return usuario1.IniciarSesion(email, contrasenia);
        }
    }
}