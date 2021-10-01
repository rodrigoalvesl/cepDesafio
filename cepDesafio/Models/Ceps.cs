using SQLite;

namespace cepDesafio.Models
{
    [Table("Ceps")]
    public class Ceps
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
    }
}