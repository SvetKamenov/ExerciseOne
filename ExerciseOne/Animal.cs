using System;

namespace ExerciseOne
{
    public class Animal
    {
        public byte Age { get; set; }
        public string Name { get; set; }
        public AnimalType AnimalType { get; set; }

        private int hungerLevel = 50;

        public int HungerLevel
        {
            get
            {
                return hungerLevel;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    hungerLevel = value;
                }
                else
                {
                    Console.WriteLine("Hunger level must be between 0 and 100!");
                }
            }
        }

        public Animal(string name, AnimalType type, byte age)
        {
            Name = name;
            AnimalType = type;
            Age = age;
        }

        public void IncreaseHunger()
        {
            HungerLevel = Math.Min(100, HungerLevel + 5);
        }
    }
}
