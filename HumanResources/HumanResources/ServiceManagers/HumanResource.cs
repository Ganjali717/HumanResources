using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResources.Models;
using HumanResources.ServiceManagers.Interfaces;

namespace HumanResources.ServiceManagers
{
    public class HumanResource:IHumanResourceManager
    {
        public HumanResource()
        {
            _departments = new Department[0]; 
        }

        private Department[] _departments; 
        public Department[] Department { get { return _departments; } }
        public void AddDepartment(string name, int employeelimit, int salarylimit)
        {
            Department department = FindDepartment(name);
            if (department == null)
            {
                department = new Department(name, employeelimit, salarylimit);
                Array.Resize(ref _departments, _departments.Length + 1);
                _departments[_departments.Length - 1] = department;
            }
        }
        public void EditDepartment(string name, string newName, int newworkerlimit, int newsalarylimit)
        {
            if (FindDepartment(newName) != null) return;
            if (FindDepartmentLimit(newworkerlimit, newsalarylimit) == null) return;

            Department existDepartment = FindDepartment(name);/*
            existDepartment = FindDepartmentLimit(newworkerlimit, newsalarylimit);*/

            if (existDepartment != null)
            {
                existDepartment.Name = newName;
                existDepartment.WorkerLimit = newworkerlimit;
                existDepartment.SalaryLimit = newsalarylimit;
            }
        }
        public void AddEmployee(string departmentName, string fullname, string position, int salary)
        {
            Department department = FindDepartment(departmentName); 
            if(department == null) return;

            Employee employee = new Employee(fullname, position, salary)
            {
                DepartmentName = departmentName, 
                Salary = salary,
                Position = position
            };

            Array.Resize(ref department.employee, department.employee.Length + 1);
            department.employee[department.employee.Length - 1] = employee;
        }
        public void EditEmployee(string no, int newSalary, string newPosition)
        {

            if (GetEmployeesByNo(no) == null) return;

            Employee[] existEmployee = GetEmployeesByNo(no);

            foreach (var item in existEmployee)
            {
                if (item.No == no)
                {
                    item.Salary = newSalary;
                    item.Position = newPosition;
                }

            }

        }
        public void RemoveEmployee(string no, string departmentname)
        {

            if (GetEmployeesByNo(no) == null) return;

            Employee[] removeEmployee = GetEmployeesByNo(no);
            foreach (var item in removeEmployee)
            {
                if (item.No == no && item.DepartmentName == departmentname)
                {
                    item.No = null;
                    item.Fullname = null;
                    item.Position = null;
                    item.Salary = 0;
                    item.DepartmentName = null;
                }

            }

        }
        public Employee[] SearchEmployee(string search)
        {
            Employee[] employees = new Employee[0];
            foreach (var department in _departments)
            {
                foreach (var empl in department.employee)
                {
                    if ((empl.Fullname).Contains(search))
                    {

                        Array.Resize(ref employees, employees.Length + 1);
                        employees[employees.Length - 1] = empl;

                    }
                }
            }
            return employees;
        }

        /*  =============================================================================================== */
        public Department FindDepartment(string name)
        {

            foreach (var item in _departments)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }
        public Department FindDepartmentLimit(int workerlimit, int salarylimit)
        {
            foreach (var item in _departments)
            {
                if (item.WorkerLimit == workerlimit && item.SalaryLimit == salarylimit)
                {
                    return item;
                }
            }
            return null;
        }
        public Employee[] AllEmployees()
        {
            Employee[] employees = new Employee[0];

            foreach (var department in _departments)
            {
                foreach (var empl in department.employee)
                {

                    Array.Resize(ref employees, employees.Length + 1);
                    employees[employees.Length - 1] = empl;
                }
            }
            return employees;
        }
        public Employee[] GetEmployeesByNo(string no)
        {
            Employee[] employee = AllEmployees();

            foreach (var item in employee)
            {
                if (item.No == no)
                {
                    Array.Resize(ref employee, employee.Length + 1);
                    employee[employee.Length - 1] = item;
                }
            }

            return employee;

        }
        public Employee[] GetEmployeesByName(string fullname)
        {
            Employee[] employees = new Employee[0];
            foreach (var department in _departments)
            {
                foreach (var empl in department.employee)
                {
                    if (empl.Fullname == fullname)
                    {

                        Array.Resize(ref employees, employees.Length + 1);
                        employees[employees.Length - 1] = empl;

                    }
                }
            }
            return employees;
        }
    }
}
