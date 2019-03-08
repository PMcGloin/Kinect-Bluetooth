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
            this.ReceiveRadioButton = new System.Windows.Forms.RadioButton();
            this.GoButton = new System.Windows.Forms.Button();
            this.connectionType.SuspendLayout();
            this.SuspendLayout();
            // 
            // InfoTextBox
            // 
            this.InfoTextBox.Location = new System.Drawing.Point(12, 32);
            this.InfoTextBox.Multiline = true;
            this.InfoTextBox.Name = "InfoTextBox";
            this.InfoTextBox.Size = new System.Drawing.Size(710, 804);
            this.InfoTextBox.TabIndex = 0;
            // 
            // SendTextBox
            // 
            this.SendTextBox.Location = new System.Drawing.Point(12, 842);
            this.SendTextBox.Multiline = true;
            this.SendTextBox.Name = "SendTextBox";
            this.SendTextBox.Size = new System.Drawing.Size(710, 163);
            this.SendTextBox.TabIndex = 1;
            this.SendTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SendTextBox_KeyPress);
            // 
            // DevicesListBox
            // 
            this.DevicesListBox.FormattingEnabled = true;
            this.DevicesListBox.ItemHeight = 25;
            this.DevicesListBox.Location = new System.Drawing.Point(728, 32);
            this.DevicesListBox.Name = "DevicesListBox";
            this.DevicesListBox.Size = new System.Drawing.Size(308, 804);
            this.DevicesListBox.TabIndex = 2;
            this.DevicesListBox.DoubleClick += new System.EventHandler(this.DevicesListBox_DoubleClick);
            // 
            // connectionType
            // 
            this.connectionType.Controls.Add(this.SendRadioButton);
            this.connectionType.Controls.Add(this.ReceiveRadioButton);
            this.connectionType.Location = new System.Drawing.Point(728, 842);
            this.connectionType.Name = "connectionType";
            this.connectionType.Size = new System.Drawing.Size(308, 71);
            this.connectionType.TabIndex = 3;
            this.connectionType.TabStop = false;
            // 
            // SendRadioButton
            // 
            this.SendRadioButton.AutoSize = true;
            this.SendRadioButton.Location = new System.Drawing.Point(209, 30);
            this.SendRadioButton.Name = "SendRadioButton";
            this.SendRadioButton.Size = new System.Drawing.Size(93, 29);
            this.SendRadioButton.TabIndex = 1;
            this.SendRadioButton.TabStop = true;
            this.SendRadioButton.Text = "Send";
            this.SendRadioButton.UseVisualStyleBackColor = true;
            // 
            // ReceiveRadioButton
            // 
            this.ReceiveRadioButton.AutoSize = true;
            this.ReceiveRadioButton.Checked = true;
            this.ReceiveRadioButton.Location = new System.Drawing.Point(6, 30);
            this.ReceiveRadioButton.Name = "ReceiveRadioButton";
            this.ReceiveRadioButton.Size = new System.Drawing.Size(121, 29);
            this.ReceiveRadioButton.TabIndex = 0;
            this.ReceiveRadioButton.TabStop = true;
            this.ReceiveRadioButton.Text = "Receive";
            this.ReceiveRadioButton.UseVisualStyleBackColor = true;
            // 
            // GoButton
            // 
            this.GoButton.Location = new System.Drawing.Point(728, 919);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(308, 86);
            this.GoButton.TabIndex = 2;
            this.GoButton.Text = "GO";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 1017);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.connectionType);
            this.Controls.Add(this.DevicesListBox);
            this.Controls.Add(this.SendTextBox);
            this.Controls.Add(this.InfoTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.RadioButton ReceiveRadioButton;
        private System.Windows.Forms.Button GoButton;
    }
}

