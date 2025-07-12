using Microsoft.EntityFrameworkCore;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;
using System.Reflection;



namespace TechnicalToolsAppBackendV2.AccesoDatos
{
    public class TechnicalToolsContexto:DbContext
    {
        public DbSet<ConfiguracionGlobal> ConfiguracionGlobal { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Sucursal> Sucursales  { get; set; }
       public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Tecnico> Tecnicos {  get; set; }
        public DbSet<Permiso>Permisos {  get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RelPermisoUsuario> RelPermisoUsuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        public DbSet<RelTecnicoUsuario> RelTecnicoUsuario { get; set; }

        public TechnicalToolsContexto(DbContextOptions<TechnicalToolsContexto> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<RelTecnicoUsuario>()
                 .HasOne(r => r.Tecnico)
                 .WithMany()
                 .HasForeignKey("TecnicoId") // asegúrate que esta FK exista o la defines
                 .OnDelete(DeleteBehavior.Restrict); // evita cascada

            modelBuilder.Entity<RelTecnicoUsuario>()
                .HasOne(r => r.Usuario)
                .WithMany()
                .HasForeignKey("UsuarioId") // asegúrate que esta FK exista o la defines
                .OnDelete(DeleteBehavior.Cascade); // solo una puede ser Cascade
            base.OnModelCreating(modelBuilder);
        }


    }
}
