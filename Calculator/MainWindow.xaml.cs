using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public decimal firstNumber;
        public decimal secondNumber;
        public string input = "";
        public bool dotCheck = true;
        public bool checkMinusPlus = true;
        public decimal result;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void NumberButtonOperation(string number)
        {
            if (input.Length <= 27)
            {
                input += number;
                line.Text = input;
            }
        }
        private void SimpleOperation(string sign)
        {
            if (checkMinusPlus)
            {
                if (result != 0 && input == "")
                {
                    firstNumber = result;
                }
                else if (input == "")
                {
                    firstNumber = 0;
                }
                else if (input == ",")
                {
                    firstNumber = 0;
                }
                else
                {
                    firstNumber = Convert.ToDecimal(input);
                }
                checkMinusPlus = false;
                secondLine.Text = $"{firstNumber} {sign}";
                input = "";
                line.Text = input;
            }
            else
            {
                secondLine.Text = $"{firstNumber} {sign}";
            }
            dotCheck = true;
        }
        private void _7_Click(object sender, RoutedEventArgs e)
        {
            NumberButtonOperation("7");
        }
        private void _8_Click(object sender, RoutedEventArgs e)
        {
            NumberButtonOperation("8");
        }
        private void _9_Click(object sender, RoutedEventArgs e)
        {
            NumberButtonOperation("9");
        }
        private void _4_Click(object sender, RoutedEventArgs e)
        {
            NumberButtonOperation("4");
        }
        private void _5_Click(object sender, RoutedEventArgs e)
        {
            NumberButtonOperation("5");
        }
        private void _6_Click(object sender, RoutedEventArgs e)
        {
            NumberButtonOperation("6");
        }
        private void _1_Click(object sender, RoutedEventArgs e)
        {
            NumberButtonOperation("1");
        }
        private void _2_Click(object sender, RoutedEventArgs e)
        {
            NumberButtonOperation("2");
        }
        private void _3_Click(object sender, RoutedEventArgs e)
        {
            NumberButtonOperation("3");
        }
        private void _0_Click(object sender, RoutedEventArgs e)
        {
            NumberButtonOperation("0");
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            input = "";
            secondNumber = 0;
            firstNumber = 0;
            result = 0;
            secondLine.Text = input;
            line.Text = input;
            checkMinusPlus = true;
            dotCheck = true;
        }
        private void dot_Click(object sender, RoutedEventArgs e)
        {
            if (dotCheck)
            {
                input += ",";
                line.Text = input;
                dotCheck= false;
            }
        }
        private void plus_Click(object sender, RoutedEventArgs e)
        {
            SimpleOperation("+");
        }
        private void minus_Click(object sender, RoutedEventArgs e)
        {
            SimpleOperation("-");
        }
        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            SimpleOperation("*");
        }
        private void percent_Click(object sender, RoutedEventArgs e)
        {
            SimpleOperation("% of");
        }
        private void division_Click(object sender, RoutedEventArgs e)
        {
            SimpleOperation("/");
        }
        private void degree_Click(object sender, RoutedEventArgs e)
        {
            SimpleOperation("^");
        }
        private void square_Click(object sender, RoutedEventArgs e)
        {
            if (result != 0 && input == "")
            {
                firstNumber = result;
                result = (decimal)Math.Sqrt((double)firstNumber);
                secondLine.Text = Convert.ToString(result);
            }
            else if (input == "")
            {

                result = 0;
                secondLine.Text = Convert.ToString(result);
            }
            else
            {
                firstNumber= Convert.ToDecimal(input);
                result = (decimal)Math.Sqrt((double)firstNumber);
                secondLine.Text = Convert.ToString(result);
            }
            input = "";
            secondNumber = 0;
            firstNumber = 0;
            line.Text = input;
            checkMinusPlus = true;
            dotCheck = true;
        }
        private void equal_Click(object sender, RoutedEventArgs e)
        {
            Decimal.TryParse(input, out secondNumber);
            string act = $"{secondNumber} {secondLine.Text}";
            if (act.Contains('/'))
            {
                if(secondNumber == 0)
                {
                    result = 1337;
                    secondLine.Text = $"{result}";
                }
                else
                {
                    result = firstNumber / secondNumber;
                    secondLine.Text = $"{result}";
                }
            }
            else if (act.Contains('*'))
            {
                result = firstNumber * secondNumber;
                secondLine.Text = $"{result}";
            }
            else if (act.Contains('+'))
            {
                result = firstNumber + secondNumber;
                secondLine.Text = $"{result}";
            }
            else if (act.Contains('-'))
            {
                result = firstNumber - secondNumber;
                secondLine.Text = $"{result}";
            }
            else if (act.Contains('%'))
            {
                result = firstNumber / 100 * secondNumber;
                secondLine.Text = $"{result}";
            }
            else if (act.Contains('^'))
            {
                result = (decimal)Math.Pow((double)firstNumber, (double)secondNumber);
                secondLine.Text = $"{result}";
            }
            else
            {
                Decimal.TryParse(input, out firstNumber);
                result = firstNumber;
                secondLine.Text = $"{result}";
            }
            input = "";
            secondNumber = 0;
            firstNumber = 0;
            line.Text = input;
            checkMinusPlus = true;
            dotCheck = true;
        }
    }
}
