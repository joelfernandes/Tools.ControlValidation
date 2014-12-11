namespace ControlValidationTests
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
            this._groupBoxAll = new System.Windows.Forms.GroupBox();
            this._groupBoxCustom = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownPadding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownBlinkRate)).BeginInit();
            this._groupBoxAll.SuspendLayout();
            this._groupBoxCustom.SuspendLayout();
            this.SuspendLayout();
            // 
            // _buttonTest
            // 
            this._buttonTest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._buttonTest.Location = new System.Drawing.Point(250, 215);
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
            this._labelErrorBlinkStyle.Location = new System.Drawing.Point(23, 40);
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
            this._comboBoxBlinkStyle.Location = new System.Drawing.Point(124, 37);
            this._comboBoxBlinkStyle.Name = "_comboBoxBlinkStyle";
            this._comboBoxBlinkStyle.Size = new System.Drawing.Size(178, 21);
            this._comboBoxBlinkStyle.TabIndex = 12;
            // 
            // _labelErrorBlinkRate
            // 
            this._labelErrorBlinkRate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._labelErrorBlinkRate.AutoSize = true;
            this._labelErrorBlinkRate.Location = new System.Drawing.Point(328, 40);
            this._labelErrorBlinkRate.Name = "_labelErrorBlinkRate";
            this._labelErrorBlinkRate.Size = new System.Drawing.Size(92, 13);
            this._labelErrorBlinkRate.TabIndex = 11;
            this._labelErrorBlinkRate.Text = "Error blinking rate:";
            // 
            // _numericUpDownBlinkRate
            // 
            this._numericUpDownBlinkRate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._numericUpDownBlinkRate.Enabled = false;
            this._numericUpDownBlinkRate.Location = new System.Drawing.Point(426, 38);
            this._numericUpDownBlinkRate.Maximum = new decimal(new int[] {
            500,
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
            this._labelBadass.Location = new System.Drawing.Point(247, 280);
            this._labelBadass.Name = "_labelBadass";
            this._labelBadass.Size = new System.Drawing.Size(195, 13);
            this._labelBadass.TabIndex = 11;
            this._labelBadass.Text = "I\'m badass because I clicked the button";
            // 
            // _groupBoxAll
            // 
            this._groupBoxAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._groupBoxAll.Controls.Add(this._labelErrorBlinkStyle);
            this._groupBoxAll.Controls.Add(this._comboBoxBlinkStyle);
            this._groupBoxAll.Controls.Add(this._numericUpDownBlinkRate);
            this._groupBoxAll.Controls.Add(this._labelErrorBlinkRate);
            this._groupBoxAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._groupBoxAll.Location = new System.Drawing.Point(28, 12);
            this._groupBoxAll.Name = "_groupBoxAll";
            this._groupBoxAll.Size = new System.Drawing.Size(632, 87);
            this._groupBoxAll.TabIndex = 14;
            this._groupBoxAll.TabStop = false;
            this._groupBoxAll.Text = "General settings - affects ALL control/validations";
            // 
            // _groupBoxCustom
            // 
            this._groupBoxCustom.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._groupBoxCustom.Controls.Add(this._labelErrorAlignment);
            this._groupBoxCustom.Controls.Add(this._comboBoxErrorAlign);
            this._groupBoxCustom.Controls.Add(this._labelErrorPadding);
            this._groupBoxCustom.Controls.Add(this._numericUpDownPadding);
            this._groupBoxCustom.Location = new System.Drawing.Point(28, 105);
            this._groupBoxCustom.Name = "_groupBoxCustom";
            this._groupBoxCustom.Size = new System.Drawing.Size(632, 87);
            this._groupBoxCustom.TabIndex = 15;
            this._groupBoxCustom.TabStop = false;
            this._groupBoxCustom.Text = "Customization - affects the button below";
            // 
            // ValidatorTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 350);
            this.Controls.Add(this._groupBoxCustom);
            this.Controls.Add(this._groupBoxAll);
            this.Controls.Add(this._labelBadass);
            this.Controls.Add(this._buttonTest);
            this.Name = "ErrorCustomizerForm";
            this.Text = "Customization (Button Validation)";
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownPadding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownBlinkRate)).EndInit();
            this._groupBoxAll.ResumeLayout(false);
            this._groupBoxAll.PerformLayout();
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
        private System.Windows.Forms.GroupBox _groupBoxAll;
        private System.Windows.Forms.GroupBox _groupBoxCustom;
    }
}

