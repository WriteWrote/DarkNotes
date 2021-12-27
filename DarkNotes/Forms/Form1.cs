using System;
using System.Drawing;
using System.Drawing.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Windows.Input;
using Color = System.Drawing.Color;
using Font = System.Drawing.Font;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;

namespace DarkNotes
{
    public partial class Form1 : Form
    {
        public static AppearanceService AppearanceService;
        public static AppService AppService;
        public static FileService FileService;
        public static TextService TextService;

        // public static double DefaultOpacity { get; } = 93;
        // private Int32 _currentSize = 18;
        // private Int32 _leftInd = 25;
        // private Int32 _redLine = 40;
        // private Int32 _rightInd = 20;
        //
        // private String _currentFont = "Corbel Light";
        // private String _currentText = "";
        //
        // private String _currentFilename = "";
        //private FormWindowState _currentWindowState = FormWindowState.Normal;

        public Form1()
        {
            InitializeComponent();
            AppearanceService = new AppearanceService();
            AppService = new AppService(this);
            FileService = new FileService("", saveFileDialog1, openFileDialog1);
            TextService = new TextService(richTextBox1);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // sets the ability to choose color of font from font dialog
            fontDialog.ShowColor = true;

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Multiselect = false;

            openFileDialog1.Title = "Выберите файл";
            openFileDialog1.DefaultExt = "*.rtf";
            openFileDialog1.Filter = "RTF Files|*.rtf";
            openFileDialog1.AddExtension = true;

            // Filling the combobox of fonts
            InitializeFonts();

            // toolStripTextBox1.Text = _currentSize.ToString();
            // toolStripTextBox2.Text = DefaultOpacity.ToString();

            AppearanceService.SetIndents(richTextBox1);

//            toolStripTextBox4.Text = _redLine.ToString();
        }

        private void InitializeFonts()
        {
            InstalledFontCollection fontFamilies = new InstalledFontCollection();
            foreach (FontFamily family in fontFamilies.Families)
            {
                //toolStripComboBox1.Font = new Font(family.Name, 14);
                toolStripComboBox1.Items.Add(family.Name);
            }

            takeSample();
            int ind = toolStripComboBox1.Items.IndexOf(richTextBox1.SelectionFont);
            toolStripComboBox1.Text = toolStripComboBox1.Items[ind].ToString();
        }

        private void takeSample()
        {
            richTextBox1.Select(0, 1);
        }

        // public void SetIndents()
        // {
        //     richTextBox1.SelectAll();
        //     richTextBox1.SelectionIndent = _leftInd + _redLine;
        //     richTextBox1.SelectionHangingIndent = -_redLine;
        //     richTextBox1.SelectionRightIndent = _rightInd;
        //     richTextBox1.DeselectAll();
        // }

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
            TextService.SetSize(toolStripTextBox1.Text.Trim(), e);
        }

        /// <summary>
        /// Changes opacity of form
        /// Receives number from textbox2, toolstrip1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            AppearanceService.SetOpacity(toolStripTextBox2.Text.Trim(), e, this);
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

            TextService.SetFontStyle(FontStyle.Bold);
        }

        /// <summary>
        /// Sets text into italic.
        /// Can be related to part of text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            TextService.SetFontStyle(FontStyle.Italic);
        }

        /// <summary>
        /// Sets text into underlined.
        /// Can be related to part of text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            TextService.SetFontStyle(FontStyle.Underline);
        }

        /// <summary>
        /// Changes text into strikeout.
        /// Can be related to part of text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            TextService.SetFontStyle(FontStyle.Strikeout);
        }

        //ToDo: don't lose! --> richTextBox1.GetFirstCharIndexOfCurrentLine()
        /// <summary>
        /// Sets left alignment to picked text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            TextService.SetAlignment(HorizontalAlignment.Left);
        }

        /// <summary>
        /// Sets center alignment to picked text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            TextService.SetAlignment(HorizontalAlignment.Center);
        }

        /// <summary>
        /// Sets right alignment to picked text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            TextService.SetAlignment(HorizontalAlignment.Right);
        }

        // private void SaveWithColors(Color left, Color right)
        // {
        //     richTextBox1.SelectAll();
        //     richTextBox1.ForeColor = left;
        //     richTextBox1.SelectionIndent = -richTextBox1.SelectionHangingIndent;
        //     richTextBox1.SelectionRightIndent = 0;
        //
        //     richTextBox1.SaveFile(_currentFilename);
        //
        //     richTextBox1.ForeColor = right;
        //     SetIndents();
        //     richTextBox1.DeselectAll();
        // }

        /// <summary>
        /// Opens & displays new file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FileService.OpenFile(richTextBox1);
            // if (!"".Equals(_currentFilename) || !"".Equals(_currentText) || richTextBox1.TextLength > 0)
            // {
            //     DialogResult result = MessageBox.Show("Do you want to save all of your valuable writing?",
            //         "Opening new file", MessageBoxButtons.YesNoCancel);
            //     if (result == DialogResult.Yes)
            //     {
            //         this.toolStripMenuItem3_Click(sender, e);
            //     }
            //     else if (result == DialogResult.Cancel)
            //         return;
            // }
            //
            // if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            //     return;
            //
            // richTextBox1.ResetForeColor();
            // _currentFilename = openFileDialog1.FileName;
            // richTextBox1.LoadFile(_currentFilename);
            // richTextBox1.ForeColor = Color.White;
            /*
            // sample of the text
            richTextBox1.Select(0, 1);
            _currentFont = richTextBox1.SelectionFont.Name;
            _currentSize = Convert.ToInt32(richTextBox1.SelectionFont.Size);
            richTextBox1.DeselectAll();
            _currentText = richTextBox1.Rtf;

            // set combobox
            int ind = toolStripComboBox1.Items.IndexOf(_currentFont);
            toolStripComboBox1.Text = toolStripComboBox1.Items[ind].ToString();

            //set size of text
            toolStripTextBox1.Text = _currentSize.ToString();
*/
            //TODo: void refresh settings for refreshing of _currents' and form values
            //SetIndents();
        }

        /// <summary>
        /// Saves current file. Can invoke "save as" method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FileService.SaveFile();
            // if ("".Equals(_currentFilename))
            // {
            //     toolStripMenuItem4_Click(sender, e);
            // }
            // else
            // {
            //     SaveWithColors(Color.Black, Color.White);
            //
            //     MessageBox.Show("Your text is safe now!");
            // }
        }

        /// <summary>
        /// Saves text to new file using SaveFileDialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FileService.SaveAsFile();
            // if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            //     return;
            //
            // _currentFilename = saveFileDialog1.FileName;
            //
            // if (!_currentFilename.Contains(".rtf"))
            // {
            //     _currentFilename = _currentFilename.Trim();
            //     _currentFilename += ".rtf";
            // }
            //
            // SaveWithColors(Color.Black, Color.White);
            // MessageBox.Show("Your text's safe! Don't forget the new name of file now and don't lose it");
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
                AppService.CloseApp(FileService);
            }
        }

        /// <summary>
        /// Hides window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            AppService.HideApp();
        }

        /// <summary>
        /// Makes app fill the window. Second press sets app to usual size 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            AppService.ResizeApp();
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
                richTextBox1.SelectionFont = new Font(selectedFont, _currentSize);
            }
            else
            {
                richTextBox1.Font = new Font(selectedFont, _currentSize);
            }

            _currentFont = selectedFont;
        }

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

        /// <summary>
        /// Clears the text-panel.
        /// If needed, invokes message dialog and save-method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                DialogResult result = MessageBox.Show("Do you want to save all of your valuable writing?",
                    "Closing the app", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    this.toolStripMenuItem3_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                    return;
            }

            richTextBox1.Clear();
            // reset to default
        }

        private void findSubstring()
        {
            MessageBox.Show("Finding substring");
        }

        private void changeOpacity()
        {
            MessageBox.Show("Changing opacity");
        }

        /// <summary>
        /// Hot keys.
        /// need to make a dict/factory to get rid of ifs. also need to make a library to get rid of invoking handlers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //BUG
            // if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            // {
            //     // save, save as, open, new
            //     if (Keyboard.IsKeyDown(Key.S))
            //         toolStripMenuItem3_Click(sender, e);
            //     if (Keyboard.IsKeyDown(Key.O))
            //         toolStripMenuItem2_Click(sender, e);
            //     if ((Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
            //         && Keyboard.IsKeyDown(Key.S))
            //         toolStripMenuItem4_Click(sender, e);
            //     if (Keyboard.IsKeyDown(Key.N))
            //         newToolStripMenuItem_Click(sender, e);
            //     // find substring
            //     if (Keyboard.IsKeyDown(Key.F))
            //         findSubstring();
            //     // font styles
            //     if (Keyboard.IsKeyDown(Key.B))
            //         toolStripButton1_Click(sender, e);
            //     if (Keyboard.IsKeyDown(Key.I))
            //         toolStripButton2_Click(sender, e);
            //     if (Keyboard.IsKeyDown(Key.U))
            //         toolStripButton3_Click(sender, e);
            //     if (Keyboard.IsKeyDown(Key.S) && Keyboard.IsKeyDown(Key.T))
            //         toolStripButton4_Click(sender, e);
            //     // alignment
            //     if (Keyboard.IsKeyDown(Key.C))
            //         toolStripButton6_Click(sender, e);
            //     if (Keyboard.IsKeyDown(Key.L))
            //         toolStripButton5_Click(sender, e);
            //     if (Keyboard.IsKeyDown(Key.R))
            //         toolStripButton7_Click(sender, e);
            //     // opacity, hide window, minimize/maximize, close app
            //     if (Keyboard.IsKeyDown(Key.O))
            //         changeOpacity();
            //     if (Keyboard.IsKeyDown(Key.H))
            //         toolStripButton10_Click(sender, e);
            //     if (Keyboard.IsKeyDown(Key.M))
            //         toolStripButton11_Click(sender, e);
            //     if (Keyboard.IsKeyDown(Key.R))
            //         toolStripButton12_Click(sender, e);
            //}
        }
    }
}