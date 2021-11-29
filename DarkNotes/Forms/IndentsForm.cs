using System;
using System.Windows.Forms;

namespace DarkNotes
{
    public partial class IndentsForm : Form
    {
        public IndentsForm()
        {
            InitializeComponent();
        }

        private void IndentsForm_Load(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // IndentsForm
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "IndentsForm";
            this.Load += new System.EventHandler(this.IndentsForm_Load);
            this.ResumeLayout(false);
        }
    }
}