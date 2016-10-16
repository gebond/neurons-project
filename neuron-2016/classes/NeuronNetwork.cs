using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace neuron_2016.classes
{
    class NeuronNetwork
    {
        List<Neuron> neuronList;

        public NeuronNetwork(int neuronInitNumber)
        {
            if (neuronInitNumber <= 0)
            {
                throw new ArgumentException("init lenght is 0 or less");
            }

        }
    }
}
