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
        double lastNumber, result;
        SelectedOperator selectedOperator;
        public MainWindow()
        {
          
            //event handlers
            InitializeComponent();
            acButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            percentageButton.Click += PercentageButton_Click;
            equalToButton.Click += EqualToButton_Click;
        }

        private void EqualToButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(labelResult.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                       result = SimpleMath.Subtract(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Division(lastNumber, newNumber);
                        break;
                }
                labelResult.Content = result.ToString();
                
            }
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(labelResult.Content.ToString(), out tempNumber))
            {
                tempNumber = (tempNumber / 100);
                if (lastNumber != 0)
                    tempNumber *= lastNumber;
                labelResult.Content = tempNumber.ToString();     
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(labelResult.Content.ToString(),out lastNumber)){
                lastNumber = lastNumber * -1;
                labelResult.Content = lastNumber.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            labelResult.Content = "0";
            result = 0;
            lastNumber = 0;
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(labelResult.Content.ToString(), out lastNumber))
            {

                labelResult.Content = "0";
            }

            if (sender == multiplyButton)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == divisionButton)
                selectedOperator = SelectedOperator.Division;
            if (sender == additionButton)
                selectedOperator = SelectedOperator.Addition;
            if (sender == subtractButton)
                selectedOperator = SelectedOperator.Subtraction;
        }
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;
            if (sender == zeroButton)
                selectedValue = 0;
            if (sender == oneButton)
                selectedValue = 1;
            if (sender == twoButton)
                selectedValue = 2;
            if (sender == threeButton)
                selectedValue = 3;
            if (sender == fourButton)
                selectedValue = 4;
            if (sender == fiveButton)
                selectedValue = 5;
            if (sender == sixButton)
                selectedValue = 6;
            if (sender == sevenButton)
                selectedValue = 7;
            if (sender == eightButton)
                selectedValue = 8;
            if (sender == nineButton)
                selectedValue = 9;
            if (labelResult.Content.ToString() == "0")
            {
                labelResult.Content = $"{selectedValue}";
            }
            else
            {
                labelResult.Content = $"{ labelResult.Content}{selectedValue}";
            }
        }
        public enum SelectedOperator
        {
            Addition,
            Subtraction,
            Multiplication,
            Division
        }

        private void dotButton_Click(object sender, RoutedEventArgs e)
        {
            if (labelResult.Content.ToString().Contains("."))
            {
                //do nothing
            }
            else
            {
                labelResult.Content = $"{ labelResult.Content}.";
            }
        }

        public class SimpleMath
        {
            public  static double Add(double n1, double n2)
            {
                return n1 + n2;
            }
            public static double Subtract(double n1, double n2)
            {
                return n1 - n2;
            }
            public static double Multiply(double n1, double n2)
            {
                return n1 * n2;
            }
            public static double Division(double n1, double n2)
            {
                if (n2 == 0)
                {
                    MessageBox.Show("Division by 0 is not supported", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                    return 0;
                }
                return n1 / n2;
            }
        }
    }
}
