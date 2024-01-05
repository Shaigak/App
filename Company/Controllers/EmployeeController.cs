using Company.Business.Interfaces;
using Company.Business.Services;
using Company.DataContext.Repository;
using Company.Domain.Models;
using Company.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Company.Controllers
{
    public class EmployeeController
    {
        private readonly EmployeeService _employeeService;
        private readonly DepartmentRepository _departmentRepository;
        public EmployeeController()
        {
            _employeeService = new();
            _departmentRepository = new();
        }
        public void DeleteEmployee()
        {
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Employee Id");
            int id = int.Parse(Console.ReadLine());
            var result = _employeeService.Delete(id);
            if (result == null)
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "There is no such Employee with given Id");
            }
            else
            {
                Helper.ChangeTextColor(ConsoleColor.DarkYellow, "Employee successfully deleted");
            }
        }
        public void CreateEmployee()
        {
            Employee newEmployee = new();


            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Department Name");
        EnterDepname: string departmentName = Console.ReadLine();



            if (!Helper.ContainsLetters(departmentName) || string.IsNullOrWhiteSpace(departmentName))
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Invalid DepartmentName format");
                goto EnterDepname;
            }
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Employee Name");
            EnterName: string name = Console.ReadLine();
            if (!Helper.ContainsLetters(name) || string.IsNullOrWhiteSpace(name))
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Invalid Name format");
                goto EnterName;
            }
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Employee Surname");
            EnterSurName: string surname = Console.ReadLine();
            if (!Helper.ContainsLetters(surname) || string.IsNullOrWhiteSpace(surname))
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Invalid surname format");
                goto EnterSurName;
            }
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Employee Age");
            byte age= byte.Parse(Console.ReadLine());
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Employee Adress");
            EnterAdress: string adress = Console.ReadLine();
            if (!Helper.ContainsLetters(adress) || string.IsNullOrWhiteSpace(adress))
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Invalid Adress format");
                goto EnterAdress;
            }
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Employee Email");
        startEmail: string emailInput = Console.ReadLine();
            if (Helper.ValidEmail(emailInput))
            {
                newEmployee.Email = emailInput;

            }
            else
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Invalid format of Email");
                goto startEmail;
            }
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Employee PhoneNumber");
        StartPhone: string phoneNumber = Console.ReadLine();
            if (Helper.ValidPhoneNumberFormat(phoneNumber))
            {
                newEmployee.PhoneNumber = phoneNumber;
            }
            else
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Invalid format of Phone Number");
                goto StartPhone;
            }
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Employee Salary");
            EnterSalary: string salaryImput = Console.ReadLine();
            if (decimal.TryParse(salaryImput, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal salary))
            {
                if (Helper.Currency(salaryImput))
                {
                    newEmployee.Salary = salary;
                }
            }
            else
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Put right Salary Format");
                goto EnterSalary;
            }
            
            newEmployee.Name = name;
            newEmployee.Surname = surname;
            newEmployee.Age = age;
            newEmployee.Adress = adress;
            newEmployee.PhoneNumber = phoneNumber;
            
           
    
            
            var createdEmployee = _employeeService.Create(newEmployee,departmentName);
            if (createdEmployee is not null)
            {
                Helper.ChangeTextColor(ConsoleColor.DarkYellow, $"Employee named {newEmployee.Name} is created");
            }
            else
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Something went wrong");
            }
        }
        public void GetAllEmployeeWithName()
        {
            Helper.ChangeTextColor(ConsoleColor.Yellow, "Enter Employee Name: ");
            string employeeName = Console.ReadLine();
            var employees=_employeeService.GetAllEmployeeWithName(employeeName);
            if (employees.Count > 0)
            {
                foreach (var employee in employees)
                {
                    Helper.ChangeTextColor(ConsoleColor.DarkYellow, $"Id : {employee.Id} Name : {employee.Name} Surname : {employee.Surname} Age : {employee.Age} Adress : {employee.Adress} Email : {employee.Email} Phone : {employee.PhoneNumber} Salary : {employee.Salary:C}");
                }
            }
            else
            {
                Helper.ChangeTextColor(ConsoleColor.Red, $"Empty List or Error");
            }
        }
        public void GetAllEmployee()
        {
            Helper.ChangeTextColor(ConsoleColor.Yellow, "Employee List :");
            var employees = _employeeService.GetAll();
            if (employees.Count > 0)
            {
                foreach (var employee in employees)
                {
                    Helper.ChangeTextColor(ConsoleColor.DarkYellow, $"Id : {employee.Id}| Department : {employee.Department.Name}| Name : {employee.Name}| Surname : {employee.Surname}| Age : {employee.Age}| Adress : {employee.Adress}| Email : {employee.Email}| Phone : {employee.PhoneNumber}| Salary : {employee.Salary:C}|");

                }

            }
            else
            {
                Helper.ChangeTextColor(ConsoleColor.Red, $"Empty list");
            }

        }
        public void GetAllEmployeeWithDepartmentName()
        {
            Helper.ChangeTextColor(ConsoleColor.Yellow, "Enter Department Name: ");
            string departmentName = Console.ReadLine();
            var employees = _employeeService.GetAllWithDepartmentName(departmentName);
            if (employees.Count > 0)
            {
                foreach (var employee in employees)
                {
                    Helper.ChangeTextColor(ConsoleColor.DarkYellow, $"Id : {employee.Id} Name : {employee.Name} Surname : {employee.Surname} Age : {employee.Age} Adress : {employee.Adress} Email : {employee.Email} Phone : {employee.PhoneNumber} Salary : {employee.Salary}");
                }

            }
            else
            {
                Helper.ChangeTextColor(ConsoleColor.Red, $"Empty List or Error ");

            }

        }
        public void UpdateEmployee()
        {
     Employee newEmployee = new();
 Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Employee Id ");
            int id = int.Parse(Console.ReadLine());
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Department Name");
        EnterDepname: string departmentName = Console.ReadLine();
            if (!Helper.ContainsLetters(departmentName) || string.IsNullOrWhiteSpace(departmentName))
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Invalid DepartmentName format");
                goto EnterDepname;
            }
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Employee Name");
        EnterName: string name = Console.ReadLine();
            if (!Helper.ContainsLetters(name) || string.IsNullOrWhiteSpace(name))
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Invalid Name format");
                goto EnterName;
            }
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Employee Surname");
        EnterSurName: string surname = Console.ReadLine();
            if (!Helper.ContainsLetters(surname) || string.IsNullOrWhiteSpace(surname))
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Invalid surname format");
                goto EnterSurName;
            }
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Employee Age");
            byte age = byte.Parse(Console.ReadLine());
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Employee Adress");
        EnterAdress: string adress = Console.ReadLine();
            if (!Helper.ContainsLetters(adress) || string.IsNullOrWhiteSpace(adress))
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Invalid Adress format");
                goto EnterAdress;
            }
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Employee Email");
        startEmail: string emailInput = Console.ReadLine();
            if (Helper.ValidEmail(emailInput))
            {
                newEmployee.Email = emailInput;

            }
            else
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Invalid format of Email");
                goto startEmail;
            }
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Employee PhoneNumber");
        StartPhone: string phoneNumber = Console.ReadLine();
            if (Helper.ValidPhoneNumberFormat(phoneNumber))
            {
                newEmployee.PhoneNumber = phoneNumber;
            }
            else
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Invalid format of Phone Number");
                goto StartPhone;
            }
        EnterSalary: string salaryImput = Console.ReadLine();
            if (decimal.TryParse(salaryImput, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal salary))
            {
                if (Helper.Currency(salaryImput))
                {
                    newEmployee.Salary = salary;
                }
            }
            else
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Put right Salary Format");
                goto EnterSalary;
            }

            newEmployee.Name = name;
            newEmployee.Surname = surname;
            newEmployee.Age = age;
            newEmployee.Adress = adress;
            newEmployee.PhoneNumber = phoneNumber;
       
            newEmployee.Id = id;
            var createdEmployee = _employeeService.Update(id, newEmployee, departmentName);
            if (createdEmployee is not null)
            {
                Helper.ChangeTextColor(ConsoleColor.DarkYellow, $"Employee with Id - {newEmployee.Id} updated Successfully");
            }
            else
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "There is no such employee with given Id");

            }

        }
        public void GetEmployeeById()
        {
            Helper.ChangeTextColor(ConsoleColor.Yellow, "Enter Employee Id: ");
            if (int.TryParse(Console.ReadLine(), out int employeeid))
            {
                var employee = _employeeService.GetEmployeeById(employeeid);
                if (employee is not null)
                {
                    Helper.ChangeTextColor(ConsoleColor.DarkYellow, $"Id : {employee.Id} DepartmentName {employee.Department.Name}  Name : {employee.Name} Surname : {employee.Surname} Age : {employee.Age} Adress : {employee.Adress} Email : {employee.Email} Phone : {employee.PhoneNumber} Salary : {employee.Salary:C}");

                }
                else
                {
                    Helper.ChangeTextColor(ConsoleColor.Red, "Invalid input for Employee ID. Please enter a valid number ");
                }
            }
            else
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "Invalid input for Employee ID. Please enter a valid number ");
            }

        }
        public void GetEmployeesByAge()
        {
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Employee Age");
            byte age = byte.Parse(Console.ReadLine());
            var employees = _employeeService.GetEmployeesByAge(age);
            foreach (var employee in employees)
            {
                if (employee.Age == age)
                {
                    Helper.ChangeTextColor(ConsoleColor.DarkYellow, $"Id : {employee.Id} Name : {employee.Name} Surname : {employee.Surname} Age : {employee.Age} Adress : {employee.Adress} Email : {employee.Email} Phone : {employee.PhoneNumber} Salary : {employee.Salary:C}");

                }
                else
                {
                    Helper.ChangeTextColor(ConsoleColor.Red, "Invalid input for Employee ID. Please enter a valid number ");

                }
            }



        }
        public void SearchEmployeeByName()
        {
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Employee Name");
            string name=Console.ReadLine();
            var employees=_employeeService.SearchByName(name);
            if(employees.Count>0)
            {
                foreach (var employee in employees)
                {
                    if (employee.Name == name)
                    {
                        Helper.ChangeTextColor(ConsoleColor.DarkYellow, $"Details of Employee named {employee.Name} - Id : {employee.Id} | Department {employee.Department.Name} | Surname : {employee.Surname} | Age : {employee.Age} | Adress : {employee.Adress} | Email : {employee.Email} | Phone : {employee.PhoneNumber} | Salary : {employee.Salary:C}");

                    }
                }
            }
            else
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "There is no Employee with given Name");
            }
        }
        public void GetEmployeesCount()
        {
            int count=0;
            var employees = _employeeService.GetEmployeesCount(count);
                if (employees.Count != null)
                {
                    
                    Helper.ChangeTextColor(ConsoleColor.DarkYellow, $"{employees.Count}");

                }
                else
                {
                    Helper.ChangeTextColor(ConsoleColor.Red, "Empty List ");

                }
         }
        public void SearchEmployeeBySurname()
        {
            Helper.ChangeTextColor(ConsoleColor.DarkBlue, "Enter Employee Surname");
            string surname = Console.ReadLine();
            var employees = _employeeService.SearchByName(surname);
            if (employees.Count > 0)
            {
                foreach (var employee in employees)
                {
                    if (employee.Surname == surname)
                    {
                        Helper.ChangeTextColor(ConsoleColor.DarkYellow, $"Details of Employee with Surname {employee.Surname} - Name : {employee.Name} - Id : {employee.Id} | Age : {employee.Age} | Adress : {employee.Adress} | Email : {employee.Email} | Phone : {employee.PhoneNumber} | Salary : {employee.Salary:C}");

                    }
                }
            }
            else
            {
                Helper.ChangeTextColor(ConsoleColor.Red, "There is no Employee with given Surname");
            }
        }

    }
}
