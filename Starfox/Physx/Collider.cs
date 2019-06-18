using Aiv.Fast3D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfox
{
    public abstract class Collider : IDirection, IDrawable
    {
        public bool isCollide;
        public bool IsActive => Owner.IsActive;
        public Actor CollidWith;
        public Actor Owner;
        public Mesh3 mesh;
        public Vector3 Position => mesh.Position3 + Owner.Position;
        public Vector3 Rotation => mesh.EulerRotation3 + Owner.Rotation;
        public Vector3 Scale => mesh.Scale3 + Owner.Scale;

        public Vector3 Forward
        {
            get
            {
                return mesh.Forward;
            }
        }

        public Vector3 Right
        {
            get
            {
                return mesh.Right;
            }
        }

        public Vector3 Up
        {
            get
            {
                return mesh.Up;
            }
        }

        public bool Visible
        {
            get
            {
                return Engine.DrawCollider;
            }
            set
            {
                Visible = value;
            }
        }
        public Collider(Vector3 position, Vector3 scale, Vector3 rotation, Actor owner)
        {
            mesh = new Mesh3();
            mesh.Position3 = position;
            mesh.Scale3 = scale;
            mesh.EulerRotation3 = rotation;
            Owner = owner;
        }
        public void SetParent(Mesh3 owner)
        {
            mesh.SetParent(owner);
        }

        public bool Draw()
        {
            if (Visible)
            {
                mesh.DrawWireframe(new Vector4(0, 1, 0, 1));
                return Visible;
            }
            return Visible;
        }
        public virtual bool Collide(Collider bounding)
        {
            return Owner.IsActive;
        }

    }
}
