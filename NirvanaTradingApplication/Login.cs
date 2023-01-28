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

namespace NirvanaTradingApplication
{
    public partial class Login : Form
    {
        static int attempt = 3;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {



                SqlConnection sqlcon = new SqlConnection(@"Data Source = HIMANSHUCHAUDRY\MSSQLSERVER14; Initial Catalog = NirvanaTradingApplicationDatabase; Integrated Security = True");



                string query = "Select * from [T_CompanyUser] Where username= '" + textBox1.Text + "'and passwords  = '" + textBox2.Text + " ' ";
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);

                DataTable dtbl = new DataTable();

                sda.Fill(dtbl);

                if (dtbl.Rows.Count >0)
                {
                    Nirvana obj = new Nirvana();
                    this.Hide();
                    obj.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
