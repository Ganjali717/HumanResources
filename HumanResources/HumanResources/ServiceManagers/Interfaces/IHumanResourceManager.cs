using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResources.Models;

namespace HumanResources.ServiceManagers.Interfaces
{
    public interface IHumanResourceManager
    {
        public Department[] Department { get; }
        public void AddDepartment(string name, int employeeLimit, int salaryLimit);
        void EditDepartment(string name, string newName, int newworkerlimit, int newsalarylimit);
        void AddEmployee(string departmentname, string fullname, string position, int salary);
        void RemoveEmployee(string no, string departmentname);
        void EditEmployee(string no, int salary, string position);
        Employee[] SearchEmployee(string search);

        /// ================= ///
        Department FindDepartment(string name);
        Department FindDepartmentLimit(int workerlimmit, int salarylimit);
        Employee[] AllEmployees();
        Employee[] GetEmployeesByNo(string no);
        Employee[] GetEmployeesByName(string fullname);
    }
}
