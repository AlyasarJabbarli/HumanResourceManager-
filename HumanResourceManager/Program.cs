using HumanResourceManager.Models;
using HumanResourceManager.Services;
using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace HumanResourceManager
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceService humanResourceManager = new HumanResourceService();
            do
            {
                Console.WriteLine("================Xos Gelmisiniz==============\n");
                Console.WriteLine("1. Departameantlerin siyahisini gostermek ");
                Console.WriteLine("2. Departamenet yaratmaq");
                Console.WriteLine("3. Departmanetde deyisiklik etmek");
                Console.WriteLine("4. Iscilerin siyahisini gostermek");
                Console.WriteLine("5. Departamentdeki iscilerin siyahisini gostermrek");
                Console.WriteLine("6. Isci elave etmek");
                Console.WriteLine("7. Isci uzerinde deyisiklik etmek");
                Console.WriteLine("8.  Departamentden isci silinmesi");
                Console.WriteLine("9. Sistemden Cixis:\n");
                Console.WriteLine("=======Acilan Menu Pencerisnde Bir Secim Edin. Reqem Daxil Edin:");

                string choose = Console.ReadLine();
                int chooseNum;
                while (!int.TryParse(choose, out chooseNum) || chooseNum < 1 || chooseNum > 9)
                {
                    Console.WriteLine("Duzgun Secim Edin:");
                    choose = Console.ReadLine();
                }
                Console.Clear();

                switch (chooseNum)
                {
                    case 1:
                        ShowDepartments(ref humanResourceManager);
                        break;
                    case 2:
                        AddDepartment(ref humanResourceManager);
                        break;
                    case 3:
                        EditDepartment(ref humanResourceManager);
                        break;
                    case 4:
                        ShowAllEployeers(ref humanResourceManager);
                        break;
                    case 5:
                        ShowEmployeesByDepartment(ref humanResourceManager);
                        break;
                    case 6:
                        AddEmployee(ref humanResourceManager);
                        break;
                    case 7:
                        EditEmployee(ref humanResourceManager);
                        break;
                    case 8:
                        RemoveEmployee(ref humanResourceManager);
                        break;
                    case 9:
                        return;
                }
            }
            while (true);
        }

        static void ShowDepartments(ref HumanResourceService humanResourceManager) 
        {
            if (humanResourceManager.Departments.Length > 0)
            {
                foreach (Department department in humanResourceManager.Departments)
                {
                    Console.WriteLine(department);
                }
            }
            else
            {
                Console.WriteLine("Once departament elave edin");
            }
        }
        static void AddDepartment(ref HumanResourceService humanResourceManager) 
        {
            Console.WriteLine("Departament adi Teyin edin");
            string departmentname = Console.ReadLine();
            while (!Regex.IsMatch(departmentname, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(departmentname, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine("Duzgun Departament adi daxil edin");
                departmentname = Console.ReadLine();
            }
            Console.WriteLine("Ishci limitini teyin edin");
            string workerlimitstr = Console.ReadLine();
            int workerlimitnum;
            while (!int.TryParse(workerlimitstr , out workerlimitnum) || workerlimitnum < 1 || workerlimitnum >40)
            {
                Console.WriteLine("Duzgun Daxil Edin,Minimal Ishci sayi 1 den az ola bilmez , Maksimal ishci sayi 40 dan cox ola bilmez");
                workerlimitstr = Console.ReadLine();
            }
            Console.WriteLine("Maas limitini teyin edin");
            string salarylimitstr = Console.ReadLine();
            double salarylimitnum;
            while (!double.TryParse(salarylimitstr, out salarylimitnum))
            {
                Console.WriteLine("Duzgun Daxil Edin");
                salarylimitstr = Console.ReadLine();
            }
            humanResourceManager.AddDepartment(departmentname, workerlimitnum, salarylimitnum);

        }
        static void EditDepartment(ref HumanResourceService humanResourceManager) 
        {
            if(humanResourceManager.Departments.Length > 0) 
            {
                Console.WriteLine("======Departamentlerin Siyahisi======");
                foreach (Department department in humanResourceManager.Departments)
                {
                    Console.WriteLine(department);
                    Console.WriteLine("=====================================");
                }
            }
            else 
            {
                Console.WriteLine("Once Sisteme Departament elave edin");
                return;
            }
            Console.WriteLine("Deyisiklik etmek istediyiniz departamentin adini daxil edin ");
            string oldname = Console.ReadLine();
            while (!Regex.IsMatch(oldname, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(oldname, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine("Duzgun Departament adi daxil edin");
                oldname = Console.ReadLine();
            }
            Console.WriteLine("Departamentin yeni adini daxil edin");
            string newname = Console.ReadLine();
            while (!Regex.IsMatch(newname, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(newname, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine("Duzgun Departament adi daxil edin");
                newname = Console.ReadLine();
            }
            humanResourceManager.Editdepartment(oldname ,newname);
        }
        static void ShowAllEployeers(ref HumanResourceService humanResourceManager) 
        {
            if (humanResourceManager.Departments.Length < 0)
            {
                Console.WriteLine("Once departament elave edin");
                return;
            }
            
            foreach (Department department in humanResourceManager.Departments)
            {
                if (department.Employees.Length <= 0)
                {
                    Console.WriteLine("Ishci yoxdur");
                    return;
                }
                foreach (Employee employee in department.Employees)
                {
                    Console.WriteLine(employee);
                    Console.WriteLine("=====================================");
                }
            }

            

        }
        static void ShowEmployeesByDepartment(ref HumanResourceService humanResourceManager) 
        {
            if (humanResourceManager.Departments.Length > 0)
            {
                Console.WriteLine("======Departamentlerin siyahisi======");
                foreach (Department department in humanResourceManager.Departments)
                {
                    Console.WriteLine(department);
                    Console.WriteLine("=====================================");
                }
            }
            else
            {
                Console.WriteLine("Once departament elave edin");
                return;
            }
            Console.WriteLine("Zehmet olmasa ischileri haqqinda melumat almaq istediyiniz department adini daxil edin");
            string departmentname = Console.ReadLine();
            while (!Regex.IsMatch(departmentname, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(departmentname, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine("duzgun department adi daxil edin");
                departmentname = Console.ReadLine();
            }
            foreach (Department department in humanResourceManager.Departments)
            {
                if(department.Name == departmentname.Trim().ToUpper()) 
                {
                    if (department.Employees.Length > 0)
                    {
                        foreach (Employee employee in department.Employees)
                        {
                            Console.WriteLine(employee);
                            Console.WriteLine("=====================================");
                        }
                        return;
                    }
                    else
                    {
                        Console.WriteLine("ishci yoxdur");
                        return;
                    }
                }
            }
            Console.WriteLine("Daxil etdiyiniz adda department tapilmadi");
        }

        static void AddEmployee(ref HumanResourceService humanResourceManager) 
        {
            if (humanResourceManager.Departments.Length > 0)
            {
                Console.WriteLine("======Departamentlerin Siyahisi======");
                foreach (Department department in humanResourceManager.Departments)
                {
                    Console.WriteLine(department);
                    Console.WriteLine("=====================================");

                }
            }
            else
            {
                Console.WriteLine("Once Sisteme Departament elave edin");
                return;
            }
            Console.WriteLine("Ishcini elave etmek istediyiniz departmentin adini daxil edin");
            string departmentname = Console.ReadLine();
            while (!Regex.IsMatch(departmentname, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(departmentname, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine("duzgun department adi daxil edin");
                departmentname = Console.ReadLine();
            }
            
            Console.WriteLine("ishcinin AD VE SOYADINI DAXIL EDIN");
            string fullname = Console.ReadLine();

            while (!Regex.IsMatch(fullname, @"^\b([A-ZÀ-ÿ][-,a-z. ']+[ ]*)+"))
            {
                Console.WriteLine("ishcinin AD VE SOYADINI DUZGUN DAXIL EDIN");
                fullname = Console.ReadLine();
            }

            Console.WriteLine("ishcinin vezifesini daxil edin");
            string position = Console.ReadLine();
            while (!Regex.IsMatch(position, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(position, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine("ishcinin vezifesini duzgun daxil edin");
                position = Console.ReadLine();
            }

            Console.WriteLine("ishcinin maasini daxil edin");
            string salarystr = Console.ReadLine();
            double salarynum;
            while (string.IsNullOrWhiteSpace(salarystr) || (!double.TryParse(salarystr,out salarynum)))
            {
                Console.WriteLine("ishcinin maasini duzgun daxil edin");
                salarystr = Console.ReadLine();
            }

            humanResourceManager.AddEmployee(fullname, position, salarynum, departmentname);
        }
        static void EditEmployee(ref HumanResourceService humanResourceManager) 
        {
            if (humanResourceManager.Departments.Length > 0)
            {
                Console.WriteLine("======Departamentlerin Siyahisi======");
                foreach (Department department in humanResourceManager.Departments)
                {
                    Console.WriteLine(department);
                    Console.WriteLine("=====================================");
                }
            }
            else
            {
                Console.WriteLine("Once Sisteme Departament elave edin");
                return;
            }
            foreach (Department department in humanResourceManager.Departments)
            {
                if (department.Employees.Length<= 0)
                {
                    Console.WriteLine("Once Sisteme iSHCI Elave edin");
                    return;
                }
                foreach (Employee employee in department.Employees)
                {
                    Console.WriteLine(employee);
                    Console.WriteLine("=====================================");
                }

            }
            Console.WriteLine("Ishcinin kodunu daxil edin");
            string no = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(no))
            {
                Console.WriteLine("duzgun Ishci kodu daxil edin");
                no = Console.ReadLine();
            }
            foreach (Department department in humanResourceManager.Departments)
            {
                foreach (Employee employee in department.Employees)
                {
                    Console.WriteLine(employee.FullName);
                    Console.WriteLine(employee.Position);
                    Console.WriteLine(employee.Salary);
                }
            }
            Console.WriteLine("ishcinin Yeni vezifesini daxil edin");
            string position = Console.ReadLine();
            while (!Regex.IsMatch(position, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(position, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine("ishcinin YEni vezifesini duzgun daxil edin");
                position = Console.ReadLine();
            }

            Console.WriteLine("ishcinin Yeni maasini daxil edin");
            string salarystr = Console.ReadLine();
            double salarynum;
            while (string.IsNullOrWhiteSpace(salarystr) || (!double.TryParse(salarystr, out salarynum) || salarynum < 250))
            {
                Console.WriteLine("ishcinin Yeni maasini duzgun daxil edin");
                salarystr = Console.ReadLine();
            }
            humanResourceManager.EditEmployee(no, position, salarynum);

        }
        static void RemoveEmployee(ref HumanResourceService humanResourceManager)
        {
            if (humanResourceManager.Departments.Length > 0)
            {
                Console.WriteLine("======Departamentlerin Siyahisi======");
                foreach (Department department in humanResourceManager.Departments)
                {
                    Console.WriteLine(department);
                    Console.WriteLine("=====================================");
                }
            }
            else
            {
                Console.WriteLine("Once Sisteme Departament elave edin");
                return;
            }
            foreach (Department department in humanResourceManager.Departments)
            {
                if (department.Employees.Length > 0)
                {
                    foreach (Employee employee in department.Employees)
                    {
                        Console.WriteLine(employee);
                        Console.WriteLine("=====================================");
                    }
                }
                else
                {
                    Console.WriteLine("Sistemde ishci yoxdur");
                    return;
                }

            }
            Console.WriteLine("Ishcini Silmek istediyiniz departmentin adini daxil edin");
            string departmentname = Console.ReadLine();
            while (!Regex.IsMatch(departmentname, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(departmentname, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine("duzgun department adi daxil edin");
                departmentname = Console.ReadLine();
            }
            Console.WriteLine("Ishcinin kodunu daxil edin");
            string no = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(no))
            {
                Console.WriteLine("duzgun Ishci kodu daxil edin");
                no = Console.ReadLine();
            }
            humanResourceManager.RemoveEmployee(no, departmentname);
        }

    }


}
