using System;
using System.Collections;
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
        float runningTotal = 0;
        bool firstEquation = true;
        char currentState;

        public MainWindow()
        {
            InitializeComponent();
            textBox.IsReadOnly = true;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox.Text + "1";
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox.Text + "2";
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox.Text + "3";
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox.Text + "4";
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox.Text + "5";
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox.Text + "6";
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox.Text + "7";
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox.Text + "8";
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox.Text + "9";
        }

        private void button0_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox.Text + "0";
        }

        private void buttonDecimal_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox.Text + ".";
        }

        private void buttonDivide_Click(object sender, RoutedEventArgs e)
        {
            firstEquation = false;
            textBox.Text = textBox.Text + "/";
        }

        private void buttonMultiply_Click(object sender, RoutedEventArgs e)
        {
            firstEquation = false;
            textBox.Text = textBox.Text + "*";
        }

        private void buttonMinus_Click(object sender, RoutedEventArgs e)
        {
            firstEquation = false;
            textBox.Text = textBox.Text + "-";
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            firstEquation = false;
            textBox.Text = textBox.Text + "+";
            currentState = '+';
        }

        // This is where the magic happens. 
        private void buttonEquals_Click(object sender, RoutedEventArgs e)
        {

            switch (currentState)
            {
                case '+':
                    string[] splitString = textBox.Text.Split('+', '-', '*', '/');
                    float[] numbers = new float[2];
                    int i = splitString.Length;
                    // It's -1 because i = 2, but an array with 2 blocks is 0 and 1, 2 would be the third.
                    numbers[0] = Convert.ToInt32(splitString[i - 1]);
                    numbers[1] = Convert.ToInt32(splitString[i - 2]);
                    // Need to remove what the actual tally was otherwise it will do "10 + 3 = 13... 13 + 5 is equal to "13 + 13 + 5"
                    numbers[1] = numbers[1] - runningTotal;
                    // Should hopefully only add the last, and second to last numbers in the array. 

                    float newNum = (numbers[0] + numbers[1]);
                    runningTotal = runningTotal + newNum;
                    firstEquation = false;
                    break;
                default:
                    MessageBox.Show("Hey! This is appearing because you likely forgot to add in at least 2 numbers and 1 operator!");
                    break;

            }
            textBox.Text = "" + runningTotal;
        }
    }
}
