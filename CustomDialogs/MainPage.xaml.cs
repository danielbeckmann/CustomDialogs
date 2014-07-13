using Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=391641 dokumentiert.

namespace CustomDialogs
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet werden kann oder auf die innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Hier steht die Nachricht", "Titel");
            var result = await dialog.ShowAsync();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var dialog = new InfoDialog("Hier steht die Nachricht", "Titel");
            var result = await dialog.ShowAsync();
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var dialog = new InputDialog("Bitte geben Sie etwas ein", "Titel");
            var result = await dialog.ShowAsync();

            if (!string.IsNullOrEmpty(result))
            {
                Debug.WriteLine(result);
            }
        }
    }
}
