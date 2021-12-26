using System;
using System.Windows.Forms;

namespace DarkNotes
{
    public class AppearanceService
    {
        private Int32 _leftInd = 25;
        private Int32 _redLine = 40;
        private Int32 _rightInd = 20;

        public void SetIndents(RichTextBox richTextBox1)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionIndent = _leftInd + _redLine;
            richTextBox1.SelectionHangingIndent = -_redLine;
            richTextBox1.SelectionRightIndent = _rightInd;
            richTextBox1.DeselectAll();
        }

        public void SetOpacity()
        {
            
        }

        public void FindSubstring()
        {
        }
    }
}