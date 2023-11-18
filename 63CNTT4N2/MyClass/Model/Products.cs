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

        [Required(ErrorMessage = "Mã loại SP không để trống")]
        [Display(Name = "Mã loại SP")]
        public int CatId { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không để trống")]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mã nhà cung cấp không để trống")]
        [Display(Name = "Mã nhà cung cấp")]
        public int SupplierId { get; set; }

        [Display(Name = "Tên rút gọn")]
        public string Slug { get; set; }

        [Display(Name = "Hình ảnh")]
        public string Img { get; set; }

        [Required(ErrorMessage = "Giá nhập không để trống")]
        [Display(Name = "Giá nhập")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Giá bán không để trống")]
        [Display(Name = "Giá bán")]
        public decimal SalePrice { get; set; }

        [Required(ErrorMessage = "Số lượng không để trống")]
        [Display(Name = "Số lượng")]
        public int Qty { get; set; }

        [Required(ErrorMessage = "Mô tả không để trống")]
        [Display(Name = "Mô tả")]
        public string MetaDesc { get; set; }

        [Required(ErrorMessage = "Từ khóa không để trống")]
        [Display(Name = "Từ khóa")]
        public string MetaKey { get; set; }

        [Required(ErrorMessage = "Người tạo không để trống")]
        [Display(Name = "Người tạo")]
        public int CreateBy { get; set; }

        [Required(ErrorMessage = "Ngày tạo không để trống")]
        [Display(Name = "Ngày tạo")]
        public DateTime CreateAt { get; set; }

        [Required(ErrorMessage = "Người cập nhật không để trống")]
        [Display(Name = "Người cập nhật")]
        public int UpdateBy { get; set; }

        [Required(ErrorMessage = "Ngày cập nhật không để trống")]
        [Display(Name = "Ngày cập nhật")]
        public DateTime UpdateAt { get; set; }

        [Required(ErrorMessage = "Trạng thái")]
        [Display(Name = "Trạng thái")]
        public int? Status { get; set; }
    }
}
