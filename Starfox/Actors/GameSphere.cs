using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Aiv.Fast3D;

namespace Starfox
{
    public class GameSphere : ActorMesh, IStatic
    {
        public override Vector3 Forward
        {
            get
            {
                return mesh.Forward;
            }
        }
        public override Vector3 Right
        {
            get
            {
                return mesh.Right;
            }
        }
        public override Vector3 Up
        {
            get
            {
                return mesh.Up;
            }
        }
        public GameSphere():base()
        {
            mesh = new Sphere();
        }

        public GameSphere(Vector3 position, Vector3 rotation, Vector3 scale) : base(position, rotation, scale)
        {
            mesh = new Sphere();
        }
    }
}
