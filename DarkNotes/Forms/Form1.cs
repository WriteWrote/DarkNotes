using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkNotes
{
    public partial class Form1 : Form
    {
        public static double DefaultOpacity { get; } = 95;
        private Int32 _currentSize = 14;
        private String _currentFont = "Century";
        private String _currentText = "";
        private String _currentFilename = "";

        public Form1()
        {
            InitializeComponent();
            richTextBox1.SelectionIndent = 70;
            richTextBox1.SelectionHangingIndent = -40;
            richTextBox1.SelectionRightIndent = 20;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Fuck!");
        }

        ///<summary>
        /// Changing size of text
        /// If text's picked, changes size only for picked part
        /// Receives Int from textBox1 (toolStrip1) + Enter
        /// <value>Changes the global _currentSize</value>
        ///</summary>
        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // ToDo: fix bug that when you click into the textbox for size the visual of picked text goes back to unpicked.

            if (e.KeyCode == Keys.Enter)
            {
                String s = toolStripTextBox1.Text;
                try
                {
                    //s.Replace('.', '.');
                    Int32 size = Convert.ToInt32(s.Trim());
                    _currentSize = size;
                    if (richTextBox1.SelectionLength > 0)
                    {
                        richTextBox1.SelectionFont = new Font(_currentFont, size, FontStyle.Regular);
                    }
                    else
                    {
                        richTextBox1.Font = new Font(_currentFont, size, FontStyle.Regular);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("This is not a number. Or smth is just wrong, I dunno? Please use int");
                }
            }
        }

        /// <summary>
        /// Changes opacity of form
        /// Receives number from textbox2, toolstrip1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            // или можно просто сделать, чтобы принимали только инт

            if (e.KeyCode == Keys.Enter)
            {
                String s = toolStripTextBox2.Text;
                try
                {
                    Double opacity = Convert.ToDouble(s.Trim());
                    //this._opacity = opacity;
                    this.Opacity = opacity / 100;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("This is not a number. Or smth is just wrong, I dunno? Try int there");
                }
            }
        }

        /// <summary>
        /// Sets text into bold.
        /// Can be related to part of text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // ToDo: make second click on the style button reverse style to normal
            // ToDo: make styles combinated

            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.SelectionFont = new Font(_currentFont, _currentSize, FontStyle.Bold);
            }
            else
            {
                richTextBox1.Font = new Font(_currentFont, _currentSize, FontStyle.Bold);
            }
        }

        /// <summary>
        /// Sets text into italic.
        /// Can be related to part of text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // get italic text

            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.SelectionFont = new Font(_currentFont, _currentSize, FontStyle.Italic);
            }
            else
            {
                richTextBox1.Font = new Font(_currentFont, _currentSize, FontStyle.Italic);
            }
        }

        /// <summary>
        /// Sets text into underlined.
        /// Can be related to part of text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.SelectionFont = new Font(_currentFont, _currentSize, FontStyle.Underline);
            }
            else
            {
                richTextBox1.Font = new Font(_currentFont, _currentSize, FontStyle.Underline);
            }
        }

        /// <summary>
        /// Changes text into strikeout.
        /// Can be related to part of text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.SelectionFont = new Font(_currentFont, _currentSize, FontStyle.Strikeout);
            }
            else
            {
                richTextBox1.Font = new Font(_currentFont, _currentSize, FontStyle.Strikeout);
            }
        }

        // ToDo: don't lose! --> richTextBox1.SelectedText
        //ToDo: don't lose! --> richTextBox1.GetFirstCharIndexOfCurrentLine()
        /// <summary>
        /// Sets left alignment to picked text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            }
        }

        /// <summary>
        /// Sets left alignment to picked text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            }
        }

        /// <summary>
        /// Sets right alignment to picked text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            }
        }

        /// <summary>
        /// Opens & displays new file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // toolStripMenuItem1 == "File"
            // ToDo: set cursor on the first line of new text

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            _currentFilename = openFileDialog1.FileName;
            string text = System.IO.File.ReadAllText(_currentFilename);
            _currentText = text;
            richTextBox1.Text = text;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            _currentText = richTextBox1.Text;
            System.IO.File.WriteAllText(_currentFilename, _currentText);
            MessageBox.Show("Your text is safe now!");
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            _currentFilename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            _currentText = richTextBox1.Text;
            System.IO.File.WriteAllText(_currentFilename, _currentText);
            MessageBox.Show("Your text's safe! Don't forget the new name of file now and don't lose it");
        }
    }
}