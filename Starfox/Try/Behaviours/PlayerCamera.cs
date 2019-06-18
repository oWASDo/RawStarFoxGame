using Aiv.Fast2D;
using Aiv.Fast3D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfox
{
    public class PlayerCamera : Behaviour
    {
        public PlayerCamera(Actor owner) : base(owner) { }
        public override void Update()
        {
            //Vector3 pos = Engine.CurrentLevel.GetActor(typeof(PlayerShip)).Position;
            //Vector3 arm = new Vector3(0f, 5f, -20f) * 3f;
            Move(PlayerShip.Speed, Forward);
            //SetPosition(arm + pos);
            //if (Engine.GetKey(KeyCode.Up))
            //{
            //    Move(10, Up);
            //    //(Engine.Camera as PerspectiveCamera).Position3 += (Engine.Camera as PerspectiveCamera).Up;
            //}
            //else if (Engine.GetKey(KeyCode.Down))
            //{
            //    Move(10, -Up);
            //    //(Engine.Camera as PerspectiveCamera).Position3 -= (Engine.Camera as PerspectiveCamera).Up;
            //}

        }
    }
}
