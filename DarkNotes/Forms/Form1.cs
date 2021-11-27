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
        private Double _opacity = 95;
        private Int32 _size = 14;

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
            // ToDo: make equal 5.1 and 5,1 when recieving text
            if (e.KeyCode == Keys.Enter)
            {
                String s = toolStripTextBox1.Text;
                try
                {
                    Int32 size = Convert.ToInt32(s.Trim());
                    this._size = size;
                    //richTextBox1.SelectionFont = new Font("Tahoma", this._size, FontStyle.Regular);
                    richTextBox1.Font = new Font("Tahoma", this._size, FontStyle.Regular);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("This is not a number. Or smth is just wrong, I dunno?");
                }
            }
        }

        private void toolStripTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            // ToDo: make equal 5.1 and 5,1 when recieving text
            // или можно просто сделать, чтобы принимали только инт
            if (e.KeyCode == Keys.Enter)
            {
                String s = toolStripTextBox2.Text;
                try
                {
                    Double opacity = Convert.ToDouble(s.Trim());
                    //this._opacity = opacity;
                    this.Opacity = opacity/100;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("This is not a number. Or smth is just wrong, I dunno? Try int there");
                }
            }
        }
    }
}