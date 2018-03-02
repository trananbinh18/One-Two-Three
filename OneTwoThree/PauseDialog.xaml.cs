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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OneTwoThree
{
    public enum MyResult
    {
        Home,
        Back,
        Restart,
        Nothing
    }

    public sealed partial class PauseDialog : ContentDialog
    {
        public MyResult Result { get; set; }

        public PauseDialog()
        {
            this.InitializeComponent();
            this.Result = MyResult.Nothing;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            this.Result = MyResult.Restart;
            this.Hide();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Result = MyResult.Back;
            this.Hide();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            this.Result = MyResult.Home;
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Result = MyResult.Back;
            Hide();
        }
    }
}
