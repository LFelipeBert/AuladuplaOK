using System;

namespace EmployeesManagement
{
    class Program
    {
        static void Main()
        {
            string name;
            string lastName;
            int age;
            DateTime birthDate;
            decimal actualSalary;
            double percentIncrease;
            int employeeId;

            Company company = new Company();

            while (true)
            {
                Console.WriteLine("\nMenu do Sistema de Gerenciamento de Empresas:");
                Console.WriteLine("1. Contratar Funcionário");
                Console.WriteLine("2. Promover Funcionário");
                Console.WriteLine("3. Listar Todos os Funcionários");
                Console.WriteLine("4. Remover Funcionário");
                Console.WriteLine("5. Listar Salário Anual de um Funcionário");
                Console.WriteLine("6. Sair");
                Console.Write("\nDigite sua escolha: ");

                try
                {
                    int choice = Validators.ValidateChoice(int.TryParse(Console.ReadLine(), out int result) ? result : 0);

                    switch (choice)
                    {
                        case 1:
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("\nDigite o nome do funcionário:");
                                    name = Validators.ValidateName(Console.ReadLine());
                                    Console.WriteLine("\nDigite o último nome do funcionário:");
                                    lastName = Validators.ValidateName(Console.ReadLine());
                                    Console.WriteLine("\nInforme a data de nascimento do funcionário:");
                                    birthDate = Validators.ValidateDateOfBirth(Console.ReadLine());

                                    // Trocado o calculo da idade para corresponder a data de nascimento.
                                    age = Validators.ValidateAge(age = DateTime.Now.Year - birthDate.Year);

                                    // Adicionada a inserção do Salário em decimal
                                    Console.WriteLine("\nInforme o Salário do funcionário:");
                                    actualSalary = Validators.ValidateSalary(Console.ReadLine());

                                    Console.WriteLine("\nInforme o número de matrícula do funcionário:");
                                    employeeId = Validators.ValidateEmployeeId(Console.ReadLine());

                                    Employee employee = new Employee(name, lastName, age, birthDate, actualSalary, employeeId);
                                    company.AddEmployee(employee);
                                    break; // Sair do loop interno se não houver exceção
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                            break;

                        case 2:
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("\nDigite o nome do funcionário:");
                                    name = Validators.ValidateName(Console.ReadLine());
                                    Console.WriteLine("\nDigite o último nome do funcionário:");
                                    lastName = Validators.ValidateName(Console.ReadLine());

                                    // Removido o ReadLine da porcentagem pois a mesma é fixa em 10%.
                                    percentIncrease = 10;

                                    company.PromoteEmployee(name, lastName, (decimal)percentIncrease);
                  
                                    break; 
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                            break;

                        case 3:
                            company.ListEmployees();
                            break;

                        case 4:
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("\nDigite o nome do funcionário:");
                                    name = Validators.ValidateName(Console.ReadLine());
                                    Console.WriteLine("\nDigite o último nome do funcionário:");
                                    lastName = Validators.ValidateName(Console.ReadLine());

                                    company.RemoveEmployee(name, lastName);
                                    break; 
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                            break;

                        case 5:
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("\nDigite o nome do funcionário:");
                                    name = Validators.ValidateName(Console.ReadLine());
                                    Console.WriteLine("\nDigite o último nome do funcionário:");
                                    lastName = Validators.ValidateName(Console.ReadLine());

                                    company.ListAnnualSalary(name, lastName);
                                    break; 
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                            break;

                        case 6:
                            Console.WriteLine("\nSaindo do sistema...");
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("\nOpção inválida.");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
