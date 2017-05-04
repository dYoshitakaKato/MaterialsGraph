namespace MaterialsGraph
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MaterialsLogDBContex : DbContext
    {
        public MaterialsLogDBContex()
            : base("name=MaterialsLogDBContex")
        {
        }

        public virtual DbSet<Models.MaterialsLog> MaterialsLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
