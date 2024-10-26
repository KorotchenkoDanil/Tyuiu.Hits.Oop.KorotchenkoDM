using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintReview0
{
    class Plant
    {
        public string name;
        string type;
        float height;
        public virtual void Blossom()
        {
            Console.WriteLine("Растение цветет");
        }
        public void Growing(float growth)
        {
            height += growth;
        }
    }

    class Flower : Plant
    {
        string color;
        int countOfPetal;
        public override void Blossom()
        {
            Console.WriteLine($"Цветок {name} распускается и радует глаз!");
        }
        public void FadeAway()
        {
            Console.WriteLine("Цветок начинает увядать");
        }
    }

    class Tree : Plant
    {
        int age;
        string typeOfLeaves;
        public override void Blossom()
        {
            Console.WriteLine($"Дерево {name} покрывается новыми листьями!");
        }
        public void Grow(int years)
        {
            age += years;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Flower flower = new Flower();
            Tree tree = new Tree();
            flower.name = "роза";
            tree.name = "дуб";
            flower.Blossom();
            tree.Blossom();
            flower.FadeAway();
            tree.Grow(5);
            Console.ReadKey();
        }
    }
}
