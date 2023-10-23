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
using VoxelConverter.VoxConverter.Direction;
using VoxelConverter.VoxConverter.Voxels;

namespace VoxelConverter.Pages
{
    /// <summary>
    /// Логика взаимодействия для DirectionTypePage.xaml
    /// </summary>
    public partial class DirectionTypePage : Page
    {
        public DirectionTypePage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e) => ToWork();

        private void AddTypeButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text;
            string key = KeyTextBox.Text;      

            if (title.Trim(' ') == "" || key.Trim(' ') == "" )
            {
                TitleTextBox.Foreground = Brushes.Red;
                KeyTextBox.Foreground = Brushes.Red;           
                return;
            }
            DirectionRepository.AddDir(new DirectionType(title,key));
            ToWork();
        }
        void ToWork() => MainWindow.SetPage(new WorkPage());
    }
}
