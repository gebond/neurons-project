using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuronProject.classes;

namespace NeuronTests
{
    [TestClass]
    public class NeuronUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void initTest()
        {
            var neuron = new Neuron(10);
            Assert.IsNotNull(neuron);
            neuron = new Neuron(-1);
        }
    }
   
}
