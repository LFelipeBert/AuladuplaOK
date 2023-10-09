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
            DateTime date =  DateTime.Parse(dateOfBirth, new CultureInfo("pt-BR"));

            if (typeof(DateTime) != date.GetType())
                throw new ArgumentException("A data de nascimento deve ser uma data válida.");

            if (date > DateTime.Now)
                throw new ArgumentException("A data de nascimento não pode ser no futuro.");


            return date;


        }

        public static double ValidatePercentageIncrease(double percentageIncrease)
        {
            if (percentageIncrease < 0)
                throw new ArgumentException("O percentual de aumento não pode ser negativo.");

            return percentageIncrease;
        }

        public static decimal ValidateSalary(decimal Salary)
        {
            //Inserido validação para ser digitado um numero
            if (typeof(decimal) != Salary.GetType())
                throw new ArgumentException("O nome deve ser um numero válido.");

            //inserido validação para salário negativo
            if (Salary <= 0)
                throw new ArgumentException($"\nO salário não pode ser negativo");

            if (Salary < Employee.MinimumSalary)
                Salary = Employee.MinimumSalary;


            //Deixei comentado abaixo pois o WriteLine ta duplicando as linhas e não entendi o pq, e a excessão ja fecha o programa.
            //throw new Exception($"O salário não pode ser menor do que: {Employee.MinimumSalary},o mesmo será modificado pelo Salário Mínimo");
            //Console.WriteLine("\nSalário inserido menor que o Salário Mínimo, o mesmo será modificado para o salário minimo");

            return Salary;
        }

        public static int ValidateChoice(int choice)
        {
         
            if (choice < 1 || choice > 6)
                throw new Exception("a escolha deve ser entre 1 e 6.");

            return choice;
        }

        








    }

}