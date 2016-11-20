using System;
using System.Collections.Generic;
using LinearAlgebra;

namespace NeuronProject.classes {
    public class NeuronNetwork {

        #region constructors
        public NeuronNetwork(int neuronAmount, int inputRows, int inputCols) {
            if(neuronAmount <= 0 || inputRows <= 0 || inputCols <= 0) {
                throw new ArgumentException("init number is 0 or less");
            }
            this.neurons = new List<Neuron>();
            for(int i = 0; i < neuronAmount; i++) {
                neurons.Add(new Neuron(inputRows, inputCols));
            }
            Console.WriteLine("Init Network:\n" + this.ToString());
        }
        #endregion

        #region main methods
        public void study(Matrix learnInputs, Vector correctAnswer) {
            if(correctAnswer.length != neurons.Count) {
                throw new ArgumentException("vector len != neurons amount!");
            }
            Console.WriteLine("Study with:\nCorrect answer:" + correctAnswer.ToString());
            Console.WriteLine("LearnInputs:\n" + learnInputs.ToString());

            var answer = getFullAnswer(learnInputs);
            var numIteration = 1;
            while((answer - correctAnswer).norm() > 1) {
                Console.WriteLine("{0} study iteration: answer -> {1} correct answer-> {2}",
                    numIteration, answer.ToString(), correctAnswer.ToString());
                for(int i = 0; i < neurons.Count; i++) {
                    // neuron[i].weight = inputs * diff
                    //neurons[i].study(learnInputs, (double)(correctAnswer[i] - answer[i]));
                }
                answer = getFullAnswer(learnInputs);
                numIteration++;
            }
            Console.WriteLine("After Study:\n" + this.ToString());
        }
        public void study(Matrix learnInputs, int numberNeuron) {
            if(numberNeuron < 0 || numberNeuron > neurons.Count) {
                throw new ArgumentException("number is not correct");
            }
            learnInputs.normalize();
            Console.WriteLine("Study with:\n Neuron[{0}] is under studying:", numberNeuron);
            //Console.WriteLine("LearnInputs:\n" + learnInputs.ToString());
            var neuron = neurons[numberNeuron];
            var answer = neuron.getPower(learnInputs);
            var numIteration = 1;
            while(answer < precision) {
                Console.WriteLine("{0} study iteration: answer -> {1}", numIteration,
                    answer.ToString());
                neuron.study(learnInputs);
                answer = neuron.getPower(learnInputs);
                numIteration++;
            }
            neuron.normalizeWeigths();
        }
        public int getSingleAnswer(Matrix inputs) {
            var resultVector = getFullAnswer(inputs);
            var maxIndex = 0;
            for(int i = 0; i < resultVector.length; i++) {
                if(resultVector[i] > maxIndex) {
                    maxIndex = i;
                }
            }
            Console.WriteLine("Result Single Answer: neuron[{0}] wins!", maxIndex);
            return maxIndex;
        }
        public Vector getFullAnswer(Matrix inputs) {
            var resultVector = new Vector(neurons.Count);
            for(int i = 0; i < neurons.Count; i++) {
                resultVector[i] = neurons[i].getPower(inputs);
            }
            Console.WriteLine("Result Answer: {0}", resultVector.ToString());

            Console.WriteLine("Result answer:");
            Console.WriteLine("[{0}] - {1:0.00} %", 3, resultVector[0] * 100 / resultVector.norm());
            Console.WriteLine("[{0}] - {1:0.00} %", 7, resultVector[1] * 100 / resultVector.norm());
            return resultVector;
        }
        public Vector getFullAnswerHard(Matrix inputs) {
            var resultVector = new Vector(neurons.Count);
            for(int i = 0; i < neurons.Count; i++) {
                resultVector[i] = neurons[i].getPowerHard(inputs);
            }
            Console.WriteLine("Result Hard Answer: {0}", resultVector.ToString());
            return resultVector;
        }
        #endregion

        #region override object methods
        public override string ToString() {
            String info = "Network:\n";
            for(int i = 0; i < neurons.Count; i++) {
                info = String.Concat(info, "Neuron[" + i + "]: " + neurons[i].ToString() + "\n");
            }
            return info;
        }
        #endregion

        #region private fields
        private List<Neuron> neurons;
        private double precision = 0.92;
        #endregion
    }
}
