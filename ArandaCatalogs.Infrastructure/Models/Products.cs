namespace ArandaCatalogs.Infrastructure.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Products")]
    public class Products
    {
        [Key]
        [Column(Order = 0)]
        public Guid Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Description { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid Category_Id { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
    }
}
