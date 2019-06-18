using Aiv.Fast2D;
using Aiv.Fast3D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfox
{
    public abstract class Behaviour
    {
        private Actor owner;
        public Actor Owner => owner;

        protected List<Collider> colliders => owner.colliders;
        public Behaviour(Actor owner)
        {
            this.owner = owner;
        }

        public Texture texture
        {
            get
            {
                if (owner is ActorMesh)
                {
                    return ((ActorMesh)owner).texture;
                }
                else
                {
                    return ((ActorMeshes)owner).texture;
                }
            }
        }

        protected Vector3 Forward => owner.Forward;
        protected Vector3 Right => owner.Right;
        protected Vector3 Up => owner.Up;

        protected Vector3 position => owner.Position;
        protected Vector3 rotation => owner.Rotation;
        protected Vector3 scale => owner.Scale;

        protected string Tag => owner.Tag;

        protected bool OnCollide => owner.OnCollide;
        protected Actor CollideWith => owner.CollideWith;

        protected bool Visible
        {
            get
            {
                return owner.Visible;
            }
            set
            {
                owner.Visible = value;
            }
        }
        protected bool IsActive
        {
            get
            {
                return owner.IsActive;
            }
            set
            {
                owner.IsActive = value;
            }
        }
        public virtual void Update()
        {

        }

        public void Move(float speed, Vector3 direction)
        {
            Vector3 move = (position) + (direction * speed * Engine.DeltaTime);
            SetPosition(move);
        }
        public void Rotate(float speed, Vector3 direction)
        {
            Vector3 rotete = new Vector3();
            rotete = (rotation) + (direction * speed * Engine.DeltaTime);
            SetRotation(rotete);
        }
        public void Scaling(float speed, Vector3 direction)
        {
            Vector3 scaling = new Vector3();
            scaling = (scale) + (direction * speed * Engine.DeltaTime);
            SetScale(scaling);
        }

        public void LerpRotation(Vector3 endRotation, float speed)
        {
            Vector3 vec3 = rotation;

            vec3.X = (speed) * (endRotation.X - vec3.X) + vec3.X;
            vec3.Y = (speed) * (endRotation.Y - vec3.Y) + vec3.Y;
            vec3.Z = (speed) * (endRotation.Z - vec3.Z) + vec3.Z;

            SetRotation(vec3);
        }
        public void LerpPosition(Vector3 endPosition, float speed)
        {
            Vector3 vec3 = position;

            vec3.X = (speed * Engine.DeltaTime) * (endPosition.X - vec3.X) + vec3.X;
            vec3.Y = (speed * Engine.DeltaTime) * (endPosition.Y - vec3.Y) + vec3.Y;
            vec3.Z = (speed * Engine.DeltaTime) * (endPosition.Z - vec3.Z) + vec3.Z;

            SetPosition(vec3);
        }
        public void LerpScale(Vector3 endScale, float speed)
        {
            Vector3 vec3 = scale;

            vec3.X = (speed * Engine.DeltaTime) * (endScale.X - vec3.X) + vec3.X;
            vec3.Y = (speed * Engine.DeltaTime) * (endScale.Y - vec3.Y) + vec3.Y;
            vec3.Z = (speed * Engine.DeltaTime) * (endScale.Z - vec3.Z) + vec3.Z;

            SetScale(vec3);
        }

        public void SetPosition(Vector3 newPosition)
        {
            owner.SetPosition(newPosition);
        }
        public void SetRotation(Vector3 newRotation)
        {
            owner.SetRotation(newRotation);
        }
        public void SetScale(Vector3 newScale)
        {
            owner.SetScale(newScale);
        }

        public void SetTextureUV(Vector2 offset, Vector2 size)
        {
            if (!(owner is Sprite3))
                return;

            (owner as Billboard).SetTextureUV(offset, size);
        }
        public void SetAdditiveTint(Vector4 tint)
        {
            if (owner is ActorMesh)
            {
                (owner as ActorMesh).SetAdditiveTint(tint);
            }
            else if (owner is ActorMeshes)
            {
                (owner as ActorMeshes).SetAdditiveTint(tint);
            }
        }
        public void ChangeMaterial(Material material, int index)
        {
            if (owner is ActorMesh)
            {
                ((ActorMesh)owner).ChangeMaterial(material);
            }
            else if (owner is ActorMeshes)
            {
                ((ActorMeshes)owner).ChangeMaterial(material, index);
            }
        }
    }
}
