namespace hw1sv
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
            this.consolelogs = new System.Windows.Forms.RichTextBox();
            this.PorttextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Button_Listen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // consolelogs
            // 
            this.consolelogs.Location = new System.Drawing.Point(67, 108);
            this.consolelogs.Name = "consolelogs";
            this.consolelogs.Size = new System.Drawing.Size(469, 439);
            this.consolelogs.TabIndex = 0;
            this.consolelogs.Text = "";
            // 
            // PorttextBox
            // 
            this.PorttextBox.Location = new System.Drawing.Point(96, 30);
            this.PorttextBox.Name = "PorttextBox";
            this.PorttextBox.Size = new System.Drawing.Size(100, 20);
            this.PorttextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port:";
            // 
            // Button_Listen
            // 
            this.Button_Listen.Location = new System.Drawing.Point(214, 28);
            this.Button_Listen.Name = "Button_Listen";
            this.Button_Listen.Size = new System.Drawing.Size(75, 23);
            this.Button_Listen.TabIndex = 3;
            this.Button_Listen.Text = "Listen";
            this.Button_Listen.UseVisualStyleBackColor = true;
            this.Button_Listen.Click += new System.EventHandler(this.Button_Listen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 559);
            this.Controls.Add(this.Button_Listen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PorttextBox);
            this.Controls.Add(this.consolelogs);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox consolelogs;
        private System.Windows.Forms.TextBox PorttextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Button_Listen;
    }
}

