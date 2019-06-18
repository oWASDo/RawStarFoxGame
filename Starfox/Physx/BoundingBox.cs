using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast3D;
using OpenTK;

namespace Starfox
{
    class BoundingBox : Collider
    {
        public Vector3 ExtentMin
        {
            get
            {
                float Xmin = (Position.X /*+ Owner.Position.X*/) - (Scale.X / 2);
                float Ymin = (Position.Y /*+ Owner.Position.Y*/) - (Scale.Y / 2);
                float Zmin = (Position.Z /*+ Owner.Position.Z*/) - (Scale.Z / 2);
                return new Vector3(Xmin, Ymin, Zmin);
            }
        }
        public Vector3 ExtentMax
        {
            get
            {
                float Xmax = (Position.X /*+ Owner.Position.X*/) + (Scale.X / 2);
                float Ymax = (Position.Y /*+ Owner.Position.Y*/) + (Scale.Y / 2);
                float Zmax = (Position.Z /*+ Owner.Position.Z*/) + (Scale.Z / 2);
                return new Vector3(Xmax, Ymax, Zmax);
            }
        }

        private Vector3 halfScale => mesh.Scale3 / 2;

        public BoundingBox(Vector3 position, Vector3 scale, Vector3 rotation, Actor owner) : base(position, scale, rotation, owner)
        {
            mesh = new Cube();
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

                    float xMax = Math.Max(ExtentMin.X, s.Position.X);
                    float xBest = Math.Min(ExtentMax.X, xMax);

                    float yMax = Math.Max(ExtentMin.Y, s.Position.Y);
                    float yBest = Math.Min(ExtentMax.Y, yMax);

                    float zMax = Math.Max(ExtentMin.Z, s.Position.Z);
                    float zBest = Math.Min(ExtentMax.Z, zMax);

                    Vector3 nearestPoint = new Vector3(xBest, yBest, zBest);
                    if ((s.Position - nearestPoint).Length <= s.Radius)
                    {
                        CollidWith = s.Owner;
                        s.CollidWith = Owner;
                        s.Owner.CollideWith = Owner;
                        Owner.CollideWith = s.Owner;

                        isCollide = true;
                        s.Owner.OnCollide = true;
                        Owner.OnCollide = true;
                        s.isCollide = true;

                        return true;
                    }
                    return false;
                }
                else
                {
                    //BoundingBox b = bounding as BoundingBox;

                    //Vector3 distance = b.Position - Position;
                    //float halfX = b.halfScale.X + halfScale.X;
                    //if (distance.X >= halfX)
                    //    return false;

                    //float halfY = b.halfScale.X + halfScale.X;
                    //if (distance.Y >= halfY)
                    //    return false;

                    //float halfZ = b.halfScale.X + halfScale.X;
                    //if (distance.Z >= halfZ)
                    //    return false;

                    return false;
                }
            }
            return false;
        }
    }
}
