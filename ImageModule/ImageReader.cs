using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace ImageModule
{
    public class ImageReader
    {
        Bitmap img3;
        Bitmap img7;

        public ImageReader()
        {
            img3 = Properties.Resources._image_3;
            img7 = Properties.Resources._image_7;
        }
        public void tryToRead()
        {
            Bitmap img = new Bitmap(Properties.Resources._image_3);
            Console.WriteLine("Bitmap created : {0} w and {1} h", img.Width, img.Height);
            for (int j = 0; j < img.Width; j++)
            {
                for (int i = 0; i < img.Height; i++)
                {
                    Color pixel = img.GetPixel(i, j);
                    if (pixel.R == 0 && pixel.B == 0 && pixel.G == 0)
                    {
                        Console.Write("0");
                    }
                    else
                    {
                        Console.Write("1");
                    }
                }
                Console.WriteLine("");
            }
        }

        public double[,] getInputMassive(int number)
        {
            Bitmap img;
            switch(number)
            {
                case 3: img = img3; break;
                case 7: img = img7; break;
                default: img = img3; break;
            }
            var resultMassive = new double[img.Height, img.Width];
            for (int j = 0; j < img.Width; j++)
            {
                for (int i = 0; i < img.Height; i++)
                {
                    Color pixel = img.GetPixel(i, j);
                    if (pixel.R == 0 && pixel.B == 0 && pixel.G == 0)
                    {
                        Console.Write("0");
                        resultMassive[i, j] = 0;
                    }
                    else
                    {
                        Console.Write("1");
                        resultMassive[i, j] = 1;
                    }
                }
                Console.WriteLine("");
            }
            return resultMassive;
        }
    }
}
