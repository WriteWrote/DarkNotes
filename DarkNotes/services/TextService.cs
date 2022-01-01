using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DarkNotes
{
    public class TextService
    {
        private RichTextBox _richTextBox;

        public TextService(RichTextBox richTextBox)
        {
            _richTextBox = richTextBox;
        }

        private void Select(char s)
        {
            int index = _richTextBox.SelectionStart;
            int rightBorder = _richTextBox.Find(new char[] {s}, index);
            int i = 0;
            foreach (char symbol in _richTextBox.Text.Substring(0, index).Reverse())
            {
                if (symbol == s)
                {
                    break;
                }

                i--;
            }

            int leftDot = index + i;
            _richTextBox.Select(leftDot, rightBorder - leftDot);
        }

        private void SelectMaxWord()
        {
            Select(' ');
        }

        private void SelectMaxParagraph()
        {
            Select('.');
        }

        public void SetFontStyle(FontStyle style)
        {
            if (_richTextBox.SelectionLength == 0)
                SelectMaxWord();
            if (_richTextBox.SelectionFont.Style.Equals(style))
            {
                _richTextBox.SelectionFont = new Font(_richTextBox.SelectionFont.Name,
                    _richTextBox.SelectionFont.Size,
                    FontStyle.Regular);
            }
            else
            {
                _richTextBox.SelectionFont = new Font(_richTextBox.SelectionFont.Name,
                    _richTextBox.SelectionFont.Size,
                    style);
            }
        }

        public void SetAlignment(HorizontalAlignment alignment)
        {
            if (_richTextBox.SelectionLength == 0)
                SelectMaxParagraph();
            _richTextBox.SelectionAlignment = alignment;
        }

        public void SetFont(String fontName)
        {
            if (_richTextBox.SelectionLength == 0)
                SelectMaxWord();
            _richTextBox.SelectionFont = new Font(fontName, _richTextBox.SelectionFont.Size);
            // ToDO: убрать этот говнокод
            _richTextBox.DeselectAll();
        }

        public void SetSize(String value, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Int32 size = Convert.ToInt32(value.Trim());
                    if (_richTextBox.SelectionLength > 0)
                    {
                        _richTextBox.SelectionFont = new Font(_richTextBox.SelectionFont.Name, size);
                    }

                    else
                    {
                        _richTextBox.Font = new Font(_richTextBox.SelectionFont.Name, size);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("This is not a number. Or smth is just wrong, I dunno? Please use int \n" + ex);
                }
            }
        }
    }
}