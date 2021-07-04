using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Repository.unit_of_work
{
    /// <summary>
    /// Interfejs koji nam sluzi da objedimo sve repository-je i omogucava da se sve obavlja pod jednom transakcijom
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Property koji nam sluzi za pristup metodama klase RepositroyDepartment
        /// </summary>
        public IRepositoryDepartment Departments { get; set; }
        /// <summary>
        /// Property koji nam sluzi za pristup metodama klase RepositoryStudent
        /// </summary>
        public IRepositoryStudent Students { get; set; }
        /// <summary>
        /// Property koji nam sluzi za pristup metodama klase RepositorySubject
        /// </summary>
        public IRepositorySubject Subjects { get; set; }
        /// <summary>
        /// Metoda koja sluzi za cuvanje izmena koje su izvresne pod transakcijom
        /// </summary>
        void Commit();
        /// <summary>
        /// Metoda za prekid rada nad bazom
        /// </summary>
        void Dispose();
        
    }
}
