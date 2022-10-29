using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Overall_App
{
    public partial class Form3 : Form
    {
        Dictionary<int, Animal> Animals = new Dictionary<int, Animal>();//create animals dictionary
        public int partition(double[] arr, int start, int end)//
        {
            double key = arr[start];
            while (start < end)
            {
                while (arr[end] >= key && end > start)
                {
                    --end;
                }

                arr[start] = arr[end];
                while (arr[start] <= key && end > start)
                {
                    ++start;
                }
                arr[end] = arr[start];
            }
            arr[start] = key;
            return end;
        }
        public void quickSort(double[] arr, int start, int end)
        {
            if (start >= end)//if start is greater than the end quicksort is finished
            {
                return;
            }
            int index = partition(arr, start, end);//index equals partition
            quickSort(arr, start, index - 1);
            quickSort(arr, index + 1, end);
        }
        public Form3()
        {
            InitializeComponent();
            try
            {
                String ConnStr2 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kyle Phillips\OneDrive - Wintec\COMP_609_App_Dev\App_Project\Data_Retrieval\FarmInfomation.accdb";//File location
                String[] tables = new string[] { "goats", "sheep", "cows", "dogs", "commodity_prices" };// each table name
                foreach (string type in tables)
                {
                    using (OleDbConnection conn2 = new OleDbConnection(ConnStr2))//create new connection
                    {
                        OleDbCommand cmd = new OleDbCommand("SELECT * FROM " + type, conn2);//selects each table from names above  
                        conn2.Open();//conn2 equals ConnStr2 & ConnStr2 equals Access file, therefore, conn2.open opens Access file
                        OleDbDataReader reader = cmd.ExecuteReader();//create read data command
                        if (!reader.HasRows)//if there are no tables with searched names
                        {
                            MessageBox.Show("No tables found");
                            continue;
                        }
                        while (reader.Read())
                        {
                            if (type == "goats")//for goat table create class entry for each row into Animals hash table
                            {
                                Animal gt = new Goat(reader.GetInt32(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetDouble(3), reader.GetInt16(4), reader.GetString(5), reader.GetDouble(6));
                                Animals.Add(reader.GetInt32(0), gt);
                            }
                            else if (type == "sheep")//for sheep table create class entry for each row into Animals hash table
                            {
                                Animal sp = new Sheep(reader.GetInt16(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetDouble(3), reader.GetInt16(4), reader.GetString(5), reader.GetDouble(6));
                                Animals.Add(reader.GetInt16(0), sp);
                            }
                            else if (type == "cows")//for cows table create class entry for each row into Animals hash table
                            {
                                if (reader.GetBoolean(7) == false)//determine if cow is jersey cow or not based on check box
                                {
                                    Animal cw = new Cow(reader.GetInt16(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetDouble(3), reader.GetInt16(4), reader.GetString(5), reader.GetDouble(6));
                                    Animals.Add(reader.GetInt16(0), cw);
                                }
                                else
                                {
                                    Animal jc = new J_Cow(reader.GetInt16(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetDouble(3), reader.GetInt16(4), reader.GetString(5), reader.GetDouble(6));
                                    Animals.Add(reader.GetInt16(0), jc);
                                }
                            }
                            else if (type == "dogs")//for dogs table create class entry for each row into Animals hash table
                            {
                                Animal dg = new Dog(reader.GetInt32(0), reader.GetDouble(1), reader.GetDouble(5), reader.GetDouble(2), reader.GetInt16(3), reader.GetString(4));
                                Animals.Add(reader.GetInt32(0), dg);
                            }
                            else if (type == "commodity_prices")// last table left is prices, assign each row's 2nd column to static variable based on name of each row's 1st column 
                            {
                                if (reader.GetString(0) == "Goat milk price")
                                {
                                    Overall_App.Rates_Prices.goatMilkPrice = reader.GetDouble(1);
                                }
                                else if (reader.GetString(0) == "Sheep wool price")
                                {
                                    Overall_App.Rates_Prices.woolPrice = reader.GetDouble(1);
                                }
                                else if (reader.GetString(0) == "Water price")
                                {
                                    Overall_App.Rates_Prices.waterPrice = reader.GetDouble(1);
                                }
                                else if (reader.GetString(0) == "Government tax")
                                {
                                    Overall_App.Rates_Prices.tax = reader.GetDouble(1);
                                }
                                else if (reader.GetString(0) == "Jersey cow tax")
                                {
                                    Overall_App.Rates_Prices.jcTax = reader.GetDouble(1);
                                }
                                else
                                {
                                    Overall_App.Rates_Prices.cowMilkPrice = reader.GetDouble(1);
                                }
                            }

                        }
                        conn2.Close();//close connection                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//show error message
            }

        }
        private void button2_Click(object sender, EventArgs e)//go back to main menu
        {
            Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            Close();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Animal search = Animals[int.Parse(textBox1.Text)];//animal search equals key typed into textbox
                output.Text = search.Values();
            }
            catch (Exception ex)
            {
                output.Text = "Error " + ex.Message;//error message
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int count = 0;
            double averAge = 0;
            double dailyMilkProd = 0;
            double dailyTax = 0;
            double totalProf = 0;
            double cgProf = 0;
            double sProf = 0;
            double count1 = 0;
            double red = 0;
            double dogTotal = 0;
            double total = 0;
            double jcowProf = 0;
            double jCows = 0;
            foreach (KeyValuePair<int, Animal> kvp in Animals)
            {
                totalProf += kvp.Value.dailyProf();
                dailyTax += kvp.Value.dailyTax();
                dailyMilkProd += kvp.Value.dailyMilk();
                averAge += kvp.Value.ageAvg();
                count += kvp.Value.animalNoDogCount();
                cgProf += kvp.Value.cowGoatProfitability();
                sProf += kvp.Value.sheepProfitability();
                dogTotal += kvp.Value.dogCost();
                total += kvp.Value.totalCost();
                red += kvp.Value.redColor();
                count1 += kvp.Value.animalCount();
                if (kvp.Value.jcCount() == 1)
                {
                    jCows += kvp.Value.dailyTax();
                    jcowProf += kvp.Value.dailyProf();
                }
            }
            
            outputFarmProfit.Text = "$" + Math.Round(totalProf, 2);
            outputTaxCharges.Text = "$" + Math.Round(dailyTax * 365 / 12, 2);
            outputMilk.Text = Math.Round(dailyMilkProd, 2) + "L";
            outputAge.Text = Math.Round(averAge / count, 2) + " years";
            outputGCProfit.Text = "$" + Math.Round(cgProf, 2) + " per day";
            outputSheepProfit.Text = "$" + Math.Round(sProf, 2) + " per day";
            double percentage = dogTotal / total * 100;
            double redPercent = red / count1 * 100;
            animalDogRatio.Text = "Dogs total cost per day: $" + Math.Round(dogTotal, 2) + "\nAnimals total cost per day: $" + Math.Round(total, 2) + "\nDogs account for " + Math.Round(percentage, 1) + "% of all animal costs.";
            animalColorRatio.Text = "Number of red animals: " + red + "\nRed animals account for " + Math.Round(redPercent, 2) + "% of total animals.";
            jerseyCowData.Text = "Total tax paid for jersey cows per day: $" + jCows + "\n" + "Profit generated by jersey cows per day: $" + Math.Round(jcowProf, 2);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<double, int> dailyProfit = new Dictionary<double, int>();
                foreach (KeyValuePair<int, Animal> kvp in Animals)
                {
                    if (kvp.Value.cowGoatProfitability() != 0 || kvp.Value.sheepProfitability() != 0)
                    {
                        dailyProfit.Add(kvp.Value.dailyProf(), kvp.Key);
                    }
                }
                double[] profitArr = new double[dailyProfit.Count];
                string[] stringProfit = new string[dailyProfit.Count];
                dailyProfit.Keys.CopyTo(profitArr, 0);
                quickSort(profitArr, 0, dailyProfit.Count - 1);
                foreach (KeyValuePair<double, int> kvp in dailyProfit)
                {
                    for (int i = 0; i < profitArr.Length; i++)
                    {
                        if (profitArr[i] == kvp.Key)
                        {
                            stringProfit[i] = kvp.Value.ToString();
                        }
                    }
                }
                System.IO.File.WriteAllLines(@"C:\Users\Kyle Phillips\OneDrive - Wintec\COMP_609_App_Dev\Projects\Overall_App\Animal_Profit_Order.txt", stringProfit);
                label7.Text = "File Successfully Created";
                
            }
            catch (Exception ex)
            {
                label7.Text = "Error. File Could not be Created. " + ex.Message;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                double above = 0;
                double total1 = 0;
                foreach (KeyValuePair<int, Animal> kvp in Animals)
                {
                    total1++;
                    if (kvp.Value.age > int.Parse(ageThresh.Text))
                    {
                        above++;
                    }
                }
                double percentage = above / total1 * 100;
                outputThresh.Text = "Number of animals older than age threshold: " + above + "\nPercentage of animals above age threshold: " + Math.Round(percentage, 1) + "%";
            }
            catch (Exception ex)
            {
                outputThresh.Text = "Error. " + ex.Message;
            }
        }
    }
}