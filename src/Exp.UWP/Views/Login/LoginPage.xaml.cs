using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Exp.UWP.Views.Login
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        Duration tempo = new Duration (TimeSpan.FromSeconds(10));
        public LoginPage()
        {
            this.InitializeComponent();
            myStoryboard.Begin();
      
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ConnectedAnimation imageAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("image");
            ConnectedAnimation rpAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("buttonLogin");
            ConnectedAnimation logoAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("logo");
            ConnectedAnimation loginTextAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("loginText");

            imageAnimation?.TryStart(cityDest);
            rpAnimation?.TryStart(rp_principal);
            logoAnimation?.TryStart(logoDest);
            loginTextAnimation?.TryStart(t_loginTextDest);

        }
    }
}
