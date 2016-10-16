using System;
using ImageModule;
using NeuronProject.classes;

namespace NeuronProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start");
            // var imgReader = new ImageReader();
            //imgReader.tryToRead();

            int inputLength = 10;
            int neuronLenght = 2;
            Input[] inputs = new Input[10];
            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i] = new Input(i);
            }
            
            
            var network = new NeuronNetwork(neuronLenght, inputLength);
            var answer = network.getAnswer(inputs);
            Console.WriteLine("Result Answer: {0}",answer.ToString());
            Console.ReadKey();
        }
    }
}
