using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using LinearAlgebra;


namespace ImageModule {
    public class ImageReader {

        #region initialize
        public ImageReader() {
            img3 = Properties.Resources._image_3;
            img7 = Properties.Resources._image_7;
            img3edited = Properties.Resources._3changed;
            checkImgNotNull();
        }
        #endregion

        #region main methods
        public Matrix getInput(int number) {
            var image = getBitMap(number);
            var result = new Matrix(image.Height, image.Width);
            for(int j = 0; j < image.Width; j++) {
                for(int i = 0; i < image.Height; i++) {
                    var pixel = image.GetPixel(i, j);
                    if(pixel.R == 0 && pixel.B == 0 && pixel.G == 0) {
                        result[i, j] = 0;
                    }
                    else {
                        result[i, j] = 1;
                    }
                }
            }
            return result;
        }
        public Matrix getInputChanged(int number) {
            var image = getBitMapChanged(number);
            var result = new Matrix(image.Height, image.Width);
            for(int j = 0; j < image.Width; j++) {
                for(int i = 0; i < image.Height; i++) {
                    var pixel = image.GetPixel(i, j);
                    if(pixel.R == 0 && pixel.B == 0 && pixel.G == 0) {
                        result[i, j] = 0;
                    }
                    else {
                        result[i, j] = 1;
                    }
                }
            }
            return result;
        }
        #endregion

        #region private methods
        private void checkImgNotNull() {
            if(img3 == null || img7 == null) {
                throw new ArgumentNullException("");
            }
        }

        private Bitmap getBitMap(int number) {
            Bitmap bitmap;
            switch(number) {
                case 3:
                    bitmap = img3;
                    break;
                case 7:
                    bitmap = img7;
                    break;
                default:
                    throw new ArgumentNullException("no bitmap for number {" + number + "}");
            }
            return bitmap;
        }
        private Bitmap getBitMapChanged(int number) {
            Bitmap bitmap;
            switch(number) {
                case 3:
                    bitmap = img3edited;
                    break;
                case 7:
                    bitmap = img7;
                    break;
                default:
                    throw new ArgumentNullException("no bitmap for number {" + number + "}");
            }
            return bitmap;
        }
        private void tryToRead() {
            Bitmap img = new Bitmap(Properties.Resources._image_3);
            Console.WriteLine("Bitmap created : {0} w and {1} h", img.Width, img.Height);
            for(int j = 0; j < img.Width; j++) {
                for(int i = 0; i < img.Height; i++) {
                    Color pixel = img.GetPixel(i, j);
                    if(pixel.R == 0 && pixel.B == 0 && pixel.G == 0) {
                        Console.Write("0");
                    }
                    else {
                        Console.Write("1");
                    }
                }
                Console.WriteLine("");
            }
        }
        private double[,] getInputMassive(int number) {
            Bitmap img;
            switch(number) {
                case 3:
                    img = img3;
                    break;
                case 7:
                    img = img7;
                    break;
                default:
                    img = img3;
                    break;
            }
            var resultMassive = new double[img.Height, img.Width];
            for(int j = 0; j < img.Width; j++) {
                for(int i = 0; i < img.Height; i++) {
                    Color pixel = img.GetPixel(i, j);
                    if(pixel.R == 0 && pixel.B == 0 && pixel.G == 0) {
                        Console.Write("0");
                        resultMassive[i, j] = 0;
                    }
                    else {
                        Console.Write("1");
                        resultMassive[i, j] = 1;
                    }
                }
                Console.WriteLine("");
            }
            return resultMassive;
        }
        #endregion

        #region private Fields
        private Bitmap img3;
        private Bitmap img7;
        private Bitmap img3edited;
        #endregion
    }
}
