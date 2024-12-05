using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintReview4
{
    interface IEnterprise
    {
        void AddSupplier(ISupplier suppluier);
        void AddEmployee(IEmployee employee);
        List<ISupplier> GetSuppliers();
        decimal CalculateTotalExpenses();
    }

    interface ISupplier
    {
        string GetName();
        decimal GetCost();
        string SupplierType {  get; set;  }
    }
    
    interface IEmployee
    {
        string GetFullName();
        decimal GetSalary();
        string Position {  get; set; }
    }

    class Enterprise : IEnterprise
    {
        public List<ISupplier> suppliers = new List<ISupplier>();
        public List<IEmployee> employees = new List<IEmployee>();

        public void AddSupplier(ISupplier supplier)
        {           
            suppliers.Add(supplier);
        }

        public void AddEmployee(IEmployee employee)
        {
            employees.Add(employee);
        }

        public decimal CalculateTotalExpenses()
        {
            decimal totalExpenses = 0;
            decimal supplierExpenses = 0;
            decimal employeeExpenses = 0;
            foreach (ISupplier supplier in suppliers)
            {
                supplierExpenses += supplier.GetCost();
            }
            foreach (IEmployee employee in employees)
            {
                employeeExpenses += employee.GetSalary();
            }
            totalExpenses = supplierExpenses + employeeExpenses;
            return totalExpenses;
        }

        public List<ISupplier> GetSuppliers()
        {
            return suppliers;
        }

        public List<IEmployee> GetEmployees()
        {
            return employees;
        }
    }

    class Supplier : ISupplier
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string SupplierType { get; set; }

        public Supplier(string name, decimal cost, string supplierType)
        {
            Name = name;
            Cost = cost;
            SupplierType = supplierType;
        }

        public decimal GetCost()
        {
            return Cost;
        }

        public string GetName()
        {
            return Name;
        }
    }

    class Employee : IEmployee
    {
        public string FullName { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; }
        public Employee (string fullName, decimal salary, string position)
        {
            FullName = fullName;
            Salary = salary;
            Position = position;
        }

        public string GetFullName()
        {
            return FullName;
        }

        public decimal GetSalary()
        {
            return Salary;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Enterprise enterprise = new Enterprise();

            Supplier supplier1 = new Supplier("Андрей Андреев", 100000, "Логистический центр");
            Supplier supplier2 = new Supplier("Антон Антонов", 50000, "Поставщик офисной мебели");
            enterprise.AddSupplier(supplier1);
            enterprise.AddSupplier(supplier2);

            Employee employee1 = new Employee("Иван Иванов", 70000, "Менеджер");
            Employee employee2 = new Employee("Анна Петрова", 95000, "Разработчик");
            enterprise.AddEmployee(employee1);
            enterprise.AddEmployee(employee2);

            Console.WriteLine("Список поставщиков:");
            foreach (var supplier in enterprise.GetSuppliers())
            {
                Console.WriteLine($"{supplier.SupplierType} - {supplier.GetName()} - Стоимость услуг: {supplier.GetCost()}");
            }

            Console.WriteLine("\nСписок сотрудников:");
            foreach (var employee in enterprise.GetEmployees())
            {
                Console.WriteLine($"{employee.Position} - {employee.GetFullName()} - Зарплата: {employee.GetSalary()}");
            }

            decimal totalExpenses = enterprise.CalculateTotalExpenses();
            Console.WriteLine($"\nОбщие расходы: {totalExpenses}");
            Console.ReadKey();
        }
    }
}
