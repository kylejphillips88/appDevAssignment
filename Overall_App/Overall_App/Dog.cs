using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overall_App
{
    internal class Dog : Animal
    {
        public Dog(int id, double water, double cost, double weight, int age, string color) : base(id, water, cost, weight, age, color)//all data inherited from animal
        {
            ;
        }
        override public string Values()
        {
            string values = "ID: " + id + "\nAnimal: Dog\nCost: $" + cost + " per day\nWeight: " + weight + "kg\nAge: " + age + " years old\nColor: " + color + "\nWater Consumption: " + water + "L per day";
            return values;
        }
        override public int animalNoDogCount()
        {
            return 0;
        }
        public override double ageAvg()
        {
            return 0;
        }
        public override double dogCost()
        {
            return cost + waterCost();
        }
    }
}
