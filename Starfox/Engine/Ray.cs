using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Starfox
{
    public class Ray
    {
        public Vector3 Origin;
        public Vector3 Direction;


        public Ray(Vector3 origin, Vector3 direction)
        {
            this.Origin = origin;
            this.Direction = direction;
        }

        // finding point -> origin + direction * t
        public bool IntersectsSphere(Vector3 center, float radius, out Vector3 normal)
        {
            normal = Vector3.Zero;

            Vector3 l = center - Origin;
            float tca = Vector3.Dot(l, Direction);

            // if tca < 0, l and d are opposite
            if (tca < 0) return false;

            // l * l = (d * d) + (tca * tca)
            // d * d = (l * l) - (tca * tca)

            float d2 = (l.Length * l.Length) - (tca * tca);
            // if d > radius, we miss the sphere
            if (d2 > radius * radius) return false;

            // r * r = (d * d) + (thc * thc)
            // thc * thc = (r * r) - (d * d)

            float thc2 = (radius * radius) - d2;
            float thc = (float)Math.Sqrt(thc2);

            float t0 = tca - thc;
            float t1 = tca + thc;

            // enter point is further than exit, so swap them
            if (t0 > t1)
            {
                float tmp = t0;
                t0 = t1;
                t1 = tmp;
            }

            // if t0 is negative we are into the sphere
            if (t0 < 0)
            {
                t0 = t1;
                if (t0 < 0) // if t1 is negative too we have a problem...
                    return false;
            }

            // find the normal
            Vector3 intersectionPoint = Origin + Direction * t0;

            normal = (intersectionPoint - center).Normalized();

            return true;

        }
        public bool IntersectsSphere(Vector3 center, float radius)
        {
            //normal = Vector3.Zero;

            Vector3 l = center - Origin;
            float tca = Vector3.Dot(l, Direction);

            // if tca < 0, l and d are opposite
            if (tca < 0) return false;

            // l * l = (d * d) + (tca * tca)
            // d * d = (l * l) - (tca * tca)

            float d2 = (l.Length * l.Length) - (tca * tca);
            // if d > radius, we miss the sphere
            if (d2 > radius * radius) return false;

            // r * r = (d * d) + (thc * thc)
            // thc * thc = (r * r) - (d * d)

            float thc2 = (radius * radius) - d2;
            float thc = (float)Math.Sqrt(thc2);

            float t0 = tca - thc;
            float t1 = tca + thc;

            // enter point is further than exit, so swap them
            if (t0 > t1)
            {
                float tmp = t0;
                t0 = t1;
                t1 = tmp;
            }

            // if t0 is negative we are into the sphere
            if (t0 < 0)
            {
                t0 = t1;
                if (t0 < 0) // if t1 is negative too we have a problem...
                    return false;
            }

            // find the normal
            //Vector3 intersectionPoint = Origin + Direction * t0;

            //normal = (intersectionPoint - center).Normalized();

            return true;

        }
    }
}
