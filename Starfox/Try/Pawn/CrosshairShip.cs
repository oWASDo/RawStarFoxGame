using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Starfox
{
    public class CrosshairShip : Sprite3
    {
        public CrosshairShip(Vector3 position, Vector3 rotation, Vector3 scale) : base(position, rotation, scale)
        {
            AddMaterial(new Material("Crosshair1.png"));
            ShadowRendering = false;
        }
    }
}
