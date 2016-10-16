using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinearAlgebra;

namespace NeuronProject.classes
{
    public class NeuronNetwork
    {
        List<Neuron> neuronList;

        public NeuronNetwork(int neuronInitNumber, int inputInitNumber)
        {
            if (neuronInitNumber <= 0 || inputInitNumber <= 0)
            {
                throw new ArgumentException("init lenght is 0 or less");
            }
            neuronList = new List<Neuron>();
            for (int i = 0; i < neuronInitNumber; i++)
            {
                neuronList.Add(new Neuron(inputInitNumber));
            }
        }

        public Vector getAnswer(Input[] inputs)
        {
            var resultVector = new Vector(neuronList.Count);
            for (int i = 0; i < neuronList.Count; i++)
            {
                resultVector[i] = neuronList[i].getPower(inputs);
            }
            return resultVector;
        }

        public override string ToString()
        {
            String info = "Network:";
            for (int i = 0; i < neuronList.Count; i++)
            {
                //info.Concat<String>();
            }
            return info;
        }

    }
}
