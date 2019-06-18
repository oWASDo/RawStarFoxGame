using Aiv.Fast3D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Audio;

namespace Starfox
{
    public class EnemyBehaviour : Behaviour
    {
        private AudioSource shootSound;
        private float shootTime;
        private float t;
        private Bezier3 curve;
        private bool Dead;
        private int type;
        private Random random;
        private float time;
        public EnemyBehaviour(Actor owner) : base(owner)
        {
            //type = 10;
            //Console.WriteLine(type);
            shootSound = new AudioSource();
            shootSound.Volume = 0.2f;
            shootTime = 0;
            time = 1;
            int n = DateTime.Now.Second;
            random = new Random(n);
            type = random.Next(0, 6);
            t = 0;
            Dead = false;
            curve = new Bezier3();
        }
        public override void Update()
        {


            time += Engine.DeltaTime;
            if (!Dead)
            {
                t += Engine.DeltaTime * 0.03f;
                if (type == 0)
                {
                    curve.SetPoint(0, Engine.PerspectiveCamera.Position3 + new Vector3(0, 0, 1000));
                    curve.SetPoint(1, Engine.PerspectiveCamera.Position3 + new Vector3(0, 10, 500));
                    curve.SetPoint(2, Engine.PerspectiveCamera.Position3 + new Vector3(0, -10, -50));
                }
                else if (type == 1)
                {
                    curve.SetPoint(0, Engine.PerspectiveCamera.Position3 + new Vector3(500, 0, 500));
                    curve.SetPoint(1, Engine.PerspectiveCamera.Position3 + new Vector3(0, 0, 1000));
                    curve.SetPoint(2, Engine.PerspectiveCamera.Position3 + new Vector3(-500, 0, 500));
                }
                else if (type == 2)
                {
                    curve.SetPoint(0, Engine.PerspectiveCamera.Position3 + new Vector3(500, 0, 500));
                    curve.SetPoint(1, Engine.PerspectiveCamera.Position3 + new Vector3(0, 0, 500));
                    curve.SetPoint(2, Engine.PerspectiveCamera.Position3 + new Vector3(-500, 0, 500));
                }
                else if (type == 3)
                {
                    curve.SetPoint(0, Engine.PerspectiveCamera.Position3 + new Vector3(200, 200, 500));
                    curve.SetPoint(1, Engine.PerspectiveCamera.Position3 + new Vector3(-200, Variables.MotherShipHight * 15, 500));
                    curve.SetPoint(2, Engine.PerspectiveCamera.Position3 + new Vector3(-200, 200, 500));
                }
                else if (type == 4)
                {
                    curve.SetPoint(0, Engine.PerspectiveCamera.Position3 + new Vector3(-200, 200, 500));
                    curve.SetPoint(1, Engine.PerspectiveCamera.Position3 + new Vector3(200, Variables.MotherShipHight * 15, 500));
                    curve.SetPoint(2, Engine.PerspectiveCamera.Position3 + new Vector3(200, 200, 500));
                }
                else
                {
                    curve.SetPoint(0, Engine.PerspectiveCamera.Position3 + new Vector3(60, 170, 500));
                    curve.SetPoint(1, Engine.PerspectiveCamera.Position3 + new Vector3(0, -50, 500));
                    curve.SetPoint(2, Engine.PerspectiveCamera.Position3 + new Vector3(-60, 170, 500));
                }
                if (t >= 1)
                {
                    Visible = false;
                    IsActive = false;
                    t = 0;
                    type = random.Next(0, 5);
                }
                Vector3 v = curve.Quadratic(t);
                SetPosition(v);
            }

            if (time >= 1)
            {
                if (OnCollide)
                {
                    if (CollideWith is PlayerShip || CollideWith is Laser || CollideWith is Missile)
                    {
                        Dead = true;
                        time = 0;
                    }
                }
            }

            //Vector3 b = position - Engine.CurrentLevel.GetActor(typeof(PlayerShip)).Position;
            //b.Normalize();
            //Vector3 a = new Vector3(Utils.GetPitchFromDirection(b), Utils.GetYawFromDirection(b), 0);
            //SetRotation(a);
            if (Dead)
            {
                if (IsActive)
                {
                    Explosion0 explosion = new Explosion0(position, rotation, new Vector3(1, 1, 1));
                    Engine.CurrentLevel.Spawn(explosion, Trasparecy.YES);
                }
                type = random.Next(0, 5);
                Visible = false;
                IsActive = false;
                Owner.CollideWith = null;
                Owner.OnCollide = false;
                Variables.DeadEnemyCount++;
                Dead = false;
            }
            Shoot();
            //SetPosition(new Vector3(position.X, position.Y, vec.Z + offset));
        }
        public void Shoot()
        {
            shootTime += Engine.DeltaTime;
            if (shootTime >= 1f)
            {
                EnemyLaser l = (EnemyLaser)PoolMrg.GetActor(typeof(EnemyLaser));
                if (l != null)
                {
                    shootSound.Position = position;
                    shootSound.Play(SoundLibrary.GetSound("Shoot0"));
                    //laserShot.Position = position;
                    //laserShot.Play(SoundLibrary.GetSound("Shoot0"));
                    l.SetPosition(position);
                    l.SetScale(new Vector3(0.1f, 0.1f, 2f) * 5f);
                    l.SetRotation(rotation);
                    shootTime = 0;
                }
            }
        }
    }
}