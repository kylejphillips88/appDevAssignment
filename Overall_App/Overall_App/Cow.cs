using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overall_App
{
    internal class Cow : Animal
    {
        public double milk;//milk variable is created here
        public Cow(int id, double water, double cost, double weight, int age, string color, double milk) : base(id, water, cost, weight, age, color)//inherited from animal class
        {
            this.milk = milk;
        }
        override public string Values()
        {
            string values = "ID: " + id + "\nAnimal: Cow\nCost: $" + cost + " per day\nWeight: " + weight + "kg\nAge: " + age + " years old\nMilk Production: " + milk + "L per day\nColor: " + color + "\nWater Consumption: " + water + "L per day";
            return values;
        }
        override public double dailyIncome()
        {
            double total = milk * Rates_Prices.cowMilkPrice - cost;
            return total;
        }
        override public double dailyTax()
        {
            double totalTax = weight * Rates_Prices.tax;
            return totalTax;
        }
        public override double dailyMilk()
        {
            return milk;
        }
        public override double cowGoatProfitability()
        {
            return dailyIncome() - dailyTax() - waterCost();
        }
        override public double dailyProf()
        {
            double total = dailyIncome() - dailyTax() - waterCost();
            return total;
        }
    }
}
