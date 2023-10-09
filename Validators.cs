using System;
using System.Globalization;

namespace EmployeesManagement
{
    public static class Validators 
    {
        public static string ValidateName(string name)
        {
            
            if (typeof(string) != name.GetType())
                throw new ArgumentException("O nome deve ser uma string.");

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("O nome não pode ser vazio.");
         
            if (name.Trim().Length < 3)
                throw new ArgumentException("O nome deve ter pelo 3 caracteres");

            return name;
        }

        public static int ValidateAge(int age)
        {
            //Troca da idade que estava <= 18
            if (age < 18)
                throw new ArgumentException("O funcionário deve ser maior de idade.");

            return age;
        }

        public static DateTime ValidateDateOfBirth(string dateOfBirth)
        {

            if (string.IsNullOrEmpty(dateOfBirth) || string.IsNullOrWhiteSpace(dateOfBirth) ||  dateOfBirth.GetType() != typeof(string))
                throw new ArgumentException("A data de nascimento precisa ser assim: dd/mm/yyyy.");

            DateTime date =  DateTime.Parse(dateOfBirth.Trim(), new CultureInfo("pt-br"));
     

            if (date > DateTime.Now)
                throw new ArgumentException("A data de nascimento não pode ser no futuro.");


            return date;


        }


        public static decimal ValidateSalary(string MySalary)
        {
        

            //Inserido validação para ser digitado um numero e por padrão o salário é 0
            decimal Salary = decimal.TryParse(MySalary.Trim(), out decimal result) ? result : 0;
            
            //Inserido validação para ser digitado um numero
            if (typeof(decimal) != Salary.GetType())
                throw new ArgumentException("O nome deve ser um numero válido.");

            //inserido validação para salário negativo e mínimo

            if (Salary < Employee.MinimumSalary)
                Salary = Employee.MinimumSalary;


            return Salary;
        }

        public static int ValidateChoice(int choice)
        {
         
            if (choice < 1 || choice > 6)
                throw new Exception("a escolha deve ser entre 1 e 6.");

            return choice;
        }

        public static int ValidateEmployeeId(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("A matrícula não pode ser vazia.");
                
            int employeeId = int.TryParse(id.Trim(), out int result) ? result : 0;

            foreach (Employee employee in Company.employees)
            {
                if (employee.EmployeeId == employeeId)
                    throw new ArgumentException("Já existe um funcionário com essa matrícula.");
            }
            if (employeeId.GetType() != typeof(int))
                throw new ArgumentException("A matrícula deve ser um número inteiro.");
            if (employeeId < 0)
                throw new ArgumentException("A matrícula deve ser um número positivo.");

            return employeeId;
        }

        








    }

}