using Company.Business.Interfaces;
using Company.DataContext.Repository;
using Company.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Business.Services
{
    public class EmployeeService : IEmployee
    {
        private readonly DepartmentRepository _depRepository;
        private readonly EmployeeRepository _employeeRepository;
        private static int Count = 1;
        public EmployeeService()
        {
            _depRepository = new();
            _employeeRepository = new();
        }
        public Employee Create(Employee employee,string departmentName)
        {
            var existDep = _depRepository.Get(e => e.Name==departmentName);
            
            employee.Id = Count;
            employee.Department = existDep;
            


            
           


            if (_employeeRepository.Create(employee))
            {
                Count++;
                return employee;
            }
            else
            {
                return null;
            }

        }

        public Employee Delete(int id)
        {
            var existEmployee = _employeeRepository.Get(e => e.Id == id);
            if (existEmployee is null) return null;
            if (_employeeRepository.Delete(existEmployee)) return existEmployee;
            return null;
        }
        public List<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }



        public List<Employee> GetAllWithDepartmentName(string departmentName)
        {
            return _employeeRepository.GetAll(e => e.Department.Name == departmentName);
        }
        public List<Employee> GetAllEmployeeWithName(string name)
        {
            return _employeeRepository.GetAll(e => e.Name == name);
        }

        public Employee Update(int id, Employee employee, string departmentName)
        {

            var existEmployee = _employeeRepository.Get(e => e.Id == id);
            if (existEmployee is null) return null;
            var existDepartment = _depRepository.Get(d => d.Name == departmentName );
            if (existDepartment is  null) return null;
            if (!string.IsNullOrEmpty(employee.Name))
            {
                existEmployee.Name = employee.Name;
            }
         
            if (!string.IsNullOrEmpty(employee.Surname))
            {
                existEmployee.Surname = employee.Surname;
            }

            if (!string.IsNullOrEmpty(employee.Adress))
            {
                existEmployee.Adress = employee.Adress;
            }

        

            existEmployee.Department = existDepartment;
            existEmployee.PhoneNumber = employee.PhoneNumber;
            existEmployee.Salary = employee.Salary;
            existEmployee.Email = employee.Email;
            existEmployee.Age = employee.Age;
            if (_employeeRepository.Update(employee))
            {
                return existEmployee;
            }
            else
            {
                return null;
            }
        }
        public Employee GetEmployeeById(int id)
        {
            return _employeeRepository.Get(e => e.Id == id);
        }

        public List<Employee> GetEmployeesByAge(int age)
        {
            return _employeeRepository.GetAll(e => e.Age == age);
        }

        public List<Employee> GetAll(string name)
        {
            return _employeeRepository.GetAll(e => e.Name == name);
        }

        public List<Employee> SearchByName(string name)
        {
            return _employeeRepository.GetAll(e => e.Name == name);
        }



        public List<Employee> GetEmployeesCount(int count)
        {
            return _employeeRepository.GetAll();
        }

        public List<Employee> SearchEmployeeBySurname(string surname)
        {
            return _employeeRepository.GetAll(e=>e.Surname == surname);
        }
    }
}
