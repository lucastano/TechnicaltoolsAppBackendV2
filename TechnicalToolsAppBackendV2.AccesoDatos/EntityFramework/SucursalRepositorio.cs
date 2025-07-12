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
    public class SucursalRepositorio : ISucursalRepositorio
    {
        TechnicalToolsContexto contexto;
        public SucursalRepositorio(TechnicalToolsContexto context)
        {
            this.contexto = context;    

        }
        public async Task<Sucursal> Agregar(Sucursal sucursal)
        {
            if (sucursal == null) throw new Exception("Debe ingresar una sucursal");
            Sucursal sucursalBuscada = await contexto.Sucursales.FirstOrDefaultAsync(s=>s.Empresa.Id == sucursal.Empresa.Id && s.CodigoSucursal == sucursal.CodigoSucursal);
            if (sucursalBuscada != null) throw new Exception("Ya existe la sucursal");
            await contexto.Sucursales.AddAsync(sucursal);
            await contexto.SaveChangesAsync();
            return sucursal;
        }

        public async Task Eliminar(int idEmpresa, int idSucursal)
        {
            Sucursal sucursalBuscada = await contexto.Sucursales.FirstOrDefaultAsync(s=>s.Empresa.Id == idEmpresa && s.Id == idSucursal);
            if (sucursalBuscada == null) throw new Exception("La sucursal no existe");
            contexto.Remove(sucursalBuscada);
            await contexto.SaveChangesAsync();
        }

        public Task<Sucursal> Modificar(Sucursal sucursal)
        {
            // public int Id { get; set; }
            //public string CodigoSucursal { get; set; }
            //public string Direccion { get; set; }
            //public string Telefono { get; set; }
            //public string Email { get; set; }
            //public Empresa Empresa { get; set; }
            //public string? EmailServer { get; set; }
            //public string? apiKey { get; set; }
            //public string? secretKey { get; set; }
            //public bool avisosEmail { get; set; }
            //public bool avisosWsp { get; set; }
            throw new NotImplementedException();
        }

        public Task<List<Sucursal>> ObtenerSucursalesPorEmpresa(int idEmpresa)
        {
            throw new NotImplementedException();
        }

        public Task<Sucursal> ObtenerSucursalPorId(int idEmpresa, int idSucursal)
        {
            throw new NotImplementedException();
        }
    }
}
