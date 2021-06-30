using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Repository.unit_of_work
{
    public interface IUnitOfWork
    {
        public IRepositoryDepartment Departments { get; set; }
        public IRepositoryStudent Students { get; set; }
        void Commit();

        void Dispose();
        
    }
}
