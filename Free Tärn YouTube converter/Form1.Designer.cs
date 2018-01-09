namespace Free_Tärn_YouTube_converter
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
            this.FormatList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Tõmba = new System.Windows.Forms.Button();
            this.LinkBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FormatList
            // 
            this.FormatList.FormattingEnabled = true;
            this.FormatList.Location = new System.Drawing.Point(13, 33);
            this.FormatList.Name = "FormatList";
            this.FormatList.Size = new System.Drawing.Size(121, 21);
            this.FormatList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vali format";
            // 
            // Tõmba
            // 
            this.Tõmba.Location = new System.Drawing.Point(13, 72);
            this.Tõmba.Name = "Tõmba";
            this.Tõmba.Size = new System.Drawing.Size(75, 23);
            this.Tõmba.TabIndex = 2;
            this.Tõmba.Text = "Tõmba";
            this.Tõmba.UseVisualStyleBackColor = true;
            // 
            // LinkBox
            // 
            this.LinkBox.Location = new System.Drawing.Point(196, 34);
            this.LinkBox.Name = "LinkBox";
            this.LinkBox.Size = new System.Drawing.Size(186, 20);
            this.LinkBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sisesta youtube link";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 161);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LinkBox);
            this.Controls.Add(this.Tõmba);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FormatList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox FormatList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Tõmba;
        private System.Windows.Forms.TextBox LinkBox;
        private System.Windows.Forms.Label label2;
    }
}

