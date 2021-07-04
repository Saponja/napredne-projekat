using napredne_projekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace napredne_projekat.Repository
{
    /// <summary>
    /// Interfejs koji odredjuje sve operacije za manipulaciju studentima u bazi
    /// </summary>
    public interface IRepositoryStudent : IRepository<Student>
    {
        /// <summary>
        /// Metoda koja prima lambda izraz kao uslov i vraca listu studenata koji zadovoljavaju taj uslov
        /// </summary>
        /// <param name="func"></param>
        List<Student> GetStudentsByGrade(Expression<Func<Student, bool>> func);
        /// <summary>
        /// Metoda koja prima index i vraca studenta sa tim index-om
        /// </summary>
        /// <param name="index">Index studenta kao String</param>
        Student GetStudentByIndex(string index);

    }
}
