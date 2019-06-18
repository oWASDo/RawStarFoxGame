using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfox
{
    public interface IDrawable
    {
        bool Visible { get; set; }
        bool Draw();
    }
}
