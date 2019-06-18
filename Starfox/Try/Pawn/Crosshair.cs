using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Aiv.Fast2D;

namespace Starfox
{
    public class Crosshair : Billboard
    {
        public float time;
        public Crosshair(Vector3 position, Vector3 rotation, Vector3 scale) : base(position, rotation, scale)
        {
            AddBehaviour(new CrosshairBehaviour(this));
            AddMaterial(new Material("Crosshair0.png"));
            ShadowRendering = false;
        }
    }
}
