using Company.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Business.Interfaces
{
    public interface IDepartment
    {
        List<Department> GetAll();
        List<Department> GetDepartmentsBySize(int size);
        public List<Department> SearchDepartmentName(string name);

        Department GetDepartmentById(int id);
        Department Get(string name);
        Department Delete(int id);
        Department Create(Department department);
        Department Update(int id, Department department);

        List<Department> GetDepartmentsCount(int count);
    }
}
