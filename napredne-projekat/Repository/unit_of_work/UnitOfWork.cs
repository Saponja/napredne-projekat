using napredne_projekat.Domain;
using napredne_projekat.Repository.repo_impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Repository.unit_of_work
{
    /// <summary>
    /// Klasa koja nasledjuje interfejs IUnitOfWork i koja nam sluzi da objedimo sve repository-je i omogucava da se sve obavlja pod jednom transakcijom
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NaprednoContext context;

        /// <summary>
        /// Parametraki konstruktor koji kreira objekat klase UnitOfWork i postavlja vrednosti za context, Departments, Students i Subjects
        /// </summary>
        /// <param name="context">Objekat klase NaprednoContext</param>
        public UnitOfWork(NaprednoContext context)
        {
            this.context = context;
            Departments = new RepositoryDepartment(context);
            Students = new RepositoryStudent(context);
            Subjects = new RepositorySubject(context);
        }

        ///<inheritdoc/>
        public IRepositoryDepartment Departments { get; set; }
        ///<inheritdoc/>

        public IRepositoryStudent Students { get; set; }
        ///<inheritdoc/>

        public IRepositorySubject Subjects { get; set; }
        ///<inheritdoc/>

        public void Commit()
        {
            context.SaveChanges();
        }
        ///<inheritdoc/>

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
