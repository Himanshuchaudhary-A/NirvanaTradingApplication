using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

using System.Data.SqlClient;

namespace NirvanaTradingApplication
{
    public partial class Blotter : Form
    {
        public Blotter()
        {
            InitializeComponent();
        }
        public Blotter(DataTable data)
        {
            InitializeComponent();
            ultraGrid1.DataSource = data;
            ultraGrid1.Refresh();
        }

        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

        }

        private void Blotter_Load(object sender, EventArgs e)
        {
            try
            {
                this.Location = new Point(0, 0);
                string mainConn = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
                SqlConnection conn = new SqlConnection(mainConn);
                conn.Open();
                string query = "select * from T_TradedOrders";
                SqlCommand cmd = new SqlCommand(query, conn);

                var reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                ultraGrid1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
