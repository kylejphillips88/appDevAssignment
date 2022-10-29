using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overall_App
{
    internal class Animal
    {
        public int id;//variable names
        public double water;
        public double cost;
        public double weight;
        public int age;
        public string color;
        public Animal(int id, double water, double cost, double weight, int age, string color)//constructors
        {
            this.id = id;
            this.water = water;
            this.cost = cost;
            this.weight = weight;
            this.age = age;
            this.color = color;
        }
        virtual public string Values()//method intended to be overridden by subclasses
        {
            string values = id + " " + "Mystery Animal";
            return values;
        }
        virtual public double dailyIncome()//method to be inherited by dogs, being only animal that generates 0 profit
        {
            double total = 0 - cost;
            return total;
        }
        virtual public double dailyTax()//method to be inherited by dogs being only animal that does not get taxed
        {
            return 0;
        }
        virtual public double waterCost()//method to be inherited by all animals
        {
            double wCost = water * Rates_Prices.waterPrice;//amount of water consumed times price of water per litre
            return wCost;
        }
        virtual public double dailyProf()
        {
            double total = dailyIncome() - dailyTax() - waterCost();
            return total;
        }
        virtual public double dailyMilk()//method intended to be overridden by milk producing animals
        {
            return 0;
        }
        virtual public double ageAvg()//get age for each animal
        {
            return age;
        }
        virtual public double sheepProfitability()//to be overridden by sheep
        {
            return 0;
        }
        virtual public double cowGoatProfitability()//to be overidden by cows n goats
        {
            return 0;
        }
        virtual public int animalNoDogCount()//animal count without dogs included
        {
            return 1;
        }
        virtual public double dogCost()//intended to be overridden by dogs only
        {
            return 0;
        }
        virtual public double totalCost()//calculates costs only without any profit
        {
            return cost + dailyTax() + waterCost();
        }
        virtual public int redColor()//count up red animals
        {
            if (color == "red" || color == "Red")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        virtual public int animalCount()//count all animals
        {
            return 1;
        }
        virtual public int jcCount()//count jersey cows
        {
            return 0;
        }
    }
}
