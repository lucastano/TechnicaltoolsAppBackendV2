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
    public class ClienteRepositorio : IClienteRepositorio
    {
        TechnicalToolsContexto _context;
        public ClienteRepositorio( TechnicalToolsContexto context)
        {
            _context = context;
        }
        public async Task<Cliente> Agregar(Cliente cliente)
        {
            if (cliente == null) throw new Exception("Debe ingresar cliente");
            Cliente clienteBuscado = await _context.Clientes.FirstOrDefaultAsync(c=>c.Ci == cliente.Ci);
            if (clienteBuscado != null) throw new Exception("El cliente ya existe");
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;

        }

        public Task Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> Modificar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> ObtenerPorCi(string ci)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cliente>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
