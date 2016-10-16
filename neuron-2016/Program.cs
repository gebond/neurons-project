using System;
using ImageModule;
using NeuronProject.classes;
using LinearAlgebra;

namespace NeuronProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start");
            // var imgReader = new ImageReader();
            //imgReader.tryToRead();

            int inputH = 5;
            int inputW = 5;
            int neuronLenght = 2;
            // learn 1
            Input[,] inputs1 = new Input[5,5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i < (int)inputs1.Length / 2)
                    {
                        inputs1[i,j] = new Input(1);
                    }
                    else
                    {
                        inputs1[i,j] = new Input(0);
                    }
                }
            }
            Vector correctAnswer1 = new Vector(new double[]{1.0, 0.0});

            // learn 2 
            Input[,] inputs2 = new Input[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i < (int)inputs2.Length / 2)
                    {
                        inputs2[i, j] = new Input(1);
                    }
                    else
                    {
                        inputs2[i, j] = new Input(0);
                    }
                }
            }
            Vector correctAnswer2= new Vector(new double[] { 0.0, 1.0 });


            var network = new NeuronNetwork(neuronLenght, inputH, inputW);
            network.study(inputs1, correctAnswer1);
            network.study(inputs2, correctAnswer2);
            //var answer = network.getAnswer(inputs);
            Console.ReadKey();
        }
    }
}
