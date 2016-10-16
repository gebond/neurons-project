using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuronProject.classes
{
    public class Input
    {
        double value;

        public Input(double value)
        {
            value = 1;
        }

        public double Value
        {
            get{ return value; }
        }
    }
}
