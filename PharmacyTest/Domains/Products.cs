using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyTest.Domains
{
    [Table(nameof(Products))]
    public class Products
    {
        [Key]
        public Guid IdProduct { get; set; } = Guid.NewGuid();

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage ="Nome do produto obrigario")]
        public string? Name { get; set; }

        [Column(TypeName = "DECIMAL(10,2)")]
        [Required(ErrorMessage = "Preco do produto obrigario")]
        public decimal Price { get; set; }
    }
}
