using BarbezDotEu.Executor.Wpf.Logic;
using System.Windows;
using System.Windows.Input;

namespace BarbezDotEu.Executor.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] keywords;
        private bool firstClick = true;
        private char[] charsToSplitFrom = new char[] { ',' };
        private int index = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpenNextLinkInBrowser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.tbInput.IsEnabled = false;
                if (tbInput.Text != null && !string.IsNullOrEmpty(tbInput.Text))
                {
                    if (firstClick)
                    {
                        this.keywords = tbInput.Text.Split(charsToSplitFrom);
                        firstClick = false;
                    }
                    if (this.keywords != null)
                    {
                        if (this.keywords.Length > 0)
                        {
                            Generic.OpenWebsite(this.keywords[this.index], true);
                            this.index++;
                        }
                    }
                }
                else this.tbInput.IsEnabled = true;
            }
            catch
            {
                MessageBox.Show("End of the list! You opened everything. Thanks!", "All Done.", MessageBoxButton.OK);
                this.tbInput.IsEnabled = true;
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            this.firstClick = true;
            this.index = 0;
            this.tbInput.IsEnabled = true;
            this.tbInput.Clear();
        }

        private void lblAbout_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Generic.RunExternalProcess("explorer.exe", "http://" + lblAbout.Content + "/BarbezDotEu.Executor/");
        }

        private void lblAbout_MouseDown(object sender, TouchEventArgs e)
        {
            Generic.RunExternalProcess("explorer.exe", "http://" + lblAbout.Content + "/BarbezDotEu.Executor/");
        }
    }
}