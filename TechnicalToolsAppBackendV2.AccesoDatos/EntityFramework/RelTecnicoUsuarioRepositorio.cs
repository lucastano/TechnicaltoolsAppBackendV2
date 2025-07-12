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
    public class RelTecnicoUsuarioRepositorio : IRelTecnicoUsuarioRepositorio
    {
        TechnicalToolsContexto context;
        public RelTecnicoUsuarioRepositorio(TechnicalToolsContexto context)
        {
            this.context = context;
        }

        public async Task Agregar(RelTecnicoUsuario relTecnicoUsuario)
        {
            await context.RelTecnicoUsuario.AddAsync(relTecnicoUsuario);
            await context.SaveChangesAsync();
        }

        public async Task Eliminar(Usuario usuario)
        {
            RelTecnicoUsuario tecusurel = await context.RelTecnicoUsuario.FirstOrDefaultAsync(r=>r.Usuario == usuario);
            context.RelTecnicoUsuario.Remove(tecusurel);
            await context.SaveChangesAsync();
        }

        public async Task<RelTecnicoUsuario> ObtenerTecnicoPorUsuario(Usuario usuario)
        {
            return await context.RelTecnicoUsuario.Include(r=>r.Tecnico).Include(r=>r.Usuario).FirstOrDefaultAsync(r => r.Usuario.IdUsuario == usuario.IdUsuario && r.Usuario.Rol.RolCodigo == usuario.Rol.RolCodigo);
        }
    }
}
