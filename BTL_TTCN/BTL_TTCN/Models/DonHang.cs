namespace BTL_TTCN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [Key]
        [StringLength(50)]
        public string MaDonHang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayLap { get; set; }

        [StringLength(50)]

        public string MaTaiKhoan { get; set; }

        [StringLength(50)]

        public string ThanhToan { get; set; }

        [StringLength(50)]
        public string GiaoHang { get; set; }

        [Column(TypeName = "money")]
        public decimal? TongTien { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
