using System;
using AutoAdornos.Core.Business.Seguridad;

namespace AutoAdornos.Core.TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var usuarioBL = new UsuarioBL();
            var usuario = usuarioBL.ValidarUsuario("admin", "1234");

            if (usuario != null)
            {
                Console.WriteLine($"Bienvenido: {usuario.NombreCompleto} - Perfil: {usuario.NombrePerfil}");
            }
            else
            {
                Console.WriteLine("Usuario inválido");
            }

            Console.ReadLine();
        }
    }
}