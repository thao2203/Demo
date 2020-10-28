namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DANHMUCCON")]
    public partial class DANHMUCCON
    {
        [Key]
        [StringLength(10)]
        public string maDMC { get; set; }

        [StringLength(10)]
        public string maDM { get; set; }

        [StringLength(50)]
        public string tenDMC { get; set; }

        [StringLength(250)]
        public string moTa { get; set; }
    }
}
