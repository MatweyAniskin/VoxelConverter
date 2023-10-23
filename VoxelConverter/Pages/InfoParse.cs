using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows;
using VoxelConverter.VoxConverter.File;
using VoxelConverter.VoxConverter.Tiles;
using VoxelConverter.VoxConverter.Voxels;
using System.Windows.Controls;
using VoxelConverter.VoxConverter.Direction;
using System.IO;

namespace VoxelConverter.Pages
{
    public static class InfoParse
    {
        static TextBlock InfoTextBlock;
        public static void SetTextBlock(TextBlock textBlock) => InfoTextBlock = textBlock; 
        public static void SetFileInfo()
        {
            InfoTextBlock.Inlines.Clear();
            InfoTextBlock.Inlines.Add(new Run("Путь к проекту: ") { FontWeight = FontWeights.Bold });
            InfoTextBlock.Inlines.Add(new Run(FileConverter.CurrentPath));
            InfoTextBlock.Inlines.Add(new Run("\n"));
            InfoTextBlock.Inlines.Add(new Run("Имя проекта: ") { FontWeight = FontWeights.Bold });
            InfoTextBlock.Inlines.Add(new Run(FileConverter.CurrentFileName));
            InfoTextBlock.Inlines.Add(new Run("\n"));
            InfoTextBlock.Inlines.Add(new Run("Размер проекта: ") { FontWeight = FontWeights.Bold });
            InfoTextBlock.Inlines.Add(new Run(FileConverter.FileSize + " байт"));
        }
        public static void SetProjectInfo()
        {
            InfoTextBlock.Inlines.Clear();
            InfoTextBlock.Inlines.Add(new Run("Всего типов вокселей: ") { FontWeight = FontWeights.Bold });
            InfoTextBlock.Inlines.Add(new Run(VoxelRepository.Count.ToString()));
            InfoTextBlock.Inlines.Add(new Run("\n"));
            InfoTextBlock.Inlines.Add(new Run("Всего направлений: ") { FontWeight = FontWeights.Bold });
            InfoTextBlock.Inlines.Add(new Run(DirectionRepository.Count.ToString()));
            InfoTextBlock.Inlines.Add(new Run("\n"));
            InfoTextBlock.Inlines.Add(new Run("Всего тайлов: ") { FontWeight = FontWeights.Bold });
            InfoTextBlock.Inlines.Add(new Run(TileRepository.Count.ToString()));
            InfoTextBlock.Inlines.Add(new Run("\n"));

        }
        public static void SetVoxelInfo(VoxelType type)
        {
            InfoTextBlock.Inlines.Clear();
            InfoTextBlock.Inlines.Add(new Run("Название: ") { FontWeight = FontWeights.Bold });
            InfoTextBlock.Inlines.Add(new Run(type.Title));
            InfoTextBlock.Inlines.Add(new Run("\n"));
            InfoTextBlock.Inlines.Add(new Run("Ключевое слово: ") { FontWeight = FontWeights.Bold });
            InfoTextBlock.Inlines.Add(new Run(type.Name));
            InfoTextBlock.Inlines.Add(new Run("\n"));
            InfoTextBlock.Inlines.Add(new Run("Код цвета: ") { FontWeight = FontWeights.Bold });
            InfoTextBlock.Inlines.Add(new Run(type.Color));
        }
        public static void SetTileInfo(Tile tile)
        {
            InfoTextBlock.Inlines.Clear();
            InfoTextBlock.Inlines.Add(new Run("Название: ") { FontWeight = FontWeights.Bold });
            InfoTextBlock.Inlines.Add(new Run(tile.Title));
            InfoTextBlock.Inlines.Add(new Run("\n"));
            InfoTextBlock.Inlines.Add(new Run("Количество блоков: ") { FontWeight = FontWeights.Bold });
            InfoTextBlock.Inlines.Add(new Run(tile.Blocks.Count().ToString()));
            InfoTextBlock.Inlines.Add(new Run("\n"));
            InfoTextBlock.Inlines.Add(new Run("Размер тайла: ") { FontWeight = FontWeights.Bold });
            InfoTextBlock.Inlines.Add(new Run(tile.Scale));
            InfoTextBlock.Inlines.Add(new Run("\n"));
            InfoTextBlock.Inlines.Add(new Run("Направления: ") { FontWeight = FontWeights.Bold });
            foreach(TileDirection direction in tile.Directions)
            {
                InfoTextBlock.Inlines.Add(new Run($"\n{direction}"));
            }            
            InfoTextBlock.Inlines.Add(new Run("\n\nБлоки: \n") { FontWeight = FontWeights.Bold });            
            foreach (var block in tile.Blocks)
            {
                InfoTextBlock.Inlines.Add(new Run($"{block.Type}; ") { FontWeight = FontWeights.Bold });
                InfoTextBlock.Inlines.Add(new Run($"x ={block.X}; y ={block.Y}; z ={block.Z}\n"));
            }
        }
        public static void SetDirectionInfo(DirectionType type)
        {
            InfoTextBlock.Inlines.Clear();
            InfoTextBlock.Inlines.Add(new Run("Название: ") { FontWeight = FontWeights.Bold });
            InfoTextBlock.Inlines.Add(new Run(type.Title));
            InfoTextBlock.Inlines.Add(new Run("\n"));
            InfoTextBlock.Inlines.Add(new Run("Ключевое слово: ") { FontWeight = FontWeights.Bold });
            InfoTextBlock.Inlines.Add(new Run(type.Key));
        }
        public static void SetPlyFileInfo(string path)
        {
            if (path.Trim() == "")
                return;
            InfoTextBlock.Inlines.Clear();
            InfoTextBlock.Inlines.Add(new Run("Путь к модели: ") { FontWeight = FontWeights.Bold });
            InfoTextBlock.Inlines.Add(new Run(path));
            InfoTextBlock.Inlines.Add(new Run("\n"));
            InfoTextBlock.Inlines.Add(new Run("Имя модели: ") { FontWeight = FontWeights.Bold });
            InfoTextBlock.Inlines.Add(new Run(Path.GetFileName(path)));
            InfoTextBlock.Inlines.Add(new Run("\n"));
            InfoTextBlock.Inlines.Add(new Run("Размер проекта: ") { FontWeight = FontWeights.Bold });
            InfoTextBlock.Inlines.Add(new Run(new FileInfo(path).Length.ToString() + " байт"));
        }
    }
}
