namespace J2.API.Models
{
    
    public class Appsettings
    {
        public Jwt Jwt { get; set; }
    }

    public class Jwt
    {
        public string Issuer { get; set; }
        public int ValidationDurtationMinutes { get; set; }
        public string ClientId { get; set; }
    }

}
