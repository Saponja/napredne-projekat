using Microsoft.AspNetCore.Mvc;
using napredne_projekat.Domain;
using napredne_projekat.Exeptions.cs;
using napredne_projekat.Repository.unit_of_work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Services
{
    public class DepartmentService
    {
        private readonly IUnitOfWork uow;
        public DepartmentService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public List<Department> GetAll()
        {
            return uow.Departments.GetAll();
        }

        public Department Add(Department item)
        {
            if(item == null)
            {
                throw new NullReferenceException();
            }
            if(uow.Departments.FindOne(d => d.Name == item.Name) != null)
            {
                throw new AlreadyExistsException();
            }

            Department department = uow.Departments.Add(item);
            uow.Commit();
            return department;
        }

        public Department FindById(int id)
        {
            if(id <= 0)
            {
                throw new IdException();
            }

            Department department = uow.Departments.FindById(id);

            return department;
        }

        public Department Update(Department item, int id)
        {
            if (id <= 0)
            {
                throw new IdException();
            }
            if(item == null)
            {
                throw new NullReferenceException();
            }

            Department department = uow.Departments.Update(item, id);
            uow.Commit();
            return department;

        }

        public void Delete(int id)
        {
            if(id <= 0)
            {
                throw new IdException("Id must be grater than zero");
            }
            uow.Departments.Delete(id);
            uow.Commit();
        }
    }
}
