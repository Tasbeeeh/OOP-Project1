using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    public interface IMazeObject
    {
        public char Icon { get; } //the shape of maze object
        public bool IsSolid { get; } //movement block
    }
}
