using Company.Business.Interfaces;
using Company.Business.Services;
using Company.DataContext.Repository;
using Company.Domain.Models;
using Company.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml;

namespace Company.Controllers
{
    public class DepartmentController
    {
        private readonly DepartmentRepository _depRepository;
        private readonly DepartmentService _depService;
        public DepartmentController()
        {
            _depRepository = new();
            _depService = new();
        }
        public void CreateDepartment()
        {
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Department Name");
        EnterDepartment: string departmentName = Console.ReadLine();
            if (!Helper.ContainsLetters(departmentName) || string.IsNullOrWhiteSpace(departmentName))
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Invalid Department Name format");
                goto EnterDepartment;
            }
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Department Size ");
            EnterSize: string size = Console.ReadLine();
            bool result = int.TryParse(size, out int departmentSize);
            if (result)
            {
                Department department = new();
                department.Name = departmentName;
                 department.MaxSize = departmentSize;
                var createdDepartment = _depService.Create(department);
                if (createdDepartment is not null)
                {
                    Helper.ChangeTextColor(ConsoleColor.DarkYellow, $"Department named {department.Name} is created");
                }
                else
                {
                    Helper.ChangeTextColor(ConsoleColor.Red, "You Cant create two Departments with same Name");
                }
            }
            else
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Put right size");
                goto EnterSize;
            }

        }
        public void GetAllDepartments()
        {
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Department list: ");
            var departments=_depService.GetAll();
            if(departments.Count>0)
            {
                foreach (var department in departments)
                {
                    Helper.ChangeTextColor(ConsoleColor.DarkYellow, $"Id : {department.Id} Name : {department.Name} Size : {department.MaxSize}");
                }
            }
            else
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Empty list");
            }
        }
        public void UpdateDepartment()
        {
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Department Id");
            int id = int.Parse(Console.ReadLine());
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Department Name");
        EnterDepartment: string departmentName = Console.ReadLine();
            if (!Helper.ContainsLetters(departmentName) || string.IsNullOrWhiteSpace(departmentName))
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Invalid Department Name format");
                goto EnterDepartment;
            }
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Department Size ");
        EnterSize: string size = Console.ReadLine();
           if(int.TryParse(size, out int departmentSize))
            {
                Department department = new();
                department.Name = departmentName;
                department.MaxSize = departmentSize;
                department.Id = id;
                var createdDepartment = _depService.Update(id, department);
                if (createdDepartment is not null)
                {
                    Helper.ChangeTextColor(ConsoleColor.DarkYellow, $"Department with  Id : {department.Id} is updated. ");
                }
                else
                {
                    Helper.ChangeTextColor(ConsoleColor.Red, "Something went wrong");
                }
            }
            else
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Put right size");
                goto EnterSize;
            }
           
        }
        public void DeleteDepartment()
        {
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Department Id");
            int id=int.Parse(Console.ReadLine());
            var result=_depService.Delete(id);
            if (result is not null)
            {
                Helper.ChangeTextColor(ConsoleColor.DarkYellow, "Department successfully deleted");
            }
            else 
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Something went wrong");
            }
        }
        public void GetDepartmentById()
        {
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Department Id");
            int id=int.Parse(Console.ReadLine());
            {
                Department department = _depRepository.Get(d => d.Id == id);
                if (department == null)
                {
                    Helper.ChangeTextColor(ConsoleColor.Red, "Something went wrong");
                }
                else
                {
                    Helper.ChangeTextColor(ConsoleColor.DarkYellow, $"Id : {department.Id} | Name : {department.Name} | Size : {department.MaxSize}");
                }
            }
             


        }
        public void GetDepartmentsBySize()
        {
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Department size ");
            int size=int.Parse(Console.ReadLine());
            var departments=_depService.GetDepartmentsBySize(size);
            foreach (var department in departments)
            {
                if (department.MaxSize == size)
                {
                    Helper.ChangeTextColor(ConsoleColor.DarkYellow, $"Id : {department.Id} | Name : {department.Name} | Size : {department.MaxSize}");
                }
                else
                {
                    Helper.ChangeTextColor(ConsoleColor.Red, "Something went wrong");
                }
            }
        }
        public void SearchDepartmentName()
        {
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Department Name ");
            string departmentName = Console.ReadLine();
            var departments=_depService.SearchDepartmentName(departmentName);
            if(departments.Count>0)
            {
                foreach (var department in departments)
                {
                    Helper.ChangeTextColor(ConsoleColor.DarkYellow, $"Details of Department Named {department.Name} - Id : {department.Id}  | Size : {department.MaxSize}");

                }
            }
            else
            {
                Helper.ChangeTextColor(ConsoleColor.Red, " There is no Department with given DepartmentName ");
            }
        }
        public void GetDepartmentsCount()
        {
            int count = 0;
            var departments = _depService.GetDepartmentsCount(count);
            if (departments.Count != null)
            {

                Helper.ChangeTextColor(ConsoleColor.DarkYellow, $"{departments.Count}");

            }
            else
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Empty List");

            }
        }
    }
}
