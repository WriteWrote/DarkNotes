using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DarkNotes
{
    public class TextService
    {
        private RichTextBox _rtb;

        public TextService(RichTextBox rtb)
        {
            _rtb = rtb;
        }

        /// <summary>
        /// Selects the string wrapped w/ spaces (other stop-symbols), starting from the current position of cursor.
        /// \x020 -- space
        /// \n -- Enter
        /// \r -- возврат каретки
        /// \t -- Tab
        /// </summary>
        private void SelectMaxWord()
        {
            int index = _rtb.SelectionStart;

            int rightBorder = _rtb.Find(new char[] {'\x020', '\n', '\r', '\t'}, index);
            if (rightBorder == -1)
                rightBorder = _rtb.TextLength;

            int i = 0;
            foreach (char symbol in _rtb.Text.Substring(0, index).Reverse())
            {
                if (symbol == '\x020' || symbol == '\n' || symbol == '\t')
                {
                    break;
                }

                i--;
            }

            int leftDot = index + i;
            _rtb.Select(leftDot, rightBorder - leftDot);
        }

        public void SetFontStyle(FontStyle style)
        {
            if (_rtb.SelectionLength == 0)
                SelectMaxWord();

            // ToDo: какие-то проблемы
            if (_rtb.SelectionFont.Style.ToString().Contains(style.ToString()))
            {
                _rtb.SelectionFont = new Font(_rtb.SelectionFont.Name,
                    _rtb.SelectionFont.Size,
                    _rtb.SelectionFont.Style & ~style);
            }
            else
            {
                _rtb.SelectionFont = new Font(_rtb.SelectionFont.Name,
                    _rtb.SelectionFont.Size,
                    _rtb.SelectionFont.Style | style);
            }
        }
        public void SetAlignment(HorizontalAlignment alignment)
        {
            try
            {
                _rtb.SelectionAlignment = alignment;
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
                _rtb.SelectionFont = new Font(fontName, _rtb.SelectionFont.Size,
                    _rtb.SelectionFont.Style);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так." + ex);
            }
        }

        public void SetSize(String value)
        {
            try
            {
                Int32 size = Convert.ToInt32(value.Trim());
                if (_rtb.SelectionLength == 0)
                {
                    SelectMaxWord();
                }

                _rtb.SelectionFont =
                    new Font(_rtb.SelectionFont.Name, size, _rtb.SelectionFont.Style);
            }
            catch (Exception ex)
            {
                MessageBox.Show("This is not a number. Or smth is just wrong, I dunno? Please use int \n" + ex);
            }
        }
    }
}