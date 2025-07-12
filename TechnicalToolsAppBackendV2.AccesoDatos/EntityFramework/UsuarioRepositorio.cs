using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorio;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.AccesoDatos.EntityFramework
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        TechnicalToolsContexto context;
        public UsuarioRepositorio( TechnicalToolsContexto context)
        {
           this.context = context;
        }
        public async Task<Usuario> Agregar(Usuario usuario)
        {
            if (usuario == null) throw new Exception("Debe ingresar usuario");
            Usuario? usuarioBuscado = await context.Usuarios.Include(u=>u.Rol).Include(u=>u.Empresa).FirstOrDefaultAsync(u => u.Email == usuario.Email && u.Rol.IdRol == usuario.Rol.IdRol && u.Empresa.Id == usuario.Empresa.Id);
            if (usuarioBuscado != null) throw new Exception("El usuario ya existe");
            await context.Usuarios.AddAsync(usuario);
            await context.SaveChangesAsync();
            return usuario;

        }

        public Task<Usuario> CambiarPassword(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task Eliminar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Modificar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario?> Obtener(string email, string rolCod)
        {
            return await context.Usuarios.Include(u=>u.Rol).Include(u=>u.Empresa).FirstOrDefaultAsync(u=>u.Email==email && u.Rol.RolCodigo == rolCod);
        }
    }
}
