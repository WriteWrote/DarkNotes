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
            int rightBorder = _richTextBox.Find(new char[] {' ', '\n', '\r', '\t'}, index);
            int i = 0;
            foreach (char symbol in _richTextBox.Text.Substring(0, index).Reverse())
            {
                if (symbol == ' ' || symbol == '\n' || symbol == '\r' || symbol == '\t')
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
            //ToDo: пересмотреть это условие, в нем вся проблема
            if (_richTextBox.SelectionFont.Style.Equals(style))
            {
                _richTextBox.SelectionFont = new Font(_richTextBox.SelectionFont.Name,
                    _richTextBox.SelectionFont.Size,
                    _richTextBox.SelectionFont.Style & ~style);
            }
            else
            {
                _richTextBox.SelectionFont = new Font(_richTextBox.SelectionFont.Name,
                    _richTextBox.SelectionFont.Size,
                    _richTextBox.SelectionFont.Style | style);
            }

            // ToDO: убрать этот говнокод тоже
            //_richTextBox.DeselectAll();
        }
        //TODO: реструктурировать код Form1.cs с region
        public void SetAlignment(HorizontalAlignment alignment)
        {
            try
            {
                _richTextBox.SelectionAlignment = alignment;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void SetFont(String fontName)
        {
            try
            {
                _richTextBox.SelectionFont = new Font(fontName, _richTextBox.SelectionFont.Size,
                    _richTextBox.SelectionFont.Style);
            }
            catch (Exception ex)
            {
                // ToDo: разобраться
                MessageBox.Show("Что-то пошло не так." + ex);
            }
        }

        public void SetSize(String value)
        {
            try
            {
                Int32 size = Convert.ToInt32(value.Trim());
                if (_richTextBox.SelectionLength == 0)
                {
                    //ToDo: fix things
                    SelectMaxWord();
                }

                _richTextBox.SelectionFont =
                    new Font(_richTextBox.SelectionFont.Name, size, _richTextBox.SelectionFont.Style);
            }
            catch (Exception ex)
            {
                MessageBox.Show("This is not a number. Or smth is just wrong, I dunno? Please use int \n" + ex);
            }
        }
    }
}