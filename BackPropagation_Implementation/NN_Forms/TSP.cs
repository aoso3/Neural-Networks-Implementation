using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Windows.Forms.DataVisualization.Charting;
using Accord.Math;


namespace BackPropagation_Implementation.NN_Forms
{
    public partial class TSP : Telerik.WinControls.UI.RadForm
    {
   
        Series A = new Series() { ChartType = SeriesChartType.Line };
        Series B = new Series() { ChartType = SeriesChartType.Point };
        static List<int> T = new List<int>();
        static int n;
        static double min ;
        int[] ok;

    

        // SA
        private double[,] distances;
        private double[] xCities, yCities;
        private int[] solution;
        private double startingTempreture,
                       coolingConstant;
        public TSP()
        {
            InitializeComponent();
            chart1.Series.Add(B);
            chart1.Series.Add(A);

        }

        private void radButton_Exit_Click(object sender, EventArgs e)
        {
            A.Points.Clear();
            B.Points.Clear();
            for (int r = 2; r < chart1.Series.Count; r++)
            {
                chart1.Series.RemoveAt(r);
            }
            chart1.Invoke(new Action(Refresh));
            
            this.Hide();
            this.Owner.Show();
            this.Close();
        }

        private void Button_Draw_Click(object sender, EventArgs e)
        {  
                    //Do2();
            this.learnSA(Convert.ToDouble(radTextBox7.Text), Convert.ToDouble(radTextBox6.Text), 0, 100, 1);
                    //drow_edges(solution);
            MessageBox.Show("Done");
        }

      


        private void radButton_Go_Click(object sender, EventArgs e)
        {
               coolingConstant = Convert.ToDouble(radTextBox1.Text.ToString());
               startingTempreture = Convert.ToDouble(radTextBox2.Text.ToString());
           
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();

                Random r = new Random();
                for (int i = 0; i < Convert.ToInt32(radTextBox3.Text); i++)
                    chart1.Series[0].Points.Add(new DataPoint(r.Next(100), r.Next(100)));

                
            

            if (chart1.Series[0].Points.Count != 0)
                {
                    this.Button_Draw.Enabled = true;
                    intilize();
                }
        }

        private double getDistance(int i, int j)
        {
            return Math.Sqrt(Math.Pow(xCities[j] - xCities[i], 2) + Math.Pow(yCities[j] - yCities[i], 2));
        }

        private double getPropability(double distanceChange, double tempreture)
        {
            if (distanceChange <= 0)
                return 1;
            return Math.Exp(-distanceChange / tempreture);
        }
        private double cost(int[] tempSolution)
        {
            double res = 0;
            res += distances[tempSolution[0], tempSolution[1]];
            for (int i = 0; i < tempSolution.Length - 2; i++)
                res += distances[tempSolution[i], tempSolution[i + 1]];
            res += distances[tempSolution[tempSolution.Length - 1], tempSolution[0]];

            return res;
        }
        private int[] switchCities(int[] _solution, Random r)
        {
            int[] tempSolution = Vector.Create(_solution.Length, 0);
            _solution.CopyTo(tempSolution, 0);
            int t1 = r.Next(0, tempSolution.Length - 1),
                t2 = r.Next(0, tempSolution.Length - 1);
            if (t1 != t2)
                tempSolution.Swap(t1, t2);
            else
                tempSolution.Swap(t1, r.Next(0, tempSolution.Length - 1));
            return tempSolution;
        }

        //after Go
        private void intilize()
        {
            n = B.Points.Count;
           
            ok = new int[n];
            xCities = new double[n];
            yCities = new double[n];
            min = 0;


            for (var e = 0; e < n; e++)
            { ok[e] = 0; }
            for (int i = 0; i < n; i++)
            {
                xCities[i] = B.Points[i].XValue;
                yCities[i] = B.Points[i].YValues[0];
            //    comboBox2.Items.Add(xCities[i].ToString() + ',' + yCities[i].ToString());
            }

            distances = Matrix.Create(xCities.Length, xCities.Length, 0d);
            for (int i = 0; i < xCities.Length; i++)
                for (int j = 0; j < xCities.Length; j++)
                {
                    distances[i, j] = getDistance(i, j);
                    Console.WriteLine(distances[i, j]);
                }

        }

        void drow_edges(int[] cities)
        {

            chart1.Series[1].Points.Clear();

            for (int i = 0; i < cities.Length; i++)
            {
                chart1.Series[1].Points.Add(new DataPoint(xCities[cities[i]], yCities[cities[i]]));
            }
            chart1.Invoke(new Action(Refresh));
        }


        public Dictionary<string, object> learnSA(double _stoppingCost, double _maxIteration, double _minimalTempreture, int iterationChecker, double momentumTempreture)
        {
            Dictionary<string, object> res = new Dictionary<string, object>();
            //create random basic solution... any random solution is acceptable;            
            solution = Vector.Create(xCities.Length, 0);
            for (int i = 0; i < solution.Length; i++)
                solution[i] = solution.Length - 1 - i;
            int[] tempSolution = Vector.Create(solution);
            int[] betterSolutoin = Vector.Create(solution);
            double basicCost = cost(solution), tempCost = int.MaxValue, betterSolutionCost = basicCost;
            bool hasFinished = false;
            int iter = 0;
            double tempreture = this.startingTempreture;
            Random randomGenerator = new Random(91);
            while (tempCost > _stoppingCost && iter < _maxIteration && tempreture > _minimalTempreture && !hasFinished)
            {
                tempSolution = switchCities(betterSolutoin, randomGenerator);
                tempCost = cost(tempSolution);
                double prob = getPropability(tempCost - basicCost, tempreture);
                double randProb = randomGenerator.Next(0, 10) / 10.0;
                randProb = Math.Sqrt(Math.Sqrt(Math.Sqrt(randProb)));
                if (randProb <= prob)
                {
                    //Console.WriteLine("get in probable changing with randProb of {0}, and probability is {1}...in iter:{2}", randProb, prob,iter);
                    tempSolution.CopyTo(betterSolutoin, 0);
                    betterSolutionCost = cost(betterSolutoin);
                    tempreture *= coolingConstant;
                    coolingConstant *= momentumTempreture;

                    Console.WriteLine("_______________");
                    Console.WriteLine("tempreture= {0}", tempreture);
                    Console.WriteLine("_______________");
                }
                iter++;
                if (tempCost < basicCost)
                {
                    betterSolutoin.CopyTo(solution, 0);
                    basicCost = betterSolutionCost;
                    drow_edges(solution);

                }
                if (iter % iterationChecker == 0)
                {
                    //if (basicCost == betterSolutionCost)
                    //    hasFinished = true;
                    if (betterSolutionCost < basicCost)
                    {
                        betterSolutoin.CopyTo(solution);
                        basicCost = betterSolutionCost;
                    }
                    //else
                    //{
                    //    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! SWAP !!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    //    betterSolutoin.CopyTo(solution);
                    //    basicCost = betterSolutionCost;
                    //}
                }
                Console.WriteLine("iteration {0}: having error of {1}. basic cost of {2}.", iter, tempCost - _stoppingCost, basicCost);
                radTextBox4.Text = tempCost.ToString();
                radTextBox5.Text = iter.ToString();
                
                for (int i = 0; i < tempSolution.Length; i++)
                    Console.Write("{0} ", tempSolution[i]);
                Console.WriteLine();
            }
            res.Add("solution", solution);
            res.Add("iterations", iter);
            res.Add("cost", basicCost);
            return res;
        }


    

        
   
    }
}