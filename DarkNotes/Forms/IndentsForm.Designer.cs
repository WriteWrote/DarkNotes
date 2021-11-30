using System.Drawing;

namespace DarkNotes
{
    partial class IndentsForm
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
            this.button_X = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_X
            // 
            this.button_X.BackColor = System.Drawing.SystemColors.Desktop;
            this.button_X.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_X.Font = new System.Drawing.Font("RussianPunk", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.button_X.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_X.Location = new System.Drawing.Point(258, 0);
            this.button_X.Name = "button_X";
            this.button_X.Size = new System.Drawing.Size(40, 40);
            this.button_X.TabIndex = 0;
            this.button_X.Text = "X";
            this.button_X.UseVisualStyleBackColor = false;
            // 
            // IndentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(298, 298);
            this.ControlBox = false;
            this.Controls.Add(this.button_X);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Century", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "IndentsForm";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Red;
            this.Load += new System.EventHandler(this.IndentsForm_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button button_X;

        private System.Windows.Forms.Button button1;

        #endregion
    }
}