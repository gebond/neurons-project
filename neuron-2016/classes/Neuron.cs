using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace neuron_2016.classes
{
    class Neuron
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



    }
}
