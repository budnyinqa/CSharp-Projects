namespace Currency_Converter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.From = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Round_checkBox = new System.Windows.Forms.CheckBox();
            this.result2 = new System.Windows.Forms.Label();
            this.result1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.EnterAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AmountScrollBar = new System.Windows.Forms.HScrollBar();
            this.To = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // From
            // 
            this.From.BackColor = System.Drawing.SystemColors.MenuBar;
            this.From.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.From.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.From.ForeColor = System.Drawing.Color.DimGray;
            this.From.FormattingEnabled = true;
            this.From.Items.AddRange(new object[] {
            "EUR",
            "PL",
            "USD"});
            this.From.Location = new System.Drawing.Point(39, 286);
            this.From.Margin = new System.Windows.Forms.Padding(4);
            this.From.Name = "From";
            this.From.Size = new System.Drawing.Size(128, 33);
            this.From.TabIndex = 37;
            this.From.SelectedIndexChanged += new System.EventHandler(this.From_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(176, 290);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 25);
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Round_checkBox
            // 
            this.Round_checkBox.AutoSize = true;
            this.Round_checkBox.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Round_checkBox.Location = new System.Drawing.Point(243, 326);
            this.Round_checkBox.Name = "Round_checkBox";
            this.Round_checkBox.Size = new System.Drawing.Size(105, 21);
            this.Round_checkBox.TabIndex = 35;
            this.Round_checkBox.Text = "Round Value";
            this.Round_checkBox.UseVisualStyleBackColor = true;
            this.Round_checkBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // result2
            // 
            this.result2.AutoSize = true;
            this.result2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.result2.Location = new System.Drawing.Point(141, 544);
            this.result2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.result2.Name = "result2";
            this.result2.Size = new System.Drawing.Size(94, 17);
            this.result2.TabIndex = 34;
            this.result2.Text = "Enter Amount";
            // 
            // result1
            // 
            this.result1.AutoSize = true;
            this.result1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result1.Location = new System.Drawing.Point(141, 519);
            this.result1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.result1.Name = "result1";
            this.result1.Size = new System.Drawing.Size(94, 17);
            this.result1.TabIndex = 33;
            this.result1.Text = "Enter Amount";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.button2.Location = new System.Drawing.Point(39, 441);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(304, 51);
            this.button2.TabIndex = 32;
            this.button2.Text = "CLEAR";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EnterAmount
            // 
            this.EnterAmount.BackColor = System.Drawing.SystemColors.MenuBar;
            this.EnterAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EnterAmount.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterAmount.ForeColor = System.Drawing.Color.DimGray;
            this.EnterAmount.Location = new System.Drawing.Point(39, 182);
            this.EnterAmount.Name = "EnterAmount";
            this.EnterAmount.Size = new System.Drawing.Size(304, 32);
            this.EnterAmount.TabIndex = 28;
            this.EnterAmount.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(212, 265);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 17);
            this.label5.TabIndex = 31;
            this.label5.Text = "To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 265);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = "From";
            // 
            // AmountScrollBar
            // 
            this.AmountScrollBar.Location = new System.Drawing.Point(39, 232);
            this.AmountScrollBar.Maximum = 1000;
            this.AmountScrollBar.Minimum = 1;
            this.AmountScrollBar.Name = "AmountScrollBar";
            this.AmountScrollBar.Size = new System.Drawing.Size(304, 17);
            this.AmountScrollBar.SmallChange = 0;
            this.AmountScrollBar.TabIndex = 29;
            this.AmountScrollBar.Value = 1;
            this.AmountScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.AmountScrollBar_Scroll);
            // 
            // To
            // 
            this.To.BackColor = System.Drawing.SystemColors.MenuBar;
            this.To.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.To.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.To.ForeColor = System.Drawing.Color.DimGray;
            this.To.FormattingEnabled = true;
            this.To.Items.AddRange(new object[] {
            "EUR",
            "PL",
            "USD"});
            this.To.Location = new System.Drawing.Point(215, 286);
            this.To.Margin = new System.Windows.Forms.Padding(4);
            this.To.Name = "To";
            this.To.Size = new System.Drawing.Size(128, 33);
            this.To.TabIndex = 27;
            this.To.SelectedIndexChanged += new System.EventHandler(this.To_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.label1.Location = new System.Drawing.Point(33, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 33);
            this.label1.TabIndex = 26;
            this.label1.Text = "Let\'s Convert";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(39, 369);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(304, 51);
            this.button1.TabIndex = 25;
            this.button1.Text = "CONVERT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Enter Amount";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(380, 657);
            this.Controls.Add(this.From);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Round_checkBox);
            this.Controls.Add(this.result2);
            this.Controls.Add(this.result1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.EnterAmount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AmountScrollBar);
            this.Controls.Add(this.To);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Currency Converter";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox From;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox Round_checkBox;
        private System.Windows.Forms.Label result2;
        private System.Windows.Forms.Label result1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox EnterAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.HScrollBar AmountScrollBar;
        private System.Windows.Forms.ComboBox To;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
    }
}

