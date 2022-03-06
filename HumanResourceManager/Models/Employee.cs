using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManager.Models
{
    class Employee 
    {
        private static int _count = 1000;
        public string No;
        public string FullName { get; set; }
        private string _position;
        public string Position 
        {
            get => _position;
            set
            {
                while(value.Length < 2)
                {
                    Console.WriteLine("Vezife Minimum 2 Herfden ibaret olmalidir");
                    value = Console.ReadLine();
                }
                _position = value;
            }
        }
        public double _salary;
        public double Salary 
        {
            get => _salary;
            set 
            {
                while (value < 250)
                {
                    Console.WriteLine($"Emek Haqqi A.R Qanunvericiliyine uygun olaraq 250 AZN den az ola bilmez");
                    double.TryParse(Console.ReadLine(), out value);
                }
                _salary = value;
            } 
        }
        public string DepartmentName { get; set; }
        public Employee(string fullname ,  string position , double salary , string departmentname) 
        {
            _count++;
            FullName = fullname.Trim();
            Position = position.Trim().ToUpper();
            Salary = salary;
            DepartmentName = departmentname.ToUpper();
            No = $"{(DepartmentName.ToString()[0])}{(DepartmentName.ToString()[1])}{_count}";
        }
        public override string ToString()
        {
            return $"Ischinin Kodu : {No}" +
                $"\nIshcininadi adi ve soyadi : {FullName}" +
                $"\n Iscinin Maasi : {_salary}" +
                $"\n Iscinin Vezifesi: {_position}" +
                $"\n Iscinin islediyi Departament : {DepartmentName}";
        }
    }
    
}
