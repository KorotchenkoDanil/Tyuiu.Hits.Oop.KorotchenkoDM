using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintReview2
{
    class Employee
    {
        string Name { get; set; }
        string Position { get; set; }
        float Salary { get; set; }
        public Employee(string name, string position, float salary)
        {
            Name = name;
            Position = position;
            Salary = salary;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}, Position: {Position}, Salary: {Salary}");
        }
    }

    class Manager : Employee
    {
        string Department { get; set; }
        public Manager(string name, string position, float salary, string department) : base(name, position, salary)
        {
            Department = department;
        }
        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Department: {Department}");
        }
    }

    public interface IReportable
    {
        string GenerateReport();
    }

    public interface ITeamLeader
    {
        string[] GetTeamMembers();
    }
    class ProjectManager : Manager, IReportable, ITeamLeader
    {
        string ProjectName { get; set; }
        public ProjectManager(string name, string position, float salary, string department, string projectName) : base(name, position, salary, department)
        {
            ProjectName = projectName;
        }
        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Project name: {ProjectName}");
        }
        public string GenerateReport()
        {
            string report = "report";
            return (report);
        }
        public string[] GetTeamMembers()
        {
            string[] teamMembers = { "team member 1", "team member 2" };
            return (teamMembers);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Ivan", "manager", 10000);
            Manager manager = new Manager("Anton", "programmer", 15000, "IT");
            ProjectManager projectManager = new ProjectManager("Nikita", "builder", 20000, "Construction", "Chopping center");
            employee.PrintInfo();
            manager.PrintInfo();
            projectManager.PrintInfo();
            Console.WriteLine(projectManager.GenerateReport());
            for (int i = 0; i < projectManager.GetTeamMembers().Length; i++)
            {
                Console.WriteLine(projectManager.GetTeamMembers()[i]);
            }          
            Console.ReadKey();
        }
    }
}
