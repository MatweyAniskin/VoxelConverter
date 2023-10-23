using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoxelConverter.VoxConverter.Direction;
using VoxelConverter.VoxConverter.ModelObject;

namespace VoxelConverter.VoxConverter.Tiles
{
    public class Tile : SimpleObject
    {       
        public IEnumerable<Block> Blocks { protected set; get; }
        public IEnumerable<TileDirection> Directions { protected set; get; }
        public Tile(string title, IEnumerable<Block> blocks, IEnumerable<TileDirection> directions) : base(title)
        {          
            this.Blocks = blocks;
            Directions = directions;
            int minX = 0;
            int minY = 0;
            int minZ = 0;
            foreach (var block in blocks)
            {
                if(block.X < minX) minX = block.X;
                if (block.Y < minY) minY = block.Y;
                if (block.Z < minZ) minZ = block.Z;
            }
            foreach(var block in blocks)
                block.SetOffset( Math.Abs(minX), -minY,Math.Abs(minZ));
        }
        public string Scale
        {
            get
            {
                int maxX = 0;
                int maxY = 0;
                int maxZ = 0;
                foreach (var i in Blocks)
                {
                    if(maxX < i.X) maxX = i.X;
                    if (maxY < i.Y) maxY = i.Y;
                    if (maxZ < i.Z) maxZ = i.Z;
                }
                return $"{maxX+1}x{maxY + 1}x{maxZ + 1}";
            }
        }        
    }
}
