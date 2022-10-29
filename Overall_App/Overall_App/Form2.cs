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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            String ConnStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kyle Phillips\OneDrive - Wintec\COMP_609_App_Dev\App_Project\Data_Retrieval\FarmInfomation.accdb";//File location
            String tableName1 = "Select * FROM goats;";//enter table name, SELECT * FROM ; is added automatically
            String tableName2 = "Select * FROM sheep;";
            String tableName3 = "Select * FROM cows;";
            String tableName4 = "Select * FROM dogs;";
            String tableName5 = "Select * FROM commodity_prices;";
            try
            {
                OleDbConnection conn = new OleDbConnection(ConnStr);
                conn.Open();//conn equals ConnStr & ConnStr equals Access file, therefore, conn.open opens Access file
                OleDbDataAdapter adapter1 = new OleDbDataAdapter(tableName1, conn);
                OleDbDataAdapter adapter2 = new OleDbDataAdapter(tableName2, conn);
                OleDbDataAdapter adapter3 = new OleDbDataAdapter(tableName3, conn);
                OleDbDataAdapter adapter4 = new OleDbDataAdapter(tableName4, conn);
                OleDbDataAdapter adapter5 = new OleDbDataAdapter(tableName5, conn);
                DataSet Table1 = new DataSet();
                DataSet Table2 = new DataSet();
                DataSet Table3 = new DataSet();
                DataSet Table4 = new DataSet();
                DataSet Table5 = new DataSet();
                adapter1.Fill(Table1);//fill Dataset Table with requested table contents from access file
                adapter2.Fill(Table2);
                adapter3.Fill(Table3);
                adapter4.Fill(Table4);
                adapter5.Fill(Table5);
                Goats_Data.DataSource = Table1.Tables[0];//output to grid table 
                Sheep_Data.DataSource = Table2.Tables[0];
                Cows_Data.DataSource = Table3.Tables[0];
                Dogs_Data.DataSource = Table4.Tables[0];
                Commodity_Data.DataSource = Table5.Tables[0];
                conn.Close();//closes Access file
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//show error message
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            Close();
        }
    }
}
