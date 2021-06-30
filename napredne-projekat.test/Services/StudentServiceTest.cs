using Microsoft.EntityFrameworkCore;
using napredne_projekat.Domain;
using napredne_projekat.Exeptions.cs;
using napredne_projekat.Repository.unit_of_work;
using napredne_projekat.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace napredne_projekat.test.Services
{
    public class StudentServiceTest : IDisposable
    {
        private IUnitOfWork uow;
        private StudentService studentService;

        //private NaprednoContext context = new NaprednoContext(dbContextOption.Options);
        private NaprednoContext context;
        

        public StudentServiceTest()
        {
            DbContextOptionsBuilder dbContextOption = new DbContextOptionsBuilder<NaprednoContext>().UseInMemoryDatabase(new Guid().ToString());
            context = new NaprednoContext(dbContextOption.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).Options);
            //context = new NaprednoContext(dbContextOption.Options);
            context.Database.EnsureCreated();;
            uow = new UnitOfWork(context);
            studentService = new StudentService(uow);
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }

        public void SeedNoTracking()
        {
            //var s1 = context.Students.Add(new Student
            //{
            //    FirstName = "Zika",
            //    LastName = "Zikic",
            //    Grade = 10,
            //    DateOfBirth = new DateTime(),
            //    Index = "2015/1512"
            //});

            var s1 = new Student
            {
                FirstName = "Zika",
                LastName = "Zikic",
                Grade = 10,
                DateOfBirth = new DateTime(),
                Index = "2015/1512"
            };

            context.Students.Add(s1);

            var s2 = new Student
            {
                FirstName = "Pera",
                LastName = "Peric",
                Grade = 8,
                DateOfBirth = new DateTime(),
                Index = "2017/1111"
            };

            context.Students.Add(s2);

            context.Entry<Student>(s1).State = EntityState.Added;
            context.Entry<Student>(s2).State = EntityState.Added;

            context.SaveChanges();
        }

        public void Seed()
        {
            var s1 = new Student
            {
                FirstName = "Zika",
                LastName = "Zikic",
                Grade = 10,
                DateOfBirth = new DateTime(),
                Index = "2015/1512"
            };

            context.Students.Add(s1);

            var s2 = new Student
            {
                FirstName = "Pera",
                LastName = "Peric",
                Grade = 8,
                DateOfBirth = new DateTime(),
                Index = "2017/1111"
            };

            context.Students.Add(s1);
            context.Students.Add(s2);

            context.SaveChanges();

            Thread.Sleep(700);

        }
        [Fact]
        public void GetAllStudentsShouldRetunrnAllStudentsFromTable()
        {
            Seed();
            List<Student> students = studentService.GetAll();
            Assert.Equal(2, students.Count);
            Dispose();
        }

        [Fact]
        public void AddNullStudentShouldThrowNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => studentService.AddStudent(null));
            Dispose();

        }

        [Fact]
        public void AddExistingStudentShouldThrowAlreadyExistsException()
        {
            Seed();
            Student student = new Student
            {
                FirstName = "Zika",
                LastName = "Zikic",
                Grade = 10,
                DateOfBirth = new DateTime(),
                Index = "2015/1512"
            };
            Assert.Throws<AlreadyExistsException>(() => studentService.AddStudent(student));
            Dispose();

        }

        [Fact]
        public void AddingValidStudentShouldInsertStudentInTable()
        {
            SeedNoTracking();
            //Seed();
            Student student = new Student
            {
                FirstName = "Mika",
                LastName = "Mikic",
                Grade = 10,
                DateOfBirth = new DateTime(),
                Index = "2012/1221"
            };
            Student newStudent = studentService.AddStudent(student);
            Assert.Equal(3, studentService.GetAll().Count);
            Assert.Equal(newStudent.Index, student.Index);
            Dispose();

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void FindByIdWithExistingIdShouldReturnStudent(int id)
        {
            Seed();
            Thread.Sleep(500);
            Student student = studentService.FindById(id);
            Assert.Equal(studentService.GetAll()[id-1].Index, student.Index);
            Dispose();

        }

        [Theory]
        [InlineData(3)]
        [InlineData(0)]
        public void FindByIdWithNonExistingIdShouldReturnNull(int id)
        {
            Seed();
            Thread.Sleep(500);
            Student student = studentService.FindById(id);
            Assert.Null(student);
            Dispose();
        }

        [Fact]
        public void GetByGradeShouldReturnStudentsWithThatGradeOrHigher()
        {
            Seed();
            List<Student> students = studentService.GetByGrade(8);
            Assert.Equal(2, students.Count);
            Dispose();
        }

        [Theory]
        [InlineData(4)]
        [InlineData(11)]
        public void GetByInvalidGradeShoudlReturnNull(int grade)
        {
            Seed();
            Assert.Null(studentService.GetByGrade(grade));
            Dispose();
        }





    }
}
