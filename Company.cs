using System;


namespace EmployeesManagement
{
    public class Company
    {
        private List<Employee> employees = new List<Employee>();
        private DateTime employeeHireDate;

        public void AddEmployee(Employee employee)
        {
            employeeHireDate = DateTime.Now;
            
            employees.Add(employee);

            Console.WriteLine($"{employee.FirstName} {employee.LastName} foi contratado. na data: {employeeHireDate}");
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
                Console.WriteLine($"{employee.FirstName} {employee.LastName} foi demitido.");
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