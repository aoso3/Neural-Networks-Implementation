using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Telerik.WinControls;
using Accord.Math;
using System.Text.RegularExpressions;

namespace BackPropagation_Implementation.NN_Forms
{
    public partial class NN : Telerik.WinControls.UI.RadForm
    {

        private Series Error_Fun;
        double[,] input, input0;
        double[,] output, output0;

        public double[,] Transpose(double[,] matrix)
        {
            int w = matrix.GetLength(0);
            int h = matrix.GetLength(1);

            double[,] result = new double[h, w];

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }

        public NN()
        {
            InitializeComponent();
            if (Intro.BP)
            {
                radTextBox5.Hide();
                radTextBox6.Hide();
                radLabel10.Hide();
                radLabel5.Hide();
                radTextBox3.Hide();
                radLabel9.Hide();
            }
            else if (Intro.BPM)
            {
                radTextBox5.Show();
                radLabel5.Show();
                radTextBox6.Hide();
                radLabel10.Hide();
                radTextBox3.Hide();
                radLabel9.Hide();
            }
            else if (Intro.Levenberg)
            {
                radTextBox6.Show();
                radLabel10.Show();
                radTextBox5.Hide();
                radLabel5.Hide();
                radTextBox3.Show();
                radLabel9.Show();
            }
            radDropDownList1.Items.Add("purelin");
            radDropDownList1.Items.Add("logsig");
            radDropDownList2.Items.Add("purelin");
            radDropDownList2.Items.Add("logsig");
            radDropDownList1.Items.Add("tanh");
            radDropDownList2.Items.Add("tanh");

        }

        private void radButton1_Click(object sender, EventArgs e)
        {

            if (input != null || output != null)
            {
                chart1.Series.Clear();
                Error_Fun = new Series() { ChartType = SeriesChartType.Spline };
                chart1.Series.Add(Error_Fun);

                List<DataPoint> err_function = new List<DataPoint>();


                //double[,] andoutput = Matrix.Create(1, 4, 0d);
                //oroutput[0, 0] = 1;
                int nurons_num = (int)radTrackBar1.Value;
                int max_iteration = Convert.ToInt16(radTextBox4.Text);
                neuralNetwork net = new neuralNetwork(input, output, new int[] { nurons_num }, new string[] { radDropDownList1.Text.ToString(), radDropDownList2.Text.ToString()});
                if (Intro.BP || Intro.BPM)
                    net.change_paramaters(Convert.ToDouble(radTextBox1.Text), Convert.ToDouble(radTextBox2.Text), Convert.ToDouble(radTextBox5.Text));
                else
                    net.change_paramaters_levenberg(Convert.ToDouble(radTextBox1.Text), Convert.ToDouble(radTextBox2.Text), Convert.ToDouble(radTextBox3.Text), Convert.ToDouble(radTextBox6.Text));


                net.init();


                for (int i = 0; i < max_iteration; i++)
                {
                    if (!Intro.Levenberg)
                    {
                        if (Intro.BP)
                            net.train("traingd", "onLine");
                        else if (Intro.BPM)
                            net.train("traingdm", "onLine");

                        net.get_class(new double[,] { { 1.1, 2.1 }, { 5.1, 3.1 }, { 3.1, 6.1 } });

                        double err = 0;
                        for (int ii = 0; ii < input.GetLength(1); ii++)
                            err += Norm.Euclidean(net.eval(input.GetColumn(ii)).Subtract(output.GetColumn(ii)));
                        err_function.Add(new DataPoint(i, err));
                    }
                    else
                    {
                        
                      
                       
                        net.levenbergMarqardt();
                        double err = 0;
                        for (int ii = 0; ii < input.GetLength(1); ii++)
                            err += Norm.Euclidean( net.eval(input.GetColumn(ii)).Subtract(output.GetColumn(ii))) ;
                        err_function.Add(new DataPoint(i, err));

                    }


                }


                foreach (DataPoint p in err_function)
                    chart1.Series[0].Points.Add(p);

            }
            else
            {
                MessageBox.Show("Enter Input !");
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Owner.Show();
            this.Close();
        }

        bool IsNumeric(string text)
        {
            int n;
            bool b = int.TryParse(text, out n);
            return b;
        }

        private void radButton3_Click(object sender, EventArgs e)
        {


            OpenFileDialog fd = new OpenFileDialog();
            int row = 0, col = 0;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(fd.OpenFile());

                List<List<int>> list = new List<List<int>>();
                int i = 0, j = 0, l = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (l == 0)
                    {
                        row = int.Parse(values[0].ToString());
                        col = int.Parse(values[1].ToString());
                        input0 = Matrix.Create(row, col, 0d);

                    }
                    else
                    {
                        j = 0;
                        foreach (string s in values)
                        {
                            input0[i, j++] = double.Parse(s);
                        }

                        i++;
                    }
                    l++;
                }
                input =input0.Transpose();
            }




        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            int row = 0, col = 0;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(fd.OpenFile());

                List<List<int>> list = new List<List<int>>();
                int i = 0, j = 0, l = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (l == 0)
                    {
                        row = int.Parse(values[0].ToString());
                        col = int.Parse(values[1].ToString());
                        output0 = Matrix.Create(row, col, 0d);

                    }
                    else
                    {
                        j = 0;
                        foreach (string s in values)
                        {
                            output0[i, j++] = double.Parse(s);
                        }

                        i++;
                    }


                    l++;
                }
                output = output0.Transpose();//.Multiply(2).Add(-1);


            }
        }
    }
}
