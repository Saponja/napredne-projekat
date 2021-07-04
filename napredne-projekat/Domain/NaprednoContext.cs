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
        
        ///<inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=napredne-projekat;");

            }
        }
        ///<inheritdoc/>
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
        /// Parametraski konstrukotor koji kreira objekat i postavlja pocetne opcije
        /// </summary>
        /// <param name="options">Opcije za kreiranje contexta</param>
        public NaprednoContext(DbContextOptions options) : base(options)
        {

        }

    }
}
