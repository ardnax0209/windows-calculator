namespace Calculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            signBttn = new Button();
            clearBttn = new Button();
            clearEntBttn = new Button();
            memorySbtrctBttn = new Button();
            memorySmBttn = new Button();
            memoryStrBttn = new Button();
            memoryRcllBttn = new Button();
            memoryClrBttn = new Button();
            decimalBttn = new Button();
            equalBttn = new Button();
            operators = new ComboBox();
            applyBttn = new Button();
            delBttn = new Button();
            calculatorDisplay = new TextBox();
            displayHistLabel = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 271);
            button1.Name = "button1";
            button1.Size = new Size(52, 49);
            button1.TabIndex = 15;
            button1.TabStop = false;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button_click;
            // 
            // button2
            // 
            button2.Location = new Point(70, 271);
            button2.Name = "button2";
            button2.Size = new Size(52, 49);
            button2.TabIndex = 16;
            button2.TabStop = false;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button_click;
            // 
            // button3
            // 
            button3.Location = new Point(128, 271);
            button3.Name = "button3";
            button3.Size = new Size(52, 49);
            button3.TabIndex = 17;
            button3.TabStop = false;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button_click;
            // 
            // button4
            // 
            button4.Location = new Point(12, 216);
            button4.Name = "button4";
            button4.Size = new Size(52, 49);
            button4.TabIndex = 10;
            button4.TabStop = false;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button_click;
            // 
            // button5
            // 
            button5.Location = new Point(70, 216);
            button5.Name = "button5";
            button5.Size = new Size(52, 49);
            button5.TabIndex = 11;
            button5.TabStop = false;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button_click;
            // 
            // button6
            // 
            button6.Location = new Point(128, 216);
            button6.Name = "button6";
            button6.Size = new Size(52, 49);
            button6.TabIndex = 12;
            button6.TabStop = false;
            button6.Text = "6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button_click;
            // 
            // button7
            // 
            button7.Location = new Point(12, 161);
            button7.Name = "button7";
            button7.Size = new Size(52, 49);
            button7.TabIndex = 5;
            button7.TabStop = false;
            button7.Text = "7";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button_click;
            // 
            // button8
            // 
            button8.Location = new Point(70, 161);
            button8.Name = "button8";
            button8.Size = new Size(52, 49);
            button8.TabIndex = 6;
            button8.TabStop = false;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button_click;
            // 
            // button9
            // 
            button9.Location = new Point(128, 161);
            button9.Name = "button9";
            button9.Size = new Size(52, 49);
            button9.TabIndex = 7;
            button9.TabStop = false;
            button9.Text = "9";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button_click;
            // 
            // button10
            // 
            button10.Location = new Point(12, 326);
            button10.Name = "button10";
            button10.Size = new Size(110, 49);
            button10.TabIndex = 20;
            button10.TabStop = false;
            button10.Text = "0";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button_click;
            // 
            // signBttn
            // 
            signBttn.Location = new Point(186, 271);
            signBttn.Name = "signBttn";
            signBttn.Size = new Size(52, 49);
            signBttn.TabIndex = 18;
            signBttn.Text = "±";
            signBttn.UseVisualStyleBackColor = true;
            signBttn.Click += signBttn_Click;
            // 
            // clearBttn
            // 
            clearBttn.Location = new Point(128, 106);
            clearBttn.Name = "clearBttn";
            clearBttn.Size = new Size(52, 49);
            clearBttn.TabIndex = 3;
            clearBttn.TabStop = false;
            clearBttn.Text = "C";
            clearBttn.UseVisualStyleBackColor = true;
            clearBttn.Click += clear_click;
            // 
            // clearEntBttn
            // 
            clearEntBttn.Location = new Point(70, 106);
            clearEntBttn.Name = "clearEntBttn";
            clearEntBttn.Size = new Size(52, 49);
            clearEntBttn.TabIndex = 2;
            clearEntBttn.Text = "CE";
            clearEntBttn.UseVisualStyleBackColor = true;
            clearEntBttn.Click += clearEntBttn_Click;
            // 
            // memorySbtrctBttn
            // 
            memorySbtrctBttn.Location = new Point(244, 216);
            memorySbtrctBttn.Name = "memorySbtrctBttn";
            memorySbtrctBttn.Size = new Size(52, 49);
            memorySbtrctBttn.TabIndex = 14;
            memorySbtrctBttn.Text = "M-";
            memorySbtrctBttn.UseVisualStyleBackColor = true;
            // 
            // memorySmBttn
            // 
            memorySmBttn.Location = new Point(186, 216);
            memorySmBttn.Name = "memorySmBttn";
            memorySmBttn.Size = new Size(52, 49);
            memorySmBttn.TabIndex = 13;
            memorySmBttn.Text = "M+";
            memorySmBttn.UseVisualStyleBackColor = true;
            // 
            // memoryStrBttn
            // 
            memoryStrBttn.Location = new Point(244, 161);
            memoryStrBttn.Name = "memoryStrBttn";
            memoryStrBttn.Size = new Size(52, 49);
            memoryStrBttn.TabIndex = 9;
            memoryStrBttn.Text = "MS";
            memoryStrBttn.UseVisualStyleBackColor = true;
            // 
            // memoryRcllBttn
            // 
            memoryRcllBttn.Location = new Point(186, 161);
            memoryRcllBttn.Name = "memoryRcllBttn";
            memoryRcllBttn.Size = new Size(52, 49);
            memoryRcllBttn.TabIndex = 8;
            memoryRcllBttn.Text = "MR";
            memoryRcllBttn.UseVisualStyleBackColor = true;
            // 
            // memoryClrBttn
            // 
            memoryClrBttn.Location = new Point(186, 106);
            memoryClrBttn.Name = "memoryClrBttn";
            memoryClrBttn.Size = new Size(110, 49);
            memoryClrBttn.TabIndex = 4;
            memoryClrBttn.Text = "MC";
            memoryClrBttn.UseVisualStyleBackColor = true;
            // 
            // decimalBttn
            // 
            decimalBttn.Location = new Point(128, 326);
            decimalBttn.Name = "decimalBttn";
            decimalBttn.Size = new Size(52, 49);
            decimalBttn.TabIndex = 21;
            decimalBttn.TabStop = false;
            decimalBttn.Text = ".";
            decimalBttn.UseVisualStyleBackColor = true;
            decimalBttn.Click += button_click;
            // 
            // equalBttn
            // 
            equalBttn.Location = new Point(186, 326);
            equalBttn.Name = "equalBttn";
            equalBttn.Size = new Size(52, 49);
            equalBttn.TabIndex = 22;
            equalBttn.TabStop = false;
            equalBttn.Text = "=";
            equalBttn.UseVisualStyleBackColor = true;
            equalBttn.Click += equalBttn_Click;
            // 
            // operators
            // 
            operators.FormattingEnabled = true;
            operators.Items.AddRange(new object[] { "+", "-", "*", "/" });
            operators.Location = new Point(244, 285);
            operators.MaxDropDownItems = 4;
            operators.Name = "operators";
            operators.Size = new Size(52, 23);
            operators.TabIndex = 19;
            operators.Text = "+";
            // 
            // applyBttn
            // 
            applyBttn.Location = new Point(244, 326);
            applyBttn.Name = "applyBttn";
            applyBttn.Size = new Size(52, 49);
            applyBttn.TabIndex = 23;
            applyBttn.Text = "Apply";
            applyBttn.UseVisualStyleBackColor = true;
            applyBttn.Click += applyBttn_Click;
            // 
            // delBttn
            // 
            delBttn.Location = new Point(12, 106);
            delBttn.Name = "delBttn";
            delBttn.Size = new Size(52, 49);
            delBttn.TabIndex = 1;
            delBttn.TabStop = false;
            delBttn.Text = "←";
            delBttn.UseVisualStyleBackColor = true;
            delBttn.Click += delete_click;
            // 
            // calculatorDisplay
            // 
            calculatorDisplay.BackColor = Color.White;
            calculatorDisplay.Font = new Font("Bodoni MT", 32.25F, FontStyle.Regular, GraphicsUnit.Point);
            calculatorDisplay.ForeColor = Color.Black;
            calculatorDisplay.Location = new Point(12, 41);
            calculatorDisplay.Name = "calculatorDisplay";
            calculatorDisplay.ReadOnly = true;
            calculatorDisplay.Size = new Size(284, 59);
            calculatorDisplay.TabIndex = 24;
            calculatorDisplay.TabStop = false;
            calculatorDisplay.Text = "0";
            calculatorDisplay.TextAlign = HorizontalAlignment.Right;
            // 
            // displayHistLabel
            // 
            displayHistLabel.BackColor = SystemColors.Control;
            displayHistLabel.BorderStyle = BorderStyle.None;
            displayHistLabel.Location = new Point(12, 12);
            displayHistLabel.Name = "displayHistLabel";
            displayHistLabel.ReadOnly = true;
            displayHistLabel.Size = new Size(284, 16);
            displayHistLabel.TabIndex = 0;
            displayHistLabel.TextAlign = HorizontalAlignment.Right;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(308, 387);
            Controls.Add(displayHistLabel);
            Controls.Add(calculatorDisplay);
            Controls.Add(delBttn);
            Controls.Add(applyBttn);
            Controls.Add(operators);
            Controls.Add(equalBttn);
            Controls.Add(decimalBttn);
            Controls.Add(memorySbtrctBttn);
            Controls.Add(memorySmBttn);
            Controls.Add(memoryStrBttn);
            Controls.Add(memoryRcllBttn);
            Controls.Add(memoryClrBttn);
            Controls.Add(signBttn);
            Controls.Add(clearBttn);
            Controls.Add(clearEntBttn);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Calculator";
            KeyDown += key_clicked;
            KeyPress += key_pressed;
            KeyUp += key_released;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button signBttn;
        private Button clearBttn;
        private Button clearEntBttn;
        private Button memorySbtrctBttn;
        private Button memorySmBttn;
        private Button memoryStrBttn;
        private Button memoryRcllBttn;
        private Button memoryClrBttn;
        private Button decimalBttn;
        private Button equalBttn;
        private ComboBox operators;
        private Button applyBttn;
        private Button delBttn;
        private TextBox calculatorDisplay;
        private TextBox displayHistLabel;
    }
}