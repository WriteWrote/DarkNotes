using System;
using System.Windows.Forms;
using DarkNotes.Forms;

namespace DarkNotes
{
    public class AppearanceService
    {
        private Int32 _leftInd = 25;
        private Int32 _redLine = 40;
        private Int32 _rightInd = 20;

        public int LeftInd
        {
            get => _leftInd;
            set => _leftInd = value;
        }

        public int RedLine
        {
            get => _redLine;
            set => _redLine = value;
        }

        public int RightInd
        {
            get => _rightInd;
            set => _rightInd = value;
        }

        public void SetIndents(RichTextBox richTextBox1)
        {
            richTextBox1.SelectionIndent = _leftInd + _redLine;
            richTextBox1.SelectionHangingIndent = -_redLine;
            richTextBox1.SelectionRightIndent = _rightInd;
        }

        public void SetOpacity(String s, Form1 app)
        {
            try
            {
                Double opacity = Convert.ToDouble(s);
                app.Opacity = opacity / 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show("This is not a number. Or smth is just wrong, I dunno? Try int there \n" + ex);
            }
        }

        public void FindSubstring()
        {
            MessageBox.Show("finding substring");
            //richTextBox1.Find("Text", RichTextBoxFinds.MatchCase);
        }
    }
}