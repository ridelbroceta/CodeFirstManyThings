using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace App.Data.Entities
{

   [Table("V_Divisions")]
    public class DivisionView
    {
        [Key]
        public int DivId { get; set; }

        public int DeptId { get; set; }

        public string DivName { get; set; }


        [ForeignKey("DeptId")]
        public virtual DepartmentView Department { get; set; }

    }

    public class DivisionViewConfiguration : EntityTypeConfiguration<DivisionView>
    {
        public DivisionViewConfiguration()
        {
            this.HasKey(t => t.DivId);
            this.ToTable("V_Divisions");
        }
    }

}
