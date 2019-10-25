using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Math;
namespace BackPropagation_Implementation
{
    class neuralNetwork
    {
        class funcs
        {
            static double logsig(double x)
         
            {
                return 1/(1+Math.Exp(-x));
            }
            static double dlogsig(double x)
            {
                return logsig(x)- Math.Pow(logsig(x),2);
            }

            static double purelin(double x)
            {
                return x;
            }
            static double dpurelin(double x)
            {
                return 1;
            }
            public static Func<double,double> get(String x)
            {
                if (x == "logsig")
                    return logsig;
                if (x == "dlogsig")
                    return dlogsig;
                if (x == "purelin")
                    return purelin;
                if (x == "dpurelin")
                    return dpurelin;
                else
                    return purelin;
            }
        }

        List<layer> layers;
        double [,] input, output;
        double [] inputAverage ;
        double [] inputcovariance;
        double covariance = 1, learningRate, mc = 0.5, targetError = .02, meoChange =10,meo=1000,curmeo;
        int patternCounter, fan_in/*input length */ , fan_out /*output length */, weightNum, maxEpoch = 1;
        int [] neurons;
        String[] _acfun;

        public void change_paramaters(double lr, double te,double mom=0.5)
        {
            learningRate = lr;
            targetError = te;
            mc = mom;
        }
        public void change_paramaters_levenberg(double lr, double te, double meoch,double meo_fac)
        {
            learningRate = lr;
            targetError = te;
            meoChange = meoch;
            meo = meo_fac;
        }

        public static double GetMax(double[,] arr, int colIndex)
        {
            return (from row in Enumerable.Range(0, arr.GetLength(0))
                    select arr[row, colIndex]).Max();
        }
        public double[,] get_class(double[,] test_data)
        {
            int row = test_data.GetLength(0);
            int col = test_data.GetLength(1);

            int[] c = Vector.Create(col,0);

            for (int i = 0; i < col; i++)
            {
                double max = GetMax(test_data, i);
                for (int j = 0; j < row; j++)
                {
                    if (test_data[j,i] == max)
                        c[i] = j;
                }
            }

            double[,] cls = Matrix.Create(row, col, 0d);

            for (int j = 0; j < col; j++) 
                cls[c[j],j] = 1;


            return cls;

        }

        public neuralNetwork(double [,] input,double [,] output,int [] neurons,String[] _acfun )
        {
            this.input = input;
            this.output = output;
            patternCounter = input.GetLength(1);
            fan_in = input.GetLength(0);
            fan_out = output.GetLength(0);
            layers = new List<layer>();
            learningRate = 0.02;
            this.neurons = neurons;
            inputAverage =  Vector.Create(fan_in,0d);
            inputcovariance = Vector.Create(fan_in, 0d);
            for (int i=0;i<patternCounter;i++)
            {
                inputAverage= inputAverage.Add(input.GetColumn(i).Divide(patternCounter));
                inputcovariance = inputcovariance.Add(Elementwise.Multiply(input.GetColumn(i), input.GetColumn(i)).Divide(patternCounter));
            }
            inputcovariance = inputcovariance.Subtract(Elementwise.Multiply(inputAverage, inputAverage));
            inputcovariance = inputcovariance.Apply((double l) => { return Math.Sqrt(l); });
            if(_acfun.Length<neurons.Length+1)
            {
                String[] temp = new string[neurons.Length + 1];
                for (int i =0; i < temp.Length; i++)
                    temp[i] = "purlin";
                _acfun.CopyTo(temp,0);
                _acfun = temp;   
            }
            this._acfun = _acfun;
        }
        public void init()
        {
            int last = fan_in;
            weightNum = 0;
            layers = new List<layer>();
            for (int i = 0; i < neurons.Length; i++)
            {
                layers.Add( new layer(Matrix.Random(neurons[i], last), funcs.get(_acfun[i]), funcs.get("d" + _acfun[i]),learningRate));
                weightNum += neurons[i] * last;
                last = neurons[i];
            }
            weightNum += fan_out * last;
            layers.Add(new layer(Matrix.Random( fan_out, last), funcs.get(_acfun[neurons.Length]), funcs.get("d" + _acfun[neurons.Length]),learningRate));
        }
        double [] traninput(double [] x)
        {
            return Elementwise.Divide(x.Subtract(inputAverage), inputcovariance).Multiply(covariance); ;
        }

        // output of the network
        public double [] eval(double [] x)
        {
            foreach(var l in layers)
            {   
                x = l.update(x).fneo();
            }
            return x;
        }
        layer lastLayer()
        {
            return layers[layers.Count - 1];
        }
        public void train(string learningMethod,string learningQuantity)
        {
            if (learningQuantity== "onLine")
                trainOnLine(learningMethod);
            if (learningQuantity == "batch")
                trainBatch(learningMethod);                
        }

        // change weights only one time after training
        public void trainBatch(String learningAlgo)
        {
            for (int i = 0; i < patternCounter; i++)
            {
                var sample = (input.GetColumn(i));
                var target = output.GetColumn(i);
                if(learningAlgo=="traingd")
                    traingd(target, sample);
                if (learningAlgo == "traingdm")
                    traingdm(target, sample);               
            }
            updateWeight();
        }

        // change weights on everty patterns
        public void trainOnLine(string learningAlgo)           
        {           
            for (int i= 0;i< patternCounter;i++)
            {
               
                var sample = (input.GetColumn(i));
                var target=output.GetColumn(i);     
                if (learningAlgo == "traingd")
                    traingd(target, sample);
                if (learningAlgo == "traingdm")
                    traingdm(target, sample); 
                updateWeight();
            
            }
        }
        private void updateWeight()
        {
            foreach(var l in layers)
            {
                l.updateWeight();
            }
        }
        public void traingd(double [] target,double [] current)
        {
            var res = eval(current);
            var lastdelta =Elementwise.Multiply(target.Subtract(res), lastLayer().gneo());
            lastLayer().addWeightDelta(lastdelta.Outer(layers[layers.Count - 2].fneo()).Multiply(learningRate));
            for(int j=layers.Count-2;j>0;j--)
            {
                var delta = Elementwise.Multiply(layers[j + 1].weights.Transpose().Dot(lastdelta), layers[j].gneo());            
                layers[j].addWeightDelta(delta.Outer(layers[j - 1].fneo()).Multiply( learningRate));
                lastdelta =delta;
            }
            var delta2 = Elementwise.Multiply(layers[ 1].weights.Transpose().Dot(lastdelta), layers[0].gneo());
            layers[0].addWeightDelta(delta2.Outer(current).Multiply(learningRate));
        }
        public void traingdm(double[] target, double[] current)
        {
            var res = eval(current);
            var lastdelta = Elementwise.Multiply(target.Subtract(res), lastLayer().gneo());
            lastLayer().addWeightDelta(lastdelta.Outer(layers[layers.Count - 2].fneo()).Add(lastLayer().lastUpdate.Multiply(mc)).Multiply(learningRate));
            for (int j = layers.Count - 2; j > 0; j--)
            {
                var delta = Elementwise.Multiply(layers[j + 1].weights.Transpose().Dot(lastdelta), layers[j].gneo());
                layers[j].addWeightDelta(delta.Outer(layers[j - 1].fneo()).Add(layers[j].lastUpdate.Multiply(mc)).Multiply(learningRate));
                lastdelta = delta;
            }
            var delta2 = Elementwise.Multiply(layers[1].weights.Transpose().Dot(lastdelta), layers[0].gneo());
            layers[0].addWeightDelta(delta2.Outer(current).Add(layers[0].lastUpdate.Multiply(mc)).Multiply(learningRate));
        }
        // return jacobi and error in  every pattern
        public Tuple <double[,],double[]> jacobi()
        {
            double[,] j = Matrix.Create(patternCounter, weightNum, 0d);
            double [] err=Vector.Create(patternCounter,0d);
            for (int i = 0; i < patternCounter; i++)
            {
                var sample = (input.GetColumn(i));
                var target = output.GetColumn(i);
                var gr=gradient(target, sample);
                err[i] =Math.Sqrt(Norm.Euclidean(lastLayer().fneo().Subtract(target))) ;
                j.SetRow(i,gr);

            }

            return new Tuple<double[,], double[]>(j, err);
        }

        // network output for levenberg
        private double [] evallm(double [] x)
        {
            foreach(var l in layers)
            {   
                x = l.lmupdate(x).fneo();
            }
            return x;
        }
        public double[] gradient(double[] target, double[] current)
        {
            double[] gr = Vector.Create(weightNum,0d);
            int pr = weightNum - 1;
            var res = eval(current);
            var lastdelta = Elementwise.Multiply(target.Subtract(res), lastLayer().gneo());
            var err = 2*Math.Sqrt(Norm.Euclidean(target.Subtract(res)));
            double [,] wd=lastdelta.Outer(layers[layers.Count - 2].fneo()).Divide(err);
            for(int i=wd.GetLength(0)-1;i>=0;i--)
                for(int j=wd.GetLength(1)-1;j>=0;j--)
                    gr[pr--]=wd[i,j];
            for (int j = layers.Count - 2; j > 0; j--)
            {
                var delta = Elementwise.Multiply(layers[j + 1].weights.Transpose().Dot(lastdelta), layers[j].gneo());
                wd=lastdelta.Outer(layers[j-1].fneo()).Divide(err);
                for(int i=wd.GetLength(0)-1;i>=0;i--)
                    for(int jj=wd.GetLength(1)-1;jj>=0;jj--)
                    gr[pr--]=wd[i,jj];
                lastdelta = delta;
            }
            var delta2 = Elementwise.Multiply(layers[1].weights.Transpose().Dot(lastdelta), layers[0].gneo());
             wd=delta2.Outer(current).Divide(err);
            for(int i=wd.GetLength(0)-1;i>=0;i--)
                for(int j=wd.GetLength(1)-1;j>=0;j--)
                    gr[pr--]=wd[i,j];

            return gr;
        }

        
        double lmerr()
        {
            double err=0;
            for (int i = 0; i < patternCounter; i++)
            {
                var sample = (input.GetColumn(i));
                var target = output.GetColumn(i);
                err+=Math.Sqrt(Norm.Euclidean((evallm(sample).Subtract(target))));
            }
            return err;

        }
        private void initDelta()
        {
            foreach (var l in layers)
            {
                l.initDelta();
            }
        }
        private void updateDelta(double [] weightdelta)
        {
            int k = 0;
            foreach (var l in layers)
            {
                for (int i = 0 ; i <l.weightDelta.GetLength(0); i++)
                    for (int j = 0; j <l.weightDelta.GetLength(1); j++)
                        l.weightDelta[i,j] = weightdelta[k++];
            }
        }
        public void levenbergMarqardt()
        {
            int count =0;
            double currenterr=1e9;
            
            while (count++ < maxEpoch && currenterr>targetError)
            {
                
                for (int i = 0; i <10; i++)
                {
                    var t = jacobi();
                    var j = t.Item1;
                    var err = t.Item2;
                    currenterr =err.Sum();
                    var jt = j.Transpose();
                    var hesian = jt.Dot(j);
                    hesian = hesian.AddToDiagonal(meo);
                    //for (int l = 0; l < hesian.GetLength(0); l++)
                      //  hesian[l, l] -= hesian[l, l] * meo;
                    var hesian_1 = hesian.PseudoInverse();
                    var dw = hesian_1.Dot(jt.Dot(err));
                    updateDelta(dw);
                    var newerr = lmerr();
                    if (newerr <= currenterr)
                    {
                        updateWeight();
                        if (meo > 0.001)
                            meo /= meoChange;

                        Console.WriteLine(" good err : " + newerr);
                        break;
                    }
                    else
                    {
                        initDelta();
                        updateDelta(jt.Dot(err).Multiply(learningRate));
                        newerr = lmerr();
                        if (newerr < currenterr)
                            updateWeight();
                        else
                            initDelta();
                        if (meo < 1000)
                            meo *= meoChange;
                        Console.WriteLine("bad err : " + newerr);
                    }
                } 
                   

            }
        }
    }
}
