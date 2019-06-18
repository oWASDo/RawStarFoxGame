using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Audio;

namespace Starfox
{
    public class PlayerShipBehaviour : Behaviour
    {
        private AudioSource laserShot;
        private AudioSource shipFloting;
        private float rotationSpeed;
        private float rightSpeed;
        private float upSpeed;
        public static float Speed = PlayerShip.Speed;
        private bool barrelRollRight;
        private bool barrelRollLeft;
        private bool MovingUpDown { get; set; }
        private bool MovingRightLeft { get; set; }
        private bool MovingBrarrelRoll { get; set; }
        private bool left;
        private bool right;
        public static Vector4 limit;
        private float rollSpeed;
        private float rollMoviment;
        private float rollTime;
        private const float ROLL_LIMIT = 0.5f;
        private float invunerabilityTime;
        private float blinkTime;
        private bool shoot;
        private int life;
        private bool hit;
        private bool DeadBool;
        private bool once;
        //float timee = 0;
        //float timeLerpLimit = 1f;
        //private Vector3 LerpStartotation;
        public PlayerShipBehaviour(Actor owner) : base(owner)
        {
            laserShot = new AudioSource();
            shipFloting = new AudioSource();
            shipFloting.Volume = 0.2f;
            Console.WriteLine(laserShot.Volume);
            laserShot.Volume = 0.5f;
            rotationSpeed = 180 + 90 + 45f;
            rightSpeed = 100f;
            upSpeed = rightSpeed;
            barrelRollRight = false;
            barrelRollLeft = false;
            rollSpeed = 360f * 2.5f;
            left = false;
            right = false;
            shoot = false;
            limit = new Vector4(150, -150, 120, -3);
            life = 3;
            hit = false;
            invunerabilityTime = 0;
            blinkTime = 0;
            rollTime = 0;
            rollMoviment = rightSpeed * 1.5f;
            once = false;
        }
        public override void Update()
        {
            if (!DeadBool)
            {
                MoveForward();

                MoveUp();

                MoveRight();

                QAndE();

                Shoot();

                Hit();

                Blink();

                Sonund();

                BarrelRoll();
            }
            else
            {
                Dead();
            }
            Variables.Life = life;
        }
        private void MoveUp()
        {
            bool moveUp = false;
            bool moveDown = false;
            if (Engine.GetKey(KeyCode.W))
            {
                if (position.Y <= limit.Z)
                {
                    Move(upSpeed, Engine.PerspectiveCamera.Up);
                    moveUp = true;
                }
                else
                    moveUp = false;

                if (rotation.X > -10f)
                {
                    if (right || left)
                    {
                        Rotate(rotationSpeed, Engine.PerspectiveCamera.Right);
                        //LerpStartotation = rotation;
                        //timee = 0;
                    }
                    else
                    {
                        if (moveUp)
                        {
                            Rotate(rotationSpeed, Right);
                            //LerpStartotation = rotation;
                            //timee = 0;
                        }
                    }
                }
            }
            else if (Engine.GetKey(KeyCode.S))
            {
                if (position.Y > limit.W)
                {
                    Move(upSpeed, -Engine.PerspectiveCamera.Up);
                    moveDown = true;
                }
                else
                    moveDown = false;
                if (rotation.X < 10f)
                {
                    if (right || left)
                    {
                        Rotate(rotationSpeed, -Engine.PerspectiveCamera.Right);
                        //LerpStartotation = rotation;
                        //timee = 0;
                    }
                    else
                    {
                        if (moveDown)
                        {
                            Rotate(rotationSpeed, -Right);
                            //LerpStartotation = rotation;
                            //timee = 0;
                        }
                    }
                }
            }
            if (moveUp || moveDown)
                MovingUpDown = true;
            else
                MovingUpDown = false;
        }
        private void MoveRight()
        {
            bool moveRigth = false;
            bool moveLeft = false;
            if (Engine.GetKey(KeyCode.A))
            {
                if (position.X < limit.X)
                {
                    Move(rightSpeed, -Engine.PerspectiveCamera.Right);
                    moveLeft = true;
                }
                else
                    moveLeft = false;
                if (rotation.Z > -30f && moveLeft)
                {
                    Rotate(rotationSpeed, -Forward);
                    //timee = 0;
                    //LerpStartotation = rotation;
                }
            }
            else if (Engine.GetKey(KeyCode.D))
            {
                if (position.X > limit.Y)
                {
                    Move(rightSpeed, Engine.PerspectiveCamera.Right);
                    moveRigth = true;
                }
                else
                    moveRigth = false;
                if (rotation.Z < 30f && moveRigth)
                {
                    Rotate(rotationSpeed, Forward);
                    //LerpStartotation = rotation;
                    //timee = 0;
                }
            }
            if (moveRigth || moveLeft)
                MovingRightLeft = true;
            else
                MovingRightLeft = false;
        }
        private void MoveForward()
        {
            Move(PlayerShip.Speed, Engine.PerspectiveCamera.Forward);
        }
        private void QAndE()
        {
            if (Engine.GetKey(KeyCode.E))
            {
                if (rotation.Z <= 90f)
                {
                    Rotate(rotationSpeed, Engine.PerspectiveCamera.Forward);
                }
                //SetRotation(Vector3.Lerp(rotation, new Vector3(0, 0, 90), Engine.DeltaTime * 10));
                //LerpStartotation = rotation;
                //timee = 0;
                if (Engine.GetKey(KeyCode.ShiftLeft))
                {
                    barrelRollRight = true;
                }
                left = true;
                right = false;
            }
            else if (Engine.GetKey(KeyCode.Q))
            {
                if (rotation.Z >= -90f)
                {
                    Rotate(rotationSpeed, -Engine.PerspectiveCamera.Forward);
                }
                //SetRotation(Vector3.Lerp(rotation, new Vector3(0, 0, -90), Engine.DeltaTime * 10));
                //LerpStartotation = rotation;
                //timee = 0;
                if (Engine.GetKey(KeyCode.ShiftLeft))
                {
                    barrelRollLeft = true;
                }
                right = true;
                left = false;
            }
            else
            {
                right = false;
                left = false;
                if (!barrelRollLeft || !barrelRollRight)
                {
                    //timee += Engine.DeltaTime;
                    //if (timee <= timeLerpLimit)
                    //{

                    //    SetRotation(Vector3.Lerp(LerpStartotation, Vector3.Zero, timee / timeLerpLimit));
                    //    //LerpRotation(new Vector3(), timee / timeLinitee);
                    //}
                    //else
                    //{
                    //    SetRotation(Vector3.Zero);
                    //    timee = timeLerpLimit;
                    //}
                    //Console.WriteLine(timee / timeLerpLimit);

                    ReturnToRotationZero();
                }
            }
            if (left || right)
                MovingBrarrelRoll = true;
            else
                MovingBrarrelRoll = false;
        }
        private void ReturnToRotationZero()
        {
            float a = 0;
            float speed = rotationSpeed * 0.5f;
            if (!MovingUpDown && (rotation.X < a || rotation.X > a))
            {
                if (rotation.X < a)
                {
                    Rotate(speed, new Vector3(1, 0, 0));
                    if (rotation.X > a)
                    {
                        SetRotation(new Vector3(0, rotation.Y, rotation.Z));
                    }
                }
                else if (rotation.X > a)
                {
                    Rotate(speed, -new Vector3(1, 0, 0));
                    if (rotation.X < a)
                    {
                        SetRotation(new Vector3(0, rotation.Y, rotation.Z));
                    }
                }
            }


            if (!MovingBrarrelRoll && (rotation.Y < 0 || rotation.Y > 0))
            {
                if (rotation.Y < a)
                {
                    Rotate(speed, new Vector3(0, 1, 0));
                    if (rotation.Y > a)
                    {
                        SetRotation(new Vector3(rotation.X, 0, rotation.Z));
                    }
                }
                else if (rotation.Y > a)
                {
                    Rotate(speed, -new Vector3(0, 1, 0));
                    if (rotation.X < a)
                    {
                        SetRotation(new Vector3(rotation.X, 0, rotation.Z));
                    }
                }
            }


            if (!MovingRightLeft && (rotation.Z < 0 || rotation.Z > 0))
            {
                if (rotation.Z < a)
                {
                    Rotate(speed, new Vector3(0, 0, 1));
                    if (rotation.Z > a)
                    {
                        SetRotation(new Vector3(rotation.X, rotation.Y, 0));
                    }
                }
                else if (rotation.Z > a)
                {
                    Rotate(speed, -new Vector3(0, 0, 1));
                    if (rotation.Z < a)
                    {
                        SetRotation(new Vector3(rotation.X, rotation.Y, 0));
                    }
                }
            }
        }
        private void Shoot()
        {
            if (Engine.GetKey(KeyCode.Space))
            {
                if (!shoot)
                {
                    Laser l = (Laser)PoolMrg.GetActor(typeof(Laser));
                    if (l != null)
                    {
                        laserShot.Position = position;
                        laserShot.Play(SoundLibrary.GetSound("Shoot0"));
                        l.SetPosition(position);
                        l.SetScale(new Vector3(0.1f, 0.1f, 2f) * 5f);
                        l.SetRotation(rotation);
                    }
                }
                shoot = true;
            }
            else
            {
                shoot = false;
            }
        }
        private void Sonund()
        {
            if (!shipFloting.IsPlaying)
            {
                shipFloting.Play(SoundLibrary.GetSound("Floating"), false);
            }

        }
        private void Blink()
        {
            if (hit)
            {
                invunerabilityTime += Engine.DeltaTime;
                blinkTime += Engine.DeltaTime;
                if (blinkTime >= 0.1f)
                {
                    if (Visible == true)
                    {
                        Visible = false;
                    }
                    else
                    {
                        Visible = true;
                    }
                    blinkTime = 0;
                }
                if (invunerabilityTime >= 3f)
                {
                    Visible = true;
                    hit = false;
                    invunerabilityTime = 0;
                }
            }
        }
        private void Hit()
        {
            if (!hit && OnCollide)
            {
                if (CollideWith is Enemy || CollideWith is WaterTank || CollideWith is EnemyLaser)
                {
                    hit = true;
                    life--;
                    Explosion0 explosion = new Explosion0(position, rotation, scale);
                    Engine.CurrentLevel.Spawn(explosion, Trasparecy.YES);
                    Variables.Hitted = true;
                }
            }
            if (life <= 0)
            {
                DeadBool = true;
                Variables.Dead = true;
            }
        }
        private void BarrelRoll()
        {
            if (barrelRollLeft)
            {
                Rotate(rollSpeed, -Engine.PerspectiveCamera.Forward);
                Move(rollMoviment, -Engine.PerspectiveCamera.Right);
            }
            else if (barrelRollRight)
            {
                Rotate(rollSpeed, Engine.PerspectiveCamera.Forward);
                Move(rollMoviment, Engine.PerspectiveCamera.Right);
            }
            rollTime += Engine.DeltaTime;
            if (rollTime >= ROLL_LIMIT)
            {
                barrelRollLeft = false;
                barrelRollRight = false;
                rollTime = 0;
            }
        }
        private void Dead()
        {
            if (once == false)
            {
                Explosion0 explosion = new Explosion0(position, rotation, scale);
                Engine.CurrentLevel.Spawn(explosion, Trasparecy.YES);
                once = true;
            }

        }
    }
}
