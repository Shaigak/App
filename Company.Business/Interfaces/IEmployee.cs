using Company.Domain.Models;


namespace Company.Business.Interfaces
{
    public interface IEmployee
    {
        
        List<Employee> GetAll();
        List<Employee> GetAll(string name);
        List<Employee> GetAllWithDepartmentName(string departmentName);
        Employee GetEmployeeById(int id);
        List<Employee> GetEmployeesByAge(int age);
        Employee Delete(int id);
        Employee Update(int id, Employee employee, string departmentName);
        Employee Create(Employee employee,string departmentName);
        List<Employee> GetEmployeesCount(int count);
        List<Employee> SearchByName(string name);
        List<Employee> SearchEmployeeBySurname(string surname);
    }  
}

    

