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
    public partial class Allocation : Form
    { 
        SqlConnection SecondCn;
       SqlCommand SecondCmd;
        SqlDataReader SecondDr;
        SqlConnection ThirdCon;
        SqlCommand ThirdCmd;
        SqlConnection ForthCon;
        SqlCommand ForthCmd;
        DataTable table = new DataTable();

       

        public Allocation()
        {
            InitializeComponent();
        }

        //public Allocation(DataTable data)
        //{
        //    //try
            //{


            //    InitializeComponent();
            //    dataTable1 = data.Copy();
            //    for (int i = dataTable1.Rows.Count - 1; i >= 0; i--)
            //    {
            //        DataRow dr = dataTable1.Rows[i];
            //        if (String.Equals(dr["Account"].ToString(), "Unallocated") == false)
            //        {
            //            dataTable1.Rows.Remove(dr);
            //        }
            //    }
            //    dataTable1.AcceptChanges();
            //    ultraGrid1.DataSource = dataTable1;
            //    ultraGrid1.Refresh();
            //    dataTable2 = data.Copy();
            //    for (int i = dataTable2.Rows.Count - 1; i >= 0; i--)
            //    {
            //        DataRow dr = dataTable2.Rows[i];
            //        if (dr["Account"].ToString() == "Unallocated")
            //        {
            //            dataTable2.Rows.Remove(dr);
            //        }
            //    }

            //    dataTable2.AcceptChanges();

            //    ultraGrid2.DataSource = dataTable2;
            //    ultraGrid2.Refresh();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        //}
        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

        }

        private void Allocation_Load(object sender, EventArgs e)
        {

            SecondCn = new SqlConnection(@"Data Source=HIMANSHUCHAUDRY\MSSQLSERVER14;Initial Catalog=NirvanaTradingApplicationDatabase;Integrated Security=True; Integrated Security=True");
            SecondCn.Open();
            BindData();
            ThirdCon = new SqlConnection(@"Data Source=HIMANSHUCHAUDRY\MSSQLSERVER14;Initial Catalog=NirvanaTradingApplicationDatabase;Integrated Security=True");
            ThirdCmd = new SqlCommand("select * from T_Group", ThirdCon);
            string selectquery = "select * from T_Group where Account= 'Unallocate'";
            SqlDataAdapter adpt = new SqlDataAdapter(selectquery, ThirdCon);
            DataTable table = new DataTable();
            adpt.Fill(table);
            ultraGrid1.DataSource = table;

            //ForthCon = new SqlConnection(@"Data Source=HIMANSHUCHAUDRY\MSSQLSERVER14;Initial Catalog=NirvanaTradingApplicationDatabase;Integrated Security=True");
            //ForthCmd = new SqlCommand("select * from T_Group", FCon);
            string selectquery2 = "select * from T_Group where Account != 'Unallocate'";
            SqlDataAdapter adpt2 = new SqlDataAdapter(selectquery, ThirdCon);
            DataTable table2 = new DataTable();
            adpt2.Fill(table2);
            ultraGrid2.DataSource = table2;

        }
        public void BindData()
        {
            try
            {


                SecondCmd = new SqlCommand("select AccountName from T_CompanyFunds ", SecondCn);
                SecondDr = SecondCmd.ExecuteReader();
                while (SecondDr.Read())
                {
                    comboBox1.Items.Add(SecondDr[0].ToString());
                }
                SecondDr.Close();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
            }
    }

}
