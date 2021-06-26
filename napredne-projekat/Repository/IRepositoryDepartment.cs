using napredne_projekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace napredne_projekat.Repository
{
    public interface IRepositoryDepartment : IRepository<Department>
    {
        Department FindOne(Expression<Func<Department, bool>> expression);
    }
}
