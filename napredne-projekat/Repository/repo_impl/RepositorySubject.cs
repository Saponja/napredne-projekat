using napredne_projekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace napredne_projekat.Repository.repo_impl
{
    public class RepositorySubject : IRepositorySubject
    {
        private NaprednoContext context;

        public RepositorySubject(NaprednoContext context)
        {
            this.context = context;
        }

        public Subject Add(Subject item)
        {
            if(context.Subjects.Add(item) == null)
            {
                return null;
            }
            return item ;
        }

        public void Delete(int id)
        {
            Subject subject = FindById(id);
            context.Subjects.Remove(subject);
        }

        public Subject FindById(int id)
        {
            return context.Subjects.SingleOrDefault(s => s.SubjectId == id);
        }

        public Subject FindOne(Expression<Func<Subject, bool>> func)
        {
            return context.Subjects.SingleOrDefault(func);
        }

        public List<Subject> GetAll()
        {
            return context.Subjects.ToList();
        }

        public Subject Update(Subject item, int id)
        {
            Subject subject = FindById(id);

            subject.Name = item.Name;
            subject.ESPB = item.ESPB;

            if(context.Subjects.Update(subject) == null)
            {
                return null;
            }

            return subject;
        }
    }
}
