using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoAvisosEmail;
using TechnicalToolsAppBackendV2.Aplicacion.ICasosUso.ICasosUsoConfiguraciones;
using TechnicalToolsAppBackendV2.LogicaNegocio;
using TechnicalToolsAppBackendV2.LogicaNegocio.Modelo;

namespace TechnicalToolsAppBackendV2.Aplicacion.CasosUso.CasosUsoAvisoEmail
{
    public class EnviarEmailNuevoUsuario : IEnviarEmailNuevoUsuario
    {

        //apikey y secretkey son datos del email de la empresa, en este ejemplo usa el de la sucursal, pero vamos a hacer de empresa 
        private readonly IObtenerConfiguracionMailServer mailServer;

        public EnviarEmailNuevoUsuario(IObtenerConfiguracionMailServer mailServer)
        {
            this.mailServer = mailServer;

        }
        public async Task Ejecutar(Usuario usuario,Tecnico tecnico, string password)
        {
            ObjetoMailServer config = await mailServer.Ejecutar();
            SmtpClient smtp = new SmtpClient("in.mailjet.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(config.apiKey, config.secretKey),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
            };
            string fromName = usuario.Empresa.NombreFantasia;
            // aca va el email de la empresa
            string fromEmail = usuario.Empresa.Email;
            string toName = tecnico.Nombre;
            string toEmail = usuario.Email;
            string subject = "Creacion de usuario";
            string body = "";
            subject = "Bienvenido " + tecnico.Nombre + " "+tecnico.Apellido;
            body = $@"
                 <html>
                 <body>
                     <p>Se registro como tecnico en {usuario.Empresa.NombreFantasia}</strong></p>
                     <p>Su clave de acceso es: {password} </strong></p>
                     <p>Su rol: {usuario.Rol.RolDescripcion}</strong></p>
                     <p>Puede cambiar su contrasena desde el panel de usuario</strong></p>
                 </body>
                 </html>";
            bool isHtml = true;
            MailMessage mailMessage = new MailMessage()
            {
                From = new MailAddress(fromEmail, fromName),
                Subject = subject,
                Body = body,
                IsBodyHtml = isHtml
            };
            mailMessage.To.Add(new MailAddress(toEmail, toName));
            await smtp.SendMailAsync(mailMessage);

        }

    }
}
