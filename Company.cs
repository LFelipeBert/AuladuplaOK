using System;


namespace EmployeesManagement
{
    public class Company
    {
        public static List<Employee> employees { get; private set; } = new List<Employee>();
        private DateTime employeeHireDate;

        public void AddEmployee(Employee employee)
        {
            employeeHireDate = DateTime.Now;
            
            employees.Add(employee);

            Console.WriteLine($"{employee.FirstName} {employee.LastName} foi contratado. na data: {employeeHireDate} com o salário de: {employee.MonthlySalary} e número de matrícula: {employee.EmployeeId}");
        }

        public void PromoteEmployee(string firstName, string lastName, decimal percentageIncrease)
        {
            Employee employee = FindEmployee(firstName, lastName);
            if (employee != null)
            {
                employee.Promote(percentageIncrease);
                Console.WriteLine($"{employee.FirstName} {employee.LastName} foi promovido.");
            }
            else
            {
                Console.WriteLine("funcionário não encontrado.");
            }
        }

        public void ListEmployees()
        {
            Console.WriteLine("\nLista de Funcionários:");
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        public Employee FindEmployee(string firstName, string lastName)
        {
            return employees.Find(e => e.FirstName == firstName && e.LastName == lastName);
        }

        public void RemoveEmployee(string firstName, string lastName)
        {
            Employee employee = FindEmployee(firstName, lastName);
            if (employee != null)
            {
                employees.Remove(employee);
                Console.WriteLine($" Funcionário {employee.FirstName} {employee.LastName} foi removido na data: {DateTime.Now}");
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado.");
            }
        }

        public void ListAnnualSalary(string firstName, string lastName)
        {
            Employee employee = FindEmployee(firstName, lastName);
            if (employee != null)
            {
                decimal annualSalary = employee.CalculateAnnualSalary();
                Console.WriteLine($"Salário anual do: {employee.FirstName} {employee.LastName}: R${annualSalary:F2} ");
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado.");
            }
        }
    }
}