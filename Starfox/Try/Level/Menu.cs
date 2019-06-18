using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;
using Aiv.Fast3D;

namespace Starfox
{
    public class Menu : Level
    {
        Sprite2 background;

        public Menu() : base()
        {
            Light = new DirectionalLight(new Vector3(0, -1, 1) /*Utils.EulerRotationToDirection(new Vector3(-30, -30, -30))*/);
            Light.SetShadowProjection(-300, 300, -100, 500, -50, 500);
        }

        public override void Init()
        {
            MaterialLibrary.LoadMaterial("Start", new Material("start.png", 0, true, true));
            MaterialLibrary.LoadMaterial("Exit", new Material("Exit.png", 0, true, true));
            MaterialLibrary.LoadMaterial("Space", new Material("hipp8.png", 0, true, true));
            Camera a = new Camera();
            Engine.SetCamera(a);

            //skySphere = new SkySphere(Vector3.Zero, Vector3.Zero, Vector3.One * 2500, "hipp8.png", 4);

            ExitButton exit = new ExitButton(new Vector3(7, 6, 1), Vector3.Zero, new Vector3(2, 1, 0));
            Spawn(exit, Trasparecy.NO);

            StartButton start = new StartButton(new Vector3(7, 4, 1), Vector3.Zero, new Vector3(2, 1, 0));
            Spawn(start, Trasparecy.NO);

            background = new Sprite2(Vector3.Zero, Vector3.Zero, new Vector3(5,4,5));
            background.AddMaterial(MaterialLibrary.GetMaterial("Space"));
            Spawn(background, Trasparecy.NO);
        }
        public override void MainBehaviour()
        {
            base.MainBehaviour();
        }
    }
}
