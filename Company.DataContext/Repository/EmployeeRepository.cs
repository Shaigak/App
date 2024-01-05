using Company.DataContext.Interfaces;
using Company.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DataContext.Repository
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public bool Create(Employee entity)
        {
            try
            {
                DbContext.Employees.Add(entity);
                return true;
            }
            catch (Exception )
            {

                throw;
            }
        }

        public bool Delete(Employee entity)
        {
           DbContext.Employees.Remove(entity);
            return true;
        }

        public Employee Get(Predicate<Employee> filter)
        {
            return DbContext.Employees.Find(filter);
        }

        public List<Employee> GetAll(Predicate<Employee> filter = null)
        {
            if (filter == null)
            {
                return DbContext.Employees;
            }
            else
            {
                return DbContext.Employees.FindAll(filter);
            }
        }

        public bool Update(Employee entity)
        {
            try
            {
                var existEmployee = Get(e => e.Id == entity.Id);
                existEmployee = entity;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
      public List<Employee>SearchByName(Employee entity)
        {
            return DbContext.Employees.FindAll(e=>e.Name == entity.Name);
        }
         

        
    }
}
