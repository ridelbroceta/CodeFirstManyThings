using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace App.Data.Entities
{
    [Table("V_States")]
    public class StateView
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StateView()
        {
            this.Requests = new HashSet<Request>();
        }

        [Column("Id")]
        [Key]
        public int StateId { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }

        public virtual CountryView Country{ get; set; }


    }


    public class StateViewConfiguration : EntityTypeConfiguration<StateView>
    {
        public StateViewConfiguration()
        {
            this.HasKey(t => t.StateId);
            this.ToTable("V_States");
        }
    }

}
