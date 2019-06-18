using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Starfox
{
    // Pierre Bézier in 1962 used them as car design basis for renault
    public class Bezier3
    {
        Vector3[] points;

        public Bezier3()
        {
            points = new Vector3[4];
        }

        public void SetPoint(int index, Vector3 point)
        {
            points[index] = point;
        }

        public Vector3 GetPoint(int index)
        {
            return points[index];
        }

        public Vector3 Linear(float t)
        {
            // (1-t)p0 + t(p1)
            MathHelper.Clamp(t, 0, 1);
            return (1f - t) * points[0] + t * points[1];
        }

        public Vector3 Quadratic(float t)
        {
            // (1-t)**2(p0) + 2(1-t)t(p1) + t**2(p2)
            MathHelper.Clamp(t, 0, 1);
            return (float)Math.Pow(1f - t, 2) * points[0] + 2 * (1f - t) * t * points[1] + (float)Math.Pow(t, 2) * points[2];
        }

        public Vector3 Cubic(float t)
        {
            // (1-t)**3(p0) + 3(1-t)**2 * t(p1) + 3(1-t)t**2(p2) + t**3(p3)
            MathHelper.Clamp(t, 0, 1);
            return (float)Math.Pow(1f - t, 3) * points[0] + 3 * (float)Math.Pow(1f - t, 2) * t * points[1] + 3 * (1f - t) * (float)Math.Pow(t, 2) * points[2] + (float)Math.Pow(t, 3) * points[3];
        }
    }
}