namespace Pancake_Sort
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblText = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtNInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPWUEOutput = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listBoxOutA = new System.Windows.Forms.ListBox();
            this.listBoxOutB = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(6, 62);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(149, 20);
            this.lblText.TabIndex = 4;
            this.lblText.Text = "Wendeoperationen:";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(3, 19);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(166, 40);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Datei öffnen";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtNInput
            // 
            this.txtNInput.Location = new System.Drawing.Point(120, 18);
            this.txtNInput.Name = "txtNInput";
            this.txtNInput.Size = new System.Drawing.Size(41, 20);
            this.txtNInput.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Eingabe von n:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPWUEOutput
            // 
            this.lblPWUEOutput.AutoSize = true;
            this.lblPWUEOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPWUEOutput.Location = new System.Drawing.Point(129, 54);
            this.lblPWUEOutput.Name = "lblPWUEOutput";
            this.lblPWUEOutput.Size = new System.Drawing.Size(18, 20);
            this.lblPWUEOutput.TabIndex = 9;
            this.lblPWUEOutput.Text = "8";
            this.lblPWUEOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "PWUE-Zahl";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBoxOutA
            // 
            this.listBoxOutA.FormattingEnabled = true;
            this.listBoxOutA.Location = new System.Drawing.Point(3, 88);
            this.listBoxOutA.Name = "listBoxOutA";
            this.listBoxOutA.Size = new System.Drawing.Size(166, 173);
            this.listBoxOutA.TabIndex = 11;
            // 
            // listBoxOutB
            // 
            this.listBoxOutB.FormattingEnabled = true;
            this.listBoxOutB.Location = new System.Drawing.Point(0, 85);
            this.listBoxOutB.Name = "listBoxOutB";
            this.listBoxOutB.Size = new System.Drawing.Size(171, 160);
            this.listBoxOutB.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Controls.Add(this.listBoxOutA);
            this.groupBox1.Controls.Add(this.lblText);
            this.groupBox1.Location = new System.Drawing.Point(4, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 266);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Teil a)";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(175, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(171, 149);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBoxOutB);
            this.groupBox3.Controls.Add(this.txtNInput);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblPWUEOutput);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(185, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(171, 248);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Teil b)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 280);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtNInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPWUEOutput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBoxOutA;
        private System.Windows.Forms.ListBox listBoxOutB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

