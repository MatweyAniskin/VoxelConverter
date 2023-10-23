using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoxelConverter.VoxConverter.Tiles
{
    public class Block
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public int Z { get; protected set; }
        public string Type { get; protected set; }
        public void SetOffset(int x, int y,int z)
        {
            X += x;
            Y += y;
            Z += z;
        }
        public Block(string x, string y, string z, string type)
        {
            X = Convert.ToInt32(x);
            Y = Convert.ToInt32(y);
            Z = Convert.ToInt32(z);
            Type = type;
        }
        public override string ToString() => $"{Type}; x={X}; y={Y}; z={Z}";        
    }
}
