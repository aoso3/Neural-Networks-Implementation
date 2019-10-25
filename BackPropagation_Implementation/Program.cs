using System;
using System.Linq;
using System.Windows.Forms;
using BackPropagation_Implementation;
using Accord.Math;
using System.Collections.Generic;
using BackPropagation_Implementation.NN_Forms;

namespace BackPropagation_Implementation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //double[] x = Vector.Create(new double[] {
            //    20833.3333,
            //    20900.0000 ,
            //    21300.0000 ,
            //    21600.0000 ,
            //    21600.0000 ,
            //    21600.0000 ,
            //    22183.3333 ,
            //    22583.3333 ,
            //    22683.3333 ,
            //    23616.6667 ,
            //    23700.0000,
            //    23883.3333,
            //    24166.6667,
            //    25149.1667,
            //    26133.3333,
            //    26150.0000,
            //    26283.3333,
            //    26433.3333,
            //    26550.0000,
            //    26733.3333,
            //    27026.1111,
            //    27096.1111,
            //    27153.6111,
            //    27166.6667,
            //    27233.3333,
            //    27233.3333,
            //    27266.6667,
            //    27433.3333,
            //    27462.5000});
            ///*
            //,
            //    1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            //    2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
            //    3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
            //    4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
            //    5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            //    6, 6, 6, 6, 6, 6, 6, 6, 6, 6,
            //    7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
            //    8, 8, 8, 8, 8, 8, 8, 8, 8, 8,
            //    9, 9, 9, 9, 9, 9, 9, 9, 9, 9
            //*/
            //double[] y = Vector.Create(new double[] {
            //    17100.0000,
            //    17066.6667 ,
            //    13016.6667 ,
            //    14150.0000 ,
            //    14966.6667 ,
            //    16500.0000 ,
            //    13133.3333 ,
            //    14300.0000 ,
            //    12716.6667 ,
            //    15866.6667 ,
            //    15933.3333,
            //    14533.3333,
            //    13250.0000,
            //    12365.8333,
            //    14500.0000,
            //    10550.0000,
            //    12766.6667,
            //    13433.3333,
            //    13850.0000,
            //    11683.3333,
            //    13051.9444,
            //    13415.8333,
            //    13203.3333,
            //    9833.3333,
            //    10450.0000,
            //    11783.3333,
            //    10383.3333,
            //    12400.0000,
            //    12992.2222});
            /*
            ,
                9, 8, 7, 6, 5, 4, 3, 2, 1, 0,
                0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
                9, 8, 7, 6, 5, 4, 3, 2, 1, 0,
                0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
                9, 8, 7, 6, 5, 4, 3, 2, 1, 0,
                0, 1, 2, 3, 4, 5, 6, 7, 8 ,9,
                9, 8, 7, 6, 5, 4, 3, 2, 1 ,0,
                0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
                9, 8, 7, 6, 5, 4, 3, 2, 1, 0
            */
            //SimulatedAnnealing res = new SimulatedAnnealing(x, y, 600000000, 0.8);
            //Dictionary<string, object> myres = res.learnSA(27601.1738, 2000000, 0, 100, 1);
            //Console.WriteLine("cost is {0}", myres["cost"]);
            //Console.WriteLine("with {0} iterations", myres["iterations"]);
            //int[] arrRes = (int[])myres["solution"];
            //for (int i = 0; i < arrRes.Length; i++)
            //    Console.Write("{0} ", arrRes[i]);
            ////////////gradient decent , our version...

            //double[,] input = Matrix.Create(3, 4, 0d);
            //input[0, 0] = 1;
            //input[0, 1] = 1;
            //input[0, 2] = 0;
            //input[0, 3] = 0;
            //input[1, 0] = 1;
            //input[1, 1] = 0;
            //input[1, 2] = 0;
            //input[1, 3] = 1;
            //input[2, 0] = 1;
            //input[2, 1] = 1;
            //input[2, 2] = 1;
            //input[2, 3] = 1;
            //double[,] oroutput = Matrix.Create(1, 4, 1d);
            //oroutput[0, 3] = 0;
            //double[,] andoutput = Matrix.Create(1, 4, 0d);
            //oroutput[0, 0] = 1;
            //neuralNetwork net = new neuralNetwork(input, oroutput, new int[] { 3}, new string[] { "logsig", "logsig", "purelin" });
            //net.init();

            //for (int i = 0; i < 5; i++)
            //{
            //   // net.train("traingd", "onLine");
            //    net.train("traingdm", "batch");
            //    net.init();
            //    double err = 0;
            //    for (int ii = 0; ii < input.GetLength(1); ii++)
            //        err += Math.Pow((net.eval(input.GetColumn(ii)).Subtract(oroutput.GetColumn(ii))[0]), 2);
            //    Console.WriteLine("before " + err);
            //    net.levenbergMarqardt();
            //    err = 0;
            //    for (int ii = 0; ii < input.GetLength(1); ii++)
            //        err += Math.Pow((net.eval(input.GetColumn(ii)).Subtract(oroutput.GetColumn(ii))[0]), 2);
            //    Console.WriteLine("after " + err);
            //    //Console.ReadKey();
            //}
            //Console.WriteLine(net.eval(input.GetColumn(0))[0]);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Intro());

           
            Console.ReadLine();
        }
    }
}