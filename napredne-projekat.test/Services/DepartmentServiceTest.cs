using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
    public class DepartmentServiceTest : IDisposable
    {
        
        private  IUnitOfWork uow;
        private  DepartmentService departmentService;

        private NaprednoContext context;


        public DepartmentServiceTest()
        {
            DbContextOptionsBuilder dbContextOption = new DbContextOptionsBuilder<NaprednoContext>().UseInMemoryDatabase(new Guid().ToString());
            context = new NaprednoContext(dbContextOption.Options);
            context.Database.EnsureCreated();
            uow = new UnitOfWork(context);
            departmentService = new DepartmentService(uow);


        }

        public void Dispose()
        {
            
            context.Database.EnsureDeleted();
            
            
        }

        [Fact]
        public void AddingNullValueShouldThrowNullPointerException()
        {
            Seed();

            Assert.Throws<NullReferenceException>(() => departmentService.Add(null));
            Dispose();
        }

        [Fact]
        public void AddingExistingItemShouldThrowAlreadyExistsException()
        {
            Seed();

            Assert.Throws<AlreadyExistsException>(() => departmentService.Add(new Department
            {
                Name = "Katedra za AI",
                Size = 11
            }));
            Dispose();
        }

        [Fact]
        public void AddingItemShouldReturnThatItem()
        {
            SeedNoTracking();

            Department department = new Department { Name = "Katedra za OK", Size = 11 };
            Department newDepartment = departmentService.Add(department);
            Assert.Equal(department.Name, newDepartment.Name);
            Dispose();
        }

        [Fact]
        public void GetAllShouldReturunAllDepartments()
        {
            Seed();

            List<Department> departments = departmentService.GetAll();
            Assert.Equal(2, departments.Count);
            Dispose();
        }
        
        [Theory]
        [InlineData(1, "Katedra za IS")]
        [InlineData(2, "Katedra za AI")]
        public void FindWithValidIdShouldReturnDepartmentWithThatId(int id, string expected)
        {
            Seed();
            Department department = departmentService.FindById(id);

            Assert.Equal(expected, department.Name);
            Dispose();
            
        }

        [Fact]
        public void FindWithNonExistingIdShouldReturnNull()
        {
            Seed();
            Department department = departmentService.FindById(11);
            Assert.Null(department);
            Dispose();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void FindWithInvalidIdShouldThrowIdException(int id)
        {
            Seed();
            Assert.Throws<IdException>(() => departmentService.FindById(id));
            Dispose();
        }


        



        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void UpdateWithInvalidIdShouldThrowIdException(int id)
        {
            Seed();
            Assert.Throws<IdException>(() => departmentService.Update(new Department { Name = "Katedra za UI",Size = 12 }, id));
            Dispose();
        }

        [Fact]
        public void UpdateWithNullShouldThrowNullReferenceException()
        {
            Seed();
            Assert.Throws<NullReferenceException>(() => departmentService.Update(null, 1));
            Dispose();
        }

        //[Fact(Skip = "Test is broken")]
        [Fact]
        public void UpdateWithValidIdAndDeparShouldRetutnUpdatedDep()
        {
            Seed();
            Department department = departmentService.Update(new Department { Name = "Katedra za UI", Size = 12 }, 1);
            Department newDepartment = departmentService.FindById(1);
            Assert.Equal(newDepartment, department);
            Dispose();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void DeleteWithInvalidIdShouldThrowIdException(int id)
        {
            Seed();
            Assert.Throws<IdException>(() => departmentService.Delete(id));
            Dispose();
        }

        //[Fact(Skip = "Test is broke")]
        [Fact]
        public void DeleteWithValidIdShouldDeleteItem()
        {
            Seed();
            departmentService.Delete(1);
            List<Department> departments = departmentService.GetAll();
            Assert.Equal(1, departments.Count);
            Dispose();
        }



        private void SeedNoTracking()
        {
            var s1 = context.Departments.Add(new Department { Name = "Katedra za IS", Size = 12 });
            var s2 = context.Departments.Add(new Department { Name = "Katedra za AI", Size = 6 });

            context.Entry<Department>(s1.Entity).State = EntityState.Detached;
            context.Entry<Department>(s2.Entity).State = EntityState.Detached;

            context.SaveChanges();

        }

        private void Seed()
        {
            var s1 = context.Departments.Add(new Department { Name = "Katedra za IS", Size = 12 });
            var s2 = context.Departments.Add(new Department { Name = "Katedra za AI", Size = 6 });
            //context.ChangeTracker.Clear();
            //context.Entry<Department>(s1.Entity).State = EntityState.Detached;
            //context.Entry<Department>(s2.Entity).State = EntityState.Detached;

            context.SaveChanges();

        }
    }
}
