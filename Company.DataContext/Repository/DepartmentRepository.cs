using Company.DataContext.Interfaces;
using Company.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DataContext.Repository
{
    public class DepartmentRepository : IRepository<Department>
    {
        public bool Create(Department entity)
        {
            try
            {
                DbContext.Departments.Add(entity);
                return true;
            }
            catch (Exception )
            {

                throw;
            }
        }

        public bool Delete(Department entity)
        {
            DbContext.Departments.Remove(entity);
            return true;
        }

        public Department Get(Predicate<Department> filter)
        {
            return DbContext.Departments.Find(filter);
        }

        public List<Department> GetAll(Predicate<Department> filter = null)
        {
            return filter is null ? DbContext.Departments : DbContext.Departments.FindAll(filter);
        }

        public bool Update(Department entity)
        {
            try
            {
                var existDepartment = Get(d => d.Id == entity.Id);
                existDepartment = entity;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}
