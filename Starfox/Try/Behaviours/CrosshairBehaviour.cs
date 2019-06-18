using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using Aiv.Audio;

namespace Starfox
{
    public class CrosshairBehaviour : Behaviour
    {
        private Vector3 vec3;
        private Actor enemy;
        private AudioSource shoot;
        private float time;
        private const float TIME_LIMIT = 10;

        public CrosshairBehaviour(Actor owner) : base(owner)
        {
            vec3 = new Vector3();
            shoot = new AudioSource();
            time = TIME_LIMIT;

        }

        private void Control()
        {
            if (Engine.GetKey(KeyCode.Up))
            {
                if (vec3.Y < 0.3)
                {
                    vec3.Y += Engine.DeltaTime;
                }
            }
            else if (Engine.GetKey(KeyCode.Down))
            {
                if (vec3.Y > -0.3)
                {
                    vec3.Y -= Engine.DeltaTime;
                }
            }
            if (Engine.GetKey(KeyCode.Right))
            {
                if (vec3.X > -0.5)
                {
                    vec3.X -= Engine.DeltaTime;
                }
            }
            else if (Engine.GetKey(KeyCode.Left))
            {
                if (vec3.X < 0.5)
                {
                    vec3.X += Engine.DeltaTime;
                }
            }
        }
        private void SetPosition()
        {
            SetPosition(Engine.PerspectiveCamera.Position3 - new Vector3(0, 0, Engine.ZNear) + vec3);

        }
        private void Shoot()
        {
            foreach (Actor item in Engine.CurrentLevel.GetActors(typeof(Enemy)))
            {
                if (item.IsActive && item.Visible)
                {
                    if (Tools.IsInLine(Owner.Position, item.Position, 0.05f))
                    {
                        enemy = item;
                        if (Engine.GetKey(KeyCode.F) && item.Position.Z >= Engine.CurrentLevel.GetActor(typeof(PlayerShip)).Position.Z)
                        {
                            if (enemy != null)
                            {
                                Actor player = Engine.CurrentLevel.GetActor(typeof(PlayerShip));
                                Missile missile = new Missile(player.Position, player.Rotation, player.Scale);
                                missile.enemy = this.enemy;
                                shoot.Play(SoundLibrary.GetSound("BigShoot"));
                                Engine.CurrentLevel.Spawn(missile, Trasparecy.NO);
                                //missile.SetPosition(player.Position);
                                //missile.SetRotation(player.Rotation);
                                time = 0;
                            }
                        }
                        break;
                    }
                }
            }
        }
        private bool Time()
        {
            time += Engine.DeltaTime;
            if (time >= TIME_LIMIT)
            {
                return true;
            }
            return false;
        }

        public override void Update()
        {
            Control();
            SetPosition();
            if (Time())
            {
                Shoot();
            }
            ((Crosshair)Owner).time = time;
            Console.WriteLine(time);
        }
    }
}
