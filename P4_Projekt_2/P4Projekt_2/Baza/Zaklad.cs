namespace P4Projekt_2.Baza
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Zaklad")]
    public partial class Zaklad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zaklad()
        {
            Pracownicy = new HashSet<Pracownicy>();
        }

        [Key]
        [StringLength(6)]
        public string Id_zakladu { get; set; }

        [Required]
        [StringLength(100)]
        public string Nazwa { get; set; }

        [Required]
        [StringLength(50)]
        public string Adres { get; set; }

        [Required]
        [StringLength(50)]
        public string Miasto { get; set; }

        [Required]
        [StringLength(50)]
        public string Region { get; set; }

        [Required]
        [StringLength(50)]
        public string Kraj { get; set; }

        [Required]
        [StringLength(10)]
        public string Kod_pocztowy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pracownicy> Pracownicy { get; set; }
    }
}
