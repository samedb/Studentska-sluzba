using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentskaSluzba.Models
{
    public partial class StudentskaSluzbaDBContext : DbContext
    {
        public StudentskaSluzbaDBContext()
        {
        }

        public StudentskaSluzbaDBContext(DbContextOptions<StudentskaSluzbaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Departman> Departman { get; set; }
        public virtual DbSet<Ispit> Ispit { get; set; }
        public virtual DbSet<IspitniRok> IspitniRok { get; set; }
        public virtual DbSet<Kandidat> Kandidat { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<Ocena> Ocena { get; set; }
        public virtual DbSet<Predmet> Predmet { get; set; }
        public virtual DbSet<PrijemniIspit> PrijemniIspit { get; set; }
        public virtual DbSet<Profesor> Profesor { get; set; }
        public virtual DbSet<RadiNaDepartmanu> RadiNaDepartmanu { get; set; }
        public virtual DbSet<Referent> Referent { get; set; }
        public virtual DbSet<RezultatPrijemnog> RezultatPrijemnog { get; set; }
        public virtual DbSet<SlusaPredmet> SlusaPredmet { get; set; }
        public virtual DbSet<Smer> Smer { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=StudentskaSluzbaDB;Trusted_Connection=False;User Id=sa; Password = sifra123; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Departman>(entity =>
            {
                entity.HasKey(e => e.IdDepartmana);

                entity.Property(e => e.IdDepartmana).HasColumnName("id_departmana");

                entity.Property(e => e.IdSefaDepartmana).HasColumnName("id_sefa_departmana");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasColumnName("naziv")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSefaDepartmanaNavigation)
                    .WithMany(p => p.Departman)
                    .HasForeignKey(d => d.IdSefaDepartmana)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departman_Profesor");
            });

            modelBuilder.Entity<Ispit>(entity =>
            {
                entity.HasKey(e => e.IdIspita)
                    .HasName("PK__Ispit__216561D00B9AE0E4");

                entity.Property(e => e.IdIspita).HasColumnName("id_ispita");

                entity.Property(e => e.BrojIndeksaStudenta).HasColumnName("broj_indeksa_studenta");

                entity.Property(e => e.Godina).HasColumnName("godina");

                entity.Property(e => e.IdPredmeta).HasColumnName("id_predmeta");

                entity.Property(e => e.NazivRoka)
                    .IsRequired()
                    .HasColumnName("naziv_roka")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BrojIndeksaStudentaNavigation)
                    .WithMany(p => p.Ispit)
                    .HasForeignKey(d => d.BrojIndeksaStudenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ispit_Student");

                entity.HasOne(d => d.IdPredmetaNavigation)
                    .WithMany(p => p.Ispit)
                    .HasForeignKey(d => d.IdPredmeta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ispit_Predmet");
            });

            modelBuilder.Entity<IspitniRok>(entity =>
            {
                entity.HasKey(e => new { e.Godina, e.NazivRoka })
                    .HasName("PK__IspitniR__464FF33C02CA3194");

                entity.Property(e => e.Godina).HasColumnName("godina");

                entity.Property(e => e.NazivRoka)
                    .HasColumnName("naziv_roka")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kandidat>(entity =>
            {
                entity.HasKey(e => e.Jmbg);

                entity.Property(e => e.Jmbg)
                    .HasColumnName("JMBG")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Adresa)
                    .IsRequired()
                    .HasColumnName("adresa")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumRodjenja)
                    .HasColumnName("datum_rodjenja")
                    .HasColumnType("date");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasColumnName("ime")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NazivSrednjeSkole)
                    .IsRequired()
                    .HasColumnName("naziv_srednje_skole")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pol)
                    .IsRequired()
                    .HasColumnName("pol")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasColumnName("prezime")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProsekUSrednjoj).HasColumnName("prosek_u_srednjoj");
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usertype)
                    .IsRequired()
                    .HasColumnName("usertype")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ocena>(entity =>
            {
                entity.HasKey(e => e.IdIspita)
                    .HasName("PK__Ocena__216561D00292AFE5");

                entity.Property(e => e.IdIspita)
                    .HasColumnName("id_ispita")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ocena1).HasColumnName("ocena");

                entity.HasOne(d => d.IdIspitaNavigation)
                    .WithOne(p => p.Ocena)
                    .HasForeignKey<Ocena>(d => d.IdIspita)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ocena_Ispit");
            });

            modelBuilder.Entity<Predmet>(entity =>
            {
                entity.HasKey(e => e.IdPredmeta)
                    .HasName("PK__Predmet__5BF3A8BE6B0C1B2B");

                entity.Property(e => e.IdPredmeta).HasColumnName("id_predmeta");

                entity.Property(e => e.Espb).HasColumnName("ESPB");

                entity.Property(e => e.IdProfesora).HasColumnName("id_profesora");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasColumnName("naziv")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProfesoraNavigation)
                    .WithMany(p => p.Predmet)
                    .HasForeignKey(d => d.IdProfesora)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Predmet_Profesor");
            });

            modelBuilder.Entity<PrijemniIspit>(entity =>
            {
                entity.HasKey(e => e.IdPrijemnogIspita)
                    .HasName("PK__Prijemni__A4D71D348E37C6E4");

                entity.Property(e => e.IdPrijemnogIspita).HasColumnName("id_prijemnog_ispita");

                entity.Property(e => e.Godina).HasColumnName("godina");

                entity.Property(e => e.IdSmera).HasColumnName("id_smera");

                entity.Property(e => e.JmbgKandidata)
                    .IsRequired()
                    .HasColumnName("JMBG_kandidata")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NazivRoka)
                    .IsRequired()
                    .HasColumnName("naziv_roka")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSmeraNavigation)
                    .WithMany(p => p.PrijemniIspit)
                    .HasForeignKey(d => d.IdSmera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrijemniIspit_Smer");

                entity.HasOne(d => d.JmbgKandidataNavigation)
                    .WithMany(p => p.PrijemniIspit)
                    .HasForeignKey(d => d.JmbgKandidata)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrijemniIspit_Kandidat");
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => e.IdProfesora)
                    .HasName("PK__Profesor__BA6DFEB1E3D8F630");

                entity.Property(e => e.IdProfesora).HasColumnName("id_profesora");

                entity.Property(e => e.DatumRodjenja)
                    .HasColumnName("datum_rodjenja")
                    .HasColumnType("date");

                entity.Property(e => e.IdSmera).HasColumnName("id_smera");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasColumnName("ime")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Jmbg)
                    .IsRequired()
                    .HasColumnName("JMBG")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Pol)
                    .IsRequired()
                    .HasColumnName("pol")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasColumnName("prezime")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RadiNaDepartmanu>(entity =>
            {
                entity.HasKey(e => new { e.IdProfesora, e.IdDepartmana });

                entity.Property(e => e.IdProfesora).HasColumnName("id_profesora");

                entity.Property(e => e.IdDepartmana).HasColumnName("id_departmana");

                entity.Property(e => e.DatumZaposlenja)
                    .HasColumnName("datum_zaposlenja")
                    .HasColumnType("date");

                entity.HasOne(d => d.IdDepartmanaNavigation)
                    .WithMany(p => p.RadiNaDepartmanu)
                    .HasForeignKey(d => d.IdDepartmana)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RadiNaDepartmanu_Departman");

                entity.HasOne(d => d.IdProfesoraNavigation)
                    .WithMany(p => p.RadiNaDepartmanu)
                    .HasForeignKey(d => d.IdProfesora)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RadiNaDepartmanu_Profesor");
            });

            modelBuilder.Entity<Referent>(entity =>
            {
                entity.HasKey(e => e.UsernameReferenta);

                entity.Property(e => e.UsernameReferenta)
                    .HasColumnName("username_referenta")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Adresa)
                    .HasColumnName("adresa")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatumRodjenja)
                    .HasColumnName("datum_rodjenja")
                    .HasColumnType("date");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasColumnName("ime")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Jmbg)
                    .IsRequired()
                    .HasColumnName("JMBG")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Pol)
                    .IsRequired()
                    .HasColumnName("pol")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasColumnName("prezime")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsernameReferentaNavigation)
                    .WithOne(p => p.Referent)
                    .HasForeignKey<Referent>(d => d.UsernameReferenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Referent_Korisnik");
            });

            modelBuilder.Entity<RezultatPrijemnog>(entity =>
            {
                entity.HasKey(e => e.IdPrijemnog)
                    .HasName("PK__Rezultat__07C6A04675E0A1EB");

                entity.Property(e => e.IdPrijemnog)
                    .HasColumnName("id_prijemnog")
                    .ValueGeneratedNever();

                entity.Property(e => e.BrojBodova).HasColumnName("broj_bodova");

                entity.HasOne(d => d.IdPrijemnogNavigation)
                    .WithOne(p => p.RezultatPrijemnog)
                    .HasForeignKey<RezultatPrijemnog>(d => d.IdPrijemnog)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RezultatPrijemnog_PrijemniIspit");
            });

            modelBuilder.Entity<SlusaPredmet>(entity =>
            {
                entity.HasKey(e => new { e.IdPredmeta, e.BrojIndeksaStudenta });

                entity.Property(e => e.IdPredmeta).HasColumnName("id_predmeta");

                entity.Property(e => e.BrojIndeksaStudenta).HasColumnName("broj_indeksa_studenta");

                entity.HasOne(d => d.BrojIndeksaStudentaNavigation)
                    .WithMany(p => p.SlusaPredmet)
                    .HasForeignKey(d => d.BrojIndeksaStudenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SlusaPredmet_Student");

                entity.HasOne(d => d.IdPredmetaNavigation)
                    .WithMany(p => p.SlusaPredmet)
                    .HasForeignKey(d => d.IdPredmeta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SlusaPredmet_Predmet");
            });

            modelBuilder.Entity<Smer>(entity =>
            {
                entity.HasKey(e => e.IdSmera);

                entity.Property(e => e.IdSmera)
                    .HasColumnName("id_smera")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdDepartmana).HasColumnName("id_departmana");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasColumnName("naziv")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsernameReferenta)
                    .IsRequired()
                    .HasColumnName("username_referenta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDepartmanaNavigation)
                    .WithMany(p => p.Smer)
                    .HasForeignKey(d => d.IdDepartmana)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Smer_Departman");

                entity.HasOne(d => d.UsernameReferentaNavigation)
                    .WithMany(p => p.Smer)
                    .HasForeignKey(d => d.UsernameReferenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Smer_Referent");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.BrojIndeksa)
                    .HasName("PK__Student__CEC09B1CF079D53A");

                entity.Property(e => e.BrojIndeksa).HasColumnName("broj_indeksa");

                entity.Property(e => e.DatumRodjenja)
                    .HasColumnName("datum_rodjenja")
                    .HasColumnType("date");

                entity.Property(e => e.IdSmera).HasColumnName("id_smera");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasColumnName("ime")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Jmbg)
                    .IsRequired()
                    .HasColumnName("JMBG")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Pol)
                    .IsRequired()
                    .HasColumnName("pol")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasColumnName("prezime")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSmeraNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.IdSmera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Smer");
            });
        }
    }
}
