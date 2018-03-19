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

namespace Exp.UWP.ContentDialogs
{
    public sealed partial class ContentDialogGrid : ContentDialog
    {
        public Page _page;

        public ContentDialogGrid(UIElement uiElement)
        {
            //this._page = page;
            this.MinWidth = Window.Current.Bounds.Width;
            this.MaxWidth = Window.Current.Bounds.Height;

            this.Content = uiElement;




            this.InitializeComponent();
            
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
