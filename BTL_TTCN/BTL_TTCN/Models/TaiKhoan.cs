namespace BTL_TTCN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        [StringLength(50)]
        [Required(ErrorMessage = "Mã tài khoản không được để trống")]
        [DisplayName("Mã tài khoản")]
        public string MaTaiKhoan { get; set; }

        [StringLength(50)]
        public string TenNguoiNhan { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Email không được để trống")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DisplayName("Mật khẩu")]
        public string MatKhau { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }
    }
}
