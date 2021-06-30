using napredne_projekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace napredne_projekat.Repository
{
    public interface IRepositorySubject : IRepository<Subject>
    {
        Subject FindOne(Expression<Func<Subject, bool>> func);
    }
}
