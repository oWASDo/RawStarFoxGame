using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfox
{
    interface IUpdatable
    {
        bool IsActive { get; set; }
        bool Update();
    }
}
