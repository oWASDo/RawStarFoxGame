using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfox
{
    public class SkySphere : GameSphere
    {
        public SkySphere(Vector3 position, Vector3 rotation, Vector3 scale, string filePaht, float multiplyFactor = 0) : base(position, rotation, scale)
        {
            Engine.CurrentLevel.Spawn(this, Trasparecy.NO);
            AddMaterial(new Material(filePaht, 0, true, true));
            if (multiplyFactor != 0)
            {
                UV_Multiplier(multiplyFactor);
            }
        }
        public override bool Update()
        {
            if (base.Update())
            {
                if (Engine.PerspectiveCamera != null)
                {
                    SetPosition(Engine.PerspectiveCamera.Position3);
                }
                else if (Engine.Camera != null)
                {
                    SetPosition(new Vector3(Engine.Camera.position.X, Engine.Camera.position.Y, 0));
                }
                return IsActive;
            }
            else
                return IsActive;
        }
        public override void DrawShadow()
        {
        }
        public override bool Draw()
        {
            if (base.Update())
            {
                if (mesh != null && material != null)
                {
                    mesh.DrawTexture(material.Texture);
                }
                return Visible;
            }
            else
                return Visible;
        }
    }
}
