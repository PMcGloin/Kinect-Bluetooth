using System;

namespace Kinect_Bluetooth
{
    partial class Form1
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
            this.InfoTextBox = new System.Windows.Forms.TextBox();
            this.SendTextBox = new System.Windows.Forms.TextBox();
            this.DevicesListBox = new System.Windows.Forms.ListBox();
            this.connectionType = new System.Windows.Forms.GroupBox();
            this.SendRadioButton = new System.Windows.Forms.RadioButton();
            this.RecieveRadioButton = new System.Windows.Forms.RadioButton();
            this.GoButton = new System.Windows.Forms.Button();
            this.connectionType.SuspendLayout();
            this.SuspendLayout();
            // 
            // InfoTextBox
            // 
            this.InfoTextBox.Location = new System.Drawing.Point(12, 12);
            this.InfoTextBox.Multiline = true;
            this.InfoTextBox.Name = "InfoTextBox";
            this.InfoTextBox.Size = new System.Drawing.Size(637, 291);
            this.InfoTextBox.TabIndex = 0;
            // 
            // SendTextBox
            // 
            this.SendTextBox.Location = new System.Drawing.Point(12, 309);
            this.SendTextBox.Multiline = true;
            this.SendTextBox.Name = "SendTextBox";
            this.SendTextBox.Size = new System.Drawing.Size(487, 129);
            this.SendTextBox.TabIndex = 1;
            this.SendTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbText_KeyPress);
            // 
            // DevicesListBox
            // 
            this.DevicesListBox.FormattingEnabled = true;
            this.DevicesListBox.ItemHeight = 25;
            this.DevicesListBox.Location = new System.Drawing.Point(505, 309);
            this.DevicesListBox.Name = "DevicesListBox";
            this.DevicesListBox.Size = new System.Drawing.Size(283, 129);
            this.DevicesListBox.TabIndex = 2;
            this.DevicesListBox.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // connectionType
            // 
            this.connectionType.Controls.Add(this.SendRadioButton);
            this.connectionType.Controls.Add(this.RecieveRadioButton);
            this.connectionType.Location = new System.Drawing.Point(655, 12);
            this.connectionType.Name = "connectionType";
            this.connectionType.Size = new System.Drawing.Size(133, 108);
            this.connectionType.TabIndex = 3;
            this.connectionType.TabStop = false;
            // 
            // SendRadioButton
            // 
            this.SendRadioButton.AutoSize = true;
            this.SendRadioButton.Location = new System.Drawing.Point(6, 30);
            this.SendRadioButton.Name = "SendRadioButton";
            this.SendRadioButton.Size = new System.Drawing.Size(93, 29);
            this.SendRadioButton.TabIndex = 1;
            this.SendRadioButton.TabStop = true;
            this.SendRadioButton.Text = "Send";
            this.SendRadioButton.UseVisualStyleBackColor = true;
            // 
            // RecieveRadioButton
            // 
            this.RecieveRadioButton.AutoSize = true;
            this.RecieveRadioButton.Checked = true;
            this.RecieveRadioButton.Location = new System.Drawing.Point(6, 65);
            this.RecieveRadioButton.Name = "RecieveRadioButton";
            this.RecieveRadioButton.Size = new System.Drawing.Size(121, 29);
            this.RecieveRadioButton.TabIndex = 0;
            this.RecieveRadioButton.TabStop = true;
            this.RecieveRadioButton.Text = "Recieve";
            this.RecieveRadioButton.UseVisualStyleBackColor = true;
            // 
            // GoButton
            // 
            this.GoButton.Location = new System.Drawing.Point(680, 126);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(75, 33);
            this.GoButton.TabIndex = 2;
            this.GoButton.Text = "GO";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.bGo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.connectionType);
            this.Controls.Add(this.DevicesListBox);
            this.Controls.Add(this.SendTextBox);
            this.Controls.Add(this.InfoTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.connectionType.ResumeLayout(false);
            this.connectionType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        #endregion

        private System.Windows.Forms.TextBox InfoTextBox;
        private System.Windows.Forms.TextBox SendTextBox;
        private System.Windows.Forms.ListBox DevicesListBox;
        private System.Windows.Forms.GroupBox connectionType;
        private System.Windows.Forms.RadioButton SendRadioButton;
        private System.Windows.Forms.RadioButton RecieveRadioButton;
        private System.Windows.Forms.Button GoButton;
    }
}

