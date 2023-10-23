using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoxelConverter.VoxConverter.Tiles
{
    public class TileDirection
    {
        public enum DirectionType { Up = 0, Right = 1, Down = 2, Left = 3 }
        public string Name { get; protected set; }
        public DirectionType Direction { get; protected set; }        
        public TileDirection(string name, int dir) 
        {
            Name = name;
            Direction = (DirectionType)dir;
        }
        public TileDirection(Direction.DirectionType type, DirectionType dir)
        {
            Name = type.Key;
            Direction = dir;
        }
        public override string ToString() => $"Direction {Direction} is {Name}";
    }
}
