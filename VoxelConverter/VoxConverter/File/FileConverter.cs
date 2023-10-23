using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Documents;
using VoxelConverter.VoxConverter.Tiles;

namespace VoxelConverter.VoxConverter.File
{
    public static class FileConverter
    {
        static readonly string nonePath = "Новый проект";
        public static string CurrentPath { get; internal set; } = nonePath;
        public static string CurrentFileName => Path.GetFileNameWithoutExtension(CurrentPath);
        public static string FileSize => CurrentPath == nonePath ? "0" : new FileInfo(CurrentPath).Length.ToString();
        public static bool IsFileLoad {  get; internal set; }
        public static bool SetXmlFile(string path)
        {
            CurrentPath = path;
            return IsFileLoad = XmlConverter.SetXmlFile(path);
        }
        public static bool SaveXmlFile() => SaveXmlFile(CurrentPath);
        public static bool SaveXmlFile(string path)
        {
            CurrentPath = path;
            return IsFileLoad = XmlConverter.SaveXmlFile(path);
        }
        public static bool SaveXmlSlimFile(string path) => XmlConverter.SaveSlimXmlFile(path);        
        public static IEnumerable<Tiles.Block> LoadPly(string path, out bool isLoad) => PlyConverter.LoadTile(path, out isLoad);
    }
}
