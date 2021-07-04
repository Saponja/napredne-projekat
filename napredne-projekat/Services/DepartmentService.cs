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
    /// <summary>
    /// Klasa koja nam sluzi za kao serivis iz koga se pozivaju operacije nad tabelom departmetnts u bazi
    /// </summary>
    public class DepartmentService
    {
        private readonly IUnitOfWork uow;
        /// <summary>
        /// Parametrizovani konstrukor koji kreira objekat klase DepartmentService i postavlja vrednost za uow
        /// </summary>
        /// <param name="uow">Objekat klase UnitOfWork</param>
        public DepartmentService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        /// <summary>
        /// Metoda koja poziva UnitOfWork i vraca listu svih katedri
        /// </summary>
        /// <returns>Lista svih katedri</returns>
        public List<Department> GetAll()
        {
            return uow.Departments.GetAll();
        }
        /// <summary>
        /// Metoda koja poziva UnitOfWork da doda katedru  i vraca tu katedru
        /// </summary>
        /// <param name="item">Objekat klase Department</param>
        /// <returns>Objekat klase Department koji je dodat</returns>
        /// <exception cref="AlreadyExistsException" />
        /// <exception cref="System.NullReferenceException" />
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
        /// <summary>
        /// Metoda koja poziva UnitOfWork i vraca katedru za prosledjenim id-jem
        /// </summary>
        /// <param name="id">Id katedre kao Int</param>
        /// <returns>Objekat klase Department koji ima dati id</returns>
        /// <exception cref="IdException" />
        public Department FindById(int id)
        {
            if(id <= 0)
            {
                throw new IdException();
            }

            Department department = uow.Departments.FindById(id);

            return department;
        }
        /// <summary>
        /// Metoda koja poziva UnitOfWork da update-uje katedru sa prosledjenim id-jem i vraca tu katedru
        /// </summary>
        /// <param name="item">Objekat klase Department sa novim podacima</param>
        /// <param name="id">Id katedre koja treba da se update-uje kao Int</param>
        /// <returns>Objekat klase Department koji je update-ovan</returns>
        /// <exception cref="IdException" />
        /// <exception cref="System.NullReferenceException" />
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
        /// <summary>
        /// Metoda koja poziva UnitOfWork da izbrise katedru sa datim id-jem
        /// </summary>
        /// <param name="id">Id katedre koja treba da se obrise kao Int</param>
        /// <exception cref="IdException" />
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
