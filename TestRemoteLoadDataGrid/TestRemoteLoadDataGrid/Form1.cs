using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TestRemoteLoadDataGrid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'electricutilityDataSet.tech' table. You can move, or remove it, as needed.
            this.techTableAdapter.Fill(this.electricutilityDataSet.tech);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox selection = (ComboBox)sender;
            int itemKey = (int) selection.SelectedValue;
            Console.WriteLine(itemKey);
            getTechTickets(itemKey);
        }

        private void getTechTickets(int techId)
        {
            try
            {
                string MyConnection2 = "server=127.0.0.1;user id=electric_util_ad;password=eleadmin;database=electricutility;";
                //Display query
                string Query = "select ticketId AS Ticket, onDate AS Date, am AS AM, pm AS PM  from schedule natural join tech where techId = "+techId+";";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                //  MyConn2.Open();
                //For offline connection we weill use  MySqlDataAdapter class.
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.             
                // MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
