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
            Sucursal? sucursalBuscada = await contexto.Sucursales.FirstOrDefaultAsync(s=>s.Empresa.Id == sucursal.Empresa.Id && s.CodigoSucursal == sucursal.CodigoSucursal);
            if (sucursalBuscada != null) throw new Exception("Ya existe la sucursal");
            await contexto.Sucursales.AddAsync(sucursal);
            await contexto.SaveChangesAsync();
            return sucursal;
        }

        public async Task Eliminar(int idEmpresa, int idSucursal)
        {
            Sucursal? sucursalBuscada = await contexto.Sucursales.FirstOrDefaultAsync(s=>s.Empresa.Id == idEmpresa && s.Id == idSucursal);
            if (sucursalBuscada == null) throw new Exception("La sucursal no existe");
            contexto.Remove(sucursalBuscada);
            await contexto.SaveChangesAsync();
        }

        public async Task<Sucursal> Modificar(Sucursal sucursal)
        {
            Sucursal? sucursalBuscada = await contexto.Sucursales.FirstOrDefaultAsync(s => s.Empresa.Id == sucursal.Empresa.Id && s.Id == sucursal.Id);
            if (sucursalBuscada == null) throw new Exception("La sucursal no existe");
            sucursalBuscada.Direccion = sucursal.Direccion;
            sucursalBuscada.Telefono = sucursal.Telefono;
            sucursalBuscada.avisosWsp = sucursal.avisosWsp;
            sucursalBuscada.avisosEmail = sucursal.avisosEmail;
            await contexto.SaveChangesAsync();
            return sucursalBuscada;
        }

        public Task<List<Sucursal?>> ObtenerSucursalesPorEmpresa(int idEmpresa)
        {
            return contexto.Sucursales.Where(s => s.Empresa.Id == idEmpresa).ToListAsync();
        }

        public Task<Sucursal?> ObtenerSucursalPorId(int idEmpresa, int idSucursal)
        {
            return contexto.Sucursales.FirstOrDefaultAsync(s => s.Empresa.Id == idEmpresa && s.Id == idSucursal);
        }
    }
}
