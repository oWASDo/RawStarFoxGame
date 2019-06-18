using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast3D;

namespace Starfox
{
    public class Missile : ActorMeshes
    {
        public Actor enemy;
        public Missile()
        {
            AddShape(0, ObjLoader.Load("Assets/Obj/NukeBomb.obj", Vector3.One)[0]);
            AddShape(1, ObjLoader.Load("Assets/Obj/NukeBomb.obj", Vector3.One)[1]);
            AddShape(2, ObjLoader.Load("Assets/Obj/NukeBomb.obj", Vector3.One)[2]);

            AddMaterial(0, MaterialLibrary.GetMaterial("Bomb"));
            AddMaterial(1, MaterialLibrary.GetMaterial("Bomb"));
            AddMaterial(2, MaterialLibrary.GetMaterial("Bomb"));

            AddCollider(Vector3.Zero, Vector3.One, Vector3.One * 10, ColliderType.SPHERE);

            AddBehaviour(new MissilesBehaviour(this));
        }
        public Missile(Vector3 position, Vector3 rotation, Vector3 scale) : base(position, rotation, scale)
        {
            AddShape(0, ObjLoader.Load("Assets/Obj/NukeBomb.obj", scale)[0]);
            AddShape(1, ObjLoader.Load("Assets/Obj/NukeBomb.obj", scale)[1]);
            AddShape(2, ObjLoader.Load("Assets/Obj/NukeBomb.obj", scale)[2]);

            AddMaterial(0, MaterialLibrary.GetMaterial("Bomb"));
            AddMaterial(1, MaterialLibrary.GetMaterial("Bomb"));
            AddMaterial(2, MaterialLibrary.GetMaterial("Bomb"));

            AddCollider(Vector3.Zero, Vector3.One, Vector3.One * 10, ColliderType.SPHERE);

            AddBehaviour(new MissilesBehaviour(this));
        }
    }
}
