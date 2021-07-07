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
    /// Klasa koja nam sluzi za kao serivis iz koga se pozivaju operacije nad tabelom student u bazi
    /// </summary>
    public class StudentService
    {
        private IUnitOfWork uow;

        /// <summary>
        /// Parametrizovani konstrukor koji kreira objekat klase StudentService i postavlja vrednost za uow
        /// </summary>
        /// <param name="uow">Objekat klase UnitOfWork</param>
        public StudentService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        /// <summary>
        /// Metoda koja poziva UnitOfWork i vraca listu svih studenata
        /// </summary>
        /// <returns>Lista svih studenata</returns>
        public List<Student> GetAll()
        {
            return uow.Students.GetAll();
        }
        /// <summary>
        /// Metoda koja poziva UnitOfWork da doda studetna  i vraca tog studetna
        /// </summary>
        /// <param name="item">Objekat klase Student</param>
        /// <returns>Objekat klase Student koji je dodat</returns>
        /// <exception cref="AlreadyExistsException" />
        /// <exception cref="System.NullReferenceException" />

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

        /// <summary>
        /// Metoda koja poziva UnitOfWork i vraca studenta za prosledjenim id-jem
        /// </summary>
        /// <param name="id">Id studenta kao Int</param>
        /// <returns>Objekat klase Student koji ima dati id</returns>
        public Student FindById(int id)
        {
            return uow.Students.FindById(id);
        }
        /// <summary>
        /// Metoda koja poziva UnitOfWork da vrati sve studente sa ocenom vecom od prosledjene
        /// </summary>
        /// <param name="grade">Ocena studenta kao Int</param>
        /// <returns>Lista studenata koji imaju ocenu vecu od prosledjene</returns>
        public List<Student> GetByGrade(int grade)
        {
            if(grade > 10 || grade < 5)
            {
                return null;
            }
            return uow.Students.GetStudentsByGrade(s => s.Grade >= grade);
        }
        /// <summary>
        /// Metoda koja poziva UnitOfWork da update-uje studenta i vrati ga nazad
        /// </summary>
        /// <param name="id">Id studenta kao int</param>
        /// <param name="student">Objekat klase student</param>
        /// <returns>Objekat klase student</returns>
        /// <exception cref="NullReferenceException" />
        /// <exception cref="ArgumentException" />
        public Student UpdateStudent(int id, Student student)
        {
            if(FindById(id) == null)
            {
                throw new ArgumentException();
            }

            if(student == null)
            {
                throw new NullReferenceException();

            }


            Student updated = uow.Students.Update(student, id);

            uow.Commit();

            return updated;
        }

    }
}
