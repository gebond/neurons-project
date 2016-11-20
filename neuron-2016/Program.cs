using System;
using ImageModule;
using NeuronProject.classes;
using LinearAlgebra;

namespace NeuronProject {
    public class Program {

        static void learn() {
            int inputH = 5;
            int inputW = 5;
            int neuronLenght = 2;
            // learn 1
            var inputs1 = new Matrix(inputH, inputW);
            for(int i = 0; i < inputs1.Rows; i++) {
                for(int j = 0; j < inputs1.Cols; j++) {
                    if(i <= j) {
                        inputs1[i, j] = 1;
                    }
                    else {
                        inputs1[i, j] = 0;
                    }
                }
            }
            var correctAnswer1 = new Vector(new double[] { 1.0, 0.0 });

            // learn 2 
            var inputs2 = new Matrix(inputH, inputW);
            for(int i = 0; i < inputs2.Rows; i++) {
                for(int j = 0; j < inputs2.Cols; j++) {
                    if(i > j) {
                        inputs2[i, j] = 1;
                    }
                    else {
                        inputs2[i, j] = 0;
                    }
                }
            }
            var correctAnswer2 = new Vector(new double[] { 0.0, 1.0 });


            var inputs3 = new Matrix(inputH, inputW);
            for(int i = 0; i < inputs3.Rows; i++) {
                for(int j = 0; j < inputs3.Cols; j++) {
                    if(i > j) {
                        inputs3[i, j] = 1;
                    }
                    else {
                        inputs3[i, j] = 0;
                    }
                }
            }
            inputs3[0, 0] = 1;
            inputs3[1, 1] = 1;
            inputs3[2, 1] = 0;

            var network = new NeuronNetwork(neuronLenght, inputH, inputW);
            network.study(inputs1, 0);
            network.study(inputs2, 1);
            var answer = network.getFullAnswer(inputs3);
            var answerTo4nyi = network.getSingleAnswer(inputs3);
        }
        static NeuronNetwork getNetworkWithLearning() {
            var reader = new ImageReader();
            var network = new NeuronNetwork(2, 45, 45);
            network.study(reader.getInput(3), 0);
            network.study(reader.getInput(7), 1);
            return network;
        }
        static void Main(string[] args) {
            var reader = new ImageReader();
            var network = getNetworkWithLearning();
            network.getFullAnswer(reader.getInputChanged(3));
            Console.ReadKey();
        }
    }
}
