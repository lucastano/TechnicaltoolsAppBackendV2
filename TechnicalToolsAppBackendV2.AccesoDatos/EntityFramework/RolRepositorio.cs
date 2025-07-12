using Microsoft.EntityFrameworkCore;
using TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorios;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.AccesoDatos;

namespace ProyectoService.AccesoDatos.EntityFramework
{
    public class RolRepositorio : IRolRepositorio
    {
        TechnicalToolsContexto _context;
        public RolRepositorio(TechnicalToolsContexto context)
        {
            _context = context;
        }
   
        public async Task<Rol> Agregar(Rol rol)
        {
            if (rol == null) throw new Exception("Debe ingresar un rol");
            Rol? rolBuscado = await _context.Roles.FirstOrDefaultAsync(r => r.RolCodigo == rol.RolCodigo);
            if (rolBuscado != null) throw new Exception("El rol ya existe");
            await _context.Roles.AddAsync(rol);
            await _context.SaveChangesAsync();
            return rol;
        }

        public async Task Eliminar(string rolCodigo)
        {
            if (rolCodigo == "") throw new Exception("Debe ingresar un codigo de rol");
            Rol? rolBuscado = await _context.Roles.FirstOrDefaultAsync(r => r.RolCodigo == rolCodigo);
            if (rolBuscado is null) throw new Exception("El rol no existe");
             _context.Roles.Remove(rolBuscado);
            await _context.SaveChangesAsync();
        }

        public async Task<Rol> Modificar(Rol rol)
        {
            Rol? rolBuscado = await _context.Roles.FirstOrDefaultAsync(r => r.RolCodigo == rol.RolCodigo);
            if (rolBuscado == null) throw new Exception("Rol no existe");
            rolBuscado.RolDescripcion = rol.RolDescripcion;
            rolBuscado.RolCodigo = rol.RolCodigo;
            await _context.SaveChangesAsync();
            return rolBuscado;
        }

        public async Task<Rol?> Obtener(string rolCodigo)
        {
            return await _context.Roles.FirstOrDefaultAsync(r =>r.RolCodigo == rolCodigo);
        }

        public async Task<List<Rol>> ObtenerTodos()
        {
            return await _context.Roles.ToListAsync();
        }
    }
}
