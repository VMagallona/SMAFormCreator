namespace SMAFormCreator
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
            this.xmlSource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.changeFormType = new System.Windows.Forms.Button();
            this.changeClientName = new System.Windows.Forms.Button();
            this.clientName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.formType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.resultLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xmlSource
            // 
            this.xmlSource.Location = new System.Drawing.Point(16, 29);
            this.xmlSource.Multiline = true;
            this.xmlSource.Name = "xmlSource";
            this.xmlSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.xmlSource.Size = new System.Drawing.Size(358, 143);
            this.xmlSource.TabIndex = 0;
            this.xmlSource.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Details:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 416);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(358, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "CREATE FORM";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "label3";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(16, 215);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(358, 74);
            this.textBox2.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.changeFormType);
            this.groupBox1.Controls.Add(this.changeClientName);
            this.groupBox1.Controls.Add(this.clientName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.formType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(16, 308);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 91);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Override values - Change some values using the fields below";
            // 
            // changeFormType
            // 
            this.changeFormType.Location = new System.Drawing.Point(277, 23);
            this.changeFormType.Name = "changeFormType";
            this.changeFormType.Size = new System.Drawing.Size(75, 23);
            this.changeFormType.TabIndex = 7;
            this.changeFormType.Text = "Change";
            this.changeFormType.UseVisualStyleBackColor = true;
            this.changeFormType.Click += new System.EventHandler(this.changeFormType_Click);
            // 
            // changeClientName
            // 
            this.changeClientName.Location = new System.Drawing.Point(277, 56);
            this.changeClientName.Name = "changeClientName";
            this.changeClientName.Size = new System.Drawing.Size(75, 23);
            this.changeClientName.TabIndex = 6;
            this.changeClientName.Text = "Change";
            this.changeClientName.UseVisualStyleBackColor = true;
            this.changeClientName.Click += new System.EventHandler(this.changeClientName_Click);
            // 
            // clientName
            // 
            this.clientName.Location = new System.Drawing.Point(94, 58);
            this.clientName.Name = "clientName";
            this.clientName.Size = new System.Drawing.Size(169, 20);
            this.clientName.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Client Name";
            // 
            // formType
            // 
            this.formType.Enabled = false;
            this.formType.FormattingEnabled = true;
            this.formType.Items.AddRange(new object[] {
            "CSC",
            "PTP",
            "CDF",
            "LED",
            "FBF"});
            this.formType.Location = new System.Drawing.Point(94, 24);
            this.formType.Name = "formType";
            this.formType.Size = new System.Drawing.Size(169, 21);
            this.formType.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Form Type";
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(16, 458);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(16, 13);
            this.resultLabel.TabIndex = 13;
            this.resultLabel.Text = "...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 490);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.xmlSource);
            this.Name = "Form1";
            this.Text = "SMA Form Creation Helper";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox xmlSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button changeFormType;
        private System.Windows.Forms.Button changeClientName;
        private System.Windows.Forms.TextBox clientName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox formType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label resultLabel;
    }
}

