using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using VoxelConverter.Pages;
using VoxelConverter.VoxConverter.Direction;
using VoxelConverter.VoxConverter.File;
using VoxelConverter.VoxConverter.ModelObject;
using VoxelConverter.VoxConverter.Tiles;
using VoxelConverter.VoxConverter.Voxels;

namespace VoxelConverter
{
    /// <summary>
    /// Логика взаимодействия для WorkPage.xaml
    /// </summary>
    public partial class WorkPage : Page
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        OpenFileDialog openXmlFileDialog = new OpenFileDialog();
        OpenFileDialog openPlyFileDialog = new OpenFileDialog();
        public WorkPage()
        {
            InitializeComponent();
            UpdateList(VoxelRepository.GetVoxelType(), VoxelsTypeListBox);
            UpdateList(TileRepository.GetTiles(), TilesListBox);
            UpdateList(DirectionRepository.GetDir(), DirTypeListBox);
            InfoParse.SetTextBlock(InfoTextBlock);
            InfoParse.SetFileInfo();            
            saveFileDialog.Filter = "*.xml|*.xml";            
            openXmlFileDialog.Filter = "*.xml|*.xml";
            openPlyFileDialog.Filter = "*.ply|*.ply";
        }
        void UpdateList(IEnumerable<SimpleObject> objects, ListBox list)
        {
            foreach (var i in objects)
                list.Items.Add(i);
        }
        private void ProjectInfoButton_Click(object sender, RoutedEventArgs e) => InfoParse.SetProjectInfo();

        private void XmlInfoButton_Click(object sender, RoutedEventArgs e) => InfoParse.SetFileInfo();

        private void VoxelsTypeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VoxelsTypeListBox.SelectedItem is VoxelType voxel)
                InfoParse.SetVoxelInfo(voxel);
        }

        private void TilesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TilesListBox.SelectedItem is Tile tile)
                InfoParse.SetTileInfo(tile);
        }

        private void AddVoxelType_Click(object sender, RoutedEventArgs e) => MainWindow.SetPage(new VoxelTypePage());

        private void RemoveVoxelType_Click(object sender, RoutedEventArgs e)
        {
            if (VoxelsTypeListBox.SelectedItem is VoxelType voxel)
                MainWindow.SetPage(new DeletePage(voxel, VoxelRepository.RemoveVoxelType));
        }

        private void RemoveTileButton_Click(object sender, RoutedEventArgs e)
        {
            if (TilesListBox.SelectedItem is Tile tile)
                MainWindow.SetPage(new DeletePage(tile, TileRepository.RemoveTile));
        }

        private void DirTypeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DirTypeListBox.SelectedItem is DirectionType dir)
                InfoParse.SetDirectionInfo(dir);
        }

        private void AddDirType_Click(object sender, RoutedEventArgs e) => MainWindow.SetPage(new DirectionTypePage());

        private void RemoveDirType_Click(object sender, RoutedEventArgs e)
        {
            if (DirTypeListBox.SelectedItem is DirectionType dir)
                MainWindow.SetPage(new DeletePage(dir, DirectionRepository.RemoveDir));
        }

        private void SaveXmlFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (!FileConverter.IsFileLoad)
            {
                SaveXmlAsFileButton_Click(sender, e);
                return;
            }
            if (FileConverter.SaveXmlFile())
            {
                MessagePage.Show("Файл сохранён");
            }
            else
            {
                MessagePage.Show("Ошибка сохранения");
            }
        }

        private void SaveXmlAsFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (saveFileDialog.ShowDialog() == false)
                return;
            if (FileConverter.SaveXmlFile(saveFileDialog.FileName))
            {
                MessagePage.Show("Файл сохранён");
            }
            else
            {
                MessagePage.Show("Ошибка сохранения");
            }
        }

        private void LoadPlyFileButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.SetPage(new TileLoadPage(CurrentPlyTextBox.Text));
        }

        private void AddPlyFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (openPlyFileDialog.ShowDialog() == false) return;
            string path = openPlyFileDialog.FileName;
            CurrentPlyTextBox.Text = path;
            InfoParse.SetPlyFileInfo(path);
        }

        private void XmlExportButton_Click(object sender, RoutedEventArgs e)
        {
            if (saveFileDialog.ShowDialog() == false)
                return;
            if (FileConverter.SaveXmlSlimFile(saveFileDialog.FileName))
            {
                MessagePage.Show("Файл экспортирован");
            }
            else
            {
                MessagePage.Show("Ошибка экспорта");
            }
        }
    }
}
