namespace BTL_TTCN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [Key]
        [StringLength(50)]
        [Required(ErrorMessage = "Mã sách không được để trống")]
        [DisplayName("Mã sách")]
        public string MaSach { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Tên sách không được để trống")]
        [DisplayName("Tên sách")]
        public string TenSach { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Ảnh minh họa không được để trống")]
        [DisplayName("Ảnh minh họa")]
        public string AnhMinhHoa { get; set; }

        [Column(TypeName = "money")]
        [Required(ErrorMessage = "Giá bán không được để trống")]
        [DisplayName("Giá bán")]
        public decimal? GiaBan { get; set; }

        [Required(ErrorMessage = "Số lượng không được để trống")]
        [DisplayName("Số lượng")]
        public double? SoLuong { get; set; }

        [StringLength(50)]
        [DisplayName("Đánh giá")]
        public string DanhGia { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Mã thể loại không được để trống")]
        [DisplayName("Mã Thể Loại")]
        public string MaTheLoai { get; set; }

        public virtual TheLoai TheLoai { get; set; }
    }
}
