using napredne_projekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace napredne_projekat.Repository.repo_impl
{
    /// <summary>
    /// Klasa u kojoj su implementirane sve opercije za manipulaciju katedrama u bazi
    /// </summary>
    public class RepositoryDepartment : IRepositoryDepartment
    {
        private readonly NaprednoContext context;
        /// <summary>
        /// Parametrizovani konstruktor koji kreira objekat klase RepositoryDepartment i postavlja vrednost za context
        /// </summary>
        /// <param name="context">Objekat klase NaprenoContext</param>
        public RepositoryDepartment(NaprednoContext context)
        {
            this.context = context;
        }

        ///<inheritdoc/>
        ///<returns>Objekat klase Department koji je dodat u bazu</returns>
        public Department Add(Department item)
        {
            if (context.Departments.Add(item) == null)
            {
                return null;
            }
            return item;
        }
        ///<inheritdoc />
        public void Delete(int id)
        {
            Department department = FindById(id);
            context.Departments.Remove(department);
        }
        ///<inheritdoc />
        ///<returns>Objekat klase Department sa datim id-jem</returns>
        public Department FindById(int id)
        {
            return context.Departments.SingleOrDefault(d => d.DepartmentId == id);
        }
        ///<inheritdoc />
        ///<returns>Objekat klase Department koji zadovoljava uslov</returns>
        public Department FindOne(Expression<Func<Department, bool>> expression)
        {
            return context.Departments.SingleOrDefault(expression);
        }
        ///<inheritdoc />
        ///<returns>Lista svih katedri</returns>
        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }
        ///<inheritdoc />
        ///<returns>Objekat klase Department koji je update-ovan</returns>
        public Department Update(Department item, int id)
        {
            Department department = FindById(id);
            department.Name = item.Name;
            department.Size = item.Size;
            if(context.Departments.Update(department) == null)
            {
                return null;
            }
            return department;
        }
    }
}
