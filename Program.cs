using System;

namespace EmployeePayrollSystem
{
    // Interface
    interface IPayroll
    {
        void CalculateSalary();
    }

    // Base Class
    class Employee
    {
        protected int empId;
        protected string empName;
        protected double basicSalary;

        public Employee(int id, string name, double salary)
        {
            empId = id;
            empName = name;
            basicSalary = salary;
        }

        public virtual void Display()
        {
            Console.WriteLine("\n===== Employee Details =====");
            Console.WriteLine("Employee ID   : " + empId);
            Console.WriteLine("Employee Name : " + empName);
            Console.WriteLine("Basic Salary  : " + basicSalary);
        }
    }

    // Derived Class (Inheritance + Interface)
    class FullTimeEmployee : Employee, IPayroll
    {
        private double hra;
        private double da;
        private double totalSalary;

        public FullTimeEmployee(int id, string name, double salary)
            : base(id, name, salary)
        {
            hra = salary * 0.20;
            da = salary * 0.10;
        }

        public void CalculateSalary()
        {
            totalSalary = basicSalary + hra + da;
        }

        // Polymorphism (Method Overriding)
        public override void Display()
        {
            base.Display();
            Console.WriteLine("HRA           : " + hra);
            Console.WriteLine("DA            : " + da);
            Console.WriteLine("Total Salary  : " + totalSalary);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===================================");
            Console.WriteLine("      EMPLOYEE PAYROLL SYSTEM");
            Console.WriteLine("===================================");

            Console.Write("Enter Employee ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Basic Salary: ");
            double salary = Convert.ToDouble(Console.ReadLine());

            // Polymorphism
            Employee emp = new FullTimeEmployee(id, name, salary);

            IPayroll payroll = (IPayroll)emp;
            payroll.CalculateSalary();

            emp.Display();

            Console.WriteLine("\nSalary Calculated Successfully!");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}