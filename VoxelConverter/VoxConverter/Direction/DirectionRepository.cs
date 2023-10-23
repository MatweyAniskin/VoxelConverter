using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoxelConverter.VoxConverter.ModelObject;
using VoxelConverter.VoxConverter.Tiles;

namespace VoxelConverter.VoxConverter.Direction
{
    public static class DirectionRepository
    {
        static List<DirectionType> directions = new List<DirectionType>();
        public static void AddDir(DirectionType value) => directions.Add(value);
        public static void RemoveDir(DirectionType value) => directions.Remove(value);
        public static void RemoveDir(SimpleObject value) => directions.Remove((DirectionType)value);
        public static List<DirectionType> GetDir() => directions;
        public static void Clear() => directions.Clear();
        public static int Count => directions.Count;
    }
}
