using Company.Business.Interfaces;
using Company.DataContext.Repository;
using Company.Domain.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Business.Services
{
    public class DepartmentService : IDepartment
    {
        private readonly DepartmentRepository _depRepository;
        private readonly EmployeeRepository _employeeRepository;
        private static int Count = 1;
        public DepartmentService()
        {
            _depRepository = new ();
            _employeeRepository = new  ();
        }
        public Department Create(Department department)
        {

            



            var existDepartment=_depRepository.Get(d=>d.Name.Equals(department.Name,StringComparison.OrdinalIgnoreCase));
            if (existDepartment is not null) return null;
            department.Id = Count;
            if (_depRepository.Create(department))
            {
                Count++;
                return department;
            }
            else
            {
                return null;
            }
            
        }

        public Department Delete(int id)
        {
            var existDepartment=_depRepository.Get(d=>d.Id==id);
            if(existDepartment is null)
            {
                var empList=_employeeRepository.GetAll(s=>s.Department.Id==id);
                if (empList.Count > 0)
                {
                    foreach (var employee in empList)
                    {
                        _employeeRepository.Delete(employee);
                    }
                }
                return existDepartment;
            }
            if (_depRepository.Delete(existDepartment)) return existDepartment;
            return null;
        }
        public List<Department> GetAll()
        {
            return _depRepository.GetAll();
        }

       

        public Department Update(int id, Department department)
        {
            var existDepartment=_depRepository.Get(d=>d.Id==id);
            if (existDepartment is null) return null;
            var existDepartmentWithName=_depRepository.Get(d=>d.Name.Equals(department.Name,StringComparison.OrdinalIgnoreCase)&&d.Id!=existDepartment.Id);
            if (existDepartmentWithName is not null) return null;
            existDepartment.Name= department.Name;
            existDepartment.MaxSize=department.MaxSize;
            if (_depRepository.Update(department))
            {
                return existDepartment;
            }
            return null;
        }
     
        public Department Get(string name)
        {
            return _depRepository.Get(d=>d.Name==name);
        }

        public Department GetDepartmentById(int id)
        {
           return _depRepository.Get(d=>d.Id==id);
        }

        public List<Department> GetDepartmentsBySize(int size)
        {
            return _depRepository.GetAll(d=>d.MaxSize==size);
        }
        public List<Department>SearchDepartmentName(string name)
        {
            return _depRepository.GetAll(d=>d.Name == name);
        }

        public List<Department> GetDepartmentsCount(int count)
        {
            return _depRepository.GetAll();
        }
    }
}
