using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            SoftUniContext context = new SoftUniContext();
            Console.WriteLine(RemoveTown(context));
        }
        //03. Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var list = context.Employees.OrderBy(e => e.EmployeeId).Select(x => new
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                MiddleName = x.MiddleName,
                Salary = x.Salary,
                JobTitle = x.JobTitle,
            }).ToList();
            foreach (var employee in list)
            {
                sb.Append($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
                sb.Append(Environment.NewLine);
            }
            return sb.ToString().Trim();
        }
        //04. Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var list = context.Employees.OrderBy(e => e.FirstName).Where(x => x.Salary > 50000).Select(x => $"{x.FirstName} - {x.Salary:F2}").ToList();
            return String.Join(Environment.NewLine, list);
        }
        //05. Employees from Research and Development

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var list = context.Employees
                .Where(x => x.Department.Name == "Research and Development")
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DepartmentName = x.Department.Name,
                    Salary = x.Salary
                })
                .ToList();
            foreach (var employee in list)
            {
                sb.Append($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:F2}");
                sb.Append(Environment.NewLine);
            }
            return sb.ToString().Trim();
        }
        //06. Adding a New Address and Updating Employee

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {

            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 5
            };
            context.Addresses.Add(address);

            context.Employees.First(x => x.LastName == "Nakov").Address = address;

            context.SaveChanges();
            var result = context.Employees.OrderByDescending(x => x.AddressId).Take(10).Select(x => x.Address.AddressText).ToList();
            return String.Join(Environment.NewLine, result);

        }
        //07. Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var empwithProject = context.Employees
                .Take(10)
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ManagerFirstName = x.Manager!.FirstName,
                    ManagerLastName = x.Manager!.LastName,
                    Projects = x.EmployeesProjects.Where(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003)
                    .Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        StartDate = p.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                        EndDate = p.Project.EndDate.HasValue ? p.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished"
                    })
                    .ToList()
                })
                .ToList();

            var sb = new StringBuilder();
            foreach (var e in empwithProject)
            {

                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                foreach (var project in e.Projects)
                {
                    sb.AppendLine($"--{project.ProjectName} - {project.StartDate} - {project.EndDate}");
                }
            }
            return sb.ToString().Trim();
        }
        //08. Addresses by Town

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var result = context.Addresses
                .OrderByDescending(x => x.Employees.Count)
                .ThenBy(x => x.Town.Name)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .Select(x => $"{x.AddressText}, {x.Town.Name} - {x.Employees.Count} employees");
            return String.Join(Environment.NewLine, result);
        }
        //09. Employee 147

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Include(x => x.EmployeesProjects)
                .FirstOrDefault(x => x.EmployeeId == 147);

            var sb = new StringBuilder();
            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var item in employee.EmployeesProjects.OrderBy(x => x.Project.Name))
            {
                Project project = item.Project;

                sb.AppendLine(project.Name);
            }
            return sb.ToString().Trim();

        }
        //10. Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var result = context.Departments
                .Where(x => x.Employees.Count > 5)
                .OrderBy(x => x.Employees.Count)
                .ThenBy(x => x.Name)
                .Select(x => new
                {
                    DepartmentName = x.Name,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Employees = x.Employees
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                        .Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle}")
                        .ToList()
                })
                .ToList();
            var sb = new StringBuilder();
            foreach (var department in result)
            {
                sb.AppendLine($"{department.DepartmentName} - {department.ManagerFirstName}  {department.ManagerLastName}");
                foreach (var employee in department.Employees)
                {
                    sb.AppendLine(employee);
                }
            }
            return sb.ToString().Trim();
        }
        //11. Find Latest 10 Projects

        public static string GetLatestProjects(SoftUniContext context)
        {
            var result = context.Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .OrderBy(x => x.Name)
                .Select(x => $"{x.Name}" + Environment.NewLine +
                $"{x.Description}" + Environment.NewLine +
                $"{x.StartDate.ToString("M/d/yyyy h:mm:ss tt")}")
                .ToList();
            return String.Join(Environment.NewLine, result);
        }
        //12. Increase Salaries

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var result = context.Employees
                .Where(x => x.Department.Name == "Engineering"
                || x.Department.Name == "Tool Design"
                || x.Department.Name == "Marketing"
                || x.Department.Name == "Information Services")
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();
            var sb = new StringBuilder();

            foreach (var employee in result)
            {
                employee.Salary *= (decimal)1.12;
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }
            return sb.ToString().Trim();

        }
        //13. Find Employees by First Name Starting With Sa

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var result = context.Employees
                .Where(x => x.FirstName.StartsWith("Sa"))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();
            var sb = new StringBuilder();

            foreach (var employee in result)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }
            return sb.ToString().Trim();
        }
        //14. Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context.Projects.Find(2);
            var employeeProjects = context.EmployeesProjects.Include(x => x.Employee).Where(x => x.ProjectId == project.ProjectId).ToList();
            foreach (var item in employeeProjects)
            {
                context.EmployeesProjects.Remove(item);
            }
            context.Projects.Remove(project);
            context.SaveChanges();

            var result = context.Projects.Take(10).ToList();
            var sb = new StringBuilder();

            foreach (var project1 in result)
            {
                sb.AppendLine(project1.Name);
            }
            return sb.ToString().Trim();
        }
        //15. Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns.FirstOrDefault(x => x.Name == "Seattle");
            var result = context.Addresses.Where(a => a.TownId == town.TownId).ToList();
            int count = 0;
            foreach (var address in result)
            {
                var employees = context.Employees.Where(e => e.AddressId == address.AddressId).ToList();
                foreach (var employee in employees)
                {
                    employee.AddressId = null;
                }
                count++;
                context.Remove(address);
            }
            context.Remove(town);

            context.SaveChanges();
            return $"{count} addresses in Seattle were deleted";
        }
    }
}