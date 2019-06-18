using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Starfox
{
    public class PlanePath : GameCube
    {
        public PlanePath(Vector3 position, Vector3 rotation, Vector3 scale) : base(position, rotation, scale)
        {
            AddMaterial(new Material("AlienShip.png", 0, true, true));
            //V_Multiplier(scale.Z /** 0.5f*/);
            float mul = Scale.Z / (250 / 2);
            V_Multiplier(mul);
            U_Multiplier(2);
            ShadowRendering = false;
        }
        public override bool Update()
        {
            //U_Multiplier(Scale.Z * 0.09f);
            return base.Update();
        }
    }
}
