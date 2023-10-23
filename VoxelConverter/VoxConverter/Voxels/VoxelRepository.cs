using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoxelConverter.VoxConverter.ModelObject;
using VoxelConverter.VoxConverter.Tiles;

namespace VoxelConverter.VoxConverter.Voxels
{
    public class VoxelRepository 
    {
        static List<VoxelType> voxelTypes = new List<VoxelType>();
        public static void AddVoxelType(VoxelType type) => voxelTypes.Add(type);
        public static void RemoveVoxelType(VoxelType type) => voxelTypes.Remove(type);
        public static void RemoveVoxelType(SimpleObject type) => voxelTypes.Remove((VoxelType)type);
        public static List<VoxelType> GetVoxelType() => voxelTypes;
        public static void Clear() => voxelTypes.Clear();       
        public static int Count => voxelTypes.Count;
        public static VoxelType GetVoxelByColor(string color) => voxelTypes.Where(v => v.Color == color).FirstOrDefault();
    }
}
