namespace Checkers
{
    partial class Checkers
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
            this.button1 = new System.Windows.Forms.Button();
            this.choosestart = new System.Windows.Forms.Label();
            this.startCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(295, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start Game";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // choosestart
            // 
            this.choosestart.AutoSize = true;
            this.choosestart.BackColor = System.Drawing.SystemColors.Window;
            this.choosestart.Location = new System.Drawing.Point(292, 118);
            this.choosestart.Name = "choosestart";
            this.choosestart.Size = new System.Drawing.Size(85, 13);
            this.choosestart.TabIndex = 1;
            this.choosestart.Text = "Start Game With";
            // 
            // startCombo
            // 
            this.startCombo.Location = new System.Drawing.Point(295, 134);
            this.startCombo.Name = "startCombo";
            this.startCombo.Size = new System.Drawing.Size(121, 21);
            this.startCombo.TabIndex = 0;
            // 
            // Checkers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Checkers.Properties.Resources.startcover;
            this.ClientSize = new System.Drawing.Size(802, 361);
            this.Controls.Add(this.startCombo);
            this.Controls.Add(this.choosestart);
            this.Controls.Add(this.button1);
            this.Name = "Checkers";
            this.Text = "Checkers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label choosestart;
        private System.Windows.Forms.ComboBox startCombo;
    }
}

