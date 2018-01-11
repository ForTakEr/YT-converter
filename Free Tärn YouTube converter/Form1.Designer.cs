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
            this.ClearButton = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.NimeBox = new System.Windows.Forms.TextBox();
            this.KonsooliNäha = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ResourceDirectory = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FormatList
            // 
            this.FormatList.FormattingEnabled = true;
            this.FormatList.Location = new System.Drawing.Point(13, 33);
            this.FormatList.Name = "FormatList";
            this.FormatList.Size = new System.Drawing.Size(121, 21);
            this.FormatList.TabIndex = 1;
            this.FormatList.SelectedIndexChanged += new System.EventHandler(this.FormatList_SelectedIndexChanged);
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
            this.Tõmba.Click += new System.EventHandler(this.Tõmba_Click);
            // 
            // LinkBox
            // 
            this.LinkBox.Location = new System.Drawing.Point(164, 34);
            this.LinkBox.Name = "LinkBox";
            this.LinkBox.Size = new System.Drawing.Size(186, 20);
            this.LinkBox.TabIndex = 0;
            this.LinkBox.TextChanged += new System.EventHandler(this.LinkBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sisesta youtube link";
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(13, 101);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 5;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(13, 159);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 6;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(356, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 21);
            this.button1.TabIndex = 5;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Valige palun faili nimi";
            // 
            // NimeBox
            // 
            this.NimeBox.Location = new System.Drawing.Point(164, 89);
            this.NimeBox.Name = "NimeBox";
            this.NimeBox.Size = new System.Drawing.Size(186, 20);
            this.NimeBox.TabIndex = 4;
            this.NimeBox.TextChanged += new System.EventHandler(this.NimeBox_TextChanged);
            // 
            // KonsooliNäha
            // 
            this.KonsooliNäha.AutoSize = true;
            this.KonsooliNäha.Location = new System.Drawing.Point(164, 116);
            this.KonsooliNäha.Name = "KonsooliNäha";
            this.KonsooliNäha.Size = new System.Drawing.Size(126, 17);
            this.KonsooliNäha.TabIndex = 9;
            this.KonsooliNäha.Text = "Tahan näha konsooli";
            this.KonsooliNäha.UseVisualStyleBackColor = true;
            this.KonsooliNäha.CheckedChanged += new System.EventHandler(this.KonsooliNäha_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Vali youtube-dl või ffmpeg/ffprobe directory";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // ResourceDirectory
            // 
            this.ResourceDirectory.Location = new System.Drawing.Point(164, 152);
            this.ResourceDirectory.Name = "ResourceDirectory";
            this.ResourceDirectory.Size = new System.Drawing.Size(75, 23);
            this.ResourceDirectory.TabIndex = 3;
            this.ResourceDirectory.Text = "Choose";
            this.ResourceDirectory.UseVisualStyleBackColor = true;
            this.ResourceDirectory.Click += new System.EventHandler(this.ResourceDirectory_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 130);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Open folder";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 188);
            this.Controls.Add(this.ResourceDirectory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.KonsooliNäha);
            this.Controls.Add(this.NimeBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LinkBox);
            this.Controls.Add(this.Tõmba);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FormatList);
            this.Name = "Form1";
            this.Text = "YouTube video converter";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.AllowDrop = true;
            this.DragEnter += new System.Windows.Forms.DragEventHandler(Form1_DragEnter);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(Form1_DragDrop);

        }

        #endregion

        private System.Windows.Forms.ComboBox FormatList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Tõmba;
        private System.Windows.Forms.TextBox LinkBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NimeBox;
        private System.Windows.Forms.CheckBox KonsooliNäha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ResourceDirectory;
        private System.Windows.Forms.Button button2;
    }
}

