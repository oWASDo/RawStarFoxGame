using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Starfox
{
    public class Explosion0 : Billboard
    {
        public Explosion0(Vector3 position, Vector3 rotation, Vector3 scale) : base(position, rotation, scale)
        {
            AddMaterial(MaterialLibrary.GetMaterial("Explosion"));
            SetScale(Vector3.One * 30);
            AddBehaviour(new ExplosionBehaviour(this));
        }
    }
}
