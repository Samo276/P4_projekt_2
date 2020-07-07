namespace P4Projekt_2.Baza
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pracownicy")]
    public partial class Pracownicy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pracownicy()
        {
            Czas_Pracy = new HashSet<Czas_Pracy>();
        }

        [Key]
        [StringLength(6)]
        public string Id_pracownika { get; set; }

        [Required]
        [StringLength(50)]
        public string Imie { get; set; }

        [Required]
        [StringLength(50)]
        public string Nazwisko { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data_Urodzenia { get; set; }

        [Required]
        [StringLength(50)]
        public string Adres_zamieszkania { get; set; }

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

        [Required]
        [StringLength(100)]
        public string Stanowisko { get; set; }

        [StringLength(6)]
        public string Id_zakladu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Czas_Pracy> Czas_Pracy { get; set; }

        public virtual Zaklad Zaklad { get; set; }
    }
}
