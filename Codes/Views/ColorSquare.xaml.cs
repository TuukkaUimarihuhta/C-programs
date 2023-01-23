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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Codes.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ColorSquare : Page
    {
        public ColorSquare()
        {
            this.InitializeComponent();
        }

        // Function to check when the combobox's selected item is changed
        private void cbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // variable for the selected combobox item
            ComboBoxItem cbi = cbox.SelectedItem as ComboBoxItem;
            // string variable that changes into the chosen combobox items content, that is given as string
            string squareTxt = cbi.Content as string;

            // Brush variable, that changes into the selected combobox items background
            Brush newSqrColor = cbi.Background;

            // Squares color, that changes into the newSqrColor variable
            bbox.Background = newSqrColor;

            // Text that is inside the square, changes into squareTxt variable
            colortxt.Text = squareTxt;

        }

    }
}
