using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuronProject.classes
{
    public class Neuron
    {
        int weigth_H; // height
        int weigth_W; // width
        double[,] weights;

        public Neuron(int inputHeigth, int inputWidth)
        {
            if(inputHeigth <= 0 || inputWidth <= 0)
            {
                throw new ArgumentException("input lenght is 0 or less");
            }
            // countInput - number of items using as Input Array
            weights = new double[inputHeigth, inputWidth];
        }
        

        public double getPower(Input[,] inputs) {
            double resultPower = 0;
            for (int i = 0; i < weigth_H; i++)
            {
                for (int j = 0; j < weigth_W; j++)
                {
                    resultPower += inputs[i,j].Value * weights[i,j];
                }
            }
            return resultPower;
        }

        public void study(Input[,] inputs, double difference)
        {
            if(inputs.Length != weights.Length)
            {
                throw new ArgumentException("inputs len != weigths len!");
            }
            if(weights == null)
            {
                throw new ArgumentNullException("weigths are Empty!");
            }
            for (int i = 0; i < weigth_H; i++)
            {
                for (int j = 0; j < weigth_W; j++)
                {
                    weights[i,j] += difference * inputs[i,j].Value;
                }
                
            }
        }

        public override string ToString()
        {
            var len = weights.Length;
            String info = " [" + len + "] weights: [";
            for (int i = 0; i < len-1; i++)
            {
                info = String.Concat(info, weights[i] + ", ");
            } 
            info = String.Concat(info, weights[len - 1] + "]");
            return info;
        }

    }
}
