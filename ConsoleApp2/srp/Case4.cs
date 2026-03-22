using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Класс Employee нарушал принцип единственной ответственности(SRP). Класс отвечал за кардинальные разные задачи: 1. хранение данных 
о зарплате и вывод информации, 2. работа с файлами. 
Методы SaveToFile и LoadFromFile были вынесены в новый класс EmpolyeeFileManager, чтобы каждый класс отвечал за свою задачу.
*/
namespace ConsoleApp2.srp
{
    class Case4
    {
        class Employee
        {
            public string Name;
            public double Salary;

            public void SetSalary(double amount)
            {
                Salary = amount;
            }

            public void PrintInfo()
            {
                Console.WriteLine("Employee: " + Name + " Salary: $" + Salary);
            }
        }
        class EmpolyeeFileManager
        {
            public void SaveToFile(Employee emp)
            {
                File.WriteAllText("employee.txt", emp.Name + " - " + emp.Salary);
                Console.WriteLine("Employee saved to file!");
            }

            public void LoadFromFile()
            {
                string data = File.ReadAllText("employee.txt");
                Console.WriteLine("Loaded: " + data);
            }
        }

        class Program
        {
            static void Main()
            {
                Employee emp = new Employee();
                emp.Name = "John";
                emp.SetSalary(5000);
                emp.PrintInfo();
                emp.SaveToFile();
            }
        }
    }
}
