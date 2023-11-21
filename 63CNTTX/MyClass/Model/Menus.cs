using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Model
{
    [Table("Menus")]
    public class Menus
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên menu không để trống")]
        [Display(Name = "Tên Menu")]
        public string Name { get; set; }

        [Display(Name = "Bảng dữ liệu")]
        public int? TableID { get; set; }

        [Display(Name = "Kiểu Menu")]
        public string TypeMenu { get; set; }

        [Display(Name = "Vị trí")]
        public string Position { get; set; }

        [Display(Name = "Liên kết")]
        public string Link { get; set; }

        [Display(Name = "Cấp cha")]
        public int? ParentID { get; set; }

        [Display(Name = "Sắp xếp")]
        public int? Order { get; set; }

        [Display(Name = "Người tạo")]
        [Required(ErrorMessage = "Người tạo không để trống")]
        public DateTime CreateAt { get; set; }

        [Display(Name = "Người tạo")]
        [Required(ErrorMessage = "Người tạo không để trống")]
        public int CreateBy { get; set; }

        [Display(Name = "Ngày cập nhật")]
        [Required(ErrorMessage = "Ngày cập nhật không để trống")]
        public DateTime UpdateAt { get; set; }

        [Display(Name = "Người cập nhật")]
        [Required(ErrorMessage = "Người cập nhật không để trống")]
        public int UpdateBy { get; set; }

        [Display(Name = "Trạng thái")]
        [Required(ErrorMessage = "Trạng thái không để trống")]
        public int Status { get; set; }

    }
}
