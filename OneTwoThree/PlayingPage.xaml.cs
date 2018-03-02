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
using System.Threading;
using Windows.System.Threading;
using System.Diagnostics;
using System.ComponentModel;
using Windows.Graphics.Imaging;
using Windows.Storage;





// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OneTwoThree
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlayingPage : Page
    {
        //Result of Player
        int iPlayer;
        //Result of Ai if (0=One),(1=Two),(2=Three)
        int iAi;
        //Score of Player
        int Score = 0;
        Random rad = new Random();
        //If this is true player can make Gesture
        bool canAction = false;
        //value to count 1 2 3 Go!
        int ilblCenter = 0;
        //Timer playing game to count Ready 1 2 3 Go!
        DispatcherTimer timerPlaying;
        //Timer and value When Player Win a Game
        DispatcherTimer timerWin;
        int Count = 0;

        public PlayingPage()
        {

            this.InitializeComponent();
            //Assign property into the Object MediaElement in this page
            MySong.Source = MainPage.MySong.Source;
            MySong.Position = MainPage.MySong.Position;

            setScore(Score);
            timerPlaying = new DispatcherTimer();
            timerPlaying.Tick += timerPlaying_Tick;
            timerPlaying.Interval = new TimeSpan(0, 0, 1);
            timerPlaying.Start();

            timerWin = new DispatcherTimer();
            timerWin.Tick += timerWin_Tick;
            timerWin.Interval = new TimeSpan(0, 0, 1);

        }

        public void playShortMusic(int index)
        {
            if (MainPage.isPlayingMusic == true)
            {
                if (index == 0) // When win
                {
                    playShort.Source = new Uri("ms-appx:///Assets/Music/MS_clap.wav", UriKind.RelativeOrAbsolute);
                }
                else if (index == 1)
                { //count 1 2 3
                    playShort.Source = new Uri("ms-appx:///Assets/Music/MS_slap.mp3", UriKind.RelativeOrAbsolute);
                }
                else if (index == 2)//Score up
                {
                    playShort.Source = new Uri("ms-appx:///Assets/Music/MS_coin.wav", UriKind.RelativeOrAbsolute);
                }
                else if (index == 3)//GO!
                {
                    playShort.Source = new Uri("ms-appx:///Assets/Music/MS_go.wav", UriKind.RelativeOrAbsolute);
                }
                else if (index == 4)//Lose
                {
                    playShort.Source = new Uri("ms-appx:///Assets/Music/MS_laugh.mp3", UriKind.RelativeOrAbsolute);
                }
                playShort.Play();
            }
            


        }
        private void timerPlaying_Tick(object sender, object e)
        {
            switch (ilblCenter) {
                case 1:
                    ConvertNumberToImage.ConvertToImage("1", lblCenter);
                    playShortMusic(1);
                    break;
                case 2:
                    ConvertNumberToImage.ConvertToImage("2", lblCenter);
                    playShortMusic(1);
                    break;
                case 3:
                    ConvertNumberToImage.ConvertToImage("3", lblCenter);
                    playShortMusic(1);
                    break;
                case 4:
                    ConvertNumberToImage.ConvertToImage("GO!", lblCenter);
                    playShortMusic(3);
                    break;
            }
            lblCenter.UpdateLayout();
            ilblCenter++;
            if (ilblCenter == 5) {
                ilblCenter = 0;
                iAi = rad.Next(3);
                canAction = true;
                timerPlaying.Stop();
            }

        }

        //Timer Occur when player Win a match
        private void timerWin_Tick(object sender, object e) {
            if (Count == 0) {
                ConvertNumberToImage.ConvertToImage("LUCKY", lblCenter);
                playShortMusic(0);
            } else if (Count == 3) {
                ConvertNumberToImage.ConvertToImage("READY", lblCenter);
                PlayerPic.Source = null;
                PlayerPic.UpdateLayout();
                AiPic.Source = null;
                AiPic.UpdateLayout();
            }
            else if (Count == 4)
            {
                timerPlaying.Start();
                Count = 0;
                timerWin.Stop();
            }
            Count++;
        }


        //Method make Result of Player or AI to Picture on Screen
        public void setOneTwoThree(int index, Image img, bool isPlayer) //isPlayer to know that is a player or Ai
        {                                                             //index if 0 that is One ,1 that is Two,2 that is Three
            if (isPlayer == true)
            {
                if (index == 0)
                {
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/One.png"));
                }
                else if (index == 1)
                {
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Two.png"));
                }
                else if (index == 2)
                {
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/Three.png"));
                }
            }
            else {
                if (index == 0)
                {
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/OneA.png"));
                }
                else if (index == 1)
                {
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/TwoA.png"));
                }
                else if (index == 2)
                {
                    img.Source = new BitmapImage(new Uri("ms-appx:///Assets/Image/ThreeA.png"));
                }
            }



        }


        //Method to set Score On picture
        public void setScore(int score) {
            int ifirst = score / 10;
            int isecond = score % 10;
            ConvertNumberToImage.ConvertToImage(ifirst.ToString(), lblScore1);
            ConvertNumberToImage.ConvertToImage(isecond.ToString(), lblScore2);
            playShortMusic(2);
            lblScore1.UpdateLayout();
            lblScore2.UpdateLayout();
        }


        //When Navigated Page Playing Music or Not
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



        private void btnBao_Click(object sender, RoutedEventArgs e)
        {
            if (canAction == true)
            {
                //Player Pick Three
                iPlayer = 2;
                setOneTwoThree(iPlayer, PlayerPic, true);
                if (iAi == 0) //Compare With One Score + And Restart Game
                {
                    Score++;
                    setScore(Score);
                    timerWin.Start();
                } else if (iAi == 1) //Compare With Two
                {
                    //Lose
                    GameOver(Score);
                }
                else //Compare With Three Restart Game
                {
                    timerPlaying.Start();
                }
                //display a result of Ai
                setOneTwoThree(iAi, AiPic, false);
                AiPic.UpdateLayout();
                canAction = false;
            }
        }

        private void btnKeo_Click(object sender, RoutedEventArgs e)
        {

            if (canAction == true)
            {
                //Player Pick Two
                iPlayer = 1;
                setOneTwoThree(iPlayer, PlayerPic, true);
                if (iAi == 2)//Compare With Three Score + And Restart Game
                {
                    Score++;
                    setScore(Score);
                    timerWin.Start();
                }
                else if (iAi == 0) //Compare With One
                {
                    //Lose
                    GameOver(Score);
                }
                else // Compare With Two and Restart Game
                {
                    timerPlaying.Start();
                }
                //display a result of Ai
                setOneTwoThree(iAi, AiPic, false);
                AiPic.UpdateLayout();
                canAction = false;
            }
        }

        private void btnBua_Click(object sender, RoutedEventArgs e)
        {
            if (canAction == true)
            {
                //Player Pick One
                iPlayer = 0;
                setOneTwoThree(iPlayer, PlayerPic, true);
                if (iAi == 1) // Compare With Two  Score + And Restart Game
                {
                    Score++;
                    setScore(Score);
                    timerWin.Start();
                }
                else if (iAi == 2) // Compare With Three
                {
                    //Lose
                    GameOver(Score);
                }
                else {
                    timerPlaying.Start(); // Compare With One Restart Game
                }
                //display a result of Ai
                setOneTwoThree(iAi, AiPic, false);
                AiPic.UpdateLayout();
                canAction = false;
            }
        }

        //Method Occur When Game Over
        public async void GameOver(int Score) {
            timerWin.Stop();
            timerPlaying.Stop();
            playShortMusic(4);
            GameOverDialog gameOverDialog = new GameOverDialog(Score);
            await gameOverDialog.ShowAsync();
            if(gameOverDialog.Result1 == MyResult1.Home)
            {
                //Click button Home
                Frame.Navigate(typeof(MainPage));
            }
            else {
                //Click button Restart
                restartGame();
            }
        }

        private async void btnHome_Click(object sender, RoutedEventArgs e)
        {
            timerWin.Stop();
            timerPlaying.Stop();
            PauseDialog pauseDialog = new PauseDialog();
            await pauseDialog.ShowAsync();
            if (pauseDialog.Result == MyResult.Back)
            {
                timerWin.Start();
                timerPlaying.Start();
            }
            else if (pauseDialog.Result == MyResult.Home)
            {
                Frame.Navigate(typeof(MainPage));
            }
            else if (pauseDialog.Result == MyResult.Restart) {
                restartGame();
            }
        }


        //Method Restart Game
        public void restartGame(){
            Score = 0;
            setScore(Score);
            PlayerPic.Source = null;
            AiPic.Source = null;
            ConvertNumberToImage.ConvertToImage("READY", lblCenter);
            timerPlaying.Start();
            }
        }
    }
