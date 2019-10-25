using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Math;
namespace BackPropagation_Implementation
{
    class layer
    {
        
        public double [,] weights,weightDelta, lastUpdate;
        public Func<double, double> activateFun, dActivateFun;
        double [] output;
        double learningRate;
        public layer(double [,] weights,Func<double, double> activate,Func<double, double> dactivate,double lr)
        {
            this.activateFun = activate;
            this.dActivateFun = dactivate;
            this.weights = weights;
            learningRate = lr;
            weightDelta = Matrix.Create(weights.GetLength(0), weights.GetLength(1),0d);
            lastUpdate = Matrix.Create(weights.GetLength(0), weights.GetLength(1), 0d);
        }

        public layer update(double [] x)
        {
            output = weights.Dot(x);           
            return this;
        }
        // update levenberg
        public layer lmupdate(double[] x)
        {
            output = (weights.Add(weightDelta)).Dot(x);
            return this;
        }
        public void addWeightDelta(double [,] weights)
        {
            weightDelta=weightDelta.Add(weights);
        }
        public void updateWeight()
        {
            weights=weights.Add(weightDelta);
            lastUpdate = weightDelta;
            weightDelta = Matrix.Create(weights.GetLength(0), weights.GetLength(1), 0d);  
        }
        public void initDelta()
        {
            weightDelta = Matrix.Create(weights.GetLength(0), weights.GetLength(1), 0d);
        }

        // activation fun on output
        public double [] fneo()
        {
            return output.Apply((double v) => { return activateFun(v); });
        }

        // dactivation fun on output

        public double [] gneo()
        {
            return output.Apply((double v) => { return dActivateFun(v); });
        }
        public double [] activation()
        {
            return output;
        }
    }
}
