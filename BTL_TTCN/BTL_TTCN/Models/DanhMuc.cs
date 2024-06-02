namespace BTL_TTCN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;
    [Table("DanhMuc")]
    public partial class DanhMuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMuc()
        {
            TheLoais = new HashSet<TheLoai>();
        }

        [Key]
        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập mã danh mục")]
        public string MaDanhMuc { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập tên danh mục")]
        public string TenDanhMuc { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập mô tả")]
        public string MoTa { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TheLoai> TheLoais { get; set; }
    }
}
