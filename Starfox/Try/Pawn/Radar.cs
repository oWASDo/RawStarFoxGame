using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Aiv.Fast2D;
using Aiv.Fast3D;

namespace Starfox
{
    public class Radar : Billboard
    {
        private GameCamera camera;
        private RenderTexture texture;
        public Radar(Vector3 position, Vector3 rotation, Vector3 scale) : base(position, rotation, scale)
        {
            camera = new GameCamera(position, new Vector3(-90, 0, 0), scale, 60, 0.1f, 1500);
            camera.AddBehaviour(new CameraRadarBehaviour(camera));
            Engine.CurrentLevel.Spawn(camera, Trasparecy.NO);
            AddBehaviour(new RadarBehaviour(this));
            texture = new RenderTexture(1080, 1080);
            AddMaterial(new Material(texture, 0));
            IsActive = true;
            Visible = true;
        }

        public override bool Update()
        {
            if (base.Update())
            {
                //Console.WriteLine(camera.Position + "camera");
                //Engine.SetClearColor(new Vector4(0f, 0.5f, 0f, 1f));
                Engine.SetCamera(camera.Camera);
                Engine.RenderTo(texture);
                foreach (Actor item in Engine.CurrentLevel.GetActors(typeof(Enemy)))
                {
                    if (item.Visible)
                    {
                        item.DrawColor(new Vector4(1.0f, 0.0f, 1.0f, 0));
                    }
                }
                foreach (Actor item in Engine.CurrentLevel.GetActors(typeof(WaterTank)))
                {
                    item.DrawColor(new Vector4(0.5f, 0.5f, 0, 0));
                }
                foreach (Actor item in Engine.CurrentLevel.GetActors(typeof(EnemyLaser)))
                {
                    item.DrawColor(new Vector4(1f, 0.5f, 0, 0));
                }
                foreach (Actor item in Engine.CurrentLevel.GetActors(typeof(Laser)))
                {
                    item.DrawColor(new Vector4(1f, 0f, 0, 0));
                }
                PlayerShip player = Engine.CurrentLevel.GetActor(typeof(PlayerShip)) as PlayerShip;
                if (player.Visible)
                {
                    player.DrawColor(new Vector4(0.0f, 1.0f, 0.0f, 0));
                }
                Engine.RenderNull();
                Engine.SetCamera(player.Camera);
                //Engine.SetClearColor(new Vector4(0f, 0f, 0f, 1f));
                material.Texture = texture;

                return IsActive;
            }
            else
                return IsActive;
        }
    }
}