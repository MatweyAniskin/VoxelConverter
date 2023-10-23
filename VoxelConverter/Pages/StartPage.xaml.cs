using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VoxelConverter.VoxConverter.File;

namespace VoxelConverter
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        OpenFileDialog openFileDialog;
        public StartPage()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.xml|*.xml";
        }
        private void AddFile_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == true)
                CurrentFileTextBox.Text = openFileDialog.FileName;
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            string path = CurrentFileTextBox.Text.Trim(' ');
            if (path == "" || !FileConverter.SetXmlFile(path))
            {
                CurrentFileTextBox.Foreground = Brushes.Red;
                return;
            }
            ToWork();
        }

        private void NewProjectButton_Click(object sender, RoutedEventArgs e)
        {
            ToWork();
        }
        void ToWork() => MainWindow.SetPage(new WorkPage());
    }
}
