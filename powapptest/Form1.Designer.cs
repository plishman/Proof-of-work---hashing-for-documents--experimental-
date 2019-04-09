namespace powapptest
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtMd5Sum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMd5SummodMod = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.lblNumIterations = new System.Windows.Forms.Label();
            this.txtNumIterations = new System.Windows.Forms.TextBox();
            this.txtFoundSaltValue = new System.Windows.Forms.TextBox();
            this.lblSalt = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTestResult = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 185);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(776, 253);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // txtMd5Sum
            // 
            this.txtMd5Sum.Location = new System.Drawing.Point(12, 22);
            this.txtMd5Sum.Name = "txtMd5Sum";
            this.txtMd5Sum.Size = new System.Drawing.Size(234, 20);
            this.txtMd5Sum.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "text MD5SUM";
            // 
            // txtMod
            // 
            this.txtMod.Location = new System.Drawing.Point(12, 48);
            this.txtMod.Name = "txtMod";
            this.txtMod.Size = new System.Drawing.Size(100, 20);
            this.txtMod.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mod";
            // 
            // txtMd5SummodMod
            // 
            this.txtMd5SummodMod.Location = new System.Drawing.Point(12, 74);
            this.txtMd5SummodMod.Name = "txtMd5SummodMod";
            this.txtMd5SummodMod.Size = new System.Drawing.Size(100, 20);
            this.txtMd5SummodMod.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "MD5SUM mod Mod";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(14, 100);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(205, 23);
            this.btnFind.TabIndex = 8;
            this.btnFind.Text = "Find MD5SUM mod Mod = 0";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lblNumIterations
            // 
            this.lblNumIterations.AutoSize = true;
            this.lblNumIterations.Location = new System.Drawing.Point(225, 105);
            this.lblNumIterations.Name = "lblNumIterations";
            this.lblNumIterations.Size = new System.Drawing.Size(102, 13);
            this.lblNumIterations.TabIndex = 9;
            this.lblNumIterations.Text = "Number of Iterations";
            // 
            // txtNumIterations
            // 
            this.txtNumIterations.Location = new System.Drawing.Point(333, 102);
            this.txtNumIterations.Name = "txtNumIterations";
            this.txtNumIterations.Size = new System.Drawing.Size(100, 20);
            this.txtNumIterations.TabIndex = 10;
            // 
            // txtFoundSaltValue
            // 
            this.txtFoundSaltValue.Location = new System.Drawing.Point(333, 128);
            this.txtFoundSaltValue.Name = "txtFoundSaltValue";
            this.txtFoundSaltValue.Size = new System.Drawing.Size(100, 20);
            this.txtFoundSaltValue.TabIndex = 11;
            // 
            // lblSalt
            // 
            this.lblSalt.AutoSize = true;
            this.lblSalt.Location = new System.Drawing.Point(225, 131);
            this.lblSalt.Name = "lblSalt";
            this.lblSalt.Size = new System.Drawing.Size(85, 13);
            this.lblSalt.TabIndex = 12;
            this.lblSalt.Text = "Found salt value";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(439, 126);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(122, 23);
            this.btnTest.TabIndex = 13;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(567, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Mod (test result)";
            // 
            // txtTestResult
            // 
            this.txtTestResult.Location = new System.Drawing.Point(655, 128);
            this.txtTestResult.Name = "txtTestResult";
            this.txtTestResult.Size = new System.Drawing.Size(100, 20);
            this.txtTestResult.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(652, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "* should return 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTestResult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.lblSalt);
            this.Controls.Add(this.txtFoundSaltValue);
            this.Controls.Add(this.txtNumIterations);
            this.Controls.Add(this.lblNumIterations);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMd5SummodMod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMd5Sum);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtMd5Sum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMd5SummodMod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label lblNumIterations;
        private System.Windows.Forms.TextBox txtNumIterations;
        private System.Windows.Forms.TextBox txtFoundSaltValue;
        private System.Windows.Forms.Label lblSalt;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTestResult;
        private System.Windows.Forms.Label label5;
    }
}

