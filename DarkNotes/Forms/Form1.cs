using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using Font = System.Drawing.Font;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;

namespace DarkNotes.Forms
{
    public partial class Form1 : Form
    {
        public static AppearanceService AppearanceService { get; set; }
        public static AppService AppService;
        public static FileService FileService;
        public static TextService TextService;

        public Form1()
        {
            InitializeComponent();
            AppearanceService = new AppearanceService();
            AppService = new AppService(this);
            FileService = new FileService("", saveFileDialog, openFileDialog, richTextBox1);
            TextService = new TextService(richTextBox1);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // sets the ability to choose color of font from font dialog
            fontDialog.ShowColor = true;

            InitializeOpenDialog();
            InitializeSaveDialog();

            // makes richtextbox keep visual selection, when focus is lost 
            richTextBox1.HideSelection = false;

            // Filling the combobox of fonts
            InitializeFonts();

            AppearanceService.SetIndents(richTextBox1);
        }

        #region InitialisingMethods

        private void InitializeOpenDialog()
        {
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = false;

            openFileDialog.Title = "Выберите файл";
            openFileDialog.DefaultExt = "*.rtf";
            openFileDialog.Filter = "RTF Files|*.rtf";
            openFileDialog.AddExtension = true;
        }

        private void InitializeSaveDialog()
        {
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.Title = "Сохранение";
            saveFileDialog.DefaultExt = "*.rtf";
            saveFileDialog.Filter = "RTF Files|*.rtf";
            saveFileDialog.AddExtension = true;
        }

        private void InitializeFonts()
        {
            InstalledFontCollection fontFamilies = new InstalledFontCollection();
            foreach (FontFamily family in fontFamilies.Families)
            {
                toolStripComboBox1.Items.Add(family.Name);
            }

            Int32 i = toolStripComboBox1.Items.IndexOf("Century");
            toolStripComboBox1.SelectedIndex = i;
        }

        private void refreshFont()
        {
            Font f = richTextBox1.SelectionFont;
            toolStripTextBox1.Text = f.Size.ToString();
            toolStripComboBox1.SelectedItem =
                toolStripComboBox1.Items[toolStripComboBox1.Items.IndexOf(f.Name)];
        }

        #endregion

        #region TextProperties

        /// <summary>
        /// Changes font of text/picked text. Picks the font from combobox (from toolbox)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextService.SetFont(toolStripComboBox1.SelectedItem.ToString());
        }

        /// <summary>
        /// Invokes method for changing font of text/picked text, if user taps Enter in font-combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextService.SetFont(toolStripComboBox1.SelectedItem.ToString());
            }
        }

        ///<summary>
        /// Changing size of text
        /// If text's picked, changes size only for picked part
        /// Receives Int from textBox1 (toolStrip1) + Enter
        /// <value>Changes the global _currentSize</value>
        ///</summary>
        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextService.SetSize(toolStripTextBox1.Text.Trim());
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

            richTextBox1.SelectAll();
            richTextBox1.SelectionFont = fontDialog.Font;
            richTextBox1.SelectionColor = fontDialog.Color;
            richTextBox1.DeselectAll();

            refreshFont();
        }

        #region FontStyle

        /// <summary>
        /// Sets text into bold.
        /// Can be related to part of text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
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

        #endregion

        #endregion

        #region Alignment

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

                    AppearanceService.RedLine = redLine;
                    AppearanceService.SetIndents(richTextBox1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "This is not a number. Or smth is just wrong, I dunno? Try int there. Those are pixels, not sms" +
                        ex);
                }
            }
        }

        #region Indentation

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

        private void toolStripTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            // ToDo: место для междустрочного интервала
        }

        #endregion

        #endregion

        #region WorkWithFiles

        /// <summary>
        /// Opens & displays new file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FileService.OpenFile();
            AppearanceService.SetIndents(richTextBox1);
            // set picked font to the combobox
            refreshFont();
        }

        /// <summary>
        /// Saves current file. Can invoke "save as" method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FileService.SaveFile();
        }

        /// <summary>
        /// Saves text to new file using SaveFileDialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FileService.SaveAsFile();
        }

        /// <summary>
        /// Clears the text-panel.
        /// If needed, invokes message dialog and save-method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileService.NewFile();
        }

        #endregion

        #region BasicAppFunction

        /// <summary>
        /// Closes the app. Invokes "save" method if there is text in the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            AppService.CloseApp(FileService, richTextBox1.TextLength > 0);
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
        /// Changes opacity of form
        /// Receives number from textbox2, toolstrip1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AppearanceService.SetOpacity(toolStripTextBox2.Text.Trim(), this);
            }
        }

        #endregion

        #region FormsCalls

        /// <summary>
        /// Invokes IndentsForm to set boundaries and indents.
        /// Passes the link to current Form1 instance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            IndentsForm newForm = new IndentsForm(AppearanceService, richTextBox1);
            newForm.Show();
        }

        #endregion

        #region KeyboardEvents

        /// <summary>
        /// Hot keys.
        /// need to make a dict/factory to get rid of ifs. also need to make a library to get rid of invoking handlers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // BUG: клавиатурные сокращения ломают вид формы
            //ToDo: сделать словарь или что-то вроде того для них
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

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // ToDo: пофиксить баг с переходом на строки вверх-вниз и с задержкой определения параметров
            //refreshFont();
        }

        #endregion
    }
}