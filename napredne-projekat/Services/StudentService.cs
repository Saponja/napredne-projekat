using napredne_projekat.Domain;
using napredne_projekat.Exeptions.cs;
using napredne_projekat.Repository.unit_of_work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class StudentService
    {
        private IUnitOfWork uow;

        public StudentService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public List<Student> GetAll()
        {
            return uow.Students.GetAll();
        }

        public Student AddStudent(Student item)
        {
            if(item == null)
            {
                throw new NullReferenceException();
            }
            if (uow.Students.GetStudentByIndex(item.Index) != null)
            {
                throw new AlreadyExistsException();
            }

            Student student = uow.Students.Add(item);
            uow.Commit();
            return student;
        }


        public Student FindById(int id)
        {
            return uow.Students.FindById(id);
        }

        public List<Student> GetByGrade(int grade)
        {
            if(grade > 10 || grade < 5)
            {
                return null;
            }
            return uow.Students.GetStudentsByGrade(s => s.Grade >= grade);
        }

    }
}
