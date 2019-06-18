using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfox
{
    public class RadarBehaviour : Behaviour
    {
        public RadarBehaviour(Actor owner) : base(owner)
        {
        }
        public override void Update()
        {
            SetPosition(Engine.PerspectiveCamera.Position3 - new OpenTK.Vector3(0.48f, 0.25f, Engine.ZNear));
            SetRotation(new OpenTK.Vector3(0, 0, 180));
        }
    }
}
