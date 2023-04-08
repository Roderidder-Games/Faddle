using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaddleEngine
{
    internal interface IRenderer
    {
        public int GetZIndex();
        public void Render();
    }
}
