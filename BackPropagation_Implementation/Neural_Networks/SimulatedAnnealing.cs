using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord;
using Accord.Math;


namespace BackPropagation_Implementation
{
    class SimulatedAnnealing
    {
        private double[,] distances;
        private double[] xCities, yCities;
        private int [] solution;
        private double startingTempreture,
                       coolingConstant;
        public SimulatedAnnealing(double[] _citiesXcords, double[] _citiesYcords, double _initialTempreture, double _coolingFactor)
        {
            this.xCities = Vector.Create(_citiesXcords.Length,0d);
            _citiesXcords.CopyTo(this.xCities, 0);
            
            this.yCities = Vector.Create(_citiesYcords.Length,0d);
            _citiesYcords.CopyTo(this.yCities, 0);            
            this.startingTempreture = _initialTempreture;
            this.coolingConstant = _coolingFactor;
            distances = Matrix.Create(xCities.Length, xCities.Length,0d);
            for (int i = 0; i < xCities.Length; i++)
                for (int j = 0; j < xCities.Length; j++)
                    distances[i, j] = getDistance(i, j);
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
                res += distances[tempSolution[0],tempSolution[1]];
                for (int i = 0; i < tempSolution.Length - 2; i++)
                    res += distances[tempSolution[i],tempSolution[i+1]];
                res += distances[tempSolution[tempSolution.Length-1], tempSolution[0]];
            
            return res;
        }
        private int[] switchCities(int [] _solution,Random r)
        {
            int[] tempSolution =Vector.Create(_solution.Length,0);
            _solution.CopyTo(tempSolution, 0);            
            int t1 = r.Next(0, tempSolution.Length - 1),
                t2 = r.Next(0, tempSolution.Length - 1);
            if (t1 != t2)
                tempSolution.Swap(t1, t2);
            else
                tempSolution.Swap(t1, r.Next(0, tempSolution.Length - 1));
            return tempSolution;
        }
        public Dictionary<string, object> learnSA(double _stoppingCost, double _maxIteration, double _minimalTempreture, int iterationChecker,double momentumTempreture)
        {
            Dictionary<string, object> res = new Dictionary<string, object>();
            //create random basic solution... any random solution is acceptable;            
            solution=Vector.Create(xCities.Length,0);
            for (int i = 0; i < solution.Length; i++)
                solution[i] = solution.Length-1-i;
            int[] tempSolution = Vector.Create(solution);
            int[] betterSolutoin = Vector.Create(solution);
            double basicCost = cost(solution),tempCost=int.MaxValue,betterSolutionCost=basicCost;
            bool hasFinished = false;
            int iter = 0;
            double tempreture = this.startingTempreture;
            Random randomGenerator = new Random(91);
            while(tempCost>_stoppingCost && iter<_maxIteration && tempreture>_minimalTempreture && !hasFinished)
            {
                tempSolution = switchCities(betterSolutoin,randomGenerator);
                tempCost = cost(tempSolution);
                double prob = getPropability(tempCost - betterSolutionCost, tempreture);
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
                    basicCost = betterSolutionCost ;
                }
                if (iter % iterationChecker == 0)
                {
                    if (basicCost == betterSolutionCost)
                        hasFinished = true;
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
                Console.WriteLine("iteration {0}: having error of {1}. basic cost of {2}.", iter, tempCost-_stoppingCost, basicCost);
                for (int i = 0; i < tempSolution.Length; i++)
                    Console.Write("{0} ", tempSolution[i]);
                Console.WriteLine();
                Console.ReadKey();
            }
            res.Add("solution", solution);
            res.Add("iterations", iter);
            res.Add("cost", basicCost);       
            return res;           
        }
    }
}
