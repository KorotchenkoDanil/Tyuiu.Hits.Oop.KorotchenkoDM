using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintReview3
{
    abstract class Component
    {
        public string Description { get; set; }
        public string Functions { get; set; }
        public int Price { get; set; }
        public Component(string description, string functions, int price)
        {
            Description = description;
            Functions = functions;
            Price = price;
        }

        public virtual void GetInfo()
        {
            Console.WriteLine($"description: {Description}, funtions: {Functions}, price: {Price}");
        }

        public string ToString(string description, string functions, int price)
        {
            return description + " | " + functions + " | " + price;
        }
    }


    class CPU : Component, IInstallable
    {
        public string Parameters {  get; set; }
        public CPU(string description, string functions, int price, string parameters) : base(description, functions, price)
        { 
            Parameters = parameters;
        }
        public override void GetInfo()
        {
            base.GetInfo();
            Console.Write($", parameters: {Parameters}");
            Console.WriteLine();
        }

        public string Install()
        {
            return ("install completed");
        }

        public static bool operator ==(CPU cpu1, CPU cpu2)
        {
            return cpu1.Parameters == cpu2.Parameters;
        }

        public static bool operator !=(CPU cpu1, CPU cpu2)
        {
            return cpu1 != cpu2;
        }
    }

    class RAM : Component, IInstallable 
    {
        public string Parameters { get; set; }
        public RAM(string description, string functions, int price, string parameters) : base(description, functions, price)
        {
            Parameters = parameters;
        }
        public override void GetInfo()
        {
            base.GetInfo();
            Console.Write($", parameters: {Parameters}");
            Console.WriteLine();
        }

        public string Install()
        {
            return ("install completed");
        }

        public static bool operator ==(RAM ram1, RAM ram2)
        {
            return ram1.Parameters == ram2.Parameters;
        }

        public static bool operator !=(RAM ram1, RAM ram2)
        {
            return ram1.Parameters != ram2.Parameters;
        }
    }

    class GPU : Component, IInstallable
    {
        public string Parameters { get; set; }
        public GPU(string description, string functions, int price, string parameters) : base(description, functions, price)
        {
            Parameters = parameters;
        }
        public override void GetInfo()
        {
            base.GetInfo();
            Console.Write($", parameters: {Parameters}");
            Console.WriteLine();
        }

        public string Install()
        {
            return ("install completed");
        }

        public static bool operator ==(GPU gpu1, GPU gpu2)
        {
            return gpu1.Parameters == gpu2.Parameters;
        }

        public static bool operator !=(GPU gpu1, GPU gpu2)
        {
            return gpu1.Parameters != gpu2.Parameters;
        }
    }

    class HDD : Component, IInstallable
    {
        public string Parameters { get; set; }
        public HDD(string description, string functions, int price, string parameters) : base(description, functions, price)
        {
            Parameters = parameters;
        }
        public override void GetInfo()
        {
            base.GetInfo();
            Console.Write($", parameters: {Parameters}");
            Console.WriteLine();
        }

        public string Install()
        {
            return ("install completed");
        }

        public static bool operator ==(HDD hdd1, HDD hdd2)
        {
            return hdd1.Parameters == hdd2.Parameters;
        }

        public static bool operator !=(HDD hdd1, HDD hdd2)
        {
            return hdd1.Parameters != hdd2.Parameters;
        }
    }

    interface IInstallable
    {
        string Install();
    }

    class Computer
    {
        private List<Component> _components = new List<Component>();

        public void AddComponent(Component component)
        {
            _components.Add(component);
        }

        public void RemoveComponent(Component component)
        {
            _components.Remove(component);
        }

        public int GetTotalPrice()
        {
            int totalPrice = 0;
            foreach (var component in _components)
            {
                totalPrice += component.Price;
            }
            return totalPrice;
        }
    }

    static class ComputerFactory
    {
        public static Computer CreateComputer(List<Component> components)
        {
            var newComputer = new Computer();
            foreach (var component in components)
            {
                newComputer.AddComponent(component);
            }
            return newComputer;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            CPU cpu = new CPU("cpu description", "cpu functions", 1000, "cpu parameters");
            RAM ram = new RAM("ram description", "ram functions", 2000, "ram parameters");
            GPU gpu = new GPU("gpu description", "gpu functions", 3000, "gpu parameters");
            HDD hdd = new HDD("hdd description", "hdd functions", 4000, "hdd parameters");
            cpu.GetInfo();
            ram.GetInfo();
            gpu.GetInfo();
            hdd.GetInfo();
            cpu.ToString();
            Console.ReadKey();
        }
    }
}
