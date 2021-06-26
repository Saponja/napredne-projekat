using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Domain
{
    /// <summary>
    /// Context klasa koja nam sluzi da preko EntityFramework-a povezemo domenske klase sa bazom
    /// </summary>
    public class NaprednoContext : DbContext
    {
        /// <summary>
        /// Posredna klasa studenata
        /// </summary>
        public DbSet<Student> Students { get; set; }
        /// <summary>
        /// Posredna klasa predmeta
        /// </summary>
        public DbSet<Subject> Subjects { get; set; }
        /// <summary>
        /// Posredna klasa katedri
        /// </summary>
        public DbSet<Department> Departments { get; set; }
        /// <summary>
        /// Posredna klasa pohadjanja
        /// </summary>
        public DbSet<Enrollment> Enrollments { get; set; }
        /// <summary>
        /// Metoda za konfiguraciju baze
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=napredne-projekat;");

            }
        }
        /// <summary>
        /// Metoda za definisnaje tabela, veza i ogranicenja u bazi
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>(e =>
            {
                e.HasKey(en => new { en.StudentId, en.SubjectId });
            });
        }

        /// <summary>
        /// Bezparametraski konstruktor za kreiranje objekta
        /// </summary>
        public NaprednoContext()
        {

        }
        /// <summary>
        /// Parametraski konstrukotor za kreiranje objekta
        /// </summary>
        /// <param name="options">Opcije za kreiranje contexta</param>
        public NaprednoContext(DbContextOptions options) : base(options)
        {

        }

    }
}
