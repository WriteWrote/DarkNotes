﻿using System;
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

        private void SelectMaxWord()
        {
            int index = _rtb.SelectionStart;
            int rightBorder = _rtb.Find(new char[] {' ', '\n', '\r', '\t'}, index);
            int i = 0;
            foreach (char symbol in _rtb.Text.Substring(0, index).Reverse())
            {
                if (symbol == ' ' || symbol == '\n' || symbol == '\r' || symbol == '\t')
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
            //ToDo: пересмотреть это условие, в нем вся проблема
            //if (_richTextBox.SelectionFont.Style.Equals(style))
            
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

            // ToDO: убрать этот говнокод тоже
            //_richTextBox.DeselectAll();
        }

        //TODO: реструктурировать код Form1.cs с region
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
                // ToDo: разобраться
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
                    //ToDo: fix things
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