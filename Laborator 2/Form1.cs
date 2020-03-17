using System;
using System.Windows.Forms;

namespace CalculatorStiintific
{
    public partial class Form1 : Form
    {
        private string MainText;

        public Form1()
        {
            InitializeComponent();
            MainText = "";
        }

        private void UpdateTextBox()
        {
            textBox1.Text = MainText;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainText += "1";
            UpdateTextBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainText += "2";
            UpdateTextBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainText += "3";
            UpdateTextBox();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainText += "4";
            UpdateTextBox();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainText += "5";
            UpdateTextBox();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MainText += "6";
            UpdateTextBox();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MainText += "7";
            UpdateTextBox();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MainText += "8";
            UpdateTextBox();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MainText += "9";
            UpdateTextBox();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MainText += "0";
            UpdateTextBox();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MainText += ".";
            UpdateTextBox();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MainText += " + ";
            UpdateTextBox();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MainText += " - ";
            UpdateTextBox();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MainText += " / ";
            UpdateTextBox();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MainText += " * ";
            UpdateTextBox();
        }

        private bool ErrorCheck_IsNotDouble(string token)
        {
            if (String.Equals(token, "+") || String.Equals(token, "-") || String.Equals(token, "*") ||
                String.Equals(token, "/") || String.Equals(token, "*"))
            {
                return true;
            }
            return false;
        }

        private bool ErrorCheck_IsNotSign(string token)
        {
            if (!String.Equals(token, "+") && !String.Equals(token, "-") && !String.Equals(token, "/") &&
                !String.Equals(token, "*") && !String.Equals(token, "="))
            {
                return true;
            }
            return false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string[] equationTokens = MainText.Split(new char[1] { ' ' });
            double result = 0.0;
            double currentNumber = 0.0;
            string currentSign = "";
            int tokenNumber = 0;
            foreach (string token in equationTokens)
            {
                if (tokenNumber % 2 == 0)
                {
                    bool isNotDouble = ErrorCheck_IsNotDouble(token);
                    if (isNotDouble)
                    {
                        break;
                    }
                    try
                    {
                        currentNumber = Convert.ToDouble(token);
                    }
                    catch (Exception)
                    {
                        break;
                    }


                    if (tokenNumber > 1)
                    {
                        if (String.Equals(currentSign, "+"))
                        {
                            result += currentNumber;
                        }
                        else if (String.Equals(currentSign, "-"))
                        {
                            result -= currentNumber;
                        }
                        else if (String.Equals(currentSign, "/"))
                        {
                            result /= currentNumber;
                        }
                        else
                        {
                            result *= currentNumber;
                        }
                    }
                }
                else
                {
                    bool isNotSign = ErrorCheck_IsNotSign(token);
                    if (isNotSign)
                    {
                        break;
                    }
                    currentSign = token;
                }

                if(tokenNumber == 0)
                {
                    result = currentNumber;
                }
                tokenNumber++;
            }

            MainText = Convert.ToString(result);
            textBox1.Text = MainText;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MainText = textBox1.Text;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            MainText = "";
            UpdateTextBox();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            MainText += "-";
            UpdateTextBox();
        }
    }
}
