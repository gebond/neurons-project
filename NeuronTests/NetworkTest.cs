using System;
using NeuronProject.classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NeuronTests
{
    [TestClass]
    public class NeuroNetworkUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void initTest()
        {
            var neuron = new NeuronNetwork(10, 100);
            Assert.IsNotNull(neuron);
            neuron = new NeuronNetwork(-1, -10);
        }
    }
}
