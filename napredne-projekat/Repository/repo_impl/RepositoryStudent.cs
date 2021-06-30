using Microsoft.EntityFrameworkCore;
using napredne_projekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace napredne_projekat.Repository.repo_impl
{
    ///<inheritdoc/>
    public class RepositoryStudent : IRepositoryStudent
    {
        private readonly NaprednoContext context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public RepositoryStudent(NaprednoContext context)
        {
            this.context = context;
        }

        ///<inheritdoc/>
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
        public Student FindById(int id)
        {
            return context.Students.SingleOrDefault(d => d.StudentId == id);
        }
        ///<inheritdoc/>
        public List<Student> GetAll()
        {
            return context.Students.ToList();
        }

        ///<inheritdoc/>
        public Student GetStudentByIndex(string index)
        {
            return context.Students.SingleOrDefault(s => s.Index == index);
        }

        ///<inheritdoc/>
        public List<Student> GetStudentsByGrade(Expression<Func<Student, bool>> func)
        {
            return context.Students.Where(func).ToList();
        }
        ///<inheritdoc/>
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
