using System.ComponentModel;
using System;
using System.Globalization;
using System.Xml;
using Microsoft.VisualBasic.ApplicationServices;

namespace Calculator
{
    public partial class Form1 : Form
    {
        string lastClicked = "";

        string[,] historyTrail = new string[50, 3];

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
                if (calculatorDisplay.Text == "0" || calculatorDisplay.Text == "Error!")
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

            string id = "";
            int cntr = 0;
            for (int i = 0; i < 50; i++)
            {
                if (i.ToString() == historyTrail[i, 0])
                {
                    int holder = Convert.ToInt32(historyTrail[i, 0]) + 1;
                    id = holder.ToString();
                }
                else
                {
                    if (i == 0)
                    {
                        cntr = i;
                        id = "1";
                    }
                    else
                    {
                        cntr = i;
                        break;
                    }
                }
            }

            historyTrail[cntr, 0] = id;
            historyTrail[cntr, 1] = "Clear";
            historyTrail[cntr, 2] = "0";
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
            double result = 0;
            string action = "";

            if (label == "")
            {
                displayHistLabel.Text = calculatorDisplay.Text + " =";
                action = "Equal";
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
                        action = "Add";
                        break;
                    case '-':
                        initialDbl = Convert.ToDouble(initialNum);
                        result = initialDbl - Convert.ToDouble(display);

                        displayHistLabel.Text = label + display + " =";
                        calculatorDisplay.Text = result.ToString();
                        action = "Subtract";
                        break;
                    case '*':
                        initialDbl = Convert.ToDouble(initialNum);
                        result = initialDbl * Convert.ToDouble(display);

                        displayHistLabel.Text = label + display + " =";
                        calculatorDisplay.Text = result.ToString();
                        action = "Multiply";
                        break;
                    case '/':
                        initialDbl = Convert.ToDouble(initialNum);

                        if (display == "0")
                        {
                            calculatorDisplay.Text = "Error!";
                        }
                        else
                        {
                            result = initialDbl / Convert.ToDouble(display);

                            displayHistLabel.Text = label + display + " =";
                            calculatorDisplay.Text = result.ToString();
                        }
                        action = "Divide";
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
                            action = "Add";
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
                            action = "Multiply";
                        }
                        else if (label.Contains('/'))
                        {
                            operatorFound = label.IndexOf("/");
                            int equalFound = label.IndexOf("=");
                            equalFound = equalFound - 1;
                            initialNum = label.Substring(operatorFound + 1, equalFound - operatorFound);

                            if (initialNum == "0")
                            {
                                calculatorDisplay.Text = "Error!";
                            }
                            else
                            {
                                initialDbl = Convert.ToDouble(initialNum);
                                result = Convert.ToDouble(display) / initialDbl;

                                displayHistLabel.Text = display + "/" + initialNum + "=";
                                calculatorDisplay.Text = result.ToString();
                            }
                            action = "Divide";
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
                            action = "Subtract";
                        }
                        break;
                }
            }

            //lastClicked = "";

            string id = "";
            int cntr = 0;
            for (int i = 0; i < 50; i++)
            {
                if (i.ToString() == historyTrail[i, 0])
                {
                    int holder = Convert.ToInt32(historyTrail[i, 0]) + 1;
                    id = holder.ToString();
                }
                else if (i == 0)
                {
                    cntr = i;
                    id = "1";
                }
                else
                {
                    cntr = i;
                    break;
                }
            }

            historyTrail[cntr, 0] = id;
            historyTrail[cntr, 1] = action;
            if (calculatorDisplay.Text != "Error!")
            {
                historyTrail[cntr, 2] = result.ToString();
            }
            else
            {
                historyTrail[cntr, 2] = "Error!";
            }
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
                        if (display == "0")
                        {
                            calculatorDisplay.Text = "Error!";
                        }
                        else
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
                        }
                        catch (Exception ex)
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
                case '-':
                    operators.Text = "-";
                    applyBttn.PerformClick();
                    break;
                case '/':
                    operators.Text = "/";
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

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearBttn.PerformClick();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(calculatorDisplay.Text);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (calculatorDisplay.Text == "0" || calculatorDisplay.Text == "Error!")
            {
                calculatorDisplay.Text = Clipboard.GetText();
            }
            else
            {
                calculatorDisplay.Text = calculatorDisplay.Text + Clipboard.GetText();
            }
        }

        private void memoryStrBttn_Click(object sender, EventArgs e)
        {
            memoryListBox.Items.Add(calculatorDisplay.Text);
            memoryClrBttn.Enabled = true;
            memoryRcllBttn.Enabled = true;
            memorySbtrctBttn.Enabled = true;
            memorySmBttn.Enabled = true;
            button11.Enabled = true;

            lastClicked = "+";
        }

        private void memoryClrBttn_Click(object sender, EventArgs e)
        {
            memoryListBox.Items.Clear();
            memoryClrBttn.Enabled = false;
            memoryRcllBttn.Enabled = false;
            memorySbtrctBttn.Enabled = false;
            memorySmBttn.Enabled = false;
            button11.Enabled = false;

            if (memoryListBox.Visible == true)
            {
                memoryListBox.Visible = false;
                Size = new Size(324, 434);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (memoryListBox.Visible == true)
            {
                memoryListBox.Visible = false;
                Size = new Size(324, 434);
            }
            else
            {
                memoryListBox.Visible = true;
                Size = new Size(451, 434);
            }
        }

        private void memoryRcllBttn_Click(object sender, EventArgs e)
        {
            int numOfItems = memoryListBox.Items.Count;
            calculatorDisplay.Text = memoryListBox.Items[numOfItems - 1].ToString();
        }

        private void memorySmBttn_Click(object sender, EventArgs e)
        {
            int numOfItems = memoryListBox.Items.Count;
            var lastItem = memoryListBox.Items[numOfItems - 1];
            double lastDbl = Convert.ToDouble(lastItem);
            double result = lastDbl + Convert.ToDouble(calculatorDisplay.Text);

            memoryListBox.Items[numOfItems - 1] = result.ToString();
        }

        private void memorySbtrctBttn_Click(object sender, EventArgs e)
        {
            int numOfItems = memoryListBox.Items.Count;
            var lastItem = memoryListBox.Items[numOfItems - 1];
            double lastDbl = Convert.ToDouble(lastItem);
            double result = lastDbl - Convert.ToDouble(calculatorDisplay.Text);

            memoryListBox.Items[numOfItems - 1] = result.ToString();
        }

        private void exportToTextToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string pathName = "";
            bool proceedCheck = false;
            // Displays a SaveFileDialog so the user can save the file
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML-File | *.xml";
            saveFileDialog1.Title = "Save XML File";
            saveFileDialog1.ShowDialog();

            // Saves the file via a FileStream created by the OpenFile method.
            System.IO.FileStream fs =
                (System.IO.FileStream)saveFileDialog1.OpenFile();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                pathName = saveFileDialog1.FileName;
                proceedCheck = true;
            }
            else
            {
                MessageBox.Show("Error: Cannot save file.");
            }
            fs.Close();

            if (proceedCheck == true)
            {
                XmlTextWriter xmlWriter = new XmlTextWriter(pathName, System.Text.Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteComment("Calculator history trail as of " + DateTime.Now.ToString());
                xmlWriter.WriteStartElement("Records");
                for (int i = 1; i < 50; i++)
                {
                    try
                    {
                        if (String.IsNullOrEmpty(historyTrail[i, 0]))
                        {
                            break;
                        } else
                        {
                            xmlWriter.WriteStartElement("Entry");
                            xmlWriter.WriteElementString("Hist_ID", historyTrail[i, 0]);
                            xmlWriter.WriteElementString("Hist_Action", historyTrail[i, 1]);
                            xmlWriter.WriteElementString("Hist_Value", historyTrail[i, 2]);
                            xmlWriter.WriteEndElement();
                        }
                    }
                    catch
                    {
                        Console.WriteLine("No item found on array.");
                        break;
                    }
                }
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Flush();
                xmlWriter.Close();
            }
        }

        private void importFromTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "XML-File | *.xml";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            //Create a document which will read XML from file
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            int i = 0;
            //Find id node
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                string histId = node.SelectSingleNode("Hist_ID").InnerText;
                string histAction = node.SelectSingleNode("Hist_Action").InnerText;
                string histValue = node.SelectSingleNode("Hist_Value").InnerText;

                historyTrail[i, 0] = histId;
                historyTrail[i, 1] = histAction;
                historyTrail[i, 2] = histValue;

                i++;
            }

            calculatorDisplay.Text = historyTrail[i - 1, 2];
        }
    }
}