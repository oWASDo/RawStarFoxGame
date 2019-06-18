using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Aiv.Fast3D;

namespace Starfox
{
    public class GUI : Billboard
    {
        public GUI(Vector3 position, Vector3 rotation, Vector3 scale) : base(position, rotation, scale)
        {
        }
        public override bool Update()
        {
            if (base.Update())
            {
                SetRotation(Utils.LookAt(Engine.PerspectiveCamera.Position3));
                SetPosition(Engine.PerspectiveCamera.Position3 - new Vector3(0, 0, Engine.ZNear));
                //SetRotation(Engine.PerspectiveCamera.EulerRotation3);
                return IsActive;
            }
            return IsActive;
        }
    }
}
