using napredne_projekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace napredne_projekat.Repository.repo_impl
{
    /// <summary>
    /// Klasa u kojoj su implementirane sve opercije za manipulaciju predmetima u bazi
    /// </summary>
    public class RepositorySubject : IRepositorySubject
    {
        private NaprednoContext context;
        /// <summary>
        /// Parametrizovani konstruktor koji kreira objekat klase RepositorySubject i postavlja vrednost za context
        /// </summary>
        /// <param name="context">Objekat klase NaprenoContext</param>
        public RepositorySubject(NaprednoContext context)
        {
            this.context = context;
        }
        ///<inheritdoc/>
        ///<returns>Objekat klase Subject koji je dodat u bazu</returns>
        public Subject Add(Subject item)
        {
            if(context.Subjects.Add(item) == null)
            {
                return null;
            }
            return item ;
        }
        ///<inheritdoc/>
        public void Delete(int id)
        {
            Subject subject = FindById(id);
            context.Subjects.Remove(subject);
        }
        ///<inheritdoc/>
        ///<returns>Objekat klase Subject koji ima dati id</returns>

        public Subject FindById(int id)
        {
            return context.Subjects.SingleOrDefault(s => s.SubjectId == id);
        }
        ///<inheritdoc/>
        ///<returns>Objekat klase Subject koji zadovoljava uslov</returns>

        public Subject FindOne(Expression<Func<Subject, bool>> func)
        {
            return context.Subjects.SingleOrDefault(func);
        }
        ///<inheritdoc/>
        ///<returns>Listu objekata klase Subject koja predstavlja listu svih predmeta</returns>

        public List<Subject> GetAll()
        {
            return context.Subjects.ToList();
        }
        ///<inheritdoc/>
        ///<returns>Objekat klase Subject koji je update-ovan</returns>

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
