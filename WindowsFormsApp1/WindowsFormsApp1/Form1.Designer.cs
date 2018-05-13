namespace WindowsFormsApp1
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pictureBoxGradient = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.colorMode2RadioButton = new System.Windows.Forms.RadioButton();
            this.colorMode1RadioButton = new System.Windows.Forms.RadioButton();
            this.checkBoxLowValuesHighlight = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGradient)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 283);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(246, 105);
            this.button1.TabIndex = 1;
            this.button1.Text = "начать отрисовку";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.pictureBox1.Location = new System.Drawing.Point(-84, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 626);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "label4";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(12, 257);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(246, 22);
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "Усиление:";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.pictureBoxGradient);
            this.splitContainer.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer.Panel1MinSize = 900;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer.Panel2.Controls.Add(this.checkBoxLowValuesHighlight);
            this.splitContainer.Panel2.Controls.Add(this.label8);
            this.splitContainer.Panel2.Controls.Add(this.label1);
            this.splitContainer.Panel2.Controls.Add(this.label4);
            this.splitContainer.Panel2.Controls.Add(this.label2);
            this.splitContainer.Panel2.Controls.Add(this.label3);
            this.splitContainer.Panel2.Controls.Add(this.numericUpDown1);
            this.splitContainer.Panel2.Controls.Add(this.button1);
            this.splitContainer.Size = new System.Drawing.Size(1175, 628);
            this.splitContainer.SplitterDistance = 900;
            this.splitContainer.TabIndex = 8;
            // 
            // pictureBoxGradient
            // 
            this.pictureBoxGradient.BackColor = System.Drawing.SystemColors.Menu;
            this.pictureBoxGradient.Location = new System.Drawing.Point(818, 0);
            this.pictureBoxGradient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxGradient.Name = "pictureBoxGradient";
            this.pictureBoxGradient.Size = new System.Drawing.Size(50, 628);
            this.pictureBoxGradient.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGradient.TabIndex = 2;
            this.pictureBoxGradient.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.colorMode2RadioButton);
            this.groupBox1.Controls.Add(this.colorMode1RadioButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 117);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(246, 80);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Цвета";
            // 
            // colorMode2RadioButton
            // 
            this.colorMode2RadioButton.AutoSize = true;
            this.colorMode2RadioButton.Checked = true;
            this.colorMode2RadioButton.Location = new System.Drawing.Point(9, 52);
            this.colorMode2RadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.colorMode2RadioButton.Name = "colorMode2RadioButton";
            this.colorMode2RadioButton.Size = new System.Drawing.Size(86, 21);
            this.colorMode2RadioButton.TabIndex = 1;
            this.colorMode2RadioButton.TabStop = true;
            this.colorMode2RadioButton.Text = "Цветной";
            this.colorMode2RadioButton.UseVisualStyleBackColor = true;
            this.colorMode2RadioButton.CheckedChanged += new System.EventHandler(this.colorMode2RadioButton_CheckedChanged);
            // 
            // colorMode1RadioButton
            // 
            this.colorMode1RadioButton.AutoSize = true;
            this.colorMode1RadioButton.Location = new System.Drawing.Point(9, 25);
            this.colorMode1RadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.colorMode1RadioButton.Name = "colorMode1RadioButton";
            this.colorMode1RadioButton.Size = new System.Drawing.Size(118, 21);
            this.colorMode1RadioButton.TabIndex = 0;
            this.colorMode1RadioButton.Text = "Чёрно-белый";
            this.colorMode1RadioButton.UseVisualStyleBackColor = true;
            this.colorMode1RadioButton.CheckedChanged += new System.EventHandler(this.colorMode1RadioButton_CheckedChanged);
            // 
            // checkBoxLowValuesHighlight
            // 
            this.checkBoxLowValuesHighlight.AutoSize = true;
            this.checkBoxLowValuesHighlight.Location = new System.Drawing.Point(12, 205);
            this.checkBoxLowValuesHighlight.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxLowValuesHighlight.Name = "checkBoxLowValuesHighlight";
            this.checkBoxLowValuesHighlight.Size = new System.Drawing.Size(215, 21);
            this.checkBoxLowValuesHighlight.TabIndex = 14;
            this.checkBoxLowValuesHighlight.Text = "Подсветка низких значений";
            this.checkBoxLowValuesHighlight.UseVisualStyleBackColor = true;
            this.checkBoxLowValuesHighlight.CheckedChanged += new System.EventHandler(this.checkBoxLowValuesHighlight_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 628);
            this.Controls.Add(this.splitContainer);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Spectrogram";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGradient)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.PictureBox pictureBoxGradient;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton colorMode2RadioButton;
        private System.Windows.Forms.RadioButton colorMode1RadioButton;
        private System.Windows.Forms.CheckBox checkBoxLowValuesHighlight;
    }
}

