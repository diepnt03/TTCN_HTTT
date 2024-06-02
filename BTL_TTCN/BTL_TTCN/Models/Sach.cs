namespace BTL_TTCN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [Key]
        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập mã sách")]

        public string MaSach { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập mã sách")]

        public string TenSach { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng chọn ảnh minh họa")]

        public string AnhMinhHoa { get; set; }

        [Column(TypeName = "money")]
        [Required(ErrorMessage = "Vui lòng nhập giá bán")]

        public decimal? GiaBan { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số lượng")]

        public double? SoLuong { get; set; }

        [StringLength(50)]
        public string DanhGia { get; set; }

        [StringLength(50)]
        public string MaTheLoai { get; set; }

        public virtual TheLoai TheLoai { get; set; }
    }
}
