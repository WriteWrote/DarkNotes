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


        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // change size

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

        private void toolStripTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            // change opacity
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // get Bold text
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // get underlined text
            
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.SelectionFont = new Font(_currentFont, _currentSize, FontStyle.Underline);
            }
            else
            {
                richTextBox1.Font = new Font(_currentFont, _currentSize, FontStyle.Underline);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            // get strikedOut text
            
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.SelectionFont = new Font(_currentFont, _currentSize, FontStyle.Strikeout);
            }
            else
            {
                richTextBox1.Font = new Font(_currentFont, _currentSize, FontStyle.Strikeout);
            }
        }
    }
}