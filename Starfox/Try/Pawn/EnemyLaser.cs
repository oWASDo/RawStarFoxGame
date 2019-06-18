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
    public class EnemyLaser : GameSphere
    {
        public EnemyLaser() : base()
        {
            AddMaterial(new Material("Red.jpg"));
            AddBehaviour(new EnemyLaserBehaviour(this));
            AddCollider(Vector3.Zero, Vector3.One * 5, Vector3.Zero, ColliderType.SPHERE);
            ShadowRendering = false;
            Tag = "EnemyLaser";
        }
    }
}
