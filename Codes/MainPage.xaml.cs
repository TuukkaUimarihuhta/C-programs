using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Codes
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

        private async void exit_Click(object sender, RoutedEventArgs e)
        {
            // Nappi applikaation sammuttamista varten.
           const string Content = "Oletko varma, että haluat sulkea ohjelman?";
           const string Title = "Sammuta ohjelma";

            MessageDialog confirmDialog = new MessageDialog(Content, Title);
            confirmDialog.Commands.Add(new UICommand("Kyllä"));
            confirmDialog.Commands.Add(new UICommand("Ei"));
            var confirmResult = await confirmDialog.ShowAsync();

            if (confirmResult != null && confirmResult.Label == "Ei") { return; }

            if (confirmResult == null || confirmResult.Label == "Kyllä") { App.Current.Exit(); }
        }
    }
}
