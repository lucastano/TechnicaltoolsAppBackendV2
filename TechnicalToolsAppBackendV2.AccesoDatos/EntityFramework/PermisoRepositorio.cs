
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
    public class PermisoRepositorio : IPermisoRepositorio
    {
        TechnicalToolsContexto context;
        public PermisoRepositorio(TechnicalToolsContexto context)
        {
            this.context = context;
        }
        public async Task<Permiso> Agregar(Permiso permiso)
        {
            if (permiso == null) throw new Exception("Debe ingresar permiso");
            Permiso? permisoBuscado = await context.Permisos.FirstOrDefaultAsync( p => p.PermisoCodigo == permiso.PermisoCodigo);
            if (permisoBuscado != null) throw new Exception("Permiso ya existe");
            await context.Permisos.AddAsync(permiso);
            await context.SaveChangesAsync();
            return permiso;
        }

        public async Task Eliminar(string permisoCodigo)
        {
            if (permisoCodigo == "") throw new Exception("Debe ingresar codigo del permiso");
            Permiso? permisoBuscado = await context.Permisos.FirstOrDefaultAsync( p => p.PermisoCodigo == permisoCodigo);
            if (permisoBuscado == null) throw new Exception("No existe permiso");
            context.Permisos.Remove(permisoBuscado);
            await context.SaveChangesAsync();
            
        }

        public async Task<Permiso> Modificar(Permiso permiso)
        {
            if (permiso == null) throw new Exception("Debe ingresas un permiso");
            Permiso? permisoBuscado = await context.Permisos.FirstOrDefaultAsync(p => p.PermisoCodigo == permiso.PermisoCodigo);
            if (permisoBuscado == null) throw new Exception("El permiso no existe");
            permisoBuscado.PermisoDescripcion = permiso.PermisoDescripcion;
            await context.SaveChangesAsync();
            return permisoBuscado;
        }

        public async Task<Permiso?> ObtenerPorCodigo(string permisoCodigo)
        {
            if (permisoCodigo == "") throw new Exception("Debe ingresar codigo del permiso");
            Permiso? permisoBuscado = await context.Permisos.FirstOrDefaultAsync(p => p.PermisoCodigo == permisoCodigo);
            return permisoBuscado;
        }

        public async Task<List<Permiso>> ObtenerTodos()
        {
            return await context.Permisos.ToListAsync();
        }
    }
}
