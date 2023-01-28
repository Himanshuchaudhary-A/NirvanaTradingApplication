using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NirvanaTradingApplication
{
    public partial class Nirvana : Form
    { 
        static DataTable dt;
        public Nirvana()
        {
            InitializeComponent();
        }

        private void tradingTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TradingTicket tradingTicket = new TradingTicket();
            tradingTicket.Show();
        }

        private void blotterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt = TradingTicket.data;
            Blotter blotter = new Blotter(dt);    
            blotter.Show();
        }

        private void allocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dt = TradingTicket.data;
            Allocation allocation = new Allocation();   
            allocation.Show();
        }
    }
}
