namespace P4Projekt_2.Baza
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Czas_Pracy
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(6)]
        public string Id_pracownika { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime Data_dnia { get; set; }

        [StringLength(1)]
        public string Obecnosc { get; set; }

        public TimeSpan? Godzina_rozpoczecia_zmiany { get; set; }

        public TimeSpan? Godzina_zakonczenia_zmiany { get; set; }

        public virtual Pracownicy Pracownicy { get; set; }
    }
}
