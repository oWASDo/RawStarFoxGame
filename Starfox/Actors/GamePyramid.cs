using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Aiv.Fast3D;

namespace Starfox
{
    public class GamePyramid : ActorMesh, IStatic
    {
        public GamePyramid(Vector3 position, Vector3 rotation, Vector3 scale) : base(position, rotation, scale)
        {
            mesh = new Pyramid();
        }
    }
}
