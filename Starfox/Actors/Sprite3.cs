using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Aiv.Fast3D;

namespace Starfox
{
    public class Sprite3 : GamePlane
    {
        public Sprite3(Vector3 position, Vector3 rotation, Vector3 scale) : base(position, rotation, scale)
        {

        }
        public override bool Update()
        {
            if (base.Update())
            {
                return Visible;
            }
            return Visible;
        }
        public void SetTextureUV(Vector2 offset, Vector2 size)
        {
            float x;
            float y;

            float delteW = 1f / material.Texture.Width;
            float deltaH = 1f / material.Texture.Height;

            x = delteW * offset.X;
            y = deltaH * offset.Y;

            float width = delteW * size.X;
            float height = deltaH * size.Y;

            mesh.uv = new float[]
            {
                x+width,y,
                x,y,
                x,y+height,

                x+width,y,
                x,y+height,
                x+width,y + height

            };
            mesh.UpdateUV();

        }
    }
}
