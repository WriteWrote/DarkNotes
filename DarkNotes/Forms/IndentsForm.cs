using System;
using System.Drawing;
using System.Windows.Forms;

namespace DarkNotes
{
    public partial class IndentsForm : Form
    {
        private Form1 _linkToForm;

        public IndentsForm()
        {
            InitializeComponent();
        }

        public IndentsForm(Form1 f)
        {
            _linkToForm = f;
        }

        private void IndentsForm_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Closes the app. Invokes "save" method if there is text in the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        

        
/*
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
        }*/
    }
}