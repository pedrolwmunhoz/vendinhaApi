namespace vendinhaApi.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Cpf { get; set; }
        public string Birth_date { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

    }
}
