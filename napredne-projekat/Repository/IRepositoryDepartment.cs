using napredne_projekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace napredne_projekat.Repository
{
    /// <summary>
    /// Interfejs koji odredjuje sve operacije za manipulaciju katedrama u bazi
    /// </summary>
    public interface IRepositoryDepartment : IRepository<Department>
    {
        /// <summary>
        /// Metoda koja vraca jedan entity iz tabele na osnovu uslova koji smo zadali
        /// </summary>
        /// <param name="expression">Lambda izraz koji prosledjujemo kao uslov koji mora da se ispuni</param>
        Department FindOne(Expression<Func<Department, bool>> expression);
    }
}
