using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurrencyConverter
{
    public partial class Form1 : Form
    {
        double[] toRate = { 0.00045, 0.000058, 0, 0.000050, 0.078, 0.000070 };
        public Form1()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int index = cboxTo.SelectedIndex;
            Object currency = cboxTo.SelectedItem;
            double fromValue = double.Parse(txtFromValue.Text);
            double toValue = fromValue * toRate[index];
            txtToValue.Text = toValue.ToString();
        }
    }
}
