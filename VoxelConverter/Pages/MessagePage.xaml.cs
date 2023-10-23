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

namespace VoxelConverter.Pages
{
    /// <summary>
    /// Логика взаимодействия для MessagePage.xaml
    /// </summary>
    public partial class MessagePage : Page
    {
        public MessagePage(string message)
        {
            InitializeComponent();
            InfoLabel.Content = message;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.SetPage(new WorkPage());
        }
        public static void Show(string message) => MainWindow.SetPage(new MessagePage(message));
    }
}
