using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace ImageModule
{
    public class ImageReader
    {
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
    }
}
