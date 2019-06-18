using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfox
{
    public class LifeGUIBehaviour : Behaviour
    {
        private Vector3 vec;
        private Vector2 offset;
        private Vector2 size;

        public LifeGUIBehaviour(Actor owner) : base(owner)
        {
            vec = new Vector3(0.45f, 0.2f, Engine.ZNear);
            offset = new Vector2(0, 0);
            size = new Vector2(159, 41);
            SetScale(Vector3.One * 0.1f + new Vector3(0.1f, -0.05f, 0));
        }
        public override void Update()
        {
            switch (Variables.Life)
            {
                case 3:
                    offset.Y = 0;
                    break;
                case 2:
                    offset.Y = 49;
                    break;
                case 1:
                    offset.Y = 99;
                    break;
                default:
                    offset.Y = 141;
                    break;
            }
            SetTextureUV(offset, size);
            vec = new Vector3(-0.42f, 0.25f, -Engine.ZNear);
            SetPosition(Engine.PerspectiveCamera.Position3 + vec);
        }
    }
}
