using System.Text.RegularExpressions;



namespace TechnicalToolsAppBackendV2.LogicaNegocio.Modelo.ValueObjects
{
    public class EmailVO:IEquatable<EmailVO>
    {
        public string Value { get;}

        private EmailVO(string email) 
        {
        this.Value = email;
        }

        public static EmailVO Crear(string EmailRecibido)
        {
            string Email = EmailRecibido.ToLower();
            string pattern = @"^[^@]+@[^@]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            bool valido = regex.IsMatch(Email);

            if (!valido) throw new Exception("Email no valido");

            return new EmailVO(Email);

           

        }

        public bool Equals(EmailVO? other)
        {
            if(other == null) return false; 
            return Value.Equals(other.Value);
        }
    }
}
