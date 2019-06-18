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
    public class EnemyMotherShip : ActorMeshes
    {
        public EnemyMotherShip(Vector3 position, Vector3 rotation, Vector3 scale) : base(position, rotation, scale)
        {
            AddShape(0, ObjLoader.Load("Assets/Obj/Floor_Ship.obj", scale)[0]);
            AddMaterial(0, MaterialLibrary.GetMaterial("BodyShip"));
            AddBehaviour(new MotherShipBehaviour(this));
            //AddMaterial(1, MaterialLibrary.GetMaterial("BodyShip"));
        }
    }
}
