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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OneTwoThree
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HintPage : Page
    {
        
        public HintPage()
        {
            this.InitializeComponent();
            //Gain property into the Object MediaElement in this page
            MySong.Source = MainPage.MySong.Source;
            MySong.Position = MainPage.MySong.Position;
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (MainPage.isPlayingMusic)
            {
                MainPage.IconMusic.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Image/Music.png"));
                btnMusic.Background = MainPage.IconMusic;
                MySong.AutoPlay = true;
                MySong.Play();
            }
            else
            {
                MainPage.IconMusic.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Image/IC_Mute.png"));
                btnMusic.Background = MainPage.IconMusic;
                MySong.Pause();
            }
        }

        //Back to MainPage
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack) {
                Frame.GoBack();
            }
        }

        //On or Off Music When Click button
        private void btnMusic_Click(object sender, RoutedEventArgs e)
        {
            if (MainPage.isPlayingMusic == true)
            {
                MainPage.IconMusic.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Image/IC_Mute.png"));
                btnMusic.Background = MainPage.IconMusic;
                MainPage.isPlayingMusic = false;
                MySong.Pause();
            }
            else
            {
                MainPage.IconMusic.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Image/Music.png"));
                btnMusic.Background = MainPage.IconMusic;
                MainPage.isPlayingMusic = true;
                MySong.Play();
            }
        }
    }
}
