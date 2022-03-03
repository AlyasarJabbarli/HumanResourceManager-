using HumanResourceManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManager.Interfaces
{
    interface IHumanResourceManager
    {
        Department[] Departments { get; }
        void AddDepartment(string name, int workerlimit, double salarylimit);
        void GetDepartment(string name, int workerlimit, double salarylimit);
        void Editdepartment(string oldname, string newname );
        void AddEmployee(string fullname, string position, double salary, string departmentname);
        void RemoveEmployee(string no,string departmentname);
        void EditEmployee(string no,string position, double salary);
    }
}
