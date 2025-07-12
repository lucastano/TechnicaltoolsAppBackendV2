using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProyectoService.AccesoDatos.EntityFramework;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using TechnicalToolsAppBackendV2.AccesoDatos;
using TechnicalToolsAppBackendV2.AccesoDatos.EntityFramework;
using TechnicalToolsAppBackendV2.Aplicacion.CasosUso.CasosUsoAvisoEmail;
using TechnicalToolsAppBackendV2.Aplicacion.CasosUso.CasosUsoConfiguraciones;
using TechnicalToolsAppBackendV2.Aplicacion.CasosUso.CasosUsoEmpresa;
using TechnicalToolsAppBackendV2.Aplicacion.CasosUso.CasosUsoRol;
using TechnicalToolsAppBackendV2.Aplicacion.CasosUso.CasosUsoSeguridad;
using TechnicalToolsAppBackendV2.Aplicacion.CasosUso.CasosUsoTecnico;
using TechnicalToolsAppBackendV2.Aplicacion.CasosUso.CasosUsoUsuario;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoAvisosEmail;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoConfiguraciones;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoEmpresa;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoRol;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoSeguridad;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoTecnico;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoUsuario;
using TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorio;
using TechnicalToolsAppBackendV2.LogicaNegocio.IRepositorios;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TechnicalToolsContexto>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ProyectoServiceContext"));
});
// Add services to the container.
//builder.Services.AddScoped<IClienteRepositorio, ClienteEFRepositorio>();
//builder.Services.AddScoped<ITecnicoRepositorio, TecnicoEFRepositorio>();
// ID REPOSITORIOS
builder.Services.AddScoped<ITecnicoRepositorio, TecnicoRepositorio>();
builder.Services.AddScoped<IEmpresaRepositorio,EmpresaRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio,UsuarioRepositorio>();
builder.Services.AddScoped<IRolRepositorio,RolRepositorio>();
builder.Services.AddScoped<IObtenerConfiguracionGlobal,ObtenerConfiguracionGlobal>();
builder.Services.AddScoped<IObtenerConfiguracionMailServer, ObtenerConfiguracionMailServer>();
// CASOS USO REPOSITORIOS
builder.Services.AddScoped<IAgregarTecnico, AgregarTecnico>();
builder.Services.AddScoped<IObtenerTecnicoPorId,ObtenerTecnicoPorId>();
builder.Services.AddScoped<IObtenerTodosLosTecnicos,ObtenerTodosLosTecnicos>();
builder.Services.AddScoped<IAgregarEmpresa,AgregarEmpresa>();
builder.Services.AddScoped<IObtenerEmpresaPorId,ObtenerEmpresaPorId>();
builder.Services.AddScoped<IObtenerTodasLasEmpresas,ObtenerTodasLasEmpresas>();
builder.Services.AddScoped<IAgregarUsuario,AgregarUsuario>();
builder.Services.AddScoped<ICrearPasswordHash,CrearPasswordHash>();
builder.Services.AddScoped<IGenerarPasswordRandom,GenerarPasswordRandom>();
builder.Services.AddScoped<IRelTecnicoUsuarioRepositorio,RelTecnicoUsuarioRepositorio>();
builder.Services.AddScoped<IAgregarRelTecnicoUsuario,AgregarRelTecnicoUsuario>();
builder.Services.AddScoped<IObtenerRoles, ObtenerRoles>();
builder.Services.AddScoped<IObtenerRolPorCod,ObtenerRolPorCod>();
builder.Services.AddScoped<IVerificarPasswordHash, VerificarPasswordHash>();
builder.Services.AddScoped<IObtenerUsuario,ObtenerUsuario>();
builder.Services.AddScoped<IObtenerTecnicoPorUsuario, ObtenerTecnicoPorUsuario>();
builder.Services.AddScoped<ILoginUc,LoginUc>();
builder.Services.AddScoped<ICrearToken, CrearToken>();
builder.Services.AddScoped<IEnviarEmailNuevoUsuario, EnviarEmailNuevoUsuario>();
builder.Services.AddHttpClient<IConfiguracionSenderEmail, ConfiguracionSenderEmail>();
builder.Services.AddScoped<IConfiguracionGlobalRepositorio, ConfiguracionGlobalRepositorio>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opciones =>
{
    opciones.SwaggerDoc("v1", new OpenApiInfo { Title = "TechnicalTools API", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    opciones.IncludeXmlComments(xmlPath);

    opciones.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
    {
        Description = "autorizacion std mediante esquema bearer",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    opciones.MapType<IFormFile>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "binary"
    });
    opciones.OperationFilter<SecurityRequirementsOperationFilter>();

});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opciones =>
{
    opciones.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:SecretTokenKey").Value!)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
