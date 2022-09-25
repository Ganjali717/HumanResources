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
        //The names of departments add to this array
        public Department[] Department { get; }

        /// =========================================================
        ///This method add department 
        public void AddDepartment(string name, int employeeLimit, int salaryLimit);

        /// =========================================================
        /// Edit department
        void EditDepartment(string name, string newName, int newworkerlimit, int newsalarylimit);

        /// =========================================================
        //Add employee
        void AddEmployee(string departmentname, string fullname, string position, int salary);

        /// =========================================================

        //remove employee
        void RemoveEmployee(string no, string departmentname);

        /// =========================================================
        //Edit employee
        void EditEmployee(string no, int salary, string position);


        /// =========================================================
        /// H E L P E R       M E T H O D S
        /// =========================================================

        Department FindDepartment(string name);


        Department FindDepartmentLimit(int workerlimmit, int salarylimit);

        Employee[] AllEmployees();
        Employee[] GetEmployeesByNo(string no);

        Employee[] GetEmployeesByName(string fullname);
    }
}
