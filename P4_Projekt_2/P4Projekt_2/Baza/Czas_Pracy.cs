namespace P4Projekt_2.Baza
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Czas_Pracy
    {
        public Czas_Pracy()
        {
        }

        public Czas_Pracy(string id_pracownika, DateTime data_dnia, string obecnosc, TimeSpan? godzina_rozpoczecia_zmiany, TimeSpan? godzina_zakonczenia_zmiany)
        {
            Id_pracownika = id_pracownika;
            Data_dnia = data_dnia;
            Obecnosc = obecnosc;
            Godzina_rozpoczecia_zmiany = godzina_rozpoczecia_zmiany;
            Godzina_zakonczenia_zmiany = godzina_zakonczenia_zmiany;
        }

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
