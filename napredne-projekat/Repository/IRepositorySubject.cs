using napredne_projekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace napredne_projekat.Repository
{
    /// <summary>
    /// Interfejs koji odredjuje sve operacije za manipulaciju predmetim u bazi
    /// </summary>
    public interface IRepositorySubject : IRepository<Subject>
    {
        /// <summary>
        /// Metoda koja prima lambda izraz kao uslov i vraca predmet koji zadovoljava taj uslov
        /// </summary>
        /// <param name="func">Uslov kao lambda izraz</param>
        Subject FindOne(Expression<Func<Subject, bool>> func);
    }
}
