using Newtonsoft.Json.Linq;
using RestSharp;
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
        string[] code = { "CNY", "EUR", "IDR", "GBP", "KRW", "USD"};
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
            var indexFrom = cboxFrom.SelectedIndex;
            var indexTo = cboxTo.SelectedIndex;

            var from = code[indexFrom];
            var to = code[indexTo];
            var amount = double.Parse(txtFromValue.Text);

            var client = new RestClient($"https://free.currconv.com/api/v7/convert?q={from}_{to}&compact=ultra&apiKey=cfd890607153b25897e7");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var jObject = JObject.Parse(response.Content);

            //Extracting Node element using Getvalue method
            string rate = (jObject.GetValue($"{from}_{to}").ToString());
            double rateDbl = double.Parse(rate);
            txtToValue.Text = (rateDbl*amount).ToString();
        }
    }
}
