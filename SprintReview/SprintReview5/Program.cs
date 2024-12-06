using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SprintReview5
{
    class Company
    {
        int CheckedID;
        public string Name { get; set; }
        public List<Employee> employees { get; set; } = new List<Employee>();
        public List<Order> orders { get; set; } = new List<Order>();

        public void AddEmployee(Employee employee)
        { 
            employees.Add(employee); 
        }

        public void AddOrder(Order order)
        {  
            order.OrderId = CheckedID;
            CheckedID++;
            orders.Add(order);
        }

        public void AssignEmployeeToOrder(int orderId, Employee employee)
        {
            Order order = orders.Find(o => o.OrderId == orderId);
            order.AssignedEmployee = employee;
            employee.OrdersProcessed++;
        }

        public void ChangeOrderStatus(int orderId, Order.OrderStatus newStatus)
        {
            Order order = orders.Find(o => o.OrderId == orderId);
            order.Status = newStatus;
            order.OnStatusChanged();
        }

        public List<Order> GetOrdersByStatus(Order.OrderStatus status)
        {
            return orders.Where(o => o.Status == status).ToList();
        }

        public List<Order> FindOrdersByCustomer(string customerFirstName, string customerLastName)
        {
            return orders.Where(o => o.Customer != null && (o.Customer.FirstName.Contains(customerFirstName) || o.Customer.LastName.Contains(customerLastName))).ToList();
        }

        public void GenerateEmployeeReport()
        {
            Console.WriteLine("Отчет по сотрудникам:");
            foreach (var employee in employees)
            {
                Console.WriteLine($"Сотрудник: {employee.FirstName} {employee.LastName}, Обработано заказов: {employee.OrdersProcessed}");
            }
        }
    }

    class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int OrdersProcessed { get; set; }

        public void NotifyOrderStatusChanged(int orderId, Order.OrderStatus newStatus)
        {
            Console.WriteLine($"Уведомление: Статус заказа {orderId} изменен на {newStatus}.");
        }
    }

    class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }

    class Order
    {
        public int OrderId { get; set; }
        public string Description { get; set; }
        public Employee AssignedEmployee { get; set; }
        public Customer Customer { get; set; }
        public enum OrderStatus
        {
            Created,
            InProcess,
            Finished
        }
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }

        public delegate void OrderHandler(int orderId, OrderStatus newStatus);
        public event OrderHandler OrderStatusChanged;

        public Order(string description)
        {
            Description = description;
            CreatedAt = DateTime.Now;
            Status = OrderStatus.Created;
        }

        public void OnStatusChanged()
        {
            OrderStatusChanged?.Invoke(OrderId, Status);
            Console.WriteLine($"Статус заказа {OrderId} изменен на {Status}.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company { Name = "Моя Компания" };

            Employee employee1 = new Employee { FirstName = "Иван", LastName = "Сидоров" };
            Employee employee2 = new Employee { FirstName = "Мария", LastName = "Петрова" };
            company.AddEmployee(employee1);
            company.AddEmployee(employee2);

            Customer customer1 = new Customer { FirstName = "Алексей", LastName = "Иванов", PhoneNumber = "123-456" };
            Customer customer2 = new Customer { FirstName = "Ольга", LastName = "Васильева", PhoneNumber = "789-012" };

            Order order1 = new Order("Заказ 1") { Customer = customer1 };
            Order order2 = new Order("Заказ 2") { Customer = customer2 };
            company.AddOrder(order1);
            company.AddOrder(order2);

            company.AssignEmployeeToOrder(order1.OrderId, employee1);
            company.AssignEmployeeToOrder(order2.OrderId, employee2);

            company.ChangeOrderStatus(order1.OrderId, Order.OrderStatus.InProcess);
            company.ChangeOrderStatus(order2.OrderId, Order.OrderStatus.Finished);

            company.GenerateEmployeeReport();

            var inProcessOrders = company.GetOrdersByStatus(Order.OrderStatus.InProcess);
            Console.WriteLine("\nЗаказы в процессе:");
            foreach (var order in inProcessOrders)
            {
                Console.WriteLine($"Заказ ID: {order.OrderId}, Описание: {order.Description}");
            }

            var customerOrders = company.FindOrdersByCustomer("Алексей", "Иванов");
            Console.WriteLine("\nЗаказы для клиента Алексей Иванов:");
            foreach (var order in customerOrders)
            {
                Console.WriteLine($"Заказ ID: {order.OrderId}, Описание: {order.Description}");
            }
            Console.ReadKey();
        }
    }
}
