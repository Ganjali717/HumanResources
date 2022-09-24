using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResources.Models;

namespace HumanResources.ServiceManagers
{
    public class HumanResource
    {
        public HumanResource()
        {
            _departments = new Department[0]; 
        }

        private Department[] _departments; 
        public Department[] Department { get { return _departments; } }
    }
}
