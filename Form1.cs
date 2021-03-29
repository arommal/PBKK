using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Reflection;
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
        string[] code = { "CNY", "EUR", "IDR", "GBP", "KRW", "USD" };
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
            // Fetch inputs
            var indexFrom = cboxFrom.SelectedIndex;
            var indexTo = cboxTo.SelectedIndex;
            var date = datePicker.Value.Date.ToString("yyyy-MM-dd");
            var amount = double.Parse(txtFromValue.Text);

            // Assign values based on index
            var from = code[indexFrom];
            var to = code[indexTo];

            // Send API request
            var client = new RestClient($"https://free.currconv.com/api/v7/convert?q={from}_{to}&compact=ultra&date={date}&apiKey=cfd890607153b25897e7");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            // Getting rate value from parsed response message
            var obj = JObject.Parse(response.Content);
            var a = obj[$"{from}_{to}"][$"{date}"];
            var rate = a.ToObject<double>();

            // Printing result
            txtToValue.Text = (rate * amount).ToString();
        }
    }
}
