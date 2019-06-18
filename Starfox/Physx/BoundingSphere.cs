using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast3D;
using OpenTK;

namespace Starfox
{
    public class BoundingSphere : Collider
    {
        public float Radius => (mesh as Sphere).Radius;
        public BoundingSphere(Vector3 position, Vector3 scale, Vector3 rotation, Actor owner) : base(position, scale, rotation, owner)
        {
            mesh = new Sphere();
            mesh.Position3 = position;
            mesh.Rotation3 = rotation;
            mesh.Scale3 = scale;
        }


        public override bool Collide(Collider bounding)
        {
            if (IsActive)
            {
                if (bounding is BoundingSphere && Owner.IsActive)
                {
                    BoundingSphere s = (BoundingSphere)bounding;
                    Vector3 distanceInVector3 = (s.Position) - (Position);
                    float distance = distanceInVector3.Length;
                    float radiusSum = s.Radius + Radius;
                    if (distance < radiusSum)
                    {
                        s.CollidWith = Owner;
                        CollidWith = s.Owner;
                        s.Owner.CollideWith = Owner;
                        Owner.CollideWith = s.Owner;

                        return isCollide = s.Owner.OnCollide = Owner.OnCollide = s.isCollide = true;
                    }
                    else
                        return false;
                }
                else if (bounding is BoundingBox && Owner.IsActive)
                {
                    BoundingBox b = (BoundingBox)bounding;

                    float xMax = Math.Max(b.ExtentMin.X, Position.X);
                    float xBest = Math.Min(b.ExtentMax.X, xMax);

                    float yMax = Math.Max(b.ExtentMin.Y, Position.Y);
                    float yBest = Math.Min(b.ExtentMax.Y, yMax);

                    float zMax = Math.Max(b.ExtentMin.Z, Position.Z);
                    float zBest = Math.Min(b.ExtentMax.Z, zMax);

                    Vector3 nearestPoint = new Vector3(xBest, yBest, zBest);

                    if ((Position - nearestPoint).Length <= Radius)
                    {
                        b.CollidWith = Owner;
                        CollidWith = b.Owner;
                        b.Owner.CollideWith = Owner;
                        Owner.CollideWith = b.Owner;

                        isCollide = true;
                        b.Owner.OnCollide = true;
                        Owner.OnCollide = true;
                        b.isCollide = true;

                        return true;
                    }
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
