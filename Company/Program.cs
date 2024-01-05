using Company.Controllers;
using Company.Helpers;
using System.ComponentModel.Design;
using static Company.Helpers.Helper;

while (true)
{
    Helper.ChangeTextColor(ConsoleColor.Green, "Company App");
    Helper.ChangeTextColor(ConsoleColor.Yellow, "Enter number :" +
            " 1. Create Employee" +
            " 2. GetAllEmployee" +
            " 3. GetAllEmployeeWithName" +
            " 4. GetAllEmployeeById" +
            " 5. GetEmployeesByAge" +
            " 6. GetEmployeesCount"+
            " 7. GetAllEmployeeWithDepartmentName"+
            " 8. SearchEmployeeByName" +
            " 9. SearchEmployeeBySurname" +
            " 10. DeleteEmployee" +
            " 11. UpdateEmployee" +
            " 12. CreateDepartment" +
            " 13. GetAllDepartment" +
            " 14. GetDepartmentsBySize" +
             " 15. GetDepartmentById" +
            " 16. UpdateDepartment" +
            " 17. SearchDepartmentName" +
            " 18. DeleteDepartment" +
            " 19. GetDepartmentsCount" +
            " 0. Exit Menu");
    DepartmentController departmentController = new ();
    EmployeeController employeeController = new ();
    EnterMenu: string menu = Console.ReadLine();
    bool result = int.TryParse(menu, out int intMenu);
    if(result&& intMenu > 0 && intMenu < 20)
    {
        switch (intMenu)
        {
            case (int)Buttons.CreateEmployee:
                employeeController.CreateEmployee();
                break;
            case(int)Buttons.GetAllEmployee:
                employeeController.GetAllEmployee();
                break;
            case (int)Buttons.GetAllEmployeeWithName:
                employeeController.GetAllEmployeeWithName();
                break;
            case (int)Buttons.DeleteEmployee:
                employeeController.DeleteEmployee();
                break;
            case (int)Buttons.UpdateEmployee:
                employeeController.UpdateEmployee();
                break;
            case (int)Buttons.CreateDepartment:
                departmentController.CreateDepartment();
                break;
            case (int)Buttons.GetDepartmentById:
                departmentController.GetDepartmentById();
                break;
            case (int)Buttons.GetDepartmentsBySize:
                departmentController.GetDepartmentsBySize();
                break;
            case (int)Buttons.GetAllDepartment:
                departmentController.GetAllDepartments();
                break;
            case (int)Buttons.GetEmployeesByAge:
                employeeController.GetEmployeesByAge();
                break;
            case (int)Buttons.UpdateDepartment:
                departmentController.UpdateDepartment();
                break;
            case (int)Buttons.DeleteDepartment:
                departmentController.DeleteDepartment();
                break;
            case (int)Buttons.GetEmployeeById:
                employeeController.GetEmployeeById();
                break;
            case (int)Buttons.SearchEmployeeByName:
                employeeController.SearchEmployeeByName();
                break;
            case (int)Buttons.GetEmployeesCount:
                employeeController.GetEmployeesCount();
                    break;
            case (int)Buttons.GetAllEmployeeWithDepartmentName:
                employeeController.GetAllEmployeeWithDepartmentName();
                break;
            case (int)Buttons.SearchDepartmentName:
                departmentController.SearchDepartmentName();
                break;
            case (int)Buttons.SearchEmployeeBySurname:
                employeeController.SearchEmployeeBySurname();
                break;
            case (int)Buttons.GetDepartmentsCount:
                departmentController.GetDepartmentsCount();
                break;
             }
       
    }else if(intMenu==0)
    {
        Helper.ChangeTextColor(ConsoleColor.Cyan, "Bye");
        break;
    }
    else
    {
        Helper.ChangeTextColor(ConsoleColor.Red, "Enter valid number ");
        goto EnterMenu;
    }


}