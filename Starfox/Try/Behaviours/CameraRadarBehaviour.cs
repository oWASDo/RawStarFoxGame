using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Aiv.Fast3D;
using Aiv.Fast2D;

namespace Starfox
{
    class CameraRadarBehaviour : Behaviour
    {
        Vector3 vec1 = new Vector3(-88.60f, 0, 0);
        public CameraRadarBehaviour(Actor owner) : base(owner)
        {
        }
        public override void Update()
        {
            Vector3 vec = Engine.CurrentLevel.GetActor(typeof(PlayerShip)).Position;
            SetPosition(vec + new Vector3(0, 500, -425));

            if (Engine.GetKey(KeyCode.P))
            {
                vec1.X += 1 * Engine.DeltaTime;
            }
            else if (Engine.GetKey(KeyCode.O))
            {
                vec1.X -= 1 * Engine.DeltaTime;
            }
            SetRotation(vec1);
        }
    }
}
