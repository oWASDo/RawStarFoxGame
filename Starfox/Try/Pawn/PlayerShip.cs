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
    public class PlayerShip : ActorMeshes
    {
        public static float Speed = 300.0f;
        GameCamera camera;
        public PerspectiveCamera Camera => camera.Camera;
        public PlayerShip(Vector3 position, Vector3 rotation, Vector3 scale) : base(position, rotation, scale)
        {
            SoundLibrary.AddSound(new Aiv.Audio.AudioClip("Assets/Sound/shoot0.wav"), "Shoot0");
            SoundLibrary.AddSound(new Aiv.Audio.AudioClip("Assets/Sound/ShipEffect.wav"), "Floating");
            AddBehaviour(new PlayerShipBehaviour(this));

            AddMaterial(0, new Material("Zaiten0.png", 0, true, true));
            AddMaterial(1, new Material("Zaiten0.png", 0, true, true));

            AddShape(0, ObjLoader.Load("Assets/Obj/Zaiten1_chassis.obj", Vector3.One)[0]);
            AddShape(1, ObjLoader.Load("Assets/Obj/Zaiten1_shell.obj", Vector3.One)[0]);

            float mul = 6;
            float y = -1.5f;


            //AddCollider(new Vector3(0f,0f,0f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            AddCollider(new Vector3(0f, y, -10f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            AddCollider(new Vector3(0f, y, 5f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            AddCollider(new Vector3(0f, y, -20f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            AddCollider(new Vector3(0f, y + 2f, -10f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            AddCollider(new Vector3(0f, y + 2f, 5f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            AddCollider(new Vector3(0f, y + 2f, -20f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);

            //AddCollider(new Vector3(0f, 0f, 20f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);

            AddCollider(new Vector3(7f, y, 0f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            AddCollider(new Vector3(7f, y, -10f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            AddCollider(new Vector3(7f, y, 10f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            AddCollider(new Vector3(7f, y, -20f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            AddCollider(new Vector3(7f, y, 20f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);

            AddCollider(new Vector3(-7f, y, 0f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            AddCollider(new Vector3(-7f, y, -10f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            AddCollider(new Vector3(-7f, y, 10f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            AddCollider(new Vector3(-7f, y, -20f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            AddCollider(new Vector3(-7f, y, 20f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);

            Tag = "Player0";

            CrosshairShip crosshair0 = new CrosshairShip(new Vector3(0, 0, 40), Vector3.Zero, Vector3.One * 5);
            crosshair0.SetParent(Mesh);
            Engine.CurrentLevel.Spawn(crosshair0, Trasparecy.YES);

            Vector3 v = new Vector3(new Vector3(0f, 5f, 40f) * 3f);
            camera = new GameCamera(Position + new Vector3(0f, 10f, -100f) * 3f, new Vector3(0, 0, 0), Vector3.One, 60, 0.1f, 5000);
            camera.AddBehaviour(new PlayerCamera(camera));
            Engine.CurrentLevel.Spawn(camera, Trasparecy.NO);
            Engine.SetCamera(camera.Camera);
            //camera0 = new PerspectiveCamera(Position + new Vector3(0f, 5f, -40f) * 3f, new Vector3(0, 0, 0), 60, 0.001f, 1000);

            PoolMrg.RegisterPool<Laser>(60, Trasparecy.NO, new Vector3(100, 100, 100));
        }
        public override bool Update()
        {
            bool b = base.Update();
            return b;
        }
    }
}
