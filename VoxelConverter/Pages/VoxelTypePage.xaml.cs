using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using VoxelConverter.VoxConverter.Voxels;

namespace VoxelConverter.Pages
{
    /// <summary>
    /// Логика взаимодействия для VoxelTypePage.xaml
    /// </summary>
    public partial class VoxelTypePage : Page
    {
        public VoxelTypePage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e) => ToWork();

        private void AddTypeButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text;
            string key = KeyTextBox.Text;
            string color = ColorTextBox.Text;

            if (title.Trim(' ') == "" || key.Trim(' ') == "" || color.Trim(' ') == "")
            {
                TitleTextBox.Foreground = Brushes.Red;
                KeyTextBox.Foreground = Brushes.Red;
                ColorTextBox.Foreground = Brushes.Red;
                return;
            }
            VoxelRepository.AddVoxelType(new VoxelType(key, color, title));
            ToWork();
        }
        void ToWork() => MainWindow.SetPage(new WorkPage());
    }
}
