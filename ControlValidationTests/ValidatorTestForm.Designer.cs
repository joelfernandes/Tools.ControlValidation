namespace ControlValidationTests
{
    partial class ValidatorTestForm
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
            this._buttonCustomizeError = new System.Windows.Forms.Button();
            this._buttonExamples = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _buttonCustomizeError
            // 
            this._buttonCustomizeError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._buttonCustomizeError.Location = new System.Drawing.Point(291, 83);
            this._buttonCustomizeError.Name = "_buttonCustomizeError";
            this._buttonCustomizeError.Size = new System.Drawing.Size(192, 62);
            this._buttonCustomizeError.TabIndex = 2;
            this._buttonCustomizeError.Text = "Customize Error Settings";
            this._buttonCustomizeError.UseVisualStyleBackColor = true;
            this._buttonCustomizeError.Click += new System.EventHandler(this.ButtonCustomizeError_Click);
            // 
            // _buttonExamples
            // 
            this._buttonExamples.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._buttonExamples.Location = new System.Drawing.Point(60, 83);
            this._buttonExamples.Name = "_buttonExamples";
            this._buttonExamples.Size = new System.Drawing.Size(192, 62);
            this._buttonExamples.TabIndex = 2;
            this._buttonExamples.Text = "Some examples";
            this._buttonExamples.UseVisualStyleBackColor = true;
            this._buttonExamples.Click += new System.EventHandler(this.ButtonExamples_Click);
            // 
            // ValidatorTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 254);
            this.Controls.Add(this._buttonExamples);
            this.Controls.Add(this._buttonCustomizeError);
            this.Name = "ValidatorTestForm";
            this.Text = "ValidatorTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _buttonCustomizeError;
        private System.Windows.Forms.Button _buttonExamples;
    }
}