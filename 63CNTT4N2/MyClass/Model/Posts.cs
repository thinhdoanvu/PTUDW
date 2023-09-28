using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Model
{
    [Table("Posts")]
    public class Posts
    {
        [Key]
        public int Id { get; set; }

        public int? TopId { get; set; }

        [Required]
        public string Tittle { get; set; }

        public string Slug { get; set; }

        public string Detail { get; set; }

        public string Img { get; set; }

        public string PostType { get; set; }

        [Required]
        public string MetaDesc { get; set; }

        [Required]
        public string MetaKey { get; set; }

        public int CreateBy { get; set; }

        public DateTime CreateAt { get; set; }

        public int UpdateBy { get; set; }

        public DateTime UpdateAt { get; set; }

        public int Status { get; set; }
    }
}
