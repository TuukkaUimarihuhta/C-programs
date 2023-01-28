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
        // First number
        double firstNumber = 0;

        // Operator, which decide the operation
        char operation;

        // what is shown in the screen
        string output = "";
        public Calculator()
        {
            this.InitializeComponent();

            this.DataContext = this;
        }

        // Function where you add numbers and a decimal point into a number
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            string added = ((Button)sender).Name;

            // switch statement which is used to add number into the output, allowing you to make multiple digit numbers
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

        // Function for adding numbers
        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                // firstNumber becomes the number on screen
                firstNumber = double.Parse(output);
                // Output becomes blank
                output = "";
                // Operation changes to plus
                operation = '+';
            }
        }

        // Function for subtracting numbers
        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            if(output != "")
            {
                // firstNumber becomes the number on screen
                firstNumber = double.Parse(output);
                // Output becomes blank
                output = "";
                // Operation changes to minus
                operation = '-';
            }
        }

        // Function for multiplying numbers
        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                // firstNumber becomes the number on screen
                firstNumber = double.Parse(output);
                // Output becomes blank
                output = "";
                // Operation changes to multiply
                operation = '*';
            }
        }

        // Function for Dividing numbers
        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                // firstNumber becomes the number on screen
                firstNumber = double.Parse(output);
                // Output becomes blank
                output = "";
                // Operation changes to divide
                operation = '/';
            }
        }

        // Function that does a certain operation based on the chosen operator, called when = button is pressed
        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            // variable for finished number
            double outputNum;

            // Case chosen based on the used operator
            switch (operation)
            {
                case '+':
                    outputNum = firstNumber + double.Parse(output);
                    output = outputNum.ToString();
                    calcText.Text = output;
                    break;
                case '-':
                    outputNum = firstNumber - double.Parse(output);
                    output = outputNum.ToString();
                    calcText.Text = output;
                    break;
                case '*':
                    outputNum = firstNumber * double.Parse(output);
                    output = outputNum.ToString();
                    calcText.Text = output;
                    break;
                case '/':
                    if(double.Parse(output) != 0)
                    {
                        outputNum = firstNumber / double.Parse(output);
                        output = outputNum.ToString();
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


        // Function for "clear" button
        private void C_Click(object sender, RoutedEventArgs e)
        {
            output = "";

            calcText.Text = output;
        }

        // Function for squared
        private void sqrBtn_Click(object sender, RoutedEventArgs e)
        {
            // Variable that takes output as a number
            double squared = double.Parse(output);

            // output changes to squared times itself
            output = (squared * squared).ToString();

            // Textbox text changed into output
            calcText.Text = output;
        }

        // Function for square root
        private void rootBtn_Click(object sender, RoutedEventArgs e)
        {
            if(output != "")
            {
                // variable for output into number
                double root = double.Parse(output);
                // Using Math.sqrt to get a square root of root as string
                output = Math.Sqrt(root).ToString();
                // Textbox text show output
                calcText.Text = output;
            }
        }
    }
}
