using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
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

        // tämä pitää kirjaa siitä mitä sivua viimeksi käytettiin
        // tätä hyödynnetään lähinnä siinä, että jos yritetään kaksi
        // kertaa navigoida samaan sivuun, jätetään se huomiotta
        private NavigationViewItem _lastItem;

        
        private string projectName = "Codes";

        // jotain painettiin valikosta, päätetään mitä tehdään
        private void NavigationView_OnItemInvoked(
            Windows.UI.Xaml.Controls.NavigationView sender,
            NavigationViewItemInvokedEventArgs args)
        {
            // haetaan klikattu NavigationViewItem
            var item = args.InvokedItemContainer as NavigationViewItem;

            // jos Itemiä ei löydy, jätetään pyyntö kesken
            if (item == null || item == _lastItem)
                return;

            // jos Itemistä ei löydy Tagia, oletuksena on silloin Settings
            // tässä tapauksessa settingsview on otettu pois käytöstä myös XAMLin puolella
            var clickedView = item.Tag?.ToString() ?? "SettingsView";

            // jos navigointi epäonnistuu, jätetään kesken
            if (!NavigateToView(clickedView)) return;

            _lastItem = item;
        }

        // suoritetaan varsinainen navigaatio, tätä kutsuu lähinnä
        // NavigationView_OnItemInvoked
        private bool NavigateToView(string clickedView)
        {
            // yritetään hakea sopiva sivu Views -kansiosta
            var view = System.Reflection.Assembly.GetExecutingAssembly()
                .GetType($"{projectName}.Views.{clickedView}");

            // jos haluttua sivua ei löydy, jätetään navigointi kesken
            if (string.IsNullOrWhiteSpace(clickedView) || view == null)
            {
                return false;
            }

            // navigoidaan valittu sivu ContentFrameen
            ContentFrame.Navigate(view, null, new EntranceNavigationTransitionInfo());
            return true;
        }

        // jos navigointi epäonnistuu, kaadetaan ohjelma
        private void ContentFrame_OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new NavigationException(
                $"Navigation failed {e.Exception.Message} for {e.SourcePageType.FullName}");
        }

        // käsitellään Back-painike => mennään edelliseen sivuun takaisin
        private void NavView_OnBackRequested(
            Windows.UI.Xaml.Controls.NavigationView sender,
            NavigationViewBackRequestedEventArgs args)
        {
            if (ContentFrame.CanGoBack)
                ContentFrame.GoBack();
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

        private void drkmd_Checked(object sender, RoutedEventArgs e)
        {// Laittaa applikaatioon Dark moden päälle
            if (Window.Current.Content is FrameworkElement frameworkElement)
            {
                frameworkElement.RequestedTheme = ElementTheme.Dark;
                drkmd.Content = "Light mode";
            }
        }

        private void drkmd_Unchecked(object sender, RoutedEventArgs e)
        {//laittaa applikaatioon Light moden päälle
            if (Window.Current.Content is FrameworkElement frameworkElement)
            {
                frameworkElement.RequestedTheme = ElementTheme.Light;
                drkmd.Content = "Dark mode";
            }
        }

        // oma poikkeustyyppi navigointiongelmille
        internal class NavigationException : Exception
        {
            public NavigationException(string msg) : base(msg)
            {

            }
        }
    }
}
