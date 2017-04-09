using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace App.Data.Entities
{
    [Table("V_Departments")]
    public class DepartmentView
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DepartmentView()
        {
            Divisions = new HashSet<DivisionView>();
        }

        [Key]
        public int DeptId { get; set; }

        public string DeptName { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DivisionView> Divisions { get; set; }

    }

    public class DepartmentViewConfiguration : EntityTypeConfiguration<DepartmentView>
    {
        public DepartmentViewConfiguration()
        {
            this.HasKey(t => t.DeptId);
            this.ToTable("V_Departments");
        }
    }

}
