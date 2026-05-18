#nullable disable
using System;
using System.Collections.Generic;

namespace PrototypePattern
{
    public class Virus
    {
        public double Weight { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public List<Virus> Children { get; set; }

        public Virus(double weight, int age, string name, string species)
        {
            Weight = weight;
            Age = age;
            Name = name;
            Species = species;
            Children = new List<Virus>();
        }

        public Virus Clone()
        {
            Virus clonedVirus = new Virus(this.Weight, this.Age, this.Name, this.Species);
            
            foreach (var child in this.Children)
            {
                clonedVirus.Children.Add(child.Clone());
            }
            
            return clonedVirus;
        }

        public void PrintInfo(string indent = "")
        {
            Console.WriteLine($"{indent}- {Name} (Вид: {Species}, Вік: {Age}, Вага: {Weight})");
            foreach (var child in Children)
            {
                child.PrintInfo(indent + "  ");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Virus grandchild1 = new Virus(1.5, 1, "Вірус-Онук 1", "Covid-19");
            Virus grandchild2 = new Virus(1.2, 1, "Вірус-Онук 2", "Covid-19");

            Virus child1 = new Virus(2.5, 3, "Вірус-Син", "Covid-19");
            child1.Children.Add(grandchild1);
            child1.Children.Add(grandchild2);

            Virus child2 = new Virus(2.8, 4, "Вірус-Донька", "Covid-19");

            Virus grandParent = new Virus(5.0, 10, "Вірус-дід (Оригінал)", "Covid-19");
            grandParent.Children.Add(child1);
            grandParent.Children.Add(child2);

            Console.WriteLine("=== Оригінальна сім'я вірусів (3 покоління) ===");
            grandParent.PrintInfo();

            Virus clonedFamily = grandParent.Clone();

            grandParent.Name = "ВІРУС-ДІД (Мутував)";
            grandParent.Children[0].Name = "Вірус-Син (Мутував)";

            Console.WriteLine("\n=== Клоновава сім'я вірусів ===");
            clonedFamily.PrintInfo();

            Console.ReadKey();
        }
    }
}