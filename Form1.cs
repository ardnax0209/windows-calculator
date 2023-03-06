using System.Globalization;

namespace Calculator
{
    public partial class Form1 : Form
    {
        string lastClicked = "";

        public Form1()
        {
            InitializeComponent();
        }

        //a number or decimal was clicked
        private void button_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (lastClicked == "+" || lastClicked == "-" || lastClicked == "*" || lastClicked == "/")
            {
                calculatorDisplay.Text = button.Text;
            }
            else
            {
                if (calculatorDisplay.Text == "0")
                {
                    if (button.Text == ".")
                    {
                        calculatorDisplay.Text = calculatorDisplay.Text + button.Text;
                    }
                    else
                    {
                        calculatorDisplay.Text = button.Text;
                    }
                }
                else
                {
                    if (button.Text == ".")
                    {
                        if (!calculatorDisplay.Text.Contains('.'))
                        {
                            calculatorDisplay.Text = calculatorDisplay.Text + button.Text;
                        }
                    }
                    else
                    {
                        calculatorDisplay.Text = calculatorDisplay.Text + button.Text;
                    }
                }
            }

            lastClicked = button.Text;
        }

        private void clear_click(object sender, EventArgs e)
        {
            calculatorDisplay.Text = "0";
            displayHistLabel.Text = "";
            lastClicked = "";

            displayHistLabel.Focus();
        }

        private void signBttn_Click(object sender, EventArgs e)
        {
            string label = displayHistLabel.Text;
            string display = calculatorDisplay.Text;
            string lastDisplay = display.Substring(0, 1);

            if (display != "0")
            {
                if (label == "")
                {
                    if (lastDisplay == "-")
                    {
                        int displayLastChar = display.Length - 1; //to make zero-based
                        string noNegativeSign = display.Substring(1, displayLastChar);
                        calculatorDisplay.Text = noNegativeSign;
                    }
                    else
                    {
                        calculatorDisplay.Text = "-" + calculatorDisplay.Text;
                    }
                }
                else
                {
                    char lastLabel = label[label.Length - 1];
                    if (lastLabel == '=')
                    {
                        string noNegativeSign;
                        string oldVal = calculatorDisplay.Text;
                        if (lastDisplay == "-")
                        {
                            int displayLastChar = display.Length - 1;
                            noNegativeSign = display.Substring(1, displayLastChar);
                            calculatorDisplay.Text = noNegativeSign;
                        }
                        else
                        {
                            noNegativeSign = "-" + oldVal;
                            calculatorDisplay.Text = noNegativeSign;
                        }

                        displayHistLabel.Text = "negate(" + oldVal + ")";
                    }
                    else
                    {
                        string noNegativeSign;
                        string oldVal = calculatorDisplay.Text;
                        if (lastDisplay == "-")
                        {
                            int displayLastChar = display.Length - 1;
                            noNegativeSign = display.Substring(1, displayLastChar);
                            calculatorDisplay.Text = noNegativeSign;
                        }
                        else
                        {
                            noNegativeSign = "-" + oldVal;
                            calculatorDisplay.Text = noNegativeSign;
                        }

                        if (lastClicked == "+" || lastClicked == "-" || lastClicked == "*" || lastClicked == "/")
                        {
                            displayHistLabel.Text = displayHistLabel.Text + "negate(" + oldVal + ")";
                        }
                    }
                }
            }
        }

        private void equalBttn_Click(object sender, EventArgs e)
        {
            string label = displayHistLabel.Text;
            string display = calculatorDisplay.Text;
            double result;

            if (label == "")
            {
                displayHistLabel.Text = calculatorDisplay.Text + " =";
            }
            else
            {
                char lastLabel = label[label.Length - 1];
                string initialNum = label.Substring(0, label.Length - 1);
                double initialDbl = 0;
                int operatorFound;

                switch (lastLabel)
                {
                    case '+':
                        initialDbl = Convert.ToDouble(initialNum);
                        result = initialDbl + Convert.ToDouble(display);

                        displayHistLabel.Text = label + display + " =";
                        calculatorDisplay.Text = result.ToString();
                        break;
                    case '-':
                        initialDbl = Convert.ToDouble(initialNum);
                        result = initialDbl - Convert.ToDouble(display);

                        displayHistLabel.Text = label + display + " =";
                        calculatorDisplay.Text = result.ToString();
                        break;
                    case '*':
                        initialDbl = Convert.ToDouble(initialNum);
                        result = initialDbl * Convert.ToDouble(display);

                        displayHistLabel.Text = label + display + " =";
                        calculatorDisplay.Text = result.ToString();
                        break;
                    case '/': //also consider divided by 0
                        initialDbl = Convert.ToDouble(initialNum);
                        result = initialDbl / Convert.ToDouble(display);

                        displayHistLabel.Text = label + display + " =";
                        calculatorDisplay.Text = result.ToString();
                        break;
                    default:
                        //check what the last character is. if number or equal
                        if (label.Contains("+"))
                        {
                            operatorFound = label.IndexOf("+");
                            int equalFound = label.IndexOf("=");
                            equalFound = equalFound - 1;
                            initialNum = label.Substring(operatorFound + 1, equalFound - operatorFound);

                            initialDbl = Convert.ToDouble(initialNum);
                            result = Convert.ToDouble(display) + initialDbl;

                            displayHistLabel.Text = display + "+" + initialNum + "=";
                            calculatorDisplay.Text = result.ToString();
                        }
                        else if (label.Contains("*"))
                        {
                            operatorFound = label.IndexOf("*");
                            int equalFound = label.IndexOf("=");
                            equalFound = equalFound - 1;
                            initialNum = label.Substring(operatorFound + 1, equalFound - operatorFound);

                            initialDbl = Convert.ToDouble(initialNum);
                            result = Convert.ToDouble(display) * initialDbl;

                            displayHistLabel.Text = display + "*" + initialNum + "=";
                            calculatorDisplay.Text = result.ToString();
                        }
                        else if (label.Contains('/'))
                        {
                            operatorFound = label.IndexOf("/");
                            int equalFound = label.IndexOf("=");
                            equalFound = equalFound - 1;
                            initialNum = label.Substring(operatorFound + 1, equalFound - operatorFound);

                            initialDbl = Convert.ToDouble(initialNum);
                            result = Convert.ToDouble(display) / initialDbl;

                            displayHistLabel.Text = display + "/" + initialNum + "=";
                            calculatorDisplay.Text = result.ToString();
                        }
                        else if (label.Contains("-"))
                        {
                            operatorFound = label.IndexOf("-", 1);
                            int equalFound = label.IndexOf("=");
                            equalFound = equalFound - 1;
                            initialNum = label.Substring(operatorFound + 1, equalFound - operatorFound);

                            initialDbl = Convert.ToDouble(initialNum);
                            result = Convert.ToDouble(display) - initialDbl;

                            displayHistLabel.Text = display + "-" + initialNum + "=";
                            calculatorDisplay.Text = result.ToString();
                        }
                        break;
                }
            }

            //lastClicked = "";
        }

        private void applyBttn_Click(object sender, EventArgs e)
        {
            string label = displayHistLabel.Text;
            string display = calculatorDisplay.Text;
            double result;

            if (label == "")
            {
                displayHistLabel.Text = display + " " + operators.Text;
                lastClicked = operators.Text;
            }
            else
            {
                string initialNum;
                char lastLabel = label[label.Length - 1];

                if (lastLabel == '=')
                {
                    displayHistLabel.Text = calculatorDisplay.Text + " " + operators.Text;
                    lastClicked = operators.Text;
                }
                else
                {
                    double initialDbl = 0;
                    int operatorFound;

                    if (label.Contains("+"))
                    {
                        operatorFound = label.IndexOf("+");
                        initialNum = label.Substring(0, operatorFound - 1);

                        initialDbl = Convert.ToDouble(initialNum);
                        result = initialDbl + Convert.ToDouble(display);

                        displayHistLabel.Text = result + " +";
                        calculatorDisplay.Text = result.ToString();
                        lastClicked = "+";
                    }
                    else if (label.Contains("*"))
                    {
                        operatorFound = label.IndexOf("*");
                        initialNum = label.Substring(0, operatorFound - 1);

                        initialDbl = Convert.ToDouble(initialNum);
                        result = initialDbl * Convert.ToDouble(display);

                        displayHistLabel.Text = result + " *";
                        calculatorDisplay.Text = result.ToString();
                        lastClicked = "*";
                    }
                    else if (label.Contains("/"))
                    {
                        operatorFound = label.IndexOf("/");
                        initialNum = label.Substring(0, operatorFound - 1);

                        initialDbl = Convert.ToDouble(initialNum);
                        result = initialDbl / Convert.ToDouble(display);

                        displayHistLabel.Text = result + " /";
                        calculatorDisplay.Text = result.ToString();
                        lastClicked = "/";
                    }
                    else if (label.Contains("-"))
                    {
                        operatorFound = label.IndexOf("-", 1);
                        initialNum = label.Substring(0, operatorFound - 1);

                        try
                        {
                            initialDbl = Convert.ToDouble(initialNum);
                            result = initialDbl - Convert.ToDouble(display);

                            displayHistLabel.Text = result + " -";
                            calculatorDisplay.Text = result.ToString();
                            lastClicked = "-";
                        } catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }

        private void delete_click(object sender, EventArgs e)
        {
            string label = displayHistLabel.Text;
            int lengthOfDisplay = calculatorDisplay.Text.Length;

            if (label == "")
            {
                if (lengthOfDisplay == 1)
                {
                    calculatorDisplay.Text = "0";
                }
                else
                {
                    calculatorDisplay.Text = calculatorDisplay.Text.Substring(0, lengthOfDisplay - 1);
                }
            }
            else
            {
                char lastLabel = label[label.Length - 1];
                if (lastLabel == '=')
                {
                    displayHistLabel.Text = "";
                }
                else
                {
                    if (lastClicked == "+" || lastClicked == "-" || lastClicked == "*" || lastClicked == "/")
                    {
                        Console.WriteLine("Ignore");
                    }
                    else
                    {
                        if (lengthOfDisplay == 1)
                        {
                            calculatorDisplay.Text = "0";
                        }
                        else
                        {
                            calculatorDisplay.Text = calculatorDisplay.Text.Substring(0, lengthOfDisplay - 1);
                        }
                    }
                }
            }
        }

        private void clearEntBttn_Click(object sender, EventArgs e)
        {
            string label = displayHistLabel.Text;

            if (label == "")
            {
                calculatorDisplay.Text = "0";
            }
            else
            {
                char lastLabel = label[label.Length - 1];
                if (lastLabel == '=')
                {
                    calculatorDisplay.Text = "0";
                    displayHistLabel.Text = "";
                }
                else
                {
                    calculatorDisplay.Text = "0";
                }
            }
        }

        private void key_clicked(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D1:
                case Keys.NumPad1:
                    button1.PerformClick();
                    break;
                case Keys.D2:
                case Keys.NumPad2:
                    button2.PerformClick();
                    break;
                case Keys.D3:
                case Keys.NumPad3:
                    button3.PerformClick();
                    break;
                case Keys.D4:
                case Keys.NumPad4:
                    button4.PerformClick();
                    break;
                case Keys.D5:
                case Keys.NumPad5:
                    button5.PerformClick();
                    break;
                case Keys.D6:
                case Keys.NumPad6:
                    button6.PerformClick();
                    break;
                case Keys.D7:
                case Keys.NumPad7:
                    button7.PerformClick();
                    break;
                case Keys.NumPad8:
                    button8.PerformClick();
                    break;
                case Keys.D9:
                case Keys.NumPad9:
                    button9.PerformClick();
                    break;
                case Keys.D0:
                case Keys.NumPad0:
                    button10.PerformClick();
                    break;
                case Keys.OemPeriod:
                case Keys.Decimal:
                    decimalBttn.PerformClick();
                    break;
                case Keys.Back:
                    delBttn.PerformClick();
                    break;
                case Keys.Escape:
                    clearBttn.PerformClick();
                    break;
                case Keys.OemMinus:
                    operators.Text = "-";
                    applyBttn.PerformClick();
                    break;
                case Keys.OemQuestion:
                    operators.Text = "/";
                    applyBttn.PerformClick();
                    break;
            }
        }

        private void key_released(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    equalBttn.PerformClick();
                    break;
            }
        }

        private void key_pressed(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '*':
                    operators.Text = "*";
                    applyBttn.PerformClick();
                    break;
                case '+':
                    operators.Text = "+";
                    applyBttn.PerformClick();
                    break;
                case '8':
                    button8.PerformClick();
                    break;
                case '=':
                    equalBttn.PerformClick();
                    break;
            }
        }
    }
}