using System.Collections.Generic;
using VoxelConverter.VoxConverter.Direction;
using VoxelConverter.VoxConverter.ModelObject;
using VoxelConverter.VoxConverter.Voxels;

namespace VoxelConverter.VoxConverter.Tiles
{
    public class TileRepository
    {
        static List<Tile> tiles = new List<Tile>();
        public static void AddTile(Tile tile) => tiles.Add(tile);
        public static void AddTile(string title, IEnumerable<Block> blocks, IEnumerable<TileDirection> tileDirections) => tiles.Add(new Tile(title,blocks, tileDirections));
        public static void RemoveTile(Tile tile) => tiles.Remove(tile);
        public static void RemoveTile(SimpleObject tile) => tiles.Remove((Tile)tile);
        public static List<Tile> GetTiles() => tiles;
        public static void Clear() => tiles.Clear();     
        public static int Count => tiles.Count;
    }
}
