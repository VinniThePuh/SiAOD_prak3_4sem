using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiAOD_prak3_4sem
{
    public partial class Form1 : Form
    {
        public void SplineChartExample(int check)
        {
            this.chart1.Series.Clear();
            this.chart1.Titles.Clear();
            this.chart1.Titles.Add("Temperature");

            

            Series series = this.chart1.Series.Add("Days");
            series.ChartType = SeriesChartType.Spline;

            switch (check)
            {
                case 1:
                    {
                        for (int i = 0; i < Class1.num; i++)
                        {
                            series.Points.AddXY(Class1.transs[i], Class1.transi[i]);
                        }
                        break;
                    }
                case 2:
                    {
                        for (int i = 0; i < Class1.num; i += 7)
                        {
                            series.Points.AddXY(Class1.transs[i], Class1.transi[i]);
                        }
                        break;
                    }
                case 3:
                    {
                        for (int i = 0; i < Class1.num; i += 30)
                        {
                            series.Points.AddXY(Class1.transs[i], Class1.transi[i]);
                        }
                        break;
                    }
                case 4:
                    {
                        for (int i = 0; i < Class1.num; i += 365)
                        {
                            series.Points.AddXY(Class1.transs[i], Class1.transi[i]);
                        }
                        break;
                    }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SplineChartExample(1);
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SplineChartExample(2);
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SplineChartExample(3);
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            SplineChartExample(4);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
