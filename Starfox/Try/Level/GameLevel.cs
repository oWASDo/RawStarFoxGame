using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;
using Aiv.Fast3D;
using Aiv.Audio;

namespace Starfox
{
    public class GameLevel : Level
    {
        private float time0;
        private float time1;
        private float time2;
        private float timelimit0;
        private float timelimit1;
        private float timeLimit2;

        private int n;

        private Random random;
        private AudioSource audio;

        public GameLevel()
        {
            n = DateTime.Now.Second + DateTime.Now.Minute + DateTime.Now.Hour + DateTime.Now.Millisecond;
            random = new Random(n);
            time0 = 0;
            time1 = 0;
            time2 = 0;
            timeLimit2 = 2;
            timelimit1 = 5;
            timelimit0 = 5;
            audio = new AudioSource();
            Light = new DirectionalLight(new Vector3(0, -1, 1) /*Utils.EulerRotationToDirection(new Vector3(-30, -30, -30))*/);
            Light.SetShadowProjection(-300, 300, -100, 500, -500, 500);
        }

        public override void Init()
        {
            #region Material
            MaterialLibrary.LoadMaterial("Enemy0", new Material("Kenos.png", 0, true, true));
            MaterialLibrary.LoadMaterial("Enemy1", new Material("Kenos - Copia.png", 0, true, true));
            MaterialLibrary.LoadMaterial("Particles0", new Material("Particles0.png", 0, true, true));
            MaterialLibrary.LoadMaterial("WaterTank", new Material("WaterTank.png", 0, true, true));
            MaterialLibrary.LoadMaterial("Bomb", new Material("RadiationLogo.png", 0, true, true));
            MaterialLibrary.LoadMaterial("MissileGUI", new Material("MissileGUI.png", 0, true, true));
            MaterialLibrary.LoadMaterial("BodyShip", new Material("bodyship_texture.jpg", 0, true, true));
            MaterialLibrary.LoadMaterial("RoadShip", new Material("Road_texture.png", 0, true, true));
            MaterialLibrary.LoadMaterial("GUI", new Material("hud+font.png", 0, true, true));
            MaterialLibrary.LoadMaterial("Tower", new Material("tower_texture.png", 0, true, true));
            MaterialLibrary.LoadMaterial("Explosion", new Material("BlueExplosion.png"));
            MaterialLibrary.LoadMaterial("Simone", new Material("Simone1.png"));
            MaterialLibrary.LoadMaterial("Capa", new Material("Capa1.png"));
            MaterialLibrary.LoadMaterial("Fulvio", new Material("Fulvio1.png"));
            MaterialLibrary.LoadMaterial("Life", new Material("Life.png"));
            MaterialLibrary.LoadMaterial("Numbers", new Material("Numbers.png"));
            #endregion

            #region Sound
            SoundLibrary.AddSound(new AudioClip("Assets/Sound/Teleport0.wav"), "Teleport");
            SoundLibrary.AddSound(new AudioClip("Assets/Sound/BigShoot.wav"), "BigShoot");
            SoundLibrary.AddSound(new AudioClip("Assets/Sound/Explosion0.wav"), "Explosion0");
            SoundLibrary.AddSound(new AudioClip("Assets/Sound/Explosion1.wav"), "Explosion1");
            SoundLibrary.AddSound(new AudioClip("Assets/Sound/Flight - Star_Stirloremastered.wav"), "Soundtrack");
            SoundLibrary.AddSound(new AudioClip("Assets/Sound/MiHannoColpito.wav"), "WeHitMe");
            SoundLibrary.AddSound(new AudioClip("Assets/Sound/CiHannoColpiti.wav"), "WeHitUs");
            SoundLibrary.AddSound(new AudioClip("Assets/Sound/AHCiHannoColpiti.wav"), "HaWeHitUs");
            SoundLibrary.AddSound(new AudioClip("Assets/Sound/WASDKey.wav"), "UseWasd");
            SoundLibrary.AddSound(new AudioClip("Assets/Sound/PremiBarraSpaziatrice.wav"), "UseSpaceBar");
            SoundLibrary.AddSound(new AudioClip("Assets/Sound/BarrelRoll.wav"), "BarrelRoll");
            SoundLibrary.AddSound(new AudioClip("Assets/Sound/MissilePronto.wav"), "MissileReady");
            SoundLibrary.AddSound(new AudioClip("Assets/Sound/No0.wav"), "No0");
            SoundLibrary.AddSound(new AudioClip("Assets/Sound/NO1.wav"), "No1");
            SoundLibrary.AddSound(new AudioClip("Assets/Sound/MissilePronto.wav"), "MissileReady");
            #endregion

            #region Pawn
            PlayerShip a = new PlayerShip(new Vector3(0f, 0f, 0f), Vector3.Zero, Vector3.One);
            Spawn(a, Trasparecy.NO);
            EnemyMotherShip cube = new EnemyMotherShip(new Vector3(0, Variables.MotherShipHight, Variables.MotherShipOffset * 2f), Vector3.Zero, new Vector3(1f, 1f, 1f));
            Spawn(cube, Trasparecy.NO);
            EnemyMotherShip plane = new EnemyMotherShip(Vector3.Zero + new Vector3(0, Variables.MotherShipHight, 0), Vector3.Zero, Vector3.One);
            Spawn(plane, Trasparecy.NO);
            skySphere = new SkySphere(Vector3.Zero, Vector3.Zero, Vector3.One * 2500, "hipp8.png", 4);
            PoolMrg.RegisterPool<Enemy>(60, Trasparecy.NO, new Vector3(-100, -100, -100));
            Radar radar = new Radar(new Vector3(0.1f, -0.1f, 0), new Vector3(0, 0, 180), Vector3.One * 0.1f);
            Spawn(radar, Trasparecy.NO);
            Crosshair b = new Crosshair(Vector3.Zero, Vector3.Zero, Vector3.One * 0.1f);
            Spawn(b, Trasparecy.YES);
            PoolMrg.RegisterPool<WaterTank>(30, Trasparecy.NO, new Vector3(-1000, -1000, -1000));
            MissileGUI m = new MissileGUI(Vector3.Zero, Vector3.Zero, Vector3.One * 0.1f);
            Spawn(m, Trasparecy.YES);
            MessageGUI gui = new MessageGUI(Vector3.One, Vector3.Zero, Vector3.One);
            Spawn(gui, Trasparecy.YES);
            LifeGUI life = new LifeGUI(Vector3.One, Vector3.Zero, Vector3.One);
            Spawn(life, Trasparecy.YES);
            PoolMrg.RegisterPool<EnemyLaser>(30, Trasparecy.NO);
            #endregion
        }

        public override void MainBehaviour()
        {
            audio.Stream(SoundLibrary.GetSound("Soundtrack"), Engine.DeltaTime, true);
            time1 += Engine.DeltaTime;
            if (time1 >= timelimit1)
            {
                Actor player0 = GetActor(typeof(PlayerShip));
                Actor tank = PoolMrg.GetActor(typeof(WaterTank));
                if (tank != null)
                {
                    if (player0 != null)
                    {
                        tank.SetPosition(new Vector3(random.Next((int)PlayerShipBehaviour.limit.Y, (int)PlayerShipBehaviour.limit.X), -75f, 2000 + player0.Position.Z));
                        tank.SetRotation(new Vector3(0, 90, 0));
                        tank.SetScale(Vector3.One);
                    }
                }
                time1 = 0;
                timelimit1 -= 0.05f;
            }

            time0 += Engine.DeltaTime;
            Console.WriteLine(time0);
            if (time0 >= timelimit0)
            {
                Enemy en = (Enemy)PoolMrg.GetActor(typeof(Enemy));
                en.SetPosition(Vector3.Zero);
                en.SetRotation(new Vector3(0, 180, 0));
                en.SetScale(Vector3.One);
                Spawn(en, Trasparecy.NO);
                time0 = 0;
                timelimit0 -= 0.05f;
            }

            if (Variables.Dead)
            {
                time2 += Engine.DeltaTime;
                timeLimit2 = SoundLibrary.GetSound("MissileReady").Duration;
                if (time2 >= timeLimit2)
                {
                    Engine.ChangeLevel(0);
                }
            }
        }
    }
}
