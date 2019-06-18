using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfox
{
    public class EnemyLaserBehaviour : Behaviour
    {
        const float TIME_LIMIT = 5f;
        const float SPEED = 200f;
        float time = 0;
        public EnemyLaserBehaviour(Actor owner) : base(owner)
        {
        }
        public override void Update()
        {
            time += Engine.DeltaTime;
            if (time >= TIME_LIMIT)
            {
                IsActive = false;
                Visible = false;
                time = 0;
            }
            //Move(SPEED + PlayerShip.Speed, Forward);
        }
    }
}
