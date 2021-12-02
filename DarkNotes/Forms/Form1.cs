using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkNotes
{
    public partial class Form1 : Form
    {
        public static double DefaultOpacity { get; } = 93;
        private Int32 _currentSize = 18;
        private Int32 _leftInd = 25;
        private Int32 _redLine = 40;
        private Int32 _rightInd = 20;

        private String _currentFont = "Corbel Light";
        private String _currentText = "";

        private String _currentFilename = "";
        //private FormWindowState _currentWindowState = FormWindowState.Normal;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // sets the ability to choose color of font from font dialog
            fontDialog.ShowColor = true;

            // Filling the combobox of fonts
            InitializeFonts();

            toolStripTextBox1.Text = _currentSize.ToString();
            toolStripTextBox2.Text = DefaultOpacity.ToString();

            SetIndents();

            toolStripTextBox4.Text = _redLine.ToString();
        }

        public int LeftInd
        {
            get => _leftInd;
            set => _leftInd = value;
        }

        public int RedLine
        {
            get => _redLine;
            set => _redLine = value;
        }

        public int RightInd
        {
            get => _rightInd;
            set => _rightInd = value;
        }

        private void InitializeFonts()
        {
            InstalledFontCollection fontFamilies = new InstalledFontCollection();
            foreach (FontFamily family in fontFamilies.Families)
            {
                //toolStripComboBox1.Font = new Font(family.Name, 14);
                toolStripComboBox1.Items.Add(family.Name);
            }

            int ind = toolStripComboBox1.Items.IndexOf(_currentFont);
            toolStripComboBox1.Text = toolStripComboBox1.Items[ind].ToString();
        }

        public void SetIndents()
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionIndent = _leftInd + _redLine;
            richTextBox1.SelectionHangingIndent = -_redLine;
            richTextBox1.SelectionRightIndent = _rightInd;
            richTextBox1.DeselectAll();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
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
            if (e.KeyCode == Keys.Enter)
            {
                String s = toolStripTextBox2.Text;
                try
                {
                    Double opacity = Convert.ToDouble(s.Trim());
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
            // ToDo: set cursor on the first line of new text

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            _currentFilename = openFileDialog1.FileName;
            string text = System.IO.File.ReadAllText(_currentFilename);
            _currentText = text;
            richTextBox1.Text = text;
        }

        /// <summary>
        /// Saves current file. Can invoke "save as" method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if ("".Equals(_currentFilename))
            {
                //ToDo: learn about Invoke
                toolStripMenuItem4_Click(sender, e);
            }
            else
            {
                _currentText = richTextBox1.Text;
                System.IO.File.WriteAllText(_currentFilename, _currentText);
                MessageBox.Show("Your text is safe now!");
            }
        }

        /// <summary>
        /// Saves text to new file using SaveFileDialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            _currentFilename = saveFileDialog1.FileName;

            if (!_currentFilename.Contains(".txt"))
                _currentFilename += ".txt";

            _currentText = richTextBox1.Text;
            System.IO.File.WriteAllText(_currentFilename, _currentText);
            MessageBox.Show("Your text's safe! Don't forget the new name of file now and don't lose it");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // ToDo: место для клавиатурных сокращений
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            // ToDo: место для междустрочного интервала
            /*
            richTextBox1.ScrollToCaret();
            richTextBox1.CanUndo = true;
            //richTextBox1.Rtf/richTextBox1.SelectedRtf
            //richTextBox1.SaveFile();/richTextBox1.LoadFile();
            //richTextBox1.Find()
            richTextBox1.Paste();
            richTextBox1.SelectAll();*/
        }

        /// <summary>
        /// Closes the app. Invokes "save" method if there is text in the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                // ToDo: make the app to understand when text is saved and there is no need in asking for saving 
                DialogResult result = MessageBox.Show("Do you want to save all of your valuable writing?",
                    "Closing the app", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this.toolStripMenuItem3_Click(sender, e);
                }
            }

            this.Close();
        }

        /// <summary>
        /// Hides window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Makes app fill the window. Second press sets app to usual size 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        /// <summary>
        /// Changes font of text/picked text. Picks the font from combobox (from toolbox)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFont = toolStripComboBox1.SelectedItem.ToString();
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.SelectionFont = new Font(selectedFont, _currentSize, FontStyle.Regular);
            }
            else
            {
                richTextBox1.Font = new Font(selectedFont, _currentSize, FontStyle.Regular);
            }

            _currentFont = selectedFont;
        }

        //ToDo: replace using key codes for "Enter" to the settings of "enter" like the entering the data (at the form)
        //ToDo: сделать так, чтобы кнопки "выравнивание" работали для строки, а не только для выделения
        //ToDo: сделать так, чтобы кнопки Ж, К, ... работали для слова
        //ToDo: сделать так, чтобы при переходе по строкам/ буквам в комбобокс показывался шрифт
        /// <summary>
        /// Invokes method for changing font of text/picked text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripComboBox1_SelectedIndexChanged(sender, e);
            }
        }

        /// <summary>
        /// Opens FontDialog for settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.Cancel)
                return;

            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.SelectionFont = fontDialog.Font;
                richTextBox1.SelectionColor = fontDialog.Color;
            }
            else
            {
                richTextBox1.Font = fontDialog.Font;
                richTextBox1.SelectAll();
                richTextBox1.SelectionColor = fontDialog.Color;
            }
        }

        /// <summary>
        /// Invokes IndentsForm to set boundaries and indents.
        /// Passes the link to current Form1 instance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            IndentsForm newForm = new IndentsForm(this);
            newForm.Show();
        }

        private void toolStripTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            // ToDo: место для междустрочного интервала
        }

        /// <summary>
        /// Sets red line to text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripTextBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String s = toolStripTextBox4.Text;
                try
                {
                    Int32 redLine = Convert.ToInt32(s.Trim());

                    this._redLine = redLine;
                    SetIndents();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "This is not a number. Or smth is just wrong, I dunno? Try int there. Those are pixels, not sms");
                }
            }
        }
    }
}