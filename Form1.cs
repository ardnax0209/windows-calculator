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
            else {
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
        }

        private void signBttn_Click(object sender, EventArgs e)
        {
            string label = displayHistLabel.Text;
            string display = calculatorDisplay.Text;
            string lastDisplay = display.Substring(0, 1);

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

        private void equalBttn_Click(object sender, EventArgs e)
        {
            string label = displayHistLabel.Text;
            string display = calculatorDisplay.Text;
            double result;

            if (label == "")
            {
                displayHistLabel.Text = calculatorDisplay.Text + " =";
            } else
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
                            initialNum = label.Substring(0, operatorFound - 1);

                            initialDbl = Convert.ToDouble(initialNum);
                            result = initialDbl + Convert.ToDouble(display);

                            displayHistLabel.Text = label + " =";
                            calculatorDisplay.Text = result.ToString();
                        }
                        else if (label.Contains("-"))
                        {
                            operatorFound = label.IndexOf("-", 1);
                            initialNum = label.Substring(0, operatorFound - 1);

                            initialDbl = Convert.ToDouble(initialNum);
                            result = initialDbl - Convert.ToDouble(display);

                            displayHistLabel.Text = label + " =";
                            calculatorDisplay.Text = result.ToString();
                        } else if (label.Contains("*"))
                        {
                            operatorFound = label.IndexOf("*");
                            initialNum = label.Substring(0, operatorFound - 1);

                            initialDbl = Convert.ToDouble(initialNum);
                            result = initialDbl * Convert.ToDouble(display);

                            displayHistLabel.Text = label + " =";
                            calculatorDisplay.Text = result.ToString();
                        } else if (label.Contains('/'))
                        {
                            operatorFound = label.IndexOf("/");
                            initialNum = label.Substring(0, operatorFound - 1);

                            initialDbl = Convert.ToDouble(initialNum);
                            result = initialDbl / Convert.ToDouble(display);

                            displayHistLabel.Text = label + " =";
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
            } else
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
                    else if (label.Contains("-"))
                    {
                        operatorFound = label.IndexOf("-", 1);
                        initialNum = label.Substring(0, operatorFound - 1);

                        initialDbl = Convert.ToDouble(initialNum);
                        result = initialDbl - Convert.ToDouble(display);

                        displayHistLabel.Text = result + " -";
                        calculatorDisplay.Text = result.ToString();
                        lastClicked = "-";
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
            } else
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
                    } else
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
    }
}