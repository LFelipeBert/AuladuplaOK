using System;

namespace EmployeesManagement
{
    public class Employee
    {

        private decimal _monthlySalary;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private int EmployeeId = new Random().Next(1000, 9999);
        public int Age { get; set; }
        public decimal actualSalary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime HireDate { get; set; }

        public decimal MonthlySalary
        {
            get { return _monthlySalary; }
            set
            {
                _monthlySalary = Validators.ValidateSalary(value.ToString());

            }
        }

        public static decimal MinimumSalary = 1320.00m;

        public Employee(string firstName, string lastName, int age, DateTime dateOfBirth, decimal actualSalary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            DateOfBirth = dateOfBirth;
            MonthlySalary = actualSalary;
        }

        public decimal CalculateAnnualSalary()
        {
            return MonthlySalary * 12;
        }

        public void Promote(decimal percentageIncrease)
        {
            //Arrumada a porcentagem para soma onde o aumento é somente 10%
            MonthlySalary += MonthlySalary / 10;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} (Matrícula: {EmployeeId}) - Idade: {Age} - Salário Mensal: R${MonthlySalary:F2}";
        }
    }

}