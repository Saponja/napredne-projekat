using napredne_projekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace napredne_projekat.Repository.repo_impl
{
    ///<inheritdoc />
    public class RepositoryDepartment : IRepositoryDepartment
    {
        private readonly NaprednoContext context;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public RepositoryDepartment(NaprednoContext context)
        {
            this.context = context;
        }

        ///<inheritdoc path="not[self::returns]"/>
        ///<returns>Entity klase Department</returns>
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
        ///<returns>Entity klase Department</returns>
        public Department FindById(int id)
        {
            return context.Departments.SingleOrDefault(d => d.DepartmentId == id);
        }
        ///<inheritdoc />
        ///<returns>Entity klase Department</returns>
        public Department FindOne(Expression<Func<Department, bool>> expression)
        {
            return context.Departments.SingleOrDefault(expression);
        }
        ///<inheritdoc />
        ///<returns>Lista entity-a klase Department</returns>
        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }
        ///<inheritdoc />
        ///<returns>Entity klase Department</returns>
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
