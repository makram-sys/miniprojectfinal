
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using miniprojectfinal.Models;
using miniprojectfinal.Services;

namespace miniproject.Menu
{
    public class MainMenu
    {
        private readonly DataService _dataService;

        public MainMenu()
        {
            _dataService = new DataService();
        }

        public void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Company Management System ===");
                Console.WriteLine("1. Manage Employees");
                Console.WriteLine("2. Manage Departments");
                Console.WriteLine("3. Manage Projects");
                Console.WriteLine("4. View Reports");
                Console.WriteLine("5. Exit");
                Console.Write("Choose option: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ShowEmployeeMenu();
                        break;
                    case "2":
                        ShowDepartmentMenu();
                        break;
                    case "3":
                        ShowProjectMenu();
                        break;
                    case "4":
                        ShowReportsMenu();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowEmployeeMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Employee Management ===");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. Edit Employee");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. View All Employees");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Choose option: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        EditEmployee();
                        break;
                    case "3":
                        DeleteEmployee();
                        break;
                    case "4":
                        DisplayAllEmployees();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowDepartmentMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Department Management ===");
                Console.WriteLine("1. Add New Department");
                Console.WriteLine("2. Edit Department");
                Console.WriteLine("3. Delete Department");
                Console.WriteLine("4. View All Departments");
                Console.WriteLine("5. Assign Employee to Department");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Choose option: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddDepartment();
                        break;
                    case "2":
                        EditDepartment();
                        break;
                    case "3":
                        DeleteDepartment();
                        break;
                    case "4":
                        DisplayAllDepartments();
                        break;
                    case "5":
                        AssignEmployeeToDepartment();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowProjectMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Project Management ===");
                Console.WriteLine("1. Add New Project");
                Console.WriteLine("2. Edit Project");
                Console.WriteLine("3. Delete Project");
                Console.WriteLine("4. View All Projects");
                Console.WriteLine("5. Assign Employee to Project");
                Console.WriteLine("6. Remove Employee from Project");
                Console.WriteLine("7. Back to Main Menu");
                Console.Write("Choose option: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddProject();
                        break;
                    case "2":
                        EditProject();
                        break;
                    case "3":
                        DeleteProject();
                        break;
                    case "4":
                        DisplayAllProjects();
                        break;
                    case "5":
                        AssignEmployeeToProject();
                        break;
                    case "6":
                        RemoveEmployeeFromProject();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowReportsMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Reports ===");
                Console.WriteLine("1. View All Employees with Details");
                Console.WriteLine("2. View All Departments with Employees");
                Console.WriteLine("3. View All Projects with Employees");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Choose option: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        DisplayAllEmployeesDetailed();
                        break;
                    case "2":
                        DisplayAllDepartmentsDetailed();
                        break;
                    case "3":
                        DisplayAllProjectsDetailed();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Employee Methods
        public void AddEmployee()
        {
            Console.Clear();
            Console.WriteLine("=== Add New Employee ===");


            var departments = _dataService.GetAllDepartments();
            if (departments.Count == 0)
            {
                Console.WriteLine("No departments available! Please add a department first.");
                Console.ReadKey();
                return;
            }

            var employee = new Employee();


            Console.Write("Enter Name: ");
            employee.Name = Console.ReadLine();


            while (true)
            {
                Console.Write("Enter Email: ");
                employee.Email = Console.ReadLine();

                if (IsValidEmail(employee.Email))
                    break;
                else
                    Console.WriteLine("Invalid email format! Please enter a valid email.");
            }


            Console.Write("Enter Position: ");
            employee.Position = Console.ReadLine();


            DateTime hireDate;
            while (true)
            {
                Console.Write("Enter Hire Date (yyyy-mm-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out hireDate))
                {
                    employee.HireDate = hireDate;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid date format! Please use yyyy-mm-dd format.");
                }
            }


            Console.WriteLine("\nAvailable Departments:");
            foreach (var dept in departments)
            {
                Console.WriteLine($"{dept.Id}: {dept.Name}");
            }

            int departmentId;
            while (true)
            {
                Console.Write("Enter Department ID: ");
                if (int.TryParse(Console.ReadLine(), out departmentId))
                {
                    if (departments.Any(d => d.Id == departmentId))
                    {
                        employee.DepartmentId = departmentId;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Department ID not found! Please choose from the list above.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a valid number.");
                }
            }

            try
            {
                _dataService.AddEmployee(employee);
                Console.WriteLine("Employee added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding employee: {ex.Message}");
            }

            Console.ReadKey();
        }


        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void EditEmployee()
        {
            Console.Clear();
            Console.WriteLine("=== Edit Employee ===");
            DisplayAllEmployees();

            Console.Write("Enter Employee ID to edit: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var employee = _dataService.GetEmployeeById(id);
                if (employee != null)
                {
                    Console.Write($"Enter new Name ({employee.Name}): ");
                    var name = Console.ReadLine();
                    if (!string.IsNullOrEmpty(name)) employee.Name = name;

                    Console.Write($"Enter new Email ({employee.Email}): ");
                    var email = Console.ReadLine();
                    if (!string.IsNullOrEmpty(email)) employee.Email = email;

                    Console.Write($"Enter new Position ({employee.Position}): ");
                    var position = Console.ReadLine();
                    if (!string.IsNullOrEmpty(position)) employee.Position = position;

                    Console.WriteLine("1. Assign to Department");
                    Console.WriteLine("2. Assign to Project");
                    Console.WriteLine("3. Just update data");
                    Console.Write("Choose: ");

                    var choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            AssignEmployeeToDepartment(employee.Id);
                            break;
                        case "2":
                            AssignEmployeeToProject(employee.Id);
                            break;
                    }

                    _dataService.UpdateEmployee(employee);
                    Console.WriteLine("Employee updated successfully!");
                }
                else
                {
                    Console.WriteLine("Employee not found!");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID!");
            }
            Console.ReadKey();
        }

        private void DeleteEmployee()
        {
            Console.Clear();
            Console.WriteLine("=== Delete Employee ===");
            DisplayAllEmployees();

            Console.Write("Enter Employee ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _dataService.DeleteEmployee(id);
                Console.WriteLine("Employee deleted successfully!");
            }
            else
            {
                Console.WriteLine("Invalid ID!");
            }
            Console.ReadKey();
        }

        private void DisplayAllEmployees()
        {
            Console.Clear();
            Console.WriteLine("=== All Employees ===");
            var employees = _dataService.GetAllEmployees();

            foreach (var emp in employees)
            {
                Console.WriteLine(emp.ToString());
            }
            Console.ReadKey();
        }

        private void DisplayAllEmployeesDetailed()
        {
            Console.Clear();
            Console.WriteLine("=== All Employees (Detailed) ===");
            var employees = _dataService.GetAllEmployees();

            foreach (var emp in employees)
            {
                Console.WriteLine($"ID: {emp.Id}");
                Console.WriteLine($"Name: {emp.Name}");
                Console.WriteLine($"Email: {emp.Email}");
                Console.WriteLine($"Position: {emp.Position}");
                Console.WriteLine($"Hire Date: {emp.HireDate:yyyy-MM-dd}");
                Console.WriteLine($"Department: {emp.Department?.Name ?? "None"}");
                Console.WriteLine($"Projects: {string.Join(", ", emp.Projects.Select(p => p.Name))}");
                Console.WriteLine("------------------------");
            }
            Console.ReadKey();
        }

        // Department Methods
        private void AddDepartment()
        {
            Console.Clear();
            Console.WriteLine("=== Add New Department ===");

            Console.Write("Enter Department Name: ");
            var name = Console.ReadLine();

            var department = new Department { Name = name };
            _dataService.AddDepartment(department);

            Console.WriteLine("Department added successfully!");
            Console.ReadKey();
        }

        private void EditDepartment()
        {
            Console.Clear();
            Console.WriteLine("=== Edit Department ===");
            DisplayAllDepartments();

            Console.Write("Enter Department ID to edit: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var department = _dataService.GetDepartmentById(id);
                if (department != null)
                {
                    Console.Write($"Enter new Name ({department.Name}): ");
                    var name = Console.ReadLine();
                    if (!string.IsNullOrEmpty(name)) department.Name = name;

                    _dataService.UpdateDepartment(department);
                    Console.WriteLine("Department updated successfully!");
                }
                else
                {
                    Console.WriteLine("Department not found!");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID!");
            }
            Console.ReadKey();
        }

        private void DeleteDepartment()
        {
            Console.Clear();
            Console.WriteLine("=== Delete Department ===");
            DisplayAllDepartments();

            Console.Write("Enter Department ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                // التحقق مما إذا كان القسم يحتوي على موظفين
                var department = _dataService.GetDepartmentById(id);
                if (department != null)
                {
                    if (department.Employees != null && department.Employees.Any())
                    {
                        Console.WriteLine("Cannot delete department! The department has employees assigned to it.");
                        Console.WriteLine($"Number of employees in this department: {department.Employees.Count}");
                        Console.WriteLine("Please reassign or delete these employees first.");
                    }
                    else
                    {
                        _dataService.DeleteDepartment(id);
                        Console.WriteLine("Department deleted successfully!");
                    }
                }
                else
                {
                    Console.WriteLine("Department not found!");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID!");
            }
            Console.ReadKey();
        }

        private void DisplayAllDepartments()
        {
            Console.Clear();
            Console.WriteLine("=== All Departments ===");
            var departments = _dataService.GetAllDepartments();

            foreach (var dept in departments)
            {
                Console.WriteLine(dept.ToString());
            }
            Console.ReadKey();
        }

        private void DisplayAllDepartmentsDetailed()
        {
            Console.Clear();
            Console.WriteLine("=== All Departments (Detailed) ===");
            var departments = _dataService.GetAllDepartments();

            foreach (var dept in departments)
            {
                Console.WriteLine($"ID: {dept.Id}");
                Console.WriteLine($"Name: {dept.Name}");
                Console.WriteLine($"Employees: {dept.Employees.Count}");
                foreach (var emp in dept.Employees)
                {
                    Console.WriteLine($"  - {emp.Name} ({emp.Position})");
                }
                Console.WriteLine("------------------------");
            }
            Console.ReadKey();
        }

        private void AssignEmployeeToDepartment()
        {
            Console.Clear();
            Console.WriteLine("=== Assign Employee to Department ===");

            DisplayAllEmployees();
            Console.Write("Enter Employee ID: ");
            if (int.TryParse(Console.ReadLine(), out int empId))
            {
                DisplayAllDepartments();
                Console.Write("Enter Department ID: ");
                if (int.TryParse(Console.ReadLine(), out int deptId))
                {
                    _dataService.AssignEmployeeToDepartment(empId, deptId);
                    Console.WriteLine("Employee assigned to department successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid Department ID!");
                }
            }
            else
            {
                Console.WriteLine("Invalid Employee ID!");
            }
            Console.ReadKey();
        }

        private void AssignEmployeeToDepartment(int employeeId)
        {
            Console.Clear();
            Console.WriteLine("=== Assign Employee to Department ===");

            DisplayAllDepartments();
            Console.Write("Enter Department ID: ");
            if (int.TryParse(Console.ReadLine(), out int deptId))
            {
                _dataService.AssignEmployeeToDepartment(employeeId, deptId);
                Console.WriteLine("Employee assigned to department successfully!");
            }
            else
            {
                Console.WriteLine("Invalid Department ID!");
            }
            Console.ReadKey();
        }

        // Project Methods
        private void AddProject()
        {
            Console.Clear();
            Console.WriteLine("=== Add New Project ===");

            var project = new Project();

            Console.Write("Enter Project Name: ");
            project.Name = Console.ReadLine();

            Console.Write("Enter Description: ");
            project.Description = Console.ReadLine();

            Console.Write("Enter Start Date (yyyy-mm-dd) or press Enter for today: ");
            var startDateInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(startDateInput))
            {
                project.StartDate = DateTime.Parse(startDateInput);
            }

            Console.Write("Enter End Date (yyyy-mm-dd) or press Enter for none: ");
            var endDateInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(endDateInput))
            {
                project.EndDate = DateTime.Parse(endDateInput);
            }

            _dataService.AddProject(project);
            Console.WriteLine("Project added successfully!");
            Console.ReadKey();
        }

        private void EditProject()
        {
            Console.Clear();
            Console.WriteLine("=== Edit Project ===");
            DisplayAllProjects();

            Console.Write("Enter Project ID to edit: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var project = _dataService.GetProjectById(id);
                if (project != null)
                {
                    Console.Write($"Enter new Name ({project.Name}): ");
                    var name = Console.ReadLine();
                    if (!string.IsNullOrEmpty(name)) project.Name = name;

                    Console.Write($"Enter new Description ({project.Description}): ");
                    var description = Console.ReadLine();
                    if (!string.IsNullOrEmpty(description)) project.Description = description;

                    _dataService.UpdateProject(project);
                    Console.WriteLine("Project updated successfully!");
                }
                else
                {
                    Console.WriteLine("Project not found!");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID!");
            }
            Console.ReadKey();
        }

        private void DeleteProject()
        {
            Console.Clear();
            Console.WriteLine("=== Delete Project ===");
            DisplayAllProjects();

            Console.Write("Enter Project ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _dataService.DeleteProject(id);
                Console.WriteLine("Project deleted successfully!");
            }
            else
            {
                Console.WriteLine("Invalid ID!");
            }
            Console.ReadKey();
        }

        private void DisplayAllProjects()
        {
            Console.Clear();
            Console.WriteLine("=== All Projects ===");
            var projects = _dataService.GetAllProjects();

            foreach (var proj in projects)
            {
                Console.WriteLine(proj.ToString());
            }
            Console.ReadKey();
        }

        private void DisplayAllProjectsDetailed()
        {
            Console.Clear();
            Console.WriteLine("=== All Projects (Detailed) ===");
            var projects = _dataService.GetAllProjects();

            foreach (var proj in projects)
            {
                Console.WriteLine($"ID: {proj.Id}");
                Console.WriteLine($"Name: {proj.Name}");
                Console.WriteLine($"Description: {proj.Description}");
                Console.WriteLine($"Start Date: {proj.StartDate:yyyy-MM-dd}");
                Console.WriteLine($"End Date: {proj.EndDate?.ToString("yyyy-MM-dd") ?? "Ongoing"}");
                Console.WriteLine($"Employees: {proj.Employees.Count}");
                foreach (var emp in proj.Employees)
                {
                    Console.WriteLine($"  - {emp.Name} ({emp.Position})");
                }
                Console.WriteLine("------------------------");
            }
            Console.ReadKey();
        }

        private void AssignEmployeeToProject()
        {
            Console.Clear();
            Console.WriteLine("=== Assign Employee to Project ===");

            DisplayAllEmployees();
            Console.Write("Enter Employee ID: ");
            if (int.TryParse(Console.ReadLine(), out int empId))
            {
                DisplayAllProjects();
                Console.Write("Enter Project ID: ");
                if (int.TryParse(Console.ReadLine(), out int projId))
                {
                    _dataService.AssignEmployeeToProject(empId, projId);
                    Console.WriteLine("Employee assigned to project successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid Project ID!");
                }
            }
            else
            {
                Console.WriteLine("Invalid Employee ID!");
            }
            Console.ReadKey();
        }

        private void AssignEmployeeToProject(int employeeId)
        {
            Console.Clear();
            Console.WriteLine("=== Assign Employee to Project ===");

            DisplayAllProjects();
            Console.Write("Enter Project ID: ");
            if (int.TryParse(Console.ReadLine(), out int projId))
            {
                _dataService.AssignEmployeeToProject(employeeId, projId);
                Console.WriteLine("Employee assigned to project successfully!");
            }
            else
            {
                Console.WriteLine("Invalid Project ID!");
            }
            Console.ReadKey();
        }

        private void RemoveEmployeeFromProject()
        {
            Console.Clear();
            Console.WriteLine("=== Remove Employee from Project ===");

            DisplayAllEmployees();
            Console.Write("Enter Employee ID: ");
            if (int.TryParse(Console.ReadLine(), out int empId))
            {
                var employee = _dataService.GetEmployeeById(empId);
                if (employee != null && employee.Projects.Any())
                {
                    Console.WriteLine("Current Projects:");
                    foreach (var project in employee.Projects)
                    {
                        Console.WriteLine($"  {project.Id}: {project.Name}");
                    }

                    Console.Write("Enter Project ID to remove from: ");
                    if (int.TryParse(Console.ReadLine(), out int projId))
                    {
                        _dataService.RemoveEmployeeFromProject(empId, projId);
                        Console.WriteLine("Employee removed from project successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Project ID!");
                    }
                }
                else
                {
                    Console.WriteLine("Employee has no projects assigned!");
                }
            }
            else
            {
                Console.WriteLine("Invalid Employee ID!");
            }
            Console.ReadKey();
        }
    }
}