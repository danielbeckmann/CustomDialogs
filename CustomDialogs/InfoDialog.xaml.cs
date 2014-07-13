using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Dialogs
{
    public sealed partial class InfoDialog : UserControl
    {
        // Popup control for displaying the dialog
        private Popup popup;

        // For async open/close operation
        private TaskCompletionSource<bool> taskCompletionSource;

        public InfoDialog(string content, string title)
        {
            this.InitializeComponent();

            this.TitleTextBlock.Text = title;
            this.ContentTextBlock.Text = content;
        }

        /// <summary>
        /// Opens the dialog.
        /// </summary>
        public Task<bool> ShowAsync()
        {
            this.taskCompletionSource = new TaskCompletionSource<bool>();
            this.CreateDialog();

            return this.taskCompletionSource.Task;
        }

        // Create a popup control and set content
        private void CreateDialog()
        {
            this.Height = Window.Current.Bounds.Height;
            this.Width = Window.Current.Bounds.Width;

            this.popup = new Popup();
            this.popup.Child = this;

            HardwareButtons.BackPressed += HardwareButtons_BackPressed;

            this.popup.IsOpen = true;
        }

        // Event handler for back button
        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
            if (this.popup.IsOpen)
            {
                this.Close(false);
                e.Handled = true;
            }
        }

        private void OKButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Close(true);
        }

        private void CancelButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Close(false);
        }

        // Closes the dialog
        private void Close(bool success)
        {
            HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
            this.popup.IsOpen = false;

            if (this.taskCompletionSource != null)
            {
                this.taskCompletionSource.SetResult(success);
            }
        }
    }
}
