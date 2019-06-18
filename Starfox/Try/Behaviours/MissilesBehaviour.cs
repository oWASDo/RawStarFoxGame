using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast3D;

namespace Starfox
{
    public class MissilesBehaviour : Behaviour
    {
        public MissilesBehaviour(Actor owner) : base(owner)
        {
        }
        public override void Update()
        {
            Missile missile = (Missile)Owner;
            Vector3 vec = missile.enemy.Position - position;
            vec.Normalize();

            if ((missile.Visible && missile.IsActive))
            {
                Move(PlayerShip.Speed * 2, vec);
                SetRotation(Utils.LookAt(missile.enemy.Position));
            }

            if (OnCollide)
            {
                if (!(CollideWith is PlayerShip))
                {
                    if (IsActive)
                    {
                        Explosion0 explosion = new Explosion0(position, rotation, new Vector3(1, 1, 1));
                        Engine.CurrentLevel.Spawn(explosion, Trasparecy.YES);
                    }
                    //Explosion0 explosion = new Explosion0(position, rotation, new Vector3(1, 1, 1));
                    //Engine.CurrentLevel.Spawn(explosion, Trasparecy.YES);
                    //SetPosition(new Vector3(-5000, -5000, -5000));
                    Visible = false;
                    IsActive = false;
                    Engine.CurrentLevel.Despawn(Owner);
                }
            }
        }
    }
}
