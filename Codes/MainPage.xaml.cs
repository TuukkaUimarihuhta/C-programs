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

        // this keeps track of which page was last accessed
        /* this is mainly used in that if the same page is attempted to navigate two times,
         the second time gets ignored  */
  
        private NavigationViewItem _lastItem;

        
        private string projectName = "Codes";

        // something was clicked from the menu, let's decide what to do
        private void NavigationView_OnItemInvoked(
            Windows.UI.Xaml.Controls.NavigationView sender,
            NavigationViewItemInvokedEventArgs args)
        {
            // the clicked NavigationViewItem is fetched
            var item = args.InvokedItemContainer as NavigationViewItem;

            // if Item is not found, query is left unfinished
            if (item == null || item == _lastItem)
                return;

            // if Item doesn't have a tag, default is Settings
            // settingsview has been taken off use in XAML as well
            var clickedView = item.Tag?.ToString() ?? "SettingsView";

            // if navigation fails, it is left unfinished
            if (!NavigateToView(clickedView)) return;

            // _lastItem gets the value of the item we clicked
            _lastItem = item;
        }

        // the actual navigation is performed, mostly called NavigationView_OnItemInvoked
        private bool NavigateToView(string clickedView)
        {
            // an attempt is made to retrieve a suitable page from the Views folder
            var view = System.Reflection.Assembly.GetExecutingAssembly()
                .GetType($"{projectName}.Views.{clickedView}");

            // if the desired page is not found, the navigation is left unfinished
            if (string.IsNullOrWhiteSpace(clickedView) || view == null)
            {
                return false;
            }

            // navigates the selected page to the ContentFrame
            ContentFrame.Navigate(view, null, new EntranceNavigationTransitionInfo());
            return true;
        }

        // if the navigation fails, the program crashes
        private void ContentFrame_OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new NavigationException(
                $"Navigation failed {e.Exception.Message} for {e.SourcePageType.FullName}");
        }

        // processed Back button => go back to the previous page
        private void NavView_OnBackRequested(
            Windows.UI.Xaml.Controls.NavigationView sender,
            NavigationViewBackRequestedEventArgs args)
        {
            if (ContentFrame.CanGoBack)
                ContentFrame.GoBack();
        }

        // button for turning off the application.
        private async void exit_Click(object sender, RoutedEventArgs e)
        {
            const string Content = "Are you sure you wanto close this app?";
            const string Title = "Close app";

            // creates a new dialog popup box with two variables
            MessageDialog confirmDialog = new MessageDialog(Content, Title);
            confirmDialog.Commands.Add(new UICommand("Yes"));
            confirmDialog.Commands.Add(new UICommand("No"));
            IUICommand confirmResult = await confirmDialog.ShowAsync();

            /* "No" button is pressed, dialogbox closes, app keeps running,
                pressing "Yes" will close the app*/
            switch (confirmResult.Label)
            {
                case "No":
                    return;
                case "Yes":
                    Application.Current.Exit();
                    break;
            }
        }

        // turn on Dark mode on in the application
        private void drkmd_Checked(object sender, RoutedEventArgs e)
        {
            if (Window.Current.Content is FrameworkElement frameworkElement)
            {
                frameworkElement.RequestedTheme = ElementTheme.Dark;  // changes the framework to dark ElementTheme
                drkmd.Content = "Light mode";                         // changes the dark mode button text to Light mode
            }
        }

        // turn Light mode on in the application
        private void drkmd_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Window.Current.Content is FrameworkElement frameworkElement)
            {
                frameworkElement.RequestedTheme = ElementTheme.Light; // changes the framework to light ElementTheme
                drkmd.Content = "Dark mode";                          // changes the dark mode button text to Dark mode
            }
        }

        // own exception type for navigation problems
        internal class NavigationException : Exception
        {
            public NavigationException(string msg) : base(msg)
            {

            }
        }
    }
}
