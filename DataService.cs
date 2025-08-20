
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using miniprojectfinal.DataServices;
using miniprojectfinal.Models;

namespace miniprojectfinal.Services
{
    public class DataService
    {

        private readonly AppDbContext _context;

        public DataService()
        {
            _context = new AppDbContext();
            _context.Database.EnsureCreated();
        }

        // Methods for Employee
        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public List<Employee> GetAllEmployees()
        {
            return _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Projects)
                .ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Projects)
                .FirstOrDefault(e => e.Id == id);
        }

        public void UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }

        // Methods for Department
        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public List<Department> GetAllDepartments()
        {
            return _context.Departments
                .Include(d => d.Employees)
                .ToList();
        }

        public Department GetDepartmentById(int id)
        {
            return _context.Departments
                .Include(d => d.Employees)
                .FirstOrDefault(d => d.Id == id);
        }

        public void UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }

        public void DeleteDepartment(int id)
        {
            var department = _context.Departments.Find(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
        }

        // Methods for Project
        public void AddProject(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        public List<Project> GetAllProjects()
        {
            return _context.Projects
                .Include(p => p.Employees)
                .ToList();
        }

        public Project GetProjectById(int id)
        {
            return _context.Projects
                .Include(p => p.Employees)
                .FirstOrDefault(p => p.Id == id);
        }

        public void UpdateProject(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
        }

        public void DeleteProject(int id)
        {
            var project = _context.Projects.Find(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
        }

        // Additional methods for assignments
        public void AssignEmployeeToDepartment(int employeeId, int departmentId)
        {
            var employee = _context.Employees.Find(employeeId);
            var department = _context.Departments.Find(departmentId);

            if (employee != null && department != null)
            {
                employee.DepartmentId = departmentId;
                _context.SaveChanges();
            }
        }

        public void AssignEmployeeToProject(int employeeId, int projectId)
        {
            var employee = _context.Employees
                .Include(e => e.Projects)
                .FirstOrDefault(e => e.Id == employeeId);

            var project = _context.Projects.Find(projectId);

            if (employee != null && project != null)
            {
                employee.Projects.Add(project);
                _context.SaveChanges();
            }
        }

        public void RemoveEmployeeFromProject(int employeeId, int projectId)
        {
            var employee = _context.Employees
                .Include(e => e.Projects)
                .FirstOrDefault(e => e.Id == employeeId);

            var project = employee?.Projects.FirstOrDefault(p => p.Id == projectId);

            if (employee != null && project != null)
            {
                employee.Projects.Remove(project);
                _context.SaveChanges();
            }
        }


    }
}
