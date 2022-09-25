using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.Models
{
    public class Department
    {
        public Department(string name, int employeeLimit, int salarylimit)
        {
            this.Name = name;
            this.WorkerLimit = employeeLimit;
            this.SalaryLimit = salarylimit;
        }
        
        public string Name;
        public int WorkerLimit;
        public int SalaryLimit;
        public Employee[] employee = new Employee[0];
    }
}
