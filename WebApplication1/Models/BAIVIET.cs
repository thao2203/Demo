namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BAIVIET")]
    public partial class BAIVIET
    {
        [Key]
        [StringLength(10)]
        public string maBV { get; set; }

        [StringLength(10)]
        public string taiKhoanUs { get; set; }

        [StringLength(10)]
        public string maBL { get; set; }

        [StringLength(10)]
        public string maDMC { get; set; }

        [StringLength(250)]
        public string tieuDe { get; set; }

        public string noiDung { get; set; }

        [Column(TypeName = "image")]
        public byte[] hinhAnh { get; set; }

        public DateTime? thoiGianDang { get; set; }

        public bool? trangThai { get; set; }
    }
}
