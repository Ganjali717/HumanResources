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

        /**/
        public HumanResource()
        {
            _departments = new Department[0]; 
        }

        private Department[] _departments; 
        public Department[] Department { get { return _departments; } }



                                       /* M E T H O D S */
        /*  =============================================================================================== */
        
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





                                  /* H E L P E R     M E T H O D S */
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
    }
}
