namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("t1.order")]
    public partial class order
    {
        [Key]
        [Column(TypeName = "uint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ordernumber { get; set; }

        [Required]
        [StringLength(50)]
        public string customername { get; set; }

        [Required]
        [StringLength(50)]
        public string goodsname { get; set; }

        [Column(TypeName = "uint")]
        public long? goodsnumber { get; set; }

        [Required]
        public List<OrderItem> Items { get; set; }

        [Required]
        public double goodsprice { get; set; }
    }
}
