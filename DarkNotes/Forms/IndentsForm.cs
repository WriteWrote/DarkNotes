using System;
using System.Drawing;
using System.Windows.Forms;

namespace DarkNotes
{
    public partial class IndentsForm : Form
    {
        private Form1 _linkToF;

        public IndentsForm()
        {
            InitializeComponent();
        }

        public IndentsForm(Form1 f)
        {
            InitializeComponent();
            _linkToF = f;
            textBox4.Text = _linkToF.LeftInd.ToString();
            textBox3.Text = _linkToF.RightInd.ToString();
            textBox1.Text = "0";
            textBox2.Text = "0";
        }

        private void IndentsForm_Load(object sender, EventArgs e)
        {
        }

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
        /// <summary>
        /// Closes the IndentForm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_X_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32 left = Convert.ToInt32(textBox4.Text.Trim());
            Int32 right = Convert.ToInt32(textBox3.Text.Trim());
            Int32 up = Convert.ToInt32(textBox1.Text.Trim());
            Int32 down = Convert.ToInt32(textBox2.Text.Trim());
            
            // ToDo: those below we must get from the IndentsForm
            //Int32 redLine = _linkToTextBox.SelectionHangingIndent;
            //Int32 lineIndent = 0;
            
            _linkToF.LeftInd = left;
            _linkToF.RightInd = right;
            _linkToF.SetIndents();
            //_linkToF.Refresh();
            
            this.Close();
        }
    }
}