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
    public class Enemy : ActorMeshes
    {
        public Enemy() : base()
        {
            AddShape(0, ObjLoader.Load("Assets/Obj/Kenos1_chassis.obj", Vector3.One)[0]);
            AddShape(1, ObjLoader.Load("Assets/Obj/Kenos1_shell.obj", Vector3.One)[0]);
            AddMaterial(0, MaterialLibrary.GetMaterial("Enemy0"));
            AddMaterial(1, MaterialLibrary.GetMaterial("Enemy1"));
            AddBehaviour(new EnemyBehaviour(this));

            float mul = 6;
            float y = -1.5f;

            AddCollider(new Vector3(0f, y, -10f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            AddCollider(new Vector3(0f, y, 5f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            AddCollider(new Vector3(0f, y, -20f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            AddCollider(new Vector3(0f, y + 2f, -10f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            AddCollider(new Vector3(0f, y + 2f, 5f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            AddCollider(new Vector3(0f, y + 2f, -20f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);

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
            
        }
        public Enemy(Vector3 position, Vector3 rotation, Vector3 scale) : base(position, rotation, scale)
        {
            AddShape(0, ObjLoader.Load("Assets/Obj/Kenos1_chassis.obj", scale)[0]);
            AddShape(1, ObjLoader.Load("Assets/Obj/Kenos1_shell.obj", scale)[0]);
            AddMaterial(0, MaterialLibrary.GetMaterial("Enemy0"));
            AddMaterial(1, MaterialLibrary.GetMaterial("Enemy1"));
            AddBehaviour(new EnemyBehaviour(this));

            float mul = 6;
            float y = -1.5f;

            AddCollider(new Vector3(0f, y, -10f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            AddCollider(new Vector3(0f, y, 5f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            AddCollider(new Vector3(0f, y, -20f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            AddCollider(new Vector3(0f, y + 2f, -10f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            AddCollider(new Vector3(0f, y + 2f, 5f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            AddCollider(new Vector3(0f, y + 2f, -20f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);

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
            
            //AddCollider(new Vector3(8f, y, 0f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            //AddCollider(new Vector3(8f, y, -10f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            //AddCollider(new Vector3(8f, y, 10f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            //AddCollider(new Vector3(8f, y, -20f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            //AddCollider(new Vector3(8f, y, 20f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);

            //AddCollider(new Vector3(-8f, y, 0f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            //AddCollider(new Vector3(-8f, y, -10f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            //AddCollider(new Vector3(-8f, y, 10f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            //AddCollider(new Vector3(-8f, y, -20f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
            //AddCollider(new Vector3(-8f, y, 20f), Vector3.One * mul, new Vector3(), ColliderType.SPHERE);
        }
    }
}
