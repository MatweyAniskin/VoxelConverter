using Microsoft.Win32;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using VoxelConverter.VoxConverter.Direction;
using VoxelConverter.VoxConverter.File;
using VoxelConverter.VoxConverter.Tiles;

namespace VoxelConverter.Pages
{
    /// <summary>
    /// Логика взаимодействия для TileLoadPage.xaml
    /// </summary>
    public partial class TileLoadPage : Page
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public TileLoadPage(string path)
        {
            InitializeComponent();
            IEnumerable<DirectionType> directions = DirectionRepository.GetDir();
            UpdateList(UpDirectionList, directions);
            UpdateList(DownDirectionList, directions);
            UpdateList(RightDirectionList, directions);
            UpdateList(LeftDirectionList, directions);
            openFileDialog.Filter = "*.ply|*.ply";
            CurrentFileTextBox.Text = path;
        }
        void UpdateList(ComboBox box, IEnumerable<DirectionType> directions)
        {
            foreach (DirectionType direction in directions)
            {
                box.Items.Add(direction);
            }
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == false) return;
            CurrentFileTextBox.Text = openFileDialog.FileName;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ToWork();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Check(CurrentFileTextBox) | !Check(UpDirectionList) | !Check(RightDirectionList) | !Check(DownDirectionList) | !Check(LeftDirectionList))
                return;
            string path = CurrentFileTextBox.Text.Trim();           
            IEnumerable<VoxConverter.Tiles.Block> blocks = FileConverter.LoadPly(path, out bool isLoad);
            if (!isLoad)
            {
                MessagePage.Show("Неудалось загрузить файл");
                return;
            }
            List<TileDirection> tileDirections = new List<TileDirection>();
            tileDirections.Add(new TileDirection((DirectionType)UpDirectionList.SelectedItem, TileDirection.DirectionType.Down));
            tileDirections.Add(new TileDirection((DirectionType)RightDirectionList.SelectedItem, TileDirection.DirectionType.Right));
            tileDirections.Add(new TileDirection((DirectionType)DownDirectionList.SelectedItem, TileDirection.DirectionType.Up));
            tileDirections.Add(new TileDirection((DirectionType)LeftDirectionList.SelectedItem, TileDirection.DirectionType.Left));
            string title = System.IO.Path.GetFileNameWithoutExtension(path);
            TileRepository.AddTile(title, blocks, tileDirections);

            ToWork();
        }
        bool Check(TextBox box)
        {
            if (box.Text.Trim() == "")
            {
                box.Foreground = Brushes.Red;
                return false;
            }
            return true;

        }
        bool Check(ComboBox box)
        {            
            if (box.SelectedValue is null)
            {
                box.Foreground = Brushes.Red;
                return false;
            }
            return true;

        }
        void ToWork() => MainWindow.SetPage(new WorkPage());
    }
}
