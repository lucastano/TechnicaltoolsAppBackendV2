using Microsoft.EntityFrameworkCore;
using System;   
using TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorio;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.AccesoDatos.EntityFramework
{
    public class EmpresaRepositorio : IEmpresaRepositorio
    {
        TechnicalToolsContexto context;
        public EmpresaRepositorio( TechnicalToolsContexto context)
        {
            this.context = context;
        }
        public async Task<Empresa> Agregar(Empresa empresa)
        {
            if (empresa == null) throw new Exception("Debe ingresar empresa");
            Empresa? emp = await context.Empresas.FirstOrDefaultAsync(e => e.NumeroRUT == empresa.NumeroRUT);
            if (emp != null) throw new Exception("La empresa ya existe");
            await context.Empresas.AddAsync(empresa);
            await context.SaveChangesAsync();
            return empresa;
        }

        public async Task Eliminar(int id)
        {
            Empresa empresa = await context.Empresas.FirstOrDefaultAsync(e=>e.Id == id);
            context.Empresas.Remove(empresa);
            await context.SaveChangesAsync();
        }

        public async Task<Empresa> Modificar(Empresa empresa)
        {
            Empresa emp = await context.Empresas.FirstOrDefaultAsync(e => e.Id == empresa.Id);
            emp.NumeroRUT = empresa.NumeroRUT;
            emp.RazonSocial = empresa.RazonSocial;
            emp.PoliticasEmpresa = empresa.PoliticasEmpresa;
            emp.Foto = empresa.Foto;
            await context.SaveChangesAsync();
            return emp;
        }

        public async Task<Empresa> ObtenerPorId(int id)
        {
            return await context.Empresas.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Empresa>> ObtenerTodas()
        {
            return await context.Empresas.ToListAsync();
        }
    }
}
