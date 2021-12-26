using System;
using System.Drawing;
using System.Windows.Forms;

namespace DarkNotes
{
    public class FileService
    {
        private String _currentFilename;
        private SaveFileDialog _saveFileDialog;
        private OpenFileDialog _openFileDialog;

        private String _currentText = "";

        //private FileDialog _fileDialog;
        public FileService(string currentFilename, SaveFileDialog saveFileDialog, OpenFileDialog openFileDialog)
        {
            _currentFilename = currentFilename;
            _saveFileDialog = saveFileDialog;
            _openFileDialog = openFileDialog;
        }

        public string CurrentText
        {
            get => _currentText;
            set => _currentText = value;
        }

        private void InvertColors(Color prevColor, Color newColor)
        {
            // richTextBox1.SelectAll();
            // richTextBox1.ForeColor = left;
            // richTextBox1.SelectionIndent = -richTextBox1.SelectionHangingIndent;
            // richTextBox1.SelectionRightIndent = 0;
            //
            // richTextBox1.SaveFile(_currentFilename);
            //
            // richTextBox1.ForeColor = right;
            // SetIndents();
            // richTextBox1.DeselectAll();
        }

        private void Save()
        {
        }

        public void SaveAsFile()
        {
            if (_saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            _currentFilename = _saveFileDialog.FileName;

            if (!_currentFilename.Contains(".rtf"))
            {
                _currentFilename = _currentFilename.Trim();
                _currentFilename += ".rtf";
            }

            this.InvertColors(Color.Black, Color.White);
            this.Save();
            MessageBox.Show("Your text's safe! Don't forget the new name of file now and don't lose it");
        }

        public void SaveFile()
        {
            if ("".Equals(_currentFilename))
            {
                this.SaveAsFile();
            }
            else
            {
                this.InvertColors(Color.Black, Color.White);
                this.Save();

                MessageBox.Show("Your text is safe now!");
            }
        }

        public void OpenFile(RichTextBox richTextBox1)
        {
            if (!"".Equals(_currentFilename) || !"".Equals(_currentText) || richTextBox1.TextLength > 0)
            {
                DialogResult result = MessageBox.Show("Do you want to save all of your valuable writing?",
                    "Opening new file", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    this.SaveFile();
                }
                else if (result == DialogResult.Cancel)
                    return;
            }

            if (_openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            richTextBox1.ResetForeColor();
            _currentFilename = _openFileDialog.FileName;
            richTextBox1.LoadFile(_currentFilename);
            richTextBox1.ForeColor = Color.White;
            //ToDo: посмотреть, как правильно делать инстансы
            new AppearanceService().SetIndents(richTextBox1);
        }

        public void NewFile(RichTextBox richTextBox1)
        {
            if (richTextBox1.TextLength > 0)
            {
                DialogResult result = MessageBox.Show("Do you want to save all of your valuable writing?",
                    "Closing the app", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    this.SaveFile();
                }
                else if (result == DialogResult.Cancel)
                    return;
            }

            richTextBox1.Clear();
            // reset to default
        }
    }
}