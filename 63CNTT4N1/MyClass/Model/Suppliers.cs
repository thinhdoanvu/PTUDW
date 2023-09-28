using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Model
{
    [Table("Suppliers")]
    public class Suppliers
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Image { get; set; }

        public string Slug { get; set; }

        public int? Order { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

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
