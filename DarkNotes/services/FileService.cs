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
        //private FileDialog _fileDialog;
        public FileService(string currentFilename, SaveFileDialog saveFileDialog, OpenFileDialog openFileDialog)
        {
            _currentFilename = currentFilename;
            _saveFileDialog = saveFileDialog;
            _openFileDialog = openFileDialog;
        }

        private void InvertColors(Color prevColor, Color newColor)
        {
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

        public void OpenFile()
        {
        }

        public void NewFile()
        {
        }
    }
}