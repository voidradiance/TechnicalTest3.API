using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerName { get; set; }
        [Required]
        [MaxLength(100)]
        public string CustomerAddress { get; set; } = string.Empty;
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}