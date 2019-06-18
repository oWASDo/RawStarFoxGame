using Aiv.Fast3D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfox
{
    public class MissileGuiBehaviour : Behaviour
    {
        public MissileGuiBehaviour(Actor owner) : base(owner)
        {

        }
        public override void Update()
        {
            Crosshair crosshair = (Crosshair)Engine.CurrentLevel.GetActor(typeof(Crosshair));

            //float timeNorm = MathHelper.Clamp(crosshair.time, 0.0f, 10.0f) / 10;

            //SetPosition(position /*- new Vector3(0, 0, Engine.ZNear) */+ new Vector3(0f, 0f, 0f));
            SetPosition(Engine.PerspectiveCamera.Position3 - new Vector3(0, 0, Engine.ZNear) + new Vector3(0.45f, -0.2f, 0));
            SetRotation(Utils.LookAt(Engine.PerspectiveCamera.Position3));

            float time = crosshair.time;

            if (time >= 10)
            {
                Visible = true;
                if (time <= 12)
                {
                    Variables.MissileReady = true;
                }
            }
            else
            {
                Variables.MissileReady = false;
                Visible = false;
            }
        }
    }
}
