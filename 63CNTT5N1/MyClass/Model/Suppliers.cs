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

        [Required(ErrorMessage = "Tên nhà cung cấp không để trống")]
        [Display(Name = "Tên nhà cung cấp")]
        public string Name { get; set; }

        [Display(Name = "Logo nhà cung cấp")]
        public string Image { get; set; }

        [Display(Name = "Tên rút gọn")]
        public string Slug { get; set; }

        [Display(Name = "Sắp xếp")]
        public int? Order { get; set; }

        [Display(Name = "Tên đầy đủ")]
        public string FullName { get; set; }

        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Địa chỉ website")]
        public string UrlSite { get; set; }

        [Required(ErrorMessage = "Mô tả không để trống")]
        [Display(Name = "Mô tả")]
        public string MetaDesc { get; set; }

        [Required(ErrorMessage = "Từ khóa không để trống")]
        [Display(Name = "Từ khóa")]
        public string MetaKey { get; set; }

        [Display(Name = "Người tạo")]
        public int CreateBy { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime CreateAt { get; set; }

        [Display(Name = "Người cập nhật")]
        public int UpdateBy { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime UpdateAt { get; set; }

        [Display(Name = "Trạng thái")]
        public int? Status { get; set; }
    }
}
