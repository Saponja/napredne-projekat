using napredne_projekat.Domain;
using napredne_projekat.Exeptions.cs;
using napredne_projekat.Repository.unit_of_work;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace napredne_projekat.Services
{
    /// <summary>
    /// Klasa koja nam sluzi za kao serivis iz koga se pozivaju operacije nad tabelom subjects u bazi
    /// </summary>
    public class SubjectService
    {
        private IUnitOfWork uow;
        /// <summary>
        /// Parametrizovani konstrukor koji kreira objekat klase SubjectService i postavlja vrednost za uow
        /// </summary>
        /// <param name="uow">Objekat klase UnitOfWork</param>
        public SubjectService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        /// <summary>
        /// Metoda koja poziva UnitOfWork i vraca listu svih predmeta
        /// </summary>
        /// <returns>Lista svih predmeta</returns>
        public List<Subject> GetAll()
        {
            return uow.Subjects.GetAll();
        }
        /// <summary>
        /// Metoda koja poziva UnitOfWork i vraca predmet za prosledjenim id-jem
        /// </summary>
        /// <param name="id">Id predmeta kao Int</param>
        /// <returns>Objekat klase Subject koji ima dati id</returns>
        public Subject FindById(int id)
        {
            Subject subject = uow.Subjects.FindById(id);
            
            return subject;
        }
        /// <summary>
        /// Metoda koja poziva UnitOfWork da update-uje predmet sa prosledjenim id-jem i vraca taj predet
        /// </summary>
        /// <param name="subject">Objekat klase Subject sa novim podacima</param>
        /// <param name="id">Id predmeta koji treba da se update-uje kao Int</param>
        /// <returns>Objekat klase Subject koji je update-ovan</returns>
        /// <exception cref="NullReferenceException" />
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
        /// <summary>
        /// Metoda koja poziva UnitOfWork da doda predmet  i vraca taj predet
        /// </summary>
        /// <param name="subject">Objekat klase Subject</param>
        /// <returns>Objekat klase Subject koji je dodat</returns>
        /// <exception cref="AlreadyExistsException" />
        /// <exception cref="System.NullReferenceException" />
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
        /// <summary>
        /// Metoda koja poziva UnitOfWork da vrati predmet koji zadovoljava uslov
        /// </summary>
        /// <param name="func">Uslov kao lambda izraz</param>
        /// <returns>Objekat klase Subject koji zadovoljava uslov</returns>
        public Subject FindOneByCondition(Expression<Func<Subject, bool>> func)
        {
            return uow.Subjects.FindOne(func);
        }

        /// <summary>
        /// Metoda koja vraca subject u json formatu
        /// </summary>
        /// <param name="subject">Objekat klase student</param>
        /// <returns>String u json formatu</returns>
        public string ToJson(Subject subject)
        {
            if(subject == null)
            {
                throw new NullReferenceException();
            }

            string json = JsonConvert.SerializeObject(subject);
            return json;
        }

    }
}
