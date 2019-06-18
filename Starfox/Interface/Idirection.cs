using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfox
{
    interface IDirection
    {
        Vector3 Forward { get; }
        Vector3 Right { get; }
        Vector3 Up { get; }
    }
}
