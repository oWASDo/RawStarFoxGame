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
    public class ActorMeshes : Actor
    {
        private Dictionary<int, Mesh3> shape;
        private Dictionary<int, Material> materials;
        private int mainMesh;
        protected Mesh3 Mesh
        {
            get
            {
                if (shape == null && shape.Count == 0)
                    return null;
                return shape[mainMesh];
            }
        }
        public Texture texture
        {
            get
            {
                return materials[mainMesh].Texture;
            }
        }

        public override Vector3 Forward
        {
            get
            {
                return shape[mainMesh].Forward;
            }
        }
        public override Vector3 Right
        {
            get
            {
                return shape[mainMesh].Right;
            }
        }
        public override Vector3 Up
        {
            get
            {
                return shape[mainMesh].Up;
            }
        }

        public ActorMeshes() : base()
        {
            shape = new Dictionary<int, Mesh3>();
            materials = new Dictionary<int, Material>();
            mainMesh = 0;
        }

        public ActorMeshes(Vector3 position, Vector3 rotation, Vector3 scale) : base(position, rotation, scale)
        {
            shape = new Dictionary<int, Mesh3>();
            materials = new Dictionary<int, Material>();
            mainMesh = 0;
        }
        public override bool Update()
        {
            if (base.Update())
            {
                foreach (Mesh3 mesh in shape.Values)
                {
                    mesh.Position3 = Position;
                    mesh.EulerRotation3 = Rotation;
                    mesh.Scale3 = Scale;
                }
                return IsActive;
            }
            return IsActive;
        }
        public override bool Draw()
        {
            int index = 0;
            if (base.Draw())
            {
                while (Visible)
                {
                    if (index < shape.Count)
                    {
                        if (Engine.DrawShadow)
                            shape[index].DrawPhong(materials[index].Texture, Engine.CurrentLevel.Light, Engine.CurrentLevel.Light.Color, materials[index].Shines, Engine.CurrentLevel.shadowMap);
                        else
                            shape[index].DrawPhong(materials[index].Texture, Engine.CurrentLevel.Light, Engine.CurrentLevel.Light.Color);
                        index++;
                    }
                    else
                    {
                        index = 0;
                        return Visible;
                    }
                }
                return Visible;
            }
            return Visible;
        }
        public override void DrawColor(Vector4 color)
        {
            foreach (Mesh3 mesh in shape.Values)
            {
                mesh.DrawColor(color);
            }
        }

        public override void DrawShadow()
        {
            if (ShadowRendering && Visible)
            {
                foreach (Mesh3 mesh in shape.Values)
                {
                    mesh.DrawShadowMap(Engine.CurrentLevel.Light);
                }
            }
        }

        public void AddMaterial(int index, Material material)
        {
            try
            {
                materials.Add(index, material);
            }
            catch (Exception)
            {
                index = materials.Count;
                materials.Add(index, material);
            }
        }
        public void ChangeMaterial(Material material, int index)
        {
            materials[index] = material;
        }
        public void AddShape(int index, Mesh3 mesh)
        {
            try
            {
                shape.Add(index, mesh);
            }
            catch (Exception)
            {
                index = shape.Count;
                shape.Add(index, mesh);
            }
        }



        public override void UV_Multiplier(float multiplier)
        {
            for (int i = 0; i < shape.Count - 1; i++)
            {
                if (materials[i].RepeatedX && materials[i].RepeatedY)
                {
                    for (int j = 0; j < shape[i].uv.Length; j++)
                    {
                        shape[i].uv[j] *= multiplier;
                        shape[i].UpdateUV();
                    }
                }
            }
        }
        public override void U_Multiplier(float multiplier)
        {
            for (int i = 0; i < shape.Count; i++)
            {
                if (materials[i].RepeatedX)
                {
                    for (int j = 0; j < shape[i].uv.Length; j += 2)
                    {
                        shape[i].uv[j] *= multiplier;
                        shape[i].UpdateUV();
                    }
                }
            }
        }
        public override void V_Multiplier(float multiplier)
        {
            for (int i = 0; i < shape.Count; i++)
            {
                if (materials[i].RepeatedY)
                {
                    for (int j = 1; j < shape[i].uv.Length; j += 2)
                    {
                        shape[i].uv[j] *= multiplier;
                        shape[i].UpdateUV();
                    }
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
                b.SetParent(shape[mainMesh]);
                Engine.CurrentLevel.AddColliders(b);
                //colliders.Add(b);
                //PhysxMgr.AddCollider(b);
            }
            else if (type == ColliderType.SPHERE)
            {
                BoundingSphere s = new BoundingSphere(position, scale, rotation, this);
                s.SetParent(shape[mainMesh]);
                Engine.CurrentLevel.AddColliders(s);
                //colliders.Add(s);
                //PhysxMgr.AddCollider(s);
            }
        }
        public void SetParent(Mesh3 mesh)
        {
            this.shape[mainMesh].SetParent(mesh);
        }
        public override void SetAdditiveTint(Vector4 tint)
        {
            foreach (Mesh3 mesh in shape.Values)
            {
                mesh.shader.SetUniform("add_tint", tint);
            }
        }
        public override void SetMultiplyTint(Vector4 tint)
        {
            foreach (Mesh3 mesh in shape.Values)
            {
                mesh.shader.SetUniform("mul_tint", tint);
            }
        }
    }
}
