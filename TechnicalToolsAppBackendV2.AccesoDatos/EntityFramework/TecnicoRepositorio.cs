using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorios;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.AccesoDatos.EntityFramework
{
    public class TecnicoRepositorio : ITecnicoRepositorio
    {
        TechnicalToolsContexto _context;
        public TecnicoRepositorio(TechnicalToolsContexto context)
        {
            _context = context;
        }
        public async Task<Tecnico> Agregar(Tecnico tecnico)
        {
            if (tecnico == null) throw new Exception("Debe ingresar tecnico");
            Tecnico? tecnicoBuscado = await _context.Tecnicos.FirstOrDefaultAsync( t=>t.Nombre.ToLower()==tecnico.Nombre.ToLower() && t.Apellido.ToLower()==tecnico.Apellido.ToLower());
            if (tecnicoBuscado != null) throw new Exception("El tecnico ya existe");
            await _context.Tecnicos.AddAsync(tecnico);
            await _context.SaveChangesAsync();
            return tecnico;
        }

        public async Task Eliminar(int id)
        {
            Tecnico? tecnicoBuscado = await _context.Tecnicos.FirstOrDefaultAsync(t=>t.IdTecnico == id);
            if (tecnicoBuscado == null) throw new Exception("Tecnico no existe");
            _context.Tecnicos.Remove(tecnicoBuscado);
            await _context.SaveChangesAsync();
        }

        public async Task<Tecnico> Modificar(Tecnico tecnico)
        {
            if (tecnico == null) throw new Exception("Debe ingresar un tecnico");
            Tecnico? tecnicoBuscado = await _context.Tecnicos.FirstOrDefaultAsync(t => t.IdTecnico == tecnico.IdTecnico);
            if (tecnicoBuscado == null) throw new Exception("Tecnico no existe");
            tecnicoBuscado.Nombre = tecnico.Nombre;
            tecnicoBuscado.Apellido = tecnico.Apellido;
            await _context.SaveChangesAsync();
            return tecnicoBuscado;
        }

        public async Task<Tecnico?> ObtenerPorId(int id)
        {
            return await _context.Tecnicos.FirstOrDefaultAsync(t=>t.IdTecnico == id);
        }

        public async Task<List<Tecnico>> ObtenerTodos()
        {
            return await _context.Tecnicos.ToListAsync();
        }
    }
}
