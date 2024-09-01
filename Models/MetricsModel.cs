using System.ComponentModel.DataAnnotations.Schema;

namespace UserAuthApi.Models
{
    public class Metrics
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("orders")]
        public int Orders { get; set; }

        [Column("total")]
        public int Total { get; set; }

        [Column("stock")]
        public int Stock { get; set; }

        [Column("users")]
        public int Users { get; set; }
    }
}
