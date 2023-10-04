using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Model
{
    [Table("Products")]
    public class Products
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CatID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Supplier { get; set; }

        public string Slug { get; set; }

        [Required]
        public string Detail { get; set; }

        public string Image { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal SalePrice { get; set; }

        public decimal Amount { get; set; }

        [Required]
        public string MetaDesc { get; set; }

        [Required]
        public string MetaKey { get; set; }

        [Required]
        public int CreateBy { get; set; }

        [Required]
        public DateTime CreateAt { get; set; }

        [Required]
        public int UpdateBy { get; set; }

        [Required]
        public DateTime UpdateAt { get; set; }

        [Required]
        public int Status { get; set; }

    }
}
