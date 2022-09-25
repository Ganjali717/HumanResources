using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Models
{
    public class Employee
    {
        public static int TotalCount;
        static Employee()
        {
            TotalCount = 1000;
        }
        public Employee(string fullname, string departmentName, int salary)
        {
            this.Fullname = fullname;
            this.DepartmentName = departmentName;
            this.Salary = salary;
            No = DepartmentName[0] + TotalCount.ToString();
            TotalCount++;
        }

        public string No;
        public string Fullname;
        public string Position;
        public int Salary;
        public string DepartmentName;
        public override string ToString()
        {
            return $"Employee number: {No} | Fullname: {Fullname} | Department:{DepartmentName} | Position: {Position} | Salary:{Salary} AZN";
        }
    }
}
