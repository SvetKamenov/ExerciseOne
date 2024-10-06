using System;
using System.Collections.Generic;
using System.Linq;

namespace ExerciseOne
{
    public class Farm
    {
        List<Animal> animals = new List<Animal>();

        public void AddAnimal()
        {
            Console.Write("Enter animal's name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name) || name.Any(ch => !char.IsLetter(ch)))
            {
                Console.WriteLine("Invalid Name! Only letters are allowed.\n");
                return;
            }
            Console.Write("Enter animal's type! Please, choose one of these options: cow, duck, pig, dog, and cat: ");
            string typeInput = Console.ReadLine();
            if (!Enum.TryParse(typeInput, true, out AnimalType type))
            {
                Console.WriteLine("Invalid animal type!\n");
                return;
            }
            Console.Write("Enter animal's age: ");
            if (!byte.TryParse(Console.ReadLine(), out byte age))
            {
                Console.WriteLine("Incorrect age!\n");
                return;
            }

            Animal animal = new Animal(name, type, age);
            animals.Add(animal);
            Console.WriteLine($"\n{name} has been added to the farm!\n");
        }

        public void FeedAnimal()
        {
            Console.Write("Enter animal's name to feed: ");
            string name = Console.ReadLine();
            Animal animal = animals.Find(a => a.Name == name);
            if (animal == null)
            {
                Console.WriteLine("Animal not found.");
                return;
            }
            animal.HungerLevel = Math.Max(0, animal.HungerLevel - 10);
            Console.WriteLine($"\n{name} has been fed!");

            switch (animal.AnimalType)
            {
                case AnimalType.cow:
                    Console.WriteLine("Moomoo\n");
                    break;
                case AnimalType.duck:
                    Console.WriteLine("Clucky-cluck\n");
                    break;
                case AnimalType.pig:
                    Console.WriteLine("pigipigi\n");
                    break;
                case AnimalType.dog:
                    Console.WriteLine("bau-bau\n");
                    break;
                case AnimalType.cat:
                    Console.WriteLine("Meow-meow\n");
                    break;
                default:
                    break;
            }
        }

        public void ShowAnimals()
        {
            Console.WriteLine("Animals in farm:");
            if (animals.Count > 0)
            {
                for (int i = 0; i < animals.Count; i++)
                {
                    Console.WriteLine($"{animals[i].Name} is from type {animals[i].AnimalType}, it's {animals[i].Age} years old and its HungerLevel is {animals[i].HungerLevel}\n");
                }
            }
            else
            {
                Console.WriteLine("The farm is empty!\n");
            }
        }

        public void RemoveAnimal()
        {
            Console.Write("Enter animal's name to remove: ");
            string nameToRemove = Console.ReadLine();
            Animal animal = animals.Find(a => a.Name == nameToRemove);
            if (animal == null)
            {
                Console.WriteLine("Animal not found.\n");
                return;
            }
            animals.Remove(animal);
            Console.WriteLine($"\n{nameToRemove} has died :(\n");
        }

        public void UpdateHungerLevels()
        {
            foreach (var animal in animals)
            {
                animal.IncreaseHunger();
            }
        }

        public void ExploreTheFarm()
        {
            Console.WriteLine("Welcome to the farm!");
            while (true)
            {
                Console.WriteLine("1. Add an animal!");
                Console.WriteLine("2. Feed an animal!");
                Console.WriteLine("3. Show all animals!");
                Console.WriteLine("4. Remove an animal!");
                Console.WriteLine("5. Exit!");
                Console.WriteLine("Choose an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddAnimal();
                        break;
                    case "2":
                        FeedAnimal();
                        break;
                    case "3":
                        ShowAnimals();
                        break;
                    case "4":
                        RemoveAnimal();
                        break;
                    case "5":
                        Console.WriteLine("Exiting the program!");
                        return;
                    default:
                        Console.WriteLine("Invalid option!!!");
                        break;
                }

                if (input != "2")
                {
                    UpdateHungerLevels();
                }
            }
        }
    }
}
