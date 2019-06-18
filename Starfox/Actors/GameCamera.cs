using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Aiv.Fast3D;

namespace Starfox
{
    public class GameCamera : Actor, IStatic
    {
        private PerspectiveCamera camera;
        public PerspectiveCamera Camera => camera;
        public override Vector3 Forward
        {
            get
            {
                return camera.Forward;
            }
        }
        public override Vector3 Right
        {
            get
            {
                return camera.Right;
            }
        }
        public override Vector3 Up
        {
            get
            {
                return camera.Up;
            }
        }
        public GameCamera(Vector3 position, Vector3 rotation, Vector3 scale,float fov,float zNear, float zFar, float aspectRatio = 0) : base(position, rotation, scale)
        {
            camera = new PerspectiveCamera(position, rotation, fov, zNear, zFar, aspectRatio);
        }
        public override bool Update()
        {
            if (base.Update())
            {
                //SetPosition(mesh.Position3);
                //SetRotation(mesh.EulerRotation3);

                //mesh.Position3 = Position;
                //mesh.Rotation3 = Rotation;

                camera.Position3 = Position;
                camera.Rotation3 = Rotation;

                //mesh.Position3 = Position;
                //mesh.EulerRotation3 = Rotation;
                //camera.Position3 = mesh.Position3;
                //camera.EulerRotation3 = mesh.Position3;

                return Visible;
            }
            return Visible;
        }
    }
}
