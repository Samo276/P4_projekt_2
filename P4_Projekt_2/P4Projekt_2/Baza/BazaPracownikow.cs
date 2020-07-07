namespace P4Projekt_2.Baza
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BazaPracownikow : DbContext
    {
        public BazaPracownikow()
            : base("name=BazaPracownikow")
        {
        }

        public virtual DbSet<Pracownicy> Pracownicy { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Zaklad> Zaklad { get; set; }
        public virtual DbSet<Czas_Pracy> Czas_Pracy { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pracownicy>()
                .Property(e => e.Id_pracownika)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Pracownicy>()
                .Property(e => e.Id_zakladu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Pracownicy>()
                .HasMany(e => e.Czas_Pracy)
                .WithRequired(e => e.Pracownicy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Zaklad>()
                .Property(e => e.Id_zakladu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Czas_Pracy>()
                .Property(e => e.Id_pracownika)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Czas_Pracy>()
                .Property(e => e.Obecnosc)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
