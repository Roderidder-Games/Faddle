using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaddleEngine
{
    public interface IObject
    {
        internal void OnRender();
        internal void Update();
    }
}
