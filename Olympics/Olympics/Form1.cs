using Olympics.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Olympics
{
    public partial class Form1 : Form
    {

        List<OlympicResult> results = new List<OlympicResult>();
        public Form1()
        {
            InitializeComponent();
            Betolt("Summer_olympic_Medals.csv");

            ComboFeltolt();
            Osztalyozas();
        }

        private void Osztalyozas()
        {
            foreach (OlympicResult item in results)
            {
                item.Position = Helyezes(item);
            }
        }

        int Helyezes(OlympicResult res)
        {
            int counter = 0;
            var szurt = from x in results where x.Year == res.Year && x.Country != res.Country select x;
            foreach (OlympicResult item in szurt)
            {
                if (item.Medals[0] > res.Medals[0]) counter++;
                else if ((item.Medals[0] == res.Medals[0]) && (item.Medals[1] > res.Medals[1])) counter++;
                else if ((item.Medals[0] == res.Medals[0]) && (item.Medals[1] == res.Medals[1]) && (item.Medals[2] > res.Medals[2])) counter++;

            }

            return counter + 1;
        }

        private void ComboFeltolt()
        {
            var years = (from x in results orderby x.Year select x.Year).Distinct();
            cbxEv.DataSource = years.ToList();
        }

        void Betolt(string fajlnev)
        {
            using (StreamReader sr = new StreamReader(fajlnev))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    string[] mezok = sor.Split(',');
                    OlympicResult or = new OlympicResult();
                    or.Year = int.Parse (mezok[0]);
                    or.Country = mezok[3];
                    int[] mtomb = new int[3];
                    //5,6,7
                    mtomb[0] = int.Parse(mezok[5]);
                    mtomb[1] = int.Parse(mezok[6]);
                    mtomb[2] = int.Parse(mezok[7]);
                    or.Medals = mtomb;
                    results.Add(or);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        Excel.Application xlApp;
        Excel.Workbook xlWB;
        Excel.Worksheet xlSheet;

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                xlApp = new Excel.Application();
                xlWB = xlApp.Workbooks.Add(Missing.Value);
                xlSheet = xlWB.ActiveSheet;

                ExcelFeltolt();

                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
                
            }
        }

        private void ExcelFeltolt()
        {
            var headers = new string[]
                {
                    "Helyezés",
                    "Ország",
                    "Arany",
                    "Ezüst",
                    "Bronz"

                };
            for (int i = 0; i < headers.Length; i++)
            {
                xlSheet.Cells[1, i + 1] = headers[i];
            }

            var fileteredResult = from x in results where x.Year == (int)cbxEv.SelectedItem orderby x.Position select x;
            int aktsor = 2;
            foreach (var item in fileteredResult)
            {
                xlSheet.Cells[aktsor, 1] = item.Position;
                xlSheet.Cells[aktsor, 2] = item.Country;
                for (int i = 0; i < 2; i++)
                {
                    xlSheet.Cells[aktsor, 3 + i] = item.Medals[i];
                }
                aktsor++;
            }
        }
    }
}
