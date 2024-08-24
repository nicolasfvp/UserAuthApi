using System.ComponentModel.DataAnnotations.Schema;

namespace UserAuthApi.Models
{
    public class LoginModel
    {
        [Column("email")]
        public string Email { get; set; }  
          
        [Column("senha")]
        public string Senha { get; set; } 
    }
}
