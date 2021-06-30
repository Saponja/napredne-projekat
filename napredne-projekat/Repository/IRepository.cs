using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Repository
{
    /// <summary>
    /// Interfejs u kom odredjujemo osnovne operacije koje mora da ima svaki Repositoty
    /// </summary>
    /// <remarks>The remarks</remarks>
    /// <typeparam name="T">Tip domenske klase sa kojom radi repozitori</typeparam>
    public interface IRepositoryStudent<T>
    {
        /// <summary>
        /// Metoda koja nam vraca jedan entity iz tabele na osonvu id kojeg smo prosledili
        /// </summary>
        /// <param name="id">Id entity-a kojeg zelimo da vratimo iz baze</param>
        T FindById(int id);
        /// <summary>
        /// Metoda koja nam vraca listu svih entity-a iz tabele
        /// </summary>
        List<T> GetAll();
        /// <summary>
        /// Metoda koja dodaje entity u tabelu
        /// </summary>
        /// <param name="item">Entity klase T</param>
        /// <returns>Entity klase T</returns>
        T Add(T item);
        /// <summary>
        /// Metoda koja update-uje onaj entity u tableli koji ima id koji smo proseldili
        /// </summary>
        /// <param name="item">Entity klase T</param>
        /// <param name="id">Id entity-a kojeg zelimo da updatetujemo</param>
        T Update(T item, int id);
        /// <summary>
        /// Metoda koja brise iz tabele entity ciji smo id prosledili
        /// </summary>
        /// <param name="id">Id entity-a kojeg zelimo da izbrisiemo</param>
        void Delete(int id);

    }
}
