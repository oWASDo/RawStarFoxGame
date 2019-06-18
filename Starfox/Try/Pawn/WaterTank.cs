using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Starfox
{
    public class WaterTank : ActorMeshes
    {
        Random random;
        public WaterTank()
        {
            int n = DateTime.Now.Second + DateTime.Now.Minute + DateTime.Now.Hour + DateTime.Now.Millisecond;
            random = new Random(n);
            random.Next();
            switch (random.Next(0, 2))
            {
                case 0:
                    AddShape(0, Aiv.Fast3D.ObjLoader.Load("Assets/Obj/Tower_Left.obj", Vector3.One)[0]);
                    break;
                case 1:
                    AddShape(0, Aiv.Fast3D.ObjLoader.Load("Assets/Obj/Tower_Right.obj", Vector3.One)[0]);
                    break;
                default:
                    AddShape(0, Aiv.Fast3D.ObjLoader.Load("Assets/Obj/Tower_Left.obj", Vector3.One)[0]);
                    break;
            }
            AddMaterial(0, MaterialLibrary.GetMaterial("Tower"));
            AddCollider(new Vector3(0f, 150f, 0f), new Vector3(30, 200, 30), Vector3.Zero, ColliderType.CUBE);
        }
        public override bool Update()
        {
            if (base.Update())
            {
                if (Position.Z <= Engine.PerspectiveCamera.Position3.Z)
                {
                    Visible = false;
                    IsActive = false;
                }
                return IsActive;
            }
            return IsActive;
        }
    }
}
