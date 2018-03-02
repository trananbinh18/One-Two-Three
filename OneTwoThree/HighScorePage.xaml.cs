using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OneTwoThree
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HighScorePage : Page
    {
        public HighScorePage()
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack) {
                Frame.GoBack();
            }
        }

        //On or Off when Click button music
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
