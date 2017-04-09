using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace App.Data.Entities
{
    [Table("V_Countries")]
    public class CountryView
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CountryView()
        {
            States = new HashSet<StateView>();
        }

        [Key]
        public int CountryId { get; set; }

        [Column("CountryName")]
        public string Name { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StateView> States { get; set; }

    }

    public class CountryViewConfiguration : EntityTypeConfiguration<CountryView>
    {
        public CountryViewConfiguration()
        {
            this.HasKey(t => t.CountryId);
            this.ToTable("V_Countries");
        }
    }

}
