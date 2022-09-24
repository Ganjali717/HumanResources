﻿using HumanResources.Models;using HumanResources.ServiceManagers;



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
            Console.WriteLine($"Department name: {item.Name} - Maximum salary: {item.SalaryLimit} AZN - Maximum employee count: {item.WorkerLimit} employees");
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
    bool checkSalary = true;
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
    int salarylimit;
    do
    {
        if (checkSalary)
        {
            Console.WriteLine("The maximum salary in department: ");
        }
        else
        {
            Console.WriteLine("Try correct format!");
        }
        salarylimit = Convert.ToInt32(Console.ReadLine());
        checkSalary = false;

    } while (Convert.ToInt32(salarylimit) < 2000);
    int workerlimit;
    do
    {
        Console.WriteLine("The maximum count of employees in department: ");
        workerlimit = Convert.ToInt32(Console.ReadLine());

    } while (Convert.ToInt32(workerlimit) < 1);

    humanResource.AddDepartment(name, workerlimit, salarylimit);
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


    int newsalarylimit;
    int newworkerlimit;
    check = true;
    do
    {


        if (check)
        {
            Console.WriteLine("Enter minimum employe salary, which you want edit:");
        }
        newworkerlimit = Convert.ToInt32(Console.ReadLine());
        if (check)
            Console.WriteLine("Enter minimum employe count, which you want edit:");
        else
            Console.WriteLine("Please enter correct!!!");

        newsalarylimit = Convert.ToInt32(Console.ReadLine());



    } while (humanResource.FindDepartmentLimit(newworkerlimit, newsalarylimit) != null);

    
    humanResource.EditDepartment(name, newName, newsalarylimit, newworkerlimit);
}