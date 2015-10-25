namespace NanoFundsSeed
{
    partial class NanoFundsSeedDataGenerator
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
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.Generate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(12, 19);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 20);
            this.datePicker.TabIndex = 0;
            this.datePicker.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // Generate
            // 
            this.Generate.Location = new System.Drawing.Point(218, 16);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(75, 23);
            this.Generate.TabIndex = 1;
            this.Generate.Text = "Generate";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // NanoFundsSeedDataGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 53);
            this.Controls.Add(this.Generate);
            this.Controls.Add(this.datePicker);
            this.Name = "NanoFundsSeedDataGenerator";
            this.Text = "Nano Funds Seed Data Generator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Button Generate;
    }
}

