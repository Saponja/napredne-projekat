using Microsoft.EntityFrameworkCore;
using napredne_projekat.Domain;
using napredne_projekat.Exeptions.cs;
using napredne_projekat.Repository.unit_of_work;
using napredne_projekat.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace napredne_projekat.test.Services
{
    public class SubjectServiceTest : IDisposable
    {
        private NaprednoContext context;
        private IUnitOfWork uow;
        private SubjectService subjectService;

        public SubjectServiceTest()
        {
            DbContextOptionsBuilder dbContextOption = new DbContextOptionsBuilder<NaprednoContext>().UseInMemoryDatabase("Testas");
            context = new NaprednoContext(dbContextOption.Options);

            context.Database.EnsureCreated();
            Seed();
            uow = new UnitOfWork(context);
            subjectService = new SubjectService(uow);
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
        }

       

        [Fact]
        public void GetAllShouldReturnAllSubjectsFromTable()
        {
            List<Subject> subjects = subjectService.GetAll();
            Assert.Equal(3, subjects.Count);
            Assert.Equal("Mobilno", subjects[0].Name);
            Dispose();
            
        }

        [Fact]
        public void AddItemShoudlInsertSubjectInTable()
        {

            var result = subjectService.AddSubject(new Subject
            {
                Name = "UIS",
                ESPB = 6
            });

            var expectedResult = subjectService.FindById(4);

            Assert.Equal(4, subjectService.GetAll().Count);
            Dispose();

        }

        [Fact]
        public void AddExistingItemShouldThorwAlreadyExistsException()
        {
            Assert.Throws<AlreadyExistsException>(() => subjectService.AddSubject(new Subject { Name = "Mobilno" }));
        }

        [Fact]
        public void AddNullItemShouldNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => subjectService.AddSubject(null));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public void FindByValidIdShouldReturnItem(int id)
        {
            var result = subjectService.FindById(id);
            Assert.NotNull(result);
            Assert.Equal(subjectService.GetAll()[id - 1].SubjectId, result.SubjectId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        public void FindByInvalidIdShouldReturnNull(int id)
        {
            var result = subjectService.FindById(id);
            Assert.Null(result);

        }

        [Fact]
        public void FindByContitionShouldReturnItemThatSatisfiesCondition()
        {
            var result = subjectService.FindOneByCondition(s => s.Name == "Mobilno");
            Assert.NotNull(result);
        }

        [Fact]
        public void UpdateWithNullShouldThrowNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => subjectService.UpdateSubject(null, 0));
        }

        [Fact]
        public void UpdateItemShouldReturnUpdatedItem()
        {
            Subject subject = new Subject { Name = "Programski", ESPB = 4 };
            var result = subjectService.UpdateSubject(subject, 2);
            Assert.NotNull(subject);
            Assert.Equal(subjectService.GetAll()[1].Name, result.Name);
        }




        public void Seed()
        {

            context.Subjects.Add(new Subject
            {
                Name = "Mobilno",
                ESPB = 6
            });
            context.Subjects.Add(new Subject
            {
                Name = "IS",
                ESPB = 5
            });
            context.Subjects.Add(new Subject
            {
                Name = "OK",
                ESPB = 4
            });

            context.SaveChanges();
        }

    }
}
