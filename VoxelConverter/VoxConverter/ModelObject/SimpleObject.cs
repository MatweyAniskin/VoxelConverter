using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoxelConverter.VoxConverter.ModelObject
{
    public abstract class SimpleObject
    {
        public string Title { protected set; get; }
        public SimpleObject(string title)
        {
            Title = title;
        }
        public override string ToString() => Title;        
    }
}
