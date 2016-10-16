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

        public NeuronNetwork(int neuronInitNumber, int inputInitHeigth, int inputInitWidth)
        {
            if (neuronInitNumber <= 0 || inputInitHeigth <= 0 || inputInitWidth <= 0)
            {
                throw new ArgumentException("init lenght is 0 or less");
            }
            neuronList = new List<Neuron>();
            for (int i = 0; i < neuronInitNumber; i++)
            {
                neuronList.Add(new Neuron(inputInitHeigth, inputInitWidth));
            }
            Console.WriteLine("Init Network:\n" + this.ToString());
        }

        public void study(Input[,] learnInputs, Vector correctAnswer)
        {
            Console.WriteLine("Study with:");
            Console.WriteLine("Correct answer:" + correctAnswer.ToString());
            Console.Write("Inputs: [");
            for (int i = 0; i < ; i++)
            {
                for (int j = 0; j < length; j++)
                {

                }
                Console.Write(learnInputs[i].Value + ", ");
            }
            Console.WriteLine(learnInputs[learnInputs.Length - 1].Value + "]");
            var study_answer = getAnswer(learnInputs);
                for (int i = 0; i < neuronList.Count; i++)
                {
                    double diff = correctAnswer[i] - study_answer[i];
                    neuronList[i].study(learnInputs, diff);
                }
                Console.WriteLine("After Study:\n" + this.ToString());
        }

        public Vector getAnswer(Input[,] inputs)
        {
            var resultVector = new Vector(neuronList.Count);
            for (int i = 0; i < neuronList.Count; i++)
            {
                resultVector[i] = neuronList[i].getPower(inputs);
            }

            Console.WriteLine("Result Answer: {0}", resultVector.ToString());
            return resultVector;
        }
        public override string ToString()
        {
            String info = "Network:\n";
            for (int i = 0; i < neuronList.Count; i++)
            {
                info = String.Concat(info, "Neuron[" + i + "] with" + neuronList[i].ToString() + "\n");
            }
            return info;
        }

    }
}
