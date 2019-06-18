using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfox
{
    public static class Tools
    {
        public static Vector3 Learp(Vector3 startPosition, Vector3 endPosition, float speed)
        {
            startPosition.X = (speed * Engine.DeltaTime) * (endPosition.X - startPosition.X) + startPosition.X;
            startPosition.Y = (speed * Engine.DeltaTime) * (endPosition.Y - startPosition.Y) + startPosition.Y;
            startPosition.Z = (speed * Engine.DeltaTime) * (endPosition.Z - startPosition.Z) + startPosition.Z;
            return startPosition;
        }
        public static bool IsInLine(Vector3 pointA, Vector3 pointB, float range = 0.01f)
        {
            pointA = new Vector3(pointA.X - Engine.PerspectiveCamera.Position3.X, pointA.Y - Engine.PerspectiveCamera.Position3.Y, pointA.Z - Engine.PerspectiveCamera.Position3.Z);
            pointB = new Vector3(pointB.X - Engine.PerspectiveCamera.Position3.X, pointB.Y - Engine.PerspectiveCamera.Position3.Y, pointB.Z - Engine.PerspectiveCamera.Position3.Z);

            float heightA = (float)Math.Tan(60 / 2) * pointA.Z * 2;
            float widthA = Engine.AspectRatio * heightA;
            float heightB = (float)Math.Tan(60 / 2) * pointB.Z * 2;
            float widthB = Engine.AspectRatio * heightB;

            float newBx = pointB.X * widthA / widthB;
            float newBy = pointB.Y * heightA / heightB;

            Vector2 newPointB = new Vector2(newBx, newBy);

            if ((new Vector2(pointA.X, pointA.Y) - newPointB).Length < range)
                return true;

            return false;
        }


        public static bool IsInLine1(Actor actorA, Actor actorB, float range)
        {
            Vector3 dir = actorA.Forward;
            dir.X = dir.X * (float)Math.Cos(60 / 2) - dir.Y * (float)Math.Sin(60 / 2);
            dir.Y = dir.X * (float)Math.Sin(60 / 2) + dir.Y * (float)Math.Cos(60 / 2);
            Ray rayCast = new Ray(actorA.Position, dir);
            return rayCast.IntersectsSphere(actorB.Position, range);
        }

        public static float[] FloatOrder(float[] array)
        {
            return array.OrderBy(a => a).ToArray();
        }
    }
}
