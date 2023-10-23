using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VoxelConverter.VoxConverter.ModelObject;

namespace VoxelConverter.VoxConverter.Voxels
{
    public class VoxelType : SimpleObject
    {        
        public string Name { protected set; get; }
        public string Color { protected set; get; }        

        static readonly Regex trimmer = new Regex(@"\s\s+");

        public VoxelType(string name, string color, string title) : base(title)
        {
            this.Name = name;
            this.Color = trimmer.Replace(color.TrimStart(' ').TrimEnd(' '), " ");        
        }                
    }
}
