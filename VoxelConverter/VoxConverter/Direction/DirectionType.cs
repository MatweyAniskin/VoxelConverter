using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoxelConverter.VoxConverter.ModelObject;

namespace VoxelConverter.VoxConverter.Direction
{
    public class DirectionType : SimpleObject
    {
        public string Key { get; protected set; }
        public DirectionType(string title, string key) : base(title)
        {
            Key = key;
        }
    }
}
