using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Company.Helpers
{
    public class Helper
    {
        public static void ChangeTextColor(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public enum Buttons
        {
            CreateEmployee=1,
            GetAllEmployee,
            GetAllEmployeeWithName,
            GetEmployeeById,
            GetEmployeesByAge,
            GetEmployeesCount,
            GetAllEmployeeWithDepartmentName,
            SearchEmployeeByName,
            SearchEmployeeBySurname,
            DeleteEmployee,
            UpdateEmployee,
            CreateDepartment,
            GetAllDepartment,
            GetDepartmentsBySize,
            GetDepartmentById,
            UpdateDepartment,
            SearchDepartmentName,
            DeleteDepartment,
            GetDepartmentsCount,

            ExitMenu
        }
       
        public static bool ValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
        public static bool ValidPhoneNumberFormat(string phone)
        {
            Regex regex = new Regex(@"[^\d]");
            phone = regex.Replace(phone, "");
            return Regex.IsMatch(phone, @"(\d{3})(\d{3})(\d{4})");
        }
        public static bool Currency(string currency)
        {

            CultureInfo cultureInfo = new("az-AZ");
            cultureInfo.NumberFormat.CurrencySymbol = "AZN";
            CultureInfo.CurrentCulture = cultureInfo;
            return true;

        }
        public static bool ContainsLetters(string input)
        {
            return !string.IsNullOrEmpty(input) && input.Any(char.IsLetter);
        }
    }
}
