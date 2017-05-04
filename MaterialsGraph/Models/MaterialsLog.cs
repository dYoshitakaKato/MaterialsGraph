namespace MaterialsGraph.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MaterialsLog")]
    public partial class MaterialsLog
    {
        [Key]
        [Column(TypeName = "date")]
        public DateTime InsertDate { get; set; }

        public int? Fuel { get; set; }

        public int? Ammunition { get; set; }

        public int? Steel { get; set; }

        public int? Bauxite { get; set; }

        public int? DevelopmentMaterials { get; set; }

        public int? InstantRepairMaterials { get; set; }

        public int? InstantBuildMaterials { get; set; }

        public int? ImprovementMaterials { get; set; }
    }
}
