using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Aiv.Fast3D;

namespace Starfox
{
    public class Billboard : Sprite3
    {
        public Billboard(Vector3 position, Vector3 rotation, Vector3 scale) : base(position, rotation, scale)
        {
        }
        public override bool Update()
        {
            if (base.Update())
            {
                //-Utils.LookAt((player.Position3 - camera.Position3).Normalized());
                SetRotation(Engine.PerspectiveCamera.EulerRotation3);
                return Visible;
            }
            return Visible;
        }
        
    }
}
