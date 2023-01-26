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
    public sealed partial class Calculator : Page
    {
        double temp = 0;

        char operation;

        string output = "";
        public Calculator()
        {
            this.InitializeComponent();

            this.DataContext = this;
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            string added = ((Button)sender).Name;

            switch (added)
            {
                case "oneBtn":
                    output += "1";
                    calcText.Text = output;
                    break;

                case "twoBtn":
                    output += "2";
                    calcText.Text = output;
                    break;

                case "threeBtn":
                    output += "3";
                    calcText.Text = output;
                    break;

                case "fourBtn":
                    output += "4";
                    calcText.Text = output;
                    break;

                case "fiveBtn":
                    output += "5";
                    calcText.Text = output;
                    break;

                case "sixBtn":
                    output += "6";
                    calcText.Text = output;
                    break;

                case "sevenBtn":
                    output += "7";
                    calcText.Text = output;
                    break;

                case "eightBtn":
                    output += "8";
                    calcText.Text = output;
                    break;

                case "nineBtn":
                    output += "9";
                    calcText.Text = output;
                    break;

                case "zeroBtn":
                    output += "0";
                    calcText.Text = output;
                    break;

                case "Decimal":
                    if (!output.Contains("."))
                    {
                        output += ".";
                        calcText.Text = output;
                    }
                    break;
            }
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                temp = double.Parse(output);

                output = "";

                operation = '+';
            }
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            if(output != "")
            {
                temp = double.Parse(output);

                output = "";

                operation = '-';
            }
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                temp = double.Parse(output);

                output = "";

                operation = '*';
            }
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                temp = double.Parse(output);

                output = "";

                operation = '/';
            }
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            double outputTemp;

            switch (operation)
            {
                case '+':
                    outputTemp = temp + double.Parse(output);
                    output = outputTemp.ToString();
                    calcText.Text = output;
                    break;
                case '-':
                    outputTemp = temp - double.Parse(output);
                    output = outputTemp.ToString();
                    calcText.Text = output;
                    break;
                case '*':
                    outputTemp = temp * double.Parse(output);
                    output = outputTemp.ToString();
                    calcText.Text = output;
                    break;
                case '/':
                    if(double.Parse(output) != 0)
                    {
                        outputTemp = temp / double.Parse(output);
                        output = outputTemp.ToString();
                        calcText.Text = output;
                    }
                    else
                    {
                        calcText.Text = "You can't divide by zero";
                    }
                    break;
                    
            }
        }

        private void PlusMinus_Click(object sender, RoutedEventArgs e)
        {
            output = (double.Parse(calcText.Text) * -1).ToString();

            calcText.Text = output;
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            output = "";

            calcText.Text = output;
        }

        private void sqrBtn_Click(object sender, RoutedEventArgs e)
        {
            double squared = double.Parse(output);

            output = (squared * squared).ToString();

            calcText.Text = output;
        }

        private void rootBtn_Click(object sender, RoutedEventArgs e)
        {
            if(output != "")
            {
                double root = double.Parse(output);

                output = Math.Sqrt(root).ToString();

                calcText.Text = output;
            }
        }
    }
}
