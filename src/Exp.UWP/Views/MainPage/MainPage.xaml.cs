using Exp.UWP.Views.Login;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Exp.UWP.Views.MainPage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void NavigateToDestinationPage()
        {
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("buttonLogin", b_login);
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("loginText", t_loginText);
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("logo", image_logo);
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("image", city);
            Frame.Navigate(typeof(LoginPage));
        }

        private void b_login_Click(object sender, RoutedEventArgs e)
        {
            NavigateToDestinationPage();
        }
    }
}
