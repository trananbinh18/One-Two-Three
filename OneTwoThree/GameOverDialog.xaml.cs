using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OneTwoThree
{
    public enum MyResult1
    {
        Home,
        Back,
        Restart,
        Nothing
    }
    public sealed partial class GameOverDialog : ContentDialog
    {
       
        public MyResult1 Result1 { get; set; }
        public GameOverDialog(int Score)
        {
            this.InitializeComponent();
            // IF have Score >= 3 print Lucky else unLucky
            if (Score >= 3)
            {
                imgDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/TODAYISYOURLUCKY.png"));
            }
            else {
                imgDisplay.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/TODAYNOTYOURLUCKY.png"));
            }
            imgDisplay.UpdateLayout();
            setScore(Score);
            this.Result1 = MyResult1.Nothing;
        }

        //Method to set Score On picture
        public void setScore(int score)
        {
            int ifirst = score / 10;
            int isecond = score % 10;
            ConvertNumberToImage.ConvertToImage(ifirst.ToString(), lblScore1);
            ConvertNumberToImage.ConvertToImage(isecond.ToString(),lblScore2);
            lblScore1.UpdateLayout();
            lblScore2.UpdateLayout();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            this.Result1 = MyResult1.Home;
            Hide();
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            this.Result1 = MyResult1.Restart;
            Hide();
        }
    }
}
