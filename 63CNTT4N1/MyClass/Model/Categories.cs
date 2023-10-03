using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Model
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tên loại hàng")]
        public string Name { get; set; }

        [Display(Name = "Tên rút gọn")]
        public string Slug { get; set; }

        [Display(Name = "Cấp cha")]
        public int? ParentId { get; set; }

        [Display(Name = "Sắp xếp")]
        public int? Order { get; set; }

        [Required]
        [Display(Name = "Mô tả")]
        public string MetaDesc { get; set; }

        [Required]
        [Display(Name = "Từ khóa")]
        public string MetaKey { get; set; }

        [Required]
        [Display(Name = "Người tạo")]
        public int CreateBy { get; set; }

        [Required]
        [Display(Name = "Ngày tạo")]
        public DateTime CreateAt { get; set; }

        [Required]
        [Display(Name = "Người cập nhật")]
        public int UpdateBy { get; set; }

        [Required]
        [Display(Name = "Ngày cập nhật")]
        public DateTime UpdateAt { get; set; }

        [Required]
        [Display(Name = "Trạng thái")]
        public int Status { get; set; }

    }
}
