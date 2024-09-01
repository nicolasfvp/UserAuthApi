using System.ComponentModel.DataAnnotations.Schema;

namespace UserAuthApi.Models
{
    public class Orders
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("value")]
        public string Value { get; set; }

        [Column("date")]
        public string Date { get; set; }

        [Column("paymentMethod")]
        public string PaymentMethod { get; set; }

        [Column("status")]
        public string Status { get; set; }
    }
}
