﻿using System;
using ImageModule;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace neuron_2016
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start");
            var imgReader = new ImageReader();
            imgReader.tryToRead();
            Console.ReadKey();
        }
    }
}
