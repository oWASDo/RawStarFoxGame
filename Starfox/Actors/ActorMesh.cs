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
    public class ActorMesh : Actor
    {
        public override Vector3 Forward
        {
            get
            {
                return mesh.Forward;
            }
        }
        public override Vector3 Right
        {
            get
            {
                return mesh.Right;
            }
        }
        public override Vector3 Up
        {
            get
            {
                return mesh.Up;
            }
        }



        protected Mesh3 mesh;
        protected Material material;
        protected Mesh3 Mesh => mesh;
        public Texture texture
        {
            get
            {
                return material.Texture;
            }
        }

        public ActorMesh(Vector3 position, Vector3 rotation, Vector3 scale) : base(position, rotation, scale)
        {
        }

        public ActorMesh()
        {
        }
        public override bool Update()
        {
            if (base.Update())
            {
                if (mesh != null)
                {
                    mesh.Position3 = Position;
                    mesh.EulerRotation3 = Rotation;
                    mesh.Scale3 = Scale;
                }
                return Visible;
            }
            return Visible;
        }
        public override bool Draw()
        {
            if (base.Draw())
            {
                if (mesh != null && material != null)
                {
                    if (Engine.DrawShadow)
                        mesh.DrawPhong(material.Texture, Engine.CurrentLevel.Light, Engine.CurrentLevel.Light.Color, material.Shines, Engine.CurrentLevel.shadowMap);
                    else
                        mesh.DrawPhong(material.Texture, Engine.CurrentLevel.Light, Engine.CurrentLevel.Light.Color);
                }
                return Visible;
            }
            return Visible;
        }
        public override void DrawColor(Vector4 color)
        {
            mesh.DrawColor(color);
        }


        public void AddMaterial(Material material)
        {
            this.material = material;
        }
        public void ChangeMaterial(Material material)
        {
            this.material = material;
        }
        public void AddShape(Mesh3 mesh)
        {
            if (this is IStatic)
                return;
            this.mesh = mesh;
        }
        public override void DrawShadow()
        {
            if (ShadowRendering && Visible)
            {
                if (!(this is Sprite2))
                {
                    bool shadow;
                    try
                    {
                        shadow = (Engine.CurrentLevel.Light.ShadowProjection != null);
                        shadow = true;
                    }
                    catch (InvalidCastException)
                    {
                        shadow = false;
                    }
                    if (Engine.CurrentLevel.Light != null && shadow)
                    {
                        mesh.DrawShadowMap(Engine.CurrentLevel.Light);
                    }
                }
            }
        }

        public override void UV_Multiplier(float multiplier)
        {
            if (material.RepeatedX && material.RepeatedY)
            {
                for (int j = 0; j < mesh.uv.Length; j++)
                {
                    mesh.uv[j] *= multiplier;
                    mesh.UpdateUV();
                }
            }
        }
        public override void U_Multiplier(float multiplier)
        {
            if (material.RepeatedX && material.RepeatedY)
            {
                for (int j = 0; j < mesh.uv.Length; j += 2)
                {
                    mesh.uv[j] *= multiplier;
                    mesh.UpdateUV();
                }
            }
        }
        public override void V_Multiplier(float multiplier)
        {
            if (material.RepeatedX && material.RepeatedY)
            {
                for (int j = 1; j < mesh.uv.Length; j += 2)
                {
                    mesh.uv[j] *= multiplier;
                    mesh.UpdateUV();
                }
            }
        }
        public void AddCollider(Vector3 position, Vector3 scale, Vector3 rotation, ColliderType type)
        {
            if (colliders == null)
                colliders = new List<Collider>();
            if (type == ColliderType.CUBE)
            {
                BoundingBox b = new BoundingBox(position, scale, rotation, this);
                b.SetParent(mesh);
                Engine.CurrentLevel.AddColliders(b);
                //colliders.Add(b);
                //PhysxMgr.AddCollider(b);
            }
            else if (type == ColliderType.SPHERE)
            {
                BoundingSphere s = new BoundingSphere(position, scale, rotation, this);
                s.SetParent(mesh);
                Engine.CurrentLevel.AddColliders(s);
                //colliders.Add(s);
                //PhysxMgr.AddCollider(s);
            }
        }

        public void SetParent(Mesh3 mesh)
        {
            this.mesh.SetParent(mesh);
        }
        public override void SetAdditiveTint(Vector4 tint)
        {
            this.mesh.shader.SetUniform("add_tint", tint);
        }
        public override void SetMultiplyTint(Vector4 tint)
        {
            this.mesh.shader.SetUniform("mul_tint", tint);
        }
    }
}
