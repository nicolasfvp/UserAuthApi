using System.ComponentModel.DataAnnotations.Schema;

namespace UserAuthApi.Models
{
    public class OrderIdRequest
    {
        [Column("id")]
        public int Id { get; set; }  
          
    }
}
