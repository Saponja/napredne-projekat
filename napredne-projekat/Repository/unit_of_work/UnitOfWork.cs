using napredne_projekat.Domain;
using napredne_projekat.Repository.repo_impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Repository.unit_of_work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NaprednoContext context;

        public UnitOfWork(NaprednoContext context)
        {
            this.context = context;
            Departments = new RepositoryDepartment(context);
        }

        public IRepositoryDepartment Departments { get; set; }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
