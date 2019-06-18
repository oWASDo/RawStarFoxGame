using Aiv.Fast3D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfox
{
    public enum ColliderType
    {
        SPHERE,
        CUBE
    }
    public enum Trasparecy
    {
        NO,
        YES
    }
    public class Actor:IUpdatable,IDrawable,IDirection
    {
        private List<Behaviour> behaviours;
        private List<Behaviour> behavioursToAdd;
        private List<Behaviour> behavioursToRemove;

        public List<Collider> colliders;
        public Trasparecy trasparancy;
        public bool OnCollide;
        public Actor CollideWith;
        public string Tag;
        protected bool ShadowRendering;


        public Vector3 Position { get; private set; }
        public Vector3 Rotation { get; private set; }
        public Vector3 Scale { get; private set; }

        public virtual Vector3 Forward { get; }
        public virtual Vector3 Right { get; }
        public virtual Vector3 Up { get; }

        public bool Visible { get; set; }
        public bool IsActive { get; set; }



        public Actor()
        {
            Position = Vector3.Zero;
            Rotation = Vector3.Zero;
            Scale = Vector3.One;
            Visible = true;
            IsActive = true;
            behaviours = new List<Behaviour>();
            behavioursToAdd = new List<Behaviour>();
            behavioursToRemove = new List<Behaviour>();
            ShadowRendering = true;
            OnCollide = false;
        }
        public Actor(Vector3 position, Vector3 rotation, Vector3 scale)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale;
            Visible = true;
            IsActive = true;
            behaviours = new List<Behaviour>();
            behavioursToAdd = new List<Behaviour>();
            behavioursToRemove = new List<Behaviour>();
            ShadowRendering = true;
        }
        public virtual bool Update()
        {
            if (IsActive)
            {
                InsertBehaviour();
                foreach (Behaviour be in behaviours)
                {
                    be.Update();
                }
                RemoveBehaviour();
                return IsActive;
            }
            else
                return IsActive;
        }
        public virtual bool Draw()
        {
            return Visible;
        }



        public void SetPosition(Vector3 newPosition)
        {
            Position = newPosition;
        }
        public void SetRotation(Vector3 newRotation)
        {
            Rotation = newRotation;
        }
        public void SetScale(Vector3 newScale)
        {
            Scale = newScale;
        }

        

        public virtual void DrawShadow()
        {
            
        }
        public virtual void DrawColor(Vector4 color)
        {

        }

        public void AddBehaviour(Behaviour newBehaviour)
        {
            behavioursToAdd.Add(newBehaviour);
        }
        public void RemoveBehaviour(Behaviour behaviour)
        {
            behavioursToRemove.Add(behaviour);
        }
        private void RemoveBehaviour()
        {
            foreach (Behaviour item in behavioursToRemove)
            {
                behaviours.Remove(item);
            }
            behavioursToRemove.Clear();
        }
        private void InsertBehaviour()
        {
            foreach (Behaviour item in behavioursToAdd)
            {
                behaviours.Add(item);
            }
            behavioursToAdd.Clear();
        }


        public virtual void UV_Multiplier(float multiplier)
        {
        }
        public virtual void U_Multiplier(float multiplier)
        {
        }
        public virtual void V_Multiplier(float multiplier)
        {
        }
        public virtual void SetAdditiveTint(Vector4 tint)
        {
        }
        public virtual void SetMultiplyTint(Vector4 tint)
        {
        }
    }
}
