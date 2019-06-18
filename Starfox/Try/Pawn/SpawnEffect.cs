using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Aiv.Audio;

namespace Starfox
{
    public class SpawnEffect : Billboard
    {
        public SpawnEffect(Vector3 position, Vector3 rotation, Vector3 scale) : base(position, rotation, scale)
        {
            
            AddBehaviour(new SpawnEffectBehaviour(this));
            AddMaterial(MaterialLibrary.GetMaterial("Particles0"));
            ShadowRendering = false;
        }
    }
}
