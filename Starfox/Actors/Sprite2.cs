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
    public class Sprite2 : ActorMesh
    {
        Sprite sprite;
        public Sprite2() : base()
        {
            sprite = new Sprite(1, 1);
        }
        public Sprite2(Vector3 position, Vector3 rotation, Vector3 scale) : base(position, rotation, scale)
        {
            sprite = new Sprite(scale.X, scale.Y);
            sprite.position = position.Xy;
            sprite.EulerRotation = rotation.X;
        }
        public override bool Update()
        {
            if (base.Update())
            {
                sprite.position = Position.Xy;
                sprite.scale = Scale.Xy;
                sprite.Rotation = Rotation.X;
                return IsActive;
            }
            return IsActive;
        }
        public override bool Draw()
        {
            if (Visible && material != null)
            {
                sprite.DrawTexture(material.Texture);
                return Visible;
            }
            else
                return Visible;
        }
    }
}
