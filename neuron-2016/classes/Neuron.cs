using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuronProject.classes
{
    public class Neuron
    {
        int power;
        double[] weights;

        public Neuron(int countInput)
        {
            if(countInput<=0)
            {
                throw new ArgumentException("input lenght is 0 or less");
            }
            // countInput - number of items using as Input Array
            weights = new double[countInput];
            power = 0;
        }
        

        public double getPower(Input[] inputs) {
            double resultPower = 0;
            for (int i = 0; i < inputs.Length; i++)
            {
                resultPower += inputs[i].Value * weights[i];
            }
            return resultPower;
        }

        public override string ToString()
        {
            String info = " weights: [" + weights.ToString() + "]";
            return info;
        }

    }
}
