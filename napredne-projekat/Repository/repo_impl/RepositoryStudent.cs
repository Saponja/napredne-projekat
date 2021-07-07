using Microsoft.EntityFrameworkCore;
using napredne_projekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace napredne_projekat.Repository.repo_impl
{
    /// <summary>
    /// Klasa u kojoj su implementirane sve opercije za manipulaciju studentima u bazi
    /// </summary>
    public class RepositoryStudent : IRepositoryStudent
    {
        private readonly NaprednoContext context;

        /// <summary>
        /// Parametrizovani konstruktor koji kreira objekat klase RepositoryStudent i postavlja vrednost za context
        /// </summary>
        /// <param name="context">Objekat klase NaprenoContext</param>
        public RepositoryStudent(NaprednoContext context)
        {
            this.context = context;
        }

        ///<inheritdoc/>
        ///<returns>Objekat klase Student koji je dodat</returns>
        public Student Add(Student item)
        {
            
            if (context.Students.Add(item) == null)
            {
                return null;
            }
            
            return item;
        }
        ///<inheritdoc/>
        public void Delete(int id)
        {
            Student student = FindById(id);
            context.Students.Remove(student);
        }
        ///<inheritdoc/>
        ///<returns>Objekat klase Student koji ima prosledjen id</returns>
        public Student FindById(int id)
        {
            return context.Students.SingleOrDefault(d => d.StudentId == id);
        }
        ///<inheritdoc/>
        ///<returns>Listu svih studenata</returns>
        public List<Student> GetAll()
        {
            return context.Students.ToList();
        }

        ///<inheritdoc/>
        ///<returns>Objekat klase student koji ima prosledjen index</returns>
        public Student GetStudentByIndex(string index)
        {
            return context.Students.SingleOrDefault(s => s.Index == index);
        }

        ///<inheritdoc/>
        ///<returns>Listu studenta koji zadovoljavaju uslov za ocene</returns>
        public List<Student> GetStudentsByGrade(Expression<Func<Student, bool>> func)
        {
            return context.Students.Where(func).ToList();
        }
        ///<inheritdoc/>
        ///<returns>Objekat klase Student koji je update-ovan</returns>
        public Student Update(Student item, int id)
        {
            Student student = FindById(id);
            student.FirstName = item.FirstName;
            student.LastName = item.LastName;
            student.DateOfBirth = item.DateOfBirth;
            student.Index = item.Index;
            student.Grade = item.Grade;

            if (context.Students.Update(student) == null)
            {
                return null;
            }
            return student;
        }
    }
}
