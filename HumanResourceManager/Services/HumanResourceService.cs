using HumanResourceManager.Interfaces;
using HumanResourceManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManager.Services
{
    class HumanResourceService : IHumanResourceManager
    {
        private Department[] _departments;
        public Department[] Departments => _departments;

        public HumanResourceService()
        {
            _departments = new Department[0];

        }
        public void AddDepartment(string name, int workerlimit, double salarylimit)
        {
            foreach (Department item in _departments)
            {
                if ((item.Name == name.Trim().ToUpper()))
                {
                    Console.WriteLine("bu adda artiq department movcuddur");
                    return;
                }
            }
            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length - 1] = new Department(name, workerlimit, salarylimit);
        }

        public void AddEmployee(string fullname, string position, double salary, string departmentname)
        {
            Department department = null;
            foreach (Department item in _departments)
            {
                if((item.Name == departmentname.Trim().ToUpper())) 
                {
                    department = item;
                }
            }
            if (department != null) 
            {
                Employee employee = new Employee(fullname, position, salary, departmentname);
                department.AddEmployee(employee);
            }
            else 
            {
                Console.WriteLine("Daxil edilen adda Departament tapilmadi ");   
            }
        }

        public void Editdepartment(string oldname, string newname)
        {
            foreach (Department department in Departments)
            {
               if(department.Name  == oldname.Trim().ToUpper())
               {
                    if (department.Name == newname.Trim().ToUpper())
                    {
                        Console.WriteLine("Departmentin yeni adi kohne adiyla bir ola bilmez");
                        return;
                    }
                    department.Name = newname.Trim().ToUpper();
                    foreach (Employee employee in department.Employees)
                    {
                        employee.No = employee.No.Replace(employee.No[0], char.ToUpper(department.Name.ToString()[0]));
                        employee.No = employee.No.Replace(employee.No[1], char.ToUpper(department.Name .ToString()[1]));
                    }
                    return;
               }
            }
            Console.WriteLine("Daxil edilen adda department tapilmadi");


        }

        public void EditEmployee(string no, string position, double salary)
        {
            foreach (Department department in Departments)
            {
                foreach (Employee employee in department.Employees)
                {
                    if (employee.No == no.Trim().ToUpper())
                    {                 
                        Console.WriteLine(employee.FullName , employee.Position , employee.Salary);
                        employee.Position = position;
                        employee.Salary = salary;
                        return;
                    }
                }
                Console.WriteLine("Daxil etdiyiniz kodda Ishci tapilmadi");
                return;
            }
            Console.WriteLine("Daxil edilen adda Departament tapilmadi ");


        }

        public void GetDepartment(string name, int workerlimit, double salarylimit)
        {
            if (Departments.Length > 0)
            {
                Console.WriteLine("=========Departamentler=========");
                foreach (Department department in Departments)
                {
                    Console.WriteLine(department);
                    Console.WriteLine("================================");
                }
            }
            else
            {
                Console.WriteLine("Once sisteme Departament elave et");
                return;
            }
        }

        public void RemoveEmployee(string no, string departmentname)
        {
            foreach (Department department in Departments)
            {
                if (department.Name == departmentname.Trim().ToUpper())
                {
                    foreach (Employee employee in department.Employees)
                    {
                        for (int i = 0; i < department.Employees.Length; i++)
                        {
                            if (employee.No == no.Trim().ToUpper())
                            {
                                department.Employees[i] = null;
                                department.Employees[i] = department.Employees[department.Employees.Length - 1];
                                Array.Resize(ref department.Employees, department.Employees.Length - 1);
                                Console.WriteLine("Ishci Sistemden Ugurla Silindi");
                                return;
                            }
                        }
                        
                    }
                    Console.WriteLine("Daxil edilen kodda Ishci tapilmadi ");
                    return;
                }
   
            }
            Console.WriteLine("Daxil edilen adda Departament tapilmadi");
        }
    }
}
