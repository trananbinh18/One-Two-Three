using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OneTwoThree
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //Convert Default MediaElement to the static Element
        public static MediaElement MySong;
        public static ImageBrush IconMusic = new ImageBrush();
        //Value to see the Music isPlaying
        public static bool isPlayingMusic = true;
        public MainPage()
        {
            this.InitializeComponent();
            MySong = MusicSong;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Frame.BackStack.Clear();
            if (isPlayingMusic)
            {
                IconMusic.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Image/Music.png"));
                btnMusic.Background = IconMusic;
                MySong.AutoPlay = true;
                MySong.Play();
            }
            else {
                IconMusic.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Image/IC_Mute.png"));
                btnMusic.Background = IconMusic;
                MySong.Pause();
            }
        }

        //Jump into HintPage
        private void btnHint_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HintPage));
        }

        //Jump into HighScorePage
        private void btnHighScore_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HighScorePage));
        }

        //On or Off Music when Click button
        private void btnMusic_Click(object sender, RoutedEventArgs e)
        {
            if (isPlayingMusic== true)
            {
                IconMusic.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Image/IC_Mute.png"));
                btnMusic.Background = IconMusic;
                isPlayingMusic = false;
                MySong.Pause();
            }
            else {
                IconMusic.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Image/Music.png"));
                btnMusic.Background = IconMusic;
                isPlayingMusic = true;
                MySong.Play();
            }
            
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PlayingPage));
        }

        private void btnAboutUs_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
