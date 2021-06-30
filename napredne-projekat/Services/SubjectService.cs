using napredne_projekat.Domain;
using napredne_projekat.Exeptions.cs;
using napredne_projekat.Repository.unit_of_work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace napredne_projekat.Services
{
    public class SubjectService
    {
        private IUnitOfWork uow;

        public SubjectService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public List<Subject> GetAll()
        {
            return uow.Subjects.GetAll();
        }

        public Subject FindById(int id)
        {
            return uow.Subjects.FindById(id);
        }

        public Subject UpdateSubject(Subject subject, int id)
        {
            if(subject == null)
            {
                throw new NullReferenceException();
            }

            Subject s =  uow.Subjects.Update(subject, id);
            uow.Commit();
            return s;
        }

        public Subject AddSubject(Subject subject)
        {
            if(subject == null)
            {
                throw new NullReferenceException();
            }
            if(uow.Subjects.FindOne(s => s.Name == subject.Name) != null)
            {
                throw new AlreadyExistsException();
            }

            Subject s =  uow.Subjects.Add(subject);
            uow.Commit();
            return s;
  
        }

        public Subject FindOneByCondition(Expression<Func<Subject, bool>> func)
        {
            return uow.Subjects.FindOne(func);
        }

    }
}
