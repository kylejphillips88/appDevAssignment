using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overall_App
{
    internal class Sheep : Animal
    {
        public double wool;
        public Sheep(int id, double water, double cost, double weight, int age, string color, double wool): base(id, water, cost, weight, age, color)
            {
            this.wool = wool;
            }
        override public string Values()
        {
            string values = "ID: " + id + "\nAnimal: Sheep\nCost: $" + cost + " per day\nWeight: " + weight + "kg\nAge: " + age + " years old\nWool Production: " + wool + "kg per year\nColor: " + color + "\nWater Consumption: " + water + "L per day";
            return values;
        }
        override public double dailyIncome()
        {
            double total = wool * Rates_Prices.woolPrice / 365 - cost;
            return total;
        }
        override public double dailyTax()
        {
            double totalTax = weight * Rates_Prices.tax;
            return totalTax;
        }
        override public double sheepProfitability()
        {
            return dailyIncome() - dailyTax() - waterCost() ;
        }
        override public double dailyProf()
        {
            double total = dailyIncome() - dailyTax() - waterCost();
            return total;
        }
    }
}
