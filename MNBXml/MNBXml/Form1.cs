using MNBXml.Entities;
using MNBXml.MNBServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace MNBXml
{
    public partial class Form1 : Form
    {
        BindingList<RateData> _rates = new BindingList<RateData>();
        public Form1()
        {
            InitializeComponent();

            getRates();

            RefreshData();
        }

        private void RefreshData()
        {
            if (cbValuta.SelectedItem == null) return;

            _rates.Clear();
            loadXml(getRates());
            dataGridView1.DataSource = _rates;
            makeChart();
        }

        private void makeChart()
        {
            chartRateData.DataSource = _rates;
            Series sorozatok = chartRateData.Series[0];
            sorozatok.ChartType = SeriesChartType.Line;
            sorozatok.XValueMember = "Date";
            sorozatok.YValueMembers = "value";
            sorozatok.BorderWidth = 2;

            var jelmagyarazat = chartRateData.Legends[0];
            jelmagyarazat.Enabled = false;

            var diagramterulet = chartRateData.ChartAreas[0];
            diagramterulet.AxisY.IsStartedFromZero = false;
            diagramterulet.AxisX.MajorGrid.Enabled = false;
            diagramterulet.AxisY.MajorGrid.Enabled = false;

        }

        private void loadXml(string xmlstring)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlstring);
            foreach (XmlElement item in xml.DocumentElement)
            {
                RateData r = new RateData();
                r.Date= DateTime.Parse(item.GetAttribute("date"));
                var childElement = (XmlElement)item.ChildNodes[0];
                r.Currency=childElement.GetAttribute("curr");
                decimal unit = decimal.Parse(childElement.GetAttribute("unit"));
                r.Value = decimal.Parse(childElement.InnerText);
                if (unit!=0)
                   r.Value = r.Value / unit;
                

                _rates.Add(r);

            }
        }

        private string getRates()
        {
            
            var mnbService = new MNBServiceReference.MNBArfolyamServiceSoapClient();
            GetExchangeRatesRequestBody req = new GetExchangeRatesRequestBody();
            req.currencyNames = cbValuta.SelectedItem.ToString();// "EUR";
            req.startDate = TolPicker.Value.ToString("yyyy-MM-dd");//"2020-01-01";
            req.endDate = IgPicker.Value.ToString("yyyy-MM-dd");//"2020-06-30";
            var response = mnbService.GetExchangeRates(req);
            return response.GetExchangeRatesResult;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void paramChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
