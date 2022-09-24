using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources.ServiceManagers.Interfaces
{
    public interface IHumanResourceManager
    {
        public void AddDepartment(string name, int employeeLimit, int salaryLimit);
    }
}
