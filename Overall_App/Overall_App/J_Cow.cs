using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overall_App
{
    internal class J_Cow: Cow
    {
        public J_Cow(int id, double water, double cost, double weight, int age, string color, double milk) : base(id, water, cost, weight, age, color, milk) //all inherited from Cow
        {
            ;
        }
        override public string Values()
        {
            string values = "ID: " + id + "\nAnimal: Jersey Cow\nCost: $" + cost + " per day\nWeight: " + weight + "kg\nAge: " + age + " years old\nMilk Production: " + milk + "L per day\nColor: " + color + "\nWater Consumption: " + water + "L per day";
            return values;
        }
        override public double dailyTax()
        {
             return weight * Rates_Prices.jcTax;
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
        public override int jcCount()
        {
            return 1;
        }
    }
}
