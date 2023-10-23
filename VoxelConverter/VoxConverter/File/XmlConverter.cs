using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using VoxelConverter.VoxConverter.Direction;
using VoxelConverter.VoxConverter.Tiles;
using VoxelConverter.VoxConverter.Voxels;

namespace VoxelConverter.VoxConverter.File
{
    public static class XmlConverter
    {
        static readonly string directions = "Directions";
        static readonly string direction = "Direction";
        static readonly string voxelTypes = "Voxel_types";
        static readonly string voxelType = "Voxel";
        static readonly string tiles = "Tiles";
        static readonly string tile_type = "Tile";    
        public static bool SetXmlFile(string path)
        {
            VoxelRepository.Clear();
            TileRepository.Clear();      
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(path);
                foreach (XmlElement rep in document.GetElementsByTagName(directions))
                {
                    foreach (XmlNode dir in rep.GetElementsByTagName(direction))
                    {
                        AddDirection(dir);
                    }
                }
                foreach (XmlElement rep in document.GetElementsByTagName(voxelTypes))
                {
                    foreach (XmlNode voxel in rep.GetElementsByTagName(voxelType))
                    {
                        AddVoxel(voxel);
                    }
                }
                foreach (XmlElement rep in document.GetElementsByTagName(tiles))
                {
                    foreach (XmlElement tile in rep.GetElementsByTagName(tile_type))
                    {
                        AddTile(tile);
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
        static void AddDirection(XmlNode node)
        {
            string title = node.Attributes["Title"].InnerText;
            string name = node.InnerText;
            DirectionRepository.AddDir(new DirectionType(title, name));
        }
        static void AddVoxel(XmlNode node)
        {
            string title = string.Empty;
            string key = string.Empty;
            string color = string.Empty;
            foreach (XmlNode i in node.ChildNodes)
            {               
                switch (i.Name.Trim(' '))
                {
                    case "Title":
                        title = i.InnerText;
                        break;
                    case "Key":
                        key = i.InnerText;
                        break;
                    case "Color":
                        color = i.InnerText;
                        break;
                }
            }            
            VoxelRepository.AddVoxelType(new VoxelType(key, color, title));
        }
        static void AddTile(XmlElement element)
        {
            List<Block> blocks = new List<Block>();
            List<TileDirection> directions = new List<TileDirection>();
            string x;
            string y;
            string z;
            string type;
            string name = element.Attributes["Name"].InnerText;
            int dirType;
            string dirName;
            foreach (XmlNode dir in element.GetElementsByTagName("Direction"))
            {
                dirType = Convert.ToInt32(dir.Attributes["Type"].InnerText);
                dirName = dir.InnerText;
                directions.Add(new TileDirection(dirName, dirType));
            }
            foreach (XmlNode block in element.GetElementsByTagName("Block"))
            {
                x = block.Attributes["X"].InnerText;
                y = block.Attributes["Y"].InnerText;
                z = block.Attributes["Z"].InnerText;
                type = block.InnerText.Trim();
                blocks.Add(new Block(x, y, z, type));
            }
            TileRepository.AddTile(new Tile(name, blocks,directions));
        }        
        public static bool SaveXmlFile(string path)
        {
            try
            {
                XDocument xmldoc = new XDocument();
                XElement root = new XElement("root");
                root.Add(GetDirectionsElement(), GetVoxelsElement(), GetTilesElement());
                xmldoc.Add(root);
                xmldoc.Save(path);                
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }            
        }
        public static bool SaveSlimXmlFile(string path)
        {
            try
            {
                XDocument xmldoc = new XDocument();                              
                xmldoc.Add(GetTilesElement());
                xmldoc.Save(path);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
        static XElement GetDirectionsElement()
        {
            XElement dirs = new XElement(directions);
            dirs.Add(GetDirection());
            return dirs;
        }
        static IEnumerable<XElement> GetDirection()
        {
            List<XElement> directions = new List<XElement>();
            XElement dir;
            XAttribute attribute;
            foreach (DirectionType direction in DirectionRepository.GetDir())
            {
                dir = new XElement("Direction",direction.Key);
                attribute = new XAttribute("Title", direction.Title);
                dir.Add(attribute);
                directions.Add(dir);
            }
            return directions;
        }
        static XElement GetVoxelsElement()
        {
            XElement dirs = new XElement(voxelTypes);
            dirs.Add(GetVoxel());
            return dirs;
        }
        static IEnumerable<XElement> GetVoxel()
        {
            List<XElement> voxels = new List<XElement>();
            XElement voxel;
            XElement title;
            XElement key;
            XElement color;           
            foreach (VoxelType vox in VoxelRepository.GetVoxelType())
            {
                voxel = new XElement("Voxel");
                title = new XElement("Title", vox.Title);
                key = new XElement("Key", vox.Name);
                color = new XElement("Color", vox.Color);
                voxel.Add(title, key, color);
                voxels.Add(voxel);
            }
            return voxels;
        }
        static XElement GetTilesElement()
        {
            XElement tiles = new XElement("Tiles");
            tiles.Add(GetTile());
            return tiles;
        }
        static IEnumerable<XElement> GetTile()
        {
            List<XElement> tiles = new List<XElement>();
            XElement tileElement;
            XAttribute tileName;

            foreach (Tile tile in TileRepository.GetTiles())
            {
                tileElement = new XElement("Tile");
                tileName = new XAttribute("Name",tile.Title);
                tileElement.Add(tileName, GetDirection(tile),GetBlock(tile));
                tiles.Add(tileElement);
            }
            return tiles;
        }
        static IEnumerable<XElement> GetBlock(Tile tile)
        {
            List<XElement> blocks = new List<XElement>();
            XElement blockElement;
            XAttribute x;
            XAttribute y;
            XAttribute z;
            foreach (Block block in tile.Blocks)
            {
                blockElement = new XElement("Block", block.Type);
                x = new XAttribute("X", block.X);
                y = new XAttribute("Y", block.Y);
                z = new XAttribute("Z", block.Z);
                blockElement.Add(x, y, z);
                blocks.Add(blockElement);
            }
            return blocks;
        }
        static IEnumerable<XElement> GetDirection(Tile tile)
        {
            List<XElement> dirs = new List<XElement>();
            XElement dirElement;
            XAttribute type;            
            foreach (TileDirection dir in tile.Directions)
            {
                dirElement = new XElement("Direction", dir.Name);
                type = new XAttribute("Type", (int)dir.Direction);
                dirElement.Add(type);
                dirs.Add(dirElement);
            }
            return dirs;
        }
    }
}
