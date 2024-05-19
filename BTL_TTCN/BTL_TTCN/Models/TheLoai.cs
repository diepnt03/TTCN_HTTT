namespace BTL_TTCN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TheLoai")]
    public partial class TheLoai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TheLoai()
        {
            Saches = new HashSet<Sach>();
        }

        [Key]
        [StringLength(50)]
        [Required(ErrorMessage = "Mã thể loại không được để trống")]
        [DisplayName("Mã thể loại")]
        public string MaTheLoai { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Tên thể loại không được để trống")]
        [DisplayName("Tên thể loại")]
        public string TenTheLoai { get; set; }

        [StringLength(50)]
        public string MoTaTheLoai { get; set; }

        [StringLength(50)]
        public string MaDanhMuc { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sach> Saches { get; set; }
    }
}
