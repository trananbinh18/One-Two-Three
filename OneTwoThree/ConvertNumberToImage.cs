using System;
using Windows.UI.Xaml.Media.Imaging;





namespace OneTwoThree
{
    // This class Convert String into Image
    public class ConvertNumberToImage
    {
        //Method Convert string To Image 
        public static void ConvertToImage(String sContent, Windows.UI.Xaml.Controls.Image img) {
            BitmapImage bmp;
            if (sContent == "GO!")
            {
                bmp = new BitmapImage(new Uri("ms-appx:///Assets/Image/Alphabet/GO!.png"));
                img.Source = bmp;
            }
            else if (sContent == "READY") {
                bmp = new BitmapImage(new Uri("ms-appx:///Assets/Image/Alphabet/READY.png"));
                img.Source = bmp;
            }
            else if (sContent == "LUCKY")
            {
                bmp = new BitmapImage(new Uri("ms-appx:///Assets/Image/Alphabet/LUCKY.png"));
                img.Source = bmp;
            }
            else if (sContent == "1")
            {
                bmp = new BitmapImage(new Uri("ms-appx:///Assets/Image/Alphabet/1.png"));
                img.Source = bmp;
            }
            else if (sContent == "2")
            {
                bmp = new BitmapImage(new Uri("ms-appx:///Assets/Image/Alphabet/2.png"));
                img.Source = bmp;
            }
            else if (sContent == "3")
            {
                bmp = new BitmapImage(new Uri("ms-appx:///Assets/Image/Alphabet/3.png"));
                img.Source = bmp;
            }
            else
            {
                bmp = TranlateToImage(sContent);
                img.Source = bmp;
            }
        }

        //Convert 1 number(Number is the String) into 1 BitmapImage
        public static BitmapImage TranlateToImage(string sNumber)
        {
            BitmapImage bmp = new BitmapImage();
            switch (sNumber)
            {
                case "0": bmp = new BitmapImage(new Uri("ms-appx:///Assets/Image/Alphabet/0.png"));
                    break;
                case "1": bmp = new BitmapImage(new Uri("ms-appx:///Assets/Image/Alphabet/1.png"));
                    break;
                case "2":
                    bmp = new BitmapImage(new Uri("ms-appx:///Assets/Image/Alphabet/2.png"));
                    break;
                case "3":
                    bmp = new BitmapImage(new Uri("ms-appx:///Assets/Image/Alphabet/3.png"));
                    break;
                case "4":
                    bmp = new BitmapImage(new Uri("ms-appx:///Assets/Image/Alphabet/4.png"));
                    break;
                case "5":
                    bmp = new BitmapImage(new Uri("ms-appx:///Assets/Image/Alphabet/5.png"));
                    break;
                case "6":
                    bmp = new BitmapImage(new Uri("ms-appx:///Assets/Image/Alphabet/6.png"));
                    break;
                case "7":
                    bmp = new BitmapImage(new Uri("ms-appx:///Assets/Image/Alphabet/7.png"));
                    break;
                case "8":
                    bmp = new BitmapImage(new Uri("ms-appx:///Assets/Image/Alphabet/8.png"));
                    break;
                case "9":
                    bmp = new BitmapImage(new Uri("ms-appx:///Assets/Image/Alphabet/9.png"));
                    break;
                default: break;

            }
            return bmp;
        }
    }
    
}
