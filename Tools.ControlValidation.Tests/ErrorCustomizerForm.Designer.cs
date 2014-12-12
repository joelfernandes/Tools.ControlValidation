namespace Tools.ControlValidation.Tests
{
    partial class ErrorCustomizerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._buttonTest = new System.Windows.Forms.Button();
            this._labelErrorAlignment = new System.Windows.Forms.Label();
            this._labelErrorPadding = new System.Windows.Forms.Label();
            this._labelErrorBlinkStyle = new System.Windows.Forms.Label();
            this._comboBoxErrorAlign = new System.Windows.Forms.ComboBox();
            this._numericUpDownPadding = new System.Windows.Forms.NumericUpDown();
            this._comboBoxBlinkStyle = new System.Windows.Forms.ComboBox();
            this._labelErrorBlinkRate = new System.Windows.Forms.Label();
            this._numericUpDownBlinkRate = new System.Windows.Forms.NumericUpDown();
            this._labelBadass = new System.Windows.Forms.Label();
            this._groupBoxCustom = new System.Windows.Forms.GroupBox();
            this._buttonChangeError = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownPadding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownBlinkRate)).BeginInit();
            this._groupBoxCustom.SuspendLayout();
            this.SuspendLayout();
            // 
            // _buttonTest
            // 
            this._buttonTest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._buttonTest.Location = new System.Drawing.Point(250, 203);
            this._buttonTest.Name = "_buttonTest";
            this._buttonTest.Size = new System.Drawing.Size(192, 62);
            this._buttonTest.TabIndex = 1;
            this._buttonTest.Text = "Don\'t click me!";
            this._buttonTest.UseVisualStyleBackColor = true;
            this._buttonTest.Click += new System.EventHandler(this.ButtonTest_Click);
            // 
            // _labelErrorAlignment
            // 
            this._labelErrorAlignment.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._labelErrorAlignment.AutoSize = true;
            this._labelErrorAlignment.Location = new System.Drawing.Point(23, 41);
            this._labelErrorAlignment.Name = "_labelErrorAlignment";
            this._labelErrorAlignment.Size = new System.Drawing.Size(80, 13);
            this._labelErrorAlignment.TabIndex = 11;
            this._labelErrorAlignment.Text = "Error alignment:";
            // 
            // _labelErrorPadding
            // 
            this._labelErrorPadding.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._labelErrorPadding.AutoSize = true;
            this._labelErrorPadding.Location = new System.Drawing.Point(333, 41);
            this._labelErrorPadding.Name = "_labelErrorPadding";
            this._labelErrorPadding.Size = new System.Drawing.Size(73, 13);
            this._labelErrorPadding.TabIndex = 11;
            this._labelErrorPadding.Text = "Error padding:";
            // 
            // _labelErrorBlinkStyle
            // 
            this._labelErrorBlinkStyle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._labelErrorBlinkStyle.AutoSize = true;
            this._labelErrorBlinkStyle.Location = new System.Drawing.Point(23, 93);
            this._labelErrorBlinkStyle.Name = "_labelErrorBlinkStyle";
            this._labelErrorBlinkStyle.Size = new System.Drawing.Size(95, 13);
            this._labelErrorBlinkStyle.TabIndex = 11;
            this._labelErrorBlinkStyle.Text = "Error blinking style:";
            // 
            // _comboBoxErrorAlign
            // 
            this._comboBoxErrorAlign.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._comboBoxErrorAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxErrorAlign.FormattingEnabled = true;
            this._comboBoxErrorAlign.Location = new System.Drawing.Point(109, 38);
            this._comboBoxErrorAlign.Name = "_comboBoxErrorAlign";
            this._comboBoxErrorAlign.Size = new System.Drawing.Size(193, 21);
            this._comboBoxErrorAlign.TabIndex = 12;
            // 
            // _numericUpDownPadding
            // 
            this._numericUpDownPadding.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._numericUpDownPadding.Location = new System.Drawing.Point(412, 39);
            this._numericUpDownPadding.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this._numericUpDownPadding.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this._numericUpDownPadding.Name = "_numericUpDownPadding";
            this._numericUpDownPadding.Size = new System.Drawing.Size(193, 20);
            this._numericUpDownPadding.TabIndex = 13;
            // 
            // _comboBoxBlinkStyle
            // 
            this._comboBoxBlinkStyle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._comboBoxBlinkStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxBlinkStyle.FormattingEnabled = true;
            this._comboBoxBlinkStyle.Location = new System.Drawing.Point(124, 90);
            this._comboBoxBlinkStyle.Name = "_comboBoxBlinkStyle";
            this._comboBoxBlinkStyle.Size = new System.Drawing.Size(178, 21);
            this._comboBoxBlinkStyle.TabIndex = 12;
            // 
            // _labelErrorBlinkRate
            // 
            this._labelErrorBlinkRate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._labelErrorBlinkRate.AutoSize = true;
            this._labelErrorBlinkRate.Location = new System.Drawing.Point(328, 93);
            this._labelErrorBlinkRate.Name = "_labelErrorBlinkRate";
            this._labelErrorBlinkRate.Size = new System.Drawing.Size(92, 13);
            this._labelErrorBlinkRate.TabIndex = 11;
            this._labelErrorBlinkRate.Text = "Error blinking rate:";
            // 
            // _numericUpDownBlinkRate
            // 
            this._numericUpDownBlinkRate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._numericUpDownBlinkRate.Enabled = false;
            this._numericUpDownBlinkRate.Location = new System.Drawing.Point(426, 91);
            this._numericUpDownBlinkRate.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this._numericUpDownBlinkRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numericUpDownBlinkRate.Name = "_numericUpDownBlinkRate";
            this._numericUpDownBlinkRate.Size = new System.Drawing.Size(179, 20);
            this._numericUpDownBlinkRate.TabIndex = 13;
            this._numericUpDownBlinkRate.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // _labelBadass
            // 
            this._labelBadass.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._labelBadass.AutoSize = true;
            this._labelBadass.Location = new System.Drawing.Point(247, 268);
            this._labelBadass.Name = "_labelBadass";
            this._labelBadass.Size = new System.Drawing.Size(195, 13);
            this._labelBadass.TabIndex = 11;
            this._labelBadass.Text = "I\'m badass because I clicked the button";
            // 
            // _groupBoxCustom
            // 
            this._groupBoxCustom.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._groupBoxCustom.Controls.Add(this._buttonChangeError);
            this._groupBoxCustom.Controls.Add(this._labelErrorBlinkStyle);
            this._groupBoxCustom.Controls.Add(this._labelErrorAlignment);
            this._groupBoxCustom.Controls.Add(this._comboBoxBlinkStyle);
            this._groupBoxCustom.Controls.Add(this._numericUpDownBlinkRate);
            this._groupBoxCustom.Controls.Add(this._comboBoxErrorAlign);
            this._groupBoxCustom.Controls.Add(this._labelErrorBlinkRate);
            this._groupBoxCustom.Controls.Add(this._labelErrorPadding);
            this._groupBoxCustom.Controls.Add(this._numericUpDownPadding);
            this._groupBoxCustom.Location = new System.Drawing.Point(28, 12);
            this._groupBoxCustom.Name = "_groupBoxCustom";
            this._groupBoxCustom.Size = new System.Drawing.Size(632, 166);
            this._groupBoxCustom.TabIndex = 15;
            this._groupBoxCustom.TabStop = false;
            this._groupBoxCustom.Text = "Customization - affects the button below";
            // 
            // _buttonChangeError
            // 
            this._buttonChangeError.Location = new System.Drawing.Point(124, 118);
            this._buttonChangeError.Name = "_buttonChangeError";
            this._buttonChangeError.Size = new System.Drawing.Size(178, 23);
            this._buttonChangeError.TabIndex = 14;
            this._buttonChangeError.Text = "Change Error";
            this._buttonChangeError.UseVisualStyleBackColor = true;
            // 
            // ErrorCustomizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 350);
            this.Controls.Add(this._groupBoxCustom);
            this.Controls.Add(this._labelBadass);
            this.Controls.Add(this._buttonTest);
            this.Name = "ErrorCustomizerForm";
            this.Text = "Customization (Button Validation)";
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownPadding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownBlinkRate)).EndInit();
            this._groupBoxCustom.ResumeLayout(false);
            this._groupBoxCustom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _buttonTest;
        private System.Windows.Forms.Label _labelErrorAlignment;
        private System.Windows.Forms.Label _labelErrorPadding;
        private System.Windows.Forms.Label _labelErrorBlinkStyle;
        private System.Windows.Forms.ComboBox _comboBoxErrorAlign;
        private System.Windows.Forms.NumericUpDown _numericUpDownPadding;
        private System.Windows.Forms.ComboBox _comboBoxBlinkStyle;
        private System.Windows.Forms.Label _labelErrorBlinkRate;
        private System.Windows.Forms.NumericUpDown _numericUpDownBlinkRate;
        private System.Windows.Forms.Label _labelBadass;
        private System.Windows.Forms.GroupBox _groupBoxCustom;
        private System.Windows.Forms.Button _buttonChangeError;
    }
}

