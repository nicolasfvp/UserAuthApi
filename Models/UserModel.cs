using System.ComponentModel.DataAnnotations.Schema;

namespace UserAuthApi.Models
{
    public class User
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("senha")]
        public string Senha { get; set; }
    }
}
