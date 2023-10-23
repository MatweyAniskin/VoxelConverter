using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoxelConverter.VoxConverter.Tiles;
using VoxelConverter.VoxConverter.Voxels;

namespace VoxelConverter.VoxConverter.File
{
    public static class PlyConverter
    {
        static string EndHeadLine => "end_header";

        public static IEnumerable<Block> LoadTile(string path, out bool isLoad)
        {
            List<Block> blocks = new List<Block>();
            StreamReader streamReader = new StreamReader(path);
            try
            {
                           
                string line = string.Empty;
                string[] lineProperty;
                string color;
                while (!streamReader.EndOfStream && line != EndHeadLine)
                {
                    line = streamReader.ReadLine().TrimStart().TrimEnd();
                }
                while (!streamReader.EndOfStream)
                {
                    lineProperty = streamReader.ReadLine().Split(' ');
                    if (lineProperty.Length < 6)
                    {
                        break;
                    }
                    color = $"{lineProperty[3]} {lineProperty[4]} {lineProperty[5]}";
                    blocks.Add(new Block(lineProperty[0], lineProperty[2], lineProperty[1], VoxelRepository.GetVoxelByColor(color).Name));
                }
                streamReader.Close();
                isLoad = true;
                return blocks;                
            }
            catch
            {
                isLoad = false;
                return null;
            }            
        }
    }
}
