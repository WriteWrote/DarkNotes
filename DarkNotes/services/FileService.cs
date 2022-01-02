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

        private RichTextBox _richTextBox;

        //private FileDialog _fileDialog;
        public FileService(string currentFilename, SaveFileDialog saveFileDialog,
            OpenFileDialog openFileDialog, RichTextBox richTextBox)
        {
            _currentFilename = currentFilename;
            _saveFileDialog = saveFileDialog;
            _openFileDialog = openFileDialog;
            _richTextBox = richTextBox;
        }

        public string CurrentText
        {
            get => _currentText;
            set => _currentText = value;
        }

        private void InvertColors(Color prevColor, Color newColor)
        {
            string rtf = _richTextBox.Rtf;

            String s1 = "red" + prevColor.R.ToString();
            String s2 = "green" + prevColor.G.ToString();
            String s3 = "blue" + prevColor.B.ToString();
            rtf = rtf.Replace("red" + prevColor.R.ToString(), "red" + newColor.R.ToString());
            rtf = rtf.Replace("green" + prevColor.G.ToString(), "green" + newColor.G.ToString());
            rtf = rtf.Replace("blue" + prevColor.B.ToString(), "blue" + newColor.B.ToString());
            
            

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

        private void Save(Color prev, Color next)
        {
            this.InvertColors(prev, next);
            //_richTextBox.SaveFile(_currentFilename);
        }

        public void SaveAsFile()
        {
            if (_saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            _currentFilename = _saveFileDialog.FileName.Trim();

            if (!_currentFilename.Contains(".rtf"))
            {
                _currentFilename += ".rtf";
            }

            this.Save(Color.White, Color.Black);
            MessageBox.Show("Your text's safe! Don't forget the new name of file now and don't lose it", "Saving file");
        }

        public void SaveFile()
        {
            if ("".Equals(_currentFilename))
            {
                this.SaveAsFile();
            }
            else
            {
                this.Save(Color.White, Color.Black);
                MessageBox.Show("Your text is safe now!", "Saving file");
            }
        }

        public void OpenFile()
        {
            if (!"".Equals(_currentFilename) ||
                //!"".Equals(_currentText) || 
                _richTextBox.TextLength > 0)
            {
                DialogResult result = MessageBox.Show("Do you want to save all of your valuable writing?",
                    "Opening new file",
                    MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    this.SaveFile();
                }
                else if (result == DialogResult.Cancel)
                    return;
            }

            if (_openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            _currentFilename = _openFileDialog.FileName;
            _richTextBox.LoadFile(_currentFilename);
        }

        public void NewFile()
        {
            if (_richTextBox.TextLength > 0)
            {
                DialogResult result = MessageBox.Show("Do you want to save all of your valuable writing?",
                    "Creating new file", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    this.SaveFile();
                }
                else if (result == DialogResult.Cancel)
                    return;
            }

            _richTextBox.Clear();
            _currentFilename = "";
        }
    }
}