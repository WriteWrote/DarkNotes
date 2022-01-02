using System;
using System.Drawing;
using System.Windows.Forms;

namespace DarkNotes
{
    public partial class IndentsForm : Form
    {
        private AppearanceService _appearanceService;
        private RichTextBox _richTextBox;

        public IndentsForm()
        {
            InitializeComponent();
        }

        public IndentsForm(AppearanceService appearanceService, RichTextBox richTextBox)
        {
            InitializeComponent();
            _appearanceService = appearanceService;
            _richTextBox = richTextBox;

            textBox4.Text = _appearanceService.LeftInd.ToString();
            textBox3.Text = _appearanceService.RightInd.ToString();
            textBox1.Text = "0";
            textBox2.Text = "0";
        }

        private void IndentsForm_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Closes the IndentForm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_X_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetIndentation(Int32 left, Int32 right)
        {
            _appearanceService.LeftInd = left;
            _appearanceService.RightInd = right;
            _appearanceService.SetIndents(_richTextBox);
        }

        /// <summary>
        /// button Apply the indents
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Int32 left = Convert.ToInt32(textBox4.Text.Trim());
            Int32 right = Convert.ToInt32(textBox3.Text.Trim());
            Int32 up = Convert.ToInt32(textBox1.Text.Trim());
            Int32 down = Convert.ToInt32(textBox2.Text.Trim());

            // ToDo: those below we must get from the IndentsForm
            //Int32 redLine = _linkToTextBox.SelectionHangingIndent;
            //Int32 lineIndent = 0;

            this.SetIndentation(left, right);
            this.Close();
        }
    }
}