using System;
using System.Drawing;
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
            MessageBox.Show("SelectMaxWord");
        }

        private void SelectMaxParagraph()
        {
            MessageBox.Show("SelectMaxParagraph");
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

        public void SetFont()
        {
        }

        public void SetSize(String value, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //s.Replace('.', '.');
                    Int32 size = Convert.ToInt32(value.Trim());
                    if (_richTextBox.SelectionLength > 0)
                    {
                        //var style = richTextBox1.SelectionFont.Style;
                        _richTextBox.SelectionFont = new Font(_richTextBox.SelectionFont.Name, size);
                    }

                    else
                    {
                        //var style = richTextBox1.SelectionFont.Style;
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