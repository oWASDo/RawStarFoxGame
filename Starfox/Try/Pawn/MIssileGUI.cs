using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Starfox
{
    class MissileGUI : GUI
    {
        public MissileGUI(Vector3 position, Vector3 rotation, Vector3 scale) : base(position, rotation, scale)
        {
            AddMaterial(MaterialLibrary.GetMaterial("MissileGUI"));
            AddBehaviour(new MissileGuiBehaviour(this));
        }
    }
}
