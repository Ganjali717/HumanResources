using HumanResources.Models;using HumanResources.ServiceManagers;



/*Human resources simple console application project for practice*/


HumanResource humanResource = new HumanResource();

string ans;
do
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\n==============================================\n");

    Console.WriteLine("1.1 - List of departments");
    Console.WriteLine("1.2 - Create department");
    Console.WriteLine("1.3 - Edit department");
    Console.WriteLine("2.1 - List of all employees");
    Console.WriteLine("2.2 - List of employees in department");
    Console.WriteLine("2.3 - Add employe");
    Console.WriteLine("2.4 - Edit employe");
    Console.WriteLine("2.5 - Delete employe from department");
    Console.WriteLine("2.6 - Search");

    Console.WriteLine("3 - EXIT");

    Console.WriteLine("\nSelect the operation you want to perform:");
    Console.ForegroundColor = ConsoleColor.White;
    ans = Console.ReadLine();
    switch (ans)
    {
        case "1.1":
            ShowDepartments(humanResource);
            break;
        case "1.2": 
            AddDepartment(humanResource);
            break;
        case "1.3":
            EditDepartment(humanResource);
            break;
        case "2.1":
            ShowAllEmployees(humanResource);
            break;
        case "2.2":
            ShowEmployesOfDepartment(humanResource);
            break;
        case "2.3":
            AddEmployee(humanResource);
            break;
        case "2.4":
            EditEmployee(humanResource);
            break;
        default:
            break;
    }

} while (ans != "3");


static void ShowDepartments(HumanResource humanResource)
{
    if (humanResource.Department.Length > 0)
    {
        foreach (var item in humanResource.Department)
        {
            Console.WriteLine($"Department name: {item.Name} - Maximum salary: {item.SalaryLimit} $ - Maximum employee count: {item.WorkerLimit} employees");
        }
    }
    else
    {
        Console.WriteLine("Name of department doesn't exit!");
    }
}

static void AddDepartment(HumanResource humanResource)
{
    string name;
    bool check = true;
    do
    {
        if (check)
        {
            Console.WriteLine("Enter new department name:");
        }
        else
        {
            Console.WriteLine("The department you entered already exist, please enter again:");
        }
        name = Console.ReadLine();

        check = false;

    } while (humanResource.FindDepartment(name) != null);
    int salaryLimit;
    do
    {
        Console.WriteLine("The maximum salary in department:");
        string salaryCheck = Console.ReadLine();

        if (!Int32.TryParse(salaryCheck, out salaryLimit))
        {
            Console.WriteLine("Not valid number try again");
        }

    } while (Convert.ToInt32(salaryLimit) < 2000);
    int workerLimit;
    do
    {
        Console.WriteLine("The maximum count of employees in department:");
        string workerCheck = Console.ReadLine(); 
        if (!Int32.TryParse(workerCheck, out workerLimit))
        {
            Console.WriteLine("Not valid number try again");
        }

    } while (Convert.ToInt32(workerLimit) < 1);

    humanResource.AddDepartment(name, workerLimit, salaryLimit);
}

static void EditDepartment(HumanResource humanResource)
{
    string name;
    bool check = true;
    do
    {

        if (check)
            Console.WriteLine("The name of department which you want to edit: ");

        else
            Console.WriteLine("The department you entered is not exit, please re-enter:");

        name = Console.ReadLine();
        check = false;

    } while (humanResource.FindDepartment(name) == null);

    string newName;
    check = true;
    do
    {
        if (check)
            Console.WriteLine("Enter the new name of department:");
        else
            Console.WriteLine("The department you entered already exit, please re-enter:");

        newName = Console.ReadLine();
        check = false;
    } while (humanResource.FindDepartment(newName) != null);


    int newsalaryLimit;
    int newworkerLimit;
    check = true;
    do
    {


        if (check)
        {
            Console.WriteLine("Enter minimum employe salary, which you want edit:");
        }
        newworkerLimit = Convert.ToInt32(Console.ReadLine());
        if (check)
            Console.WriteLine("Enter minimum employe count, which you want edit:");
        else
            Console.WriteLine("Please enter correct!!!");

        newsalaryLimit = Convert.ToInt32(Console.ReadLine());



    } while (humanResource.FindDepartmentLimit(newworkerLimit, newsalaryLimit) != null);

    
    humanResource.EditDepartment(name, newName, newsalaryLimit, newworkerLimit);
}

static void ShowAllEmployees(HumanResource humanResource)
{
    var employee = humanResource.AllEmployees();

    if (employee.Length > 0)
    {
        Console.WriteLine("==================");
        Console.WriteLine("All employees in the company:\n");
        foreach (var empl in employee)
        {
            Console.WriteLine(empl);
        }
    }
    else
    {
        Console.WriteLine("There are not employees in the company!");
    }
}

static void ShowEmployesOfDepartment(HumanResource humanResource)
{
    string name;
    bool check = true;
    Department department = null;
    do
    {
        if (check)
            Console.WriteLine("Enter department name,which employees you want to see:");
        else
            Console.WriteLine("The department you entered is not already exit, please re-enter:");

        name = Console.ReadLine();
        department = humanResource.FindDepartment(name);
        check = false;
    } while (department == null);

    if (department.employee.Length > 0)
    {
        Console.WriteLine("=================================");
        Console.WriteLine($"{name} departments' employees :\n");
        foreach (var item in department.employee)
        {
            Console.WriteLine(item);
        }
    }
    else
    {
        Console.WriteLine("There are not employees in this department!");
    }
}

static void AddEmployee(HumanResource humanResource)
{
    string departmentName;
    Department department = null;
    bool check = true;
    do
    {
        if (check)
            Console.WriteLine("Enter department name, in which you want to add employee:");
        else
            Console.WriteLine("The department you entered is not already exit, please re-enter:");

        departmentName = Console.ReadLine();
        department = humanResource.FindDepartment(departmentName);
        check = false;
    } while (department == null);

    if (Convert.ToInt32(department.WorkerLimit) <= department.employee.Length)
    {
        Console.WriteLine("Employee limit increased!");
        return;
    }

    string fullname;
    check = true;
    do
    {
        if (check)
            Console.WriteLine("Enter fullname of employee: ");
        else
            Console.WriteLine("This employee already exist: ");

        fullname = Console.ReadLine();
        check = false;
    } while (string.IsNullOrWhiteSpace(fullname));

    string position;
    check = true;
    do
    {
        if (check)
            Console.WriteLine("Enter the position of employee:");
        else
            Console.WriteLine("Please enter again:");

        position = Console.ReadLine();
        check = false;

    } while (string.IsNullOrWhiteSpace(position) || position.Length < 2);

    int salary;
    check = true;
    do
    {
        if (check)
            Console.WriteLine("Please enter salary of employee:");
        else
            Console.WriteLine($"The maximum salary {department.SalaryLimit} $ try again:");

        salary = Convert.ToInt32(Console.ReadLine());
        check = false;
    } while (department.SalaryLimit < salary);

    /* string no;
     no = departmentname[0] + Employee.TotalCount.ToString();*/
    /* Console.WriteLine(no);*/


    humanResource.AddEmployee(departmentName, fullname, position, salary);
}

static void EditEmployee(HumanResource humanResource)
{

    string no;
    bool check = true;
    do
    {
        if (check)
            Console.WriteLine("Please enter employees' number which you want edit:");
        else
            Console.WriteLine("Employee with this number, does not exist, please try again:");
        no = Console.ReadLine();


        check = false;
    } while (humanResource.GetEmployeesByNo(no) == null);

    int newSalary;
    check = true;
    do
    {
        if (check)
            Console.WriteLine("Please enter the new salary:");
        else
            Console.WriteLine($"The minimum salary 2000$, please re-enter:");
        newSalary = Convert.ToInt32(Console.ReadLine());
        check = false;
    } while (newSalary < 250);


    string newPosition;
    check = true;
    do
    {
        if (check)
            Console.WriteLine("Please enter new position:");
        newPosition = Console.ReadLine();
    } while (newPosition.Length < 2);

    humanResource.EditEmployee(no, newSalary, newPosition);
}