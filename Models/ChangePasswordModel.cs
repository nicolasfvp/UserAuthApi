using System.ComponentModel.DataAnnotations.Schema;

namespace UserAuthApi.Models
{
    public class ChangePasswordModel
    {
        [Column("senhaAtual")]
        public string SenhaAtual { get; set; } 

        [Column("senhaNova")]
        public string SenhaNova { get; set; }     
    }
}
