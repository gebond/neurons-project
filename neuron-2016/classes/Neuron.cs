using System;
using LinearAlgebra;

namespace NeuronProject.classes {
    public class Neuron {
        #region constructors
        public Neuron(int inputRows, int inputCols) {
            if(inputRows <= 0 || inputRows <= 0) {
                throw new ArgumentException("input lenght is 0 or less");
            }
            weights = new Matrix(inputRows, inputCols);
            weights.randomize();
            weights.normalize();
        }
        #endregion

        #region main methods
        public double getPower(Matrix inputs) {
            checkWeigth(inputs.Rows, inputs.Cols);
            double resultPower = 0;
            for(int i = 0; i < weights.Rows; i++) {
                for(int j = 0; j < weights.Cols; j++) {
                    resultPower += inputs[i, j] * weights[i, j];
                }
            }
            return resultPower;
        }
        public double getPowerHard(Matrix inputs) {
            var power = getPower(inputs);
            return (power > minimumPower) ? 1 : 0;
        }
        public void study(Matrix inputs) {
            checkWeigth(inputs.Rows, inputs.Cols);
            //Console.WriteLine("Weigths OLD is {0}", weights.ToString());
            for(int i = 0; i < weights.Rows; i++) {
                for(int j = 0; j < weights.Cols; j++) {
                    weights[i, j] += 0.5 * (inputs[i, j] - weights[i, j]);
                }
            }
            //Console.WriteLine("Weigths NEW is {0}", weights.ToString());
        }
        public void normalizeWeigths() {
            weights.normalize();
        }
        #endregion

        #region private methods
        private void checkWeigth(int rowsCount, int colsCount) {
            if(weights == null) {
                throw new ArgumentNullException("weigths are Empty!");
            }
            if(rowsCount != weights.Rows || colsCount != weights.Cols) {
                throw new ArgumentException("inputs len != weigths len!");
            }
        }
        #endregion

        #region override object methods
        public override string ToString() {
            var info = "neuron's weights:" + weights.ToString();
            return info;
        }
        #endregion

        #region private fields
        private Matrix weights;
        private static double minimumPower = 10;
        #endregion
    }
}
