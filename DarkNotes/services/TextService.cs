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

        private void SelectMaxWord()
        {
            int index = _richTextBox.SelectionStart;
            int rightBorder = _richTextBox.Find(new char[] {' '}, index);
            int i = 0;
            foreach (char symbol in _richTextBox.Text.Substring(0, index).Reverse())
            {
                if (symbol == ' ' || symbol == '\n' || symbol == '\r')
                {
                    break;
                }

                i--;
            }

            int leftDot = index + i;
            _richTextBox.Select(leftDot, rightBorder - leftDot);
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

            // ToDO: убрать этот говнокод тоже
            //_richTextBox.DeselectAll();
        }

        public void SetAlignment(HorizontalAlignment alignment)
        {
            _richTextBox.SelectionAlignment = alignment;
        }

        public void SetFont(String fontName)
        {
            try
            {
                _richTextBox.SelectionFont = new Font(fontName, _richTextBox.SelectionFont.Size);
            }
            catch (Exception e)
            {
                // ToDo: разобраться
                MessageBox.Show("Что-то пошло не так.");
            }
        }

        public void SetSize(String value, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Int32 size = Convert.ToInt32(value.Trim());
                    if (_richTextBox.SelectionLength == 0)
                    {
                        //ToDo: fix things
                        SelectMaxWord();
                    }

                    _richTextBox.SelectionFont = new Font(_richTextBox.SelectionFont.Name, size);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("This is not a number. Or smth is just wrong, I dunno? Please use int \n");
                }
            }
        }
    }
}