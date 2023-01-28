using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace NirvanaTradingApplication
{

    public partial class TradingTicket : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public static string symbol;
        public static string side;
        public static string account;
        public static int quantity;
        public static double avgPrice;
        public static int remainingQuanity;
        public static string orderStatus = "New";
        public static string clOrderId = "Order 1";
        public static string parentCLOrderId = "Order1";
        public static string stagedOrderId = "Null";
        public static string originalCLOrderId = "Null";

        public static DataTable data;
        static int count = 0;
        private bool providerName;

        public void IntilalizeText()
        {

            symbol = textBox1.Text;
            side = comboBox1.Text;
            account = comboBox2.Text;
            quantity = int.Parse(textBox2.Text);
            avgPrice = float.Parse(textBox3.Text);
            remainingQuanity = int.Parse(textBox2.Text);
        }
        public static DataTable InitializeTable()
        {
            data = new DataTable();
            data.Columns.Add("symbol", typeof(string));
            data.Columns.Add("side", typeof(string));
            data.Columns.Add("account", typeof(string));
            data.Columns.Add("quantity", typeof(string));
            data.Columns.Add("avgPrice", typeof(string));
            data.Columns.Add("remainingQuanity", typeof(string));
            data.Columns.Add("orderStatus", typeof(string));
            data.Columns.Add("clOrderId", typeof(string));
            data.Columns.Add("parentCLOrderId", typeof(string));
            data.Columns.Add("stagedOrderId", typeof(string));
            data.Columns.Add("originalCLOrderId", typeof(string));
            return data;
        }
        public TradingTicket()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("Enter Symbol") || comboBox1.Text.Equals("Select Side") || textBox2.Equals("Select Account") ||Int64.Parse(textBox2.Text)==0 || float.Parse(textBox3.Text) == 0.00f)
            {
                ErrorMessage errorObject = new ErrorMessage();
                errorObject.Show();
                return;
            }
            else
            {
                try
                {


                    string mainConn = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
                    SqlConnection conn = new SqlConnection(mainConn);
                    SqlCommand cmd = new SqlCommand("InsertData", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Symbol", SqlDbType.NVarChar).Value = textBox1.Text;
                    cmd.Parameters.Add("@Side", SqlDbType.NVarChar).Value = comboBox1.Text;
                    cmd.Parameters.Add("@Account", SqlDbType.NVarChar).Value = comboBox2.Text;
                    cmd.Parameters.Add("@Quantity", SqlDbType.BigInt).Value = Convert.ToInt32(textBox2.Text);
                    cmd.Parameters.Add("@AvgPrice", SqlDbType.Float).Value = Convert.ToDouble(textBox3.Text); ;
                    cmd.Parameters.Add("@RemQuantity", SqlDbType.Int).Value = 12;
                    cmd.Parameters.Add("@OrderStatus", SqlDbType.NVarChar).Value = "New";
                    cmd.Parameters.Add("@CLOrderId", SqlDbType.NVarChar).Value = "null";
                    cmd.Parameters.Add("@ParentCLOrderId", SqlDbType.NVarChar).Value = "null";
                    cmd.Parameters.Add("@StagedOrderId", SqlDbType.NVarChar).Value = "null";
                    cmd.Parameters.Add("@OriginalCLOrderId", SqlDbType.NVarChar).Value = "null";

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    string SecondMainConn = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
                    SqlConnection SecondConn = new SqlConnection(SecondMainConn);
                    SqlCommand SecondCmd = new SqlCommand("InsertDataIntoGroup", SecondConn);
                    SecondCmd.CommandType = CommandType.StoredProcedure;
                    SecondCmd.Parameters.Add("@Symbol", SqlDbType.NVarChar).Value = textBox1.Text;
                    SecondCmd.Parameters.Add("@Side", SqlDbType.NVarChar).Value = comboBox1.Text;
                    SecondCmd.Parameters.Add("@Account", SqlDbType.NVarChar).Value = comboBox2.Text;
                    SecondCmd.Parameters.Add("@Quantity", SqlDbType.BigInt).Value = Convert.ToInt32(textBox2.Text);
                    SecondCmd.Parameters.Add("@AvgPrice", SqlDbType.Float).Value = Convert.ToDouble(textBox3.Text); ;
                    SecondCmd.Parameters.Add("@RemQuantity", SqlDbType.Int).Value = 12;
                    SecondCmd.Parameters.Add("@OrderStatus", SqlDbType.NVarChar).Value = "New";
                    SecondCmd.Parameters.Add("@CLOrderId", SqlDbType.NVarChar).Value = "null";
                    SecondCmd.Parameters.Add("@ParentCLOrderId", SqlDbType.NVarChar).Value = "null";
                    SecondCmd.Parameters.Add("@StagedOrderId", SqlDbType.NVarChar).Value = "null";
                    SecondCmd.Parameters.Add("@OriginalCLOrderId", SqlDbType.NVarChar).Value = "null";

                    SecondConn.Open();
                    SecondCmd.ExecuteNonQuery();
                    SecondConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                SuccessMessage obj = new SuccessMessage();
                obj.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Equals("Enter Symbol") || comboBox1.Text.Equals("Select Side") || comboBox2.Equals("Select Account") || Int64.Parse(textBox2.Text) == 0 || float.Parse(textBox3.Text) == 0.00f)
            {
                ErrorMessage errorObject2 = new ErrorMessage();
                errorObject2.Show();
                return;
            }
            else
            {
                try
                {


                    string mainConn = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
                    SqlConnection conn = new SqlConnection(mainConn);
                    SqlCommand cmd = new SqlCommand("InsertData", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Symbol", SqlDbType.NVarChar).Value = textBox1.Text;
                    cmd.Parameters.Add("@Side", SqlDbType.NVarChar).Value = comboBox1.Text;
                    cmd.Parameters.Add("@Account", SqlDbType.NVarChar).Value = comboBox2.Text;
                    cmd.Parameters.Add("@Quantity", SqlDbType.BigInt).Value = Convert.ToInt32(textBox2.Text);
                    cmd.Parameters.Add("@AvgPrice", SqlDbType.Float).Value = Convert.ToDouble(textBox3.Text); ;
                    cmd.Parameters.Add("@RemQuantity", SqlDbType.Int).Value = 12;
                    cmd.Parameters.Add("@OrderStatus", SqlDbType.NVarChar).Value = "Filled";
                    cmd.Parameters.Add("@CLOrderId", SqlDbType.NVarChar).Value = "null";
                    cmd.Parameters.Add("@ParentCLOrderId", SqlDbType.NVarChar).Value = "null";
                    cmd.Parameters.Add("@StagedOrderId", SqlDbType.NVarChar).Value = "null";
                    cmd.Parameters.Add("@OriginalCLOrderId", SqlDbType.NVarChar).Value = "null";

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    
                    string SecondMainConn = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
                    SqlConnection SecondConn = new SqlConnection(SecondMainConn);
                    SqlCommand SecondCmd = new SqlCommand("InsertDataIntoGroup", SecondConn);
                    SecondCmd.CommandType = CommandType.StoredProcedure;
                    SecondCmd.Parameters.Add("@Symbol", SqlDbType.NVarChar).Value = textBox1.Text;
                    SecondCmd.Parameters.Add("@Side", SqlDbType.NVarChar).Value = comboBox1.Text;
                    SecondCmd.Parameters.Add("@Account", SqlDbType.NVarChar).Value = comboBox2.Text;
                    SecondCmd.Parameters.Add("@Quantity", SqlDbType.BigInt).Value = Convert.ToInt32(textBox2.Text);
                    SecondCmd.Parameters.Add("@AvgPrice", SqlDbType.Float).Value = Convert.ToDouble(textBox3.Text); ;
                    SecondCmd.Parameters.Add("@RemQuantity", SqlDbType.Int).Value = 12;
                    SecondCmd.Parameters.Add("@OrderStatus", SqlDbType.NVarChar).Value = "Filled";
                    SecondCmd.Parameters.Add("@CLOrderId", SqlDbType.NVarChar).Value = "null";
                    SecondCmd.Parameters.Add("@ParentCLOrderId", SqlDbType.NVarChar).Value = "null";
                    SecondCmd.Parameters.Add("@StagedOrderId", SqlDbType.NVarChar).Value = "null";
                    SecondCmd.Parameters.Add("@OriginalCLOrderId", SqlDbType.NVarChar).Value = "null";

                    SecondConn.Open();
                    SecondCmd.ExecuteNonQuery();
                    SecondConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                SuccessMessage obj2 = new SuccessMessage();
                obj2.Show();
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TradingTicket_Load(object sender, EventArgs e)
        {
             cn = new SqlConnection(@"Data Source=HIMANSHUCHAUDRY\MSSQLSERVER14;Initial Catalog=NirvanaTradingApplicationDatabase;Integrated Security=True; Integrated Security=True"); 
            cn.Open(); 
            BindData();
        }
        public void BindData()
        {
            try
            {


                cmd = new SqlCommand("select AccountName from T_CompanyFunds ", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox2.Items.Add(dr[0].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
      }

    }
}
