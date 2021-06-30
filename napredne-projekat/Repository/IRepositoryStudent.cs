using napredne_projekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace napredne_projekat.Repository
{
    ///<inheritdoc/>
    public interface IRepositoryStudent : IRepository<Student>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        List<Student> GetStudentsByGrade(Expression<Func<Student, bool>> func);
        Student GetStudentByIndex(string index);

    }
}
