using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManager.Models
{
    class Department
    {
        private string _name;
        public string Name 
        {
            get => _name;
            set 
            {
                while (value.Length<2)
                {
                    Console.WriteLine("Departament adi minimum 2 herfden ibaret olmalidir");
                    value = Console.ReadLine();
                }
                _name = value;

            }
        }
        private int _workerlimit;
        public int WorkerLimit 
        {
            get => _workerlimit;
            set 
            {
                while (value < 1) 
                {
                    Console.WriteLine("Departmanetde maximum var ola bilicek isci sayi minimum 1 ola biler");
                    int.TryParse(Console.ReadLine() , out value);
                }
                _workerlimit = value;
               
            }
        }
        private double _salarylimit;
        public double SalaryLimit 
        {
            get => _salarylimit;
            set
            {
                while (value < WorkerLimit*250)
                {
                    Console.WriteLine($"Maas A.R Qanunvericiliyine uygun olaraq bir isci ucun 250 AZN den az ola bilmez , Ve bu department ucun minimum {_workerlimit*250}AZN olmalidir");
                    double.TryParse(Console.ReadLine() , out value);
                }
                _salarylimit = value;
                Console.WriteLine("Emaliyyat Ugurla Yekunlasdi");
            }
        }
        public Employee[] Employees;
        public void CalcSalaryAverage() 
        {
            double salarysum = 0;
            for (int i = 0; i < Employees.Length; i++)
            {
               salarysum += Employees[i].Salary;
            }
            double AverageSalary = salarysum / Employees.Length;
            Console.WriteLine(AverageSalary);
        }
        public Department(string name,int workerlimit,double salarylimit) 
        {
            Employees = new Employee[0];
            Name = name.Trim().ToUpper();
            WorkerLimit = workerlimit;
            SalaryLimit = salarylimit;
        }
        public void AddEmployee(Employee employee) 
        {
            if (Employees.Length < WorkerLimit) 
            {
                Array.Resize(ref Employees, Employees.Length + 1);
                Employees[Employees.Length - 1] = employee;
            }
            else 
            {
                Console.WriteLine("Departamentde yer yoxdur");
            }
        }
        public override string ToString()
        {
            return $"Departamentin adi : {_name}" +
                $"\n Departamentde ola bilecek maksimum isci sayi : {_workerlimit}" +
                $"\n Verilebilecek minimum maas: {_salarylimit}";
        }
    }
}
