using System.Windows.Forms;

namespace DarkNotes
{
    public class AppService
    {
        private Form1 app;

        public AppService(Form1 app)
        {
            this.app = app;
        }

        public void CloseApp(FileService save, bool hasNotSavedText)
        {
            if (hasNotSavedText)
            {
                // ToDo: make the app to understand when text is saved and there is no need in asking for saving
                DialogResult result = MessageBox.Show("Do you want to save all of your valuable writing?",
                    "Closing the app", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    save.SaveFile();
                }
                else
                {
                    if (result == DialogResult.Cancel)
                        return;
                }
            }

            app.Close();
        }

        public void HideApp()
        {
            app.WindowState = FormWindowState.Minimized;
        }

        public void ResizeApp()
        {
            if (app.WindowState == FormWindowState.Maximized)
            {
                app.WindowState = FormWindowState.Normal;
            }
            else
            {
                app.WindowState = FormWindowState.Maximized;
            }
        }
    }
}