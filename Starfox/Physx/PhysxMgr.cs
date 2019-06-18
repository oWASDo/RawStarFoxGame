using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfox
{
    public static class PhysxMgr
    {
        private static List<Collider> bounding;
        //private static LinkedList<Collider> bounding;
        static PhysxMgr()
        {
            bounding = new List<Collider>();
            //bounding = new LinkedList<Collider>();
        }

        public static List<Collider> GetColliders(Actor a)
        {
            List<Collider> collider = new List<Collider>();
            foreach (Collider item in bounding)
            {
                if (item.Owner == a)
                {
                    collider.Add(item);
                }
            }
            return collider;
        }
        public static void AddCollider(Collider collider)
        {
            bounding.Add(collider);
        }
        public static void Remove(Collider collider)
        {
            bounding.Remove(collider);
        }
        public static void Clear()
        {
            bounding.Clear();
        }
        public static void Update()
        {
            foreach (Collider item in bounding)
            {
                item.isCollide = false;
                item.CollidWith = null;
            }
            foreach (Collider collider0 in bounding)
            {
                foreach (Collider collider1 in bounding)
                {
                    if (collider0 == collider1)
                        continue;
                    if (collider0.Owner == collider1.Owner)
                        continue;
                    if (!collider0.IsActive || !collider1.IsActive)
                        continue;
                    if (collider0.Collide(collider1))
                    {
                        Console.WriteLine(true);
                    }
                    //collider0.Collide(collider1);
                }
            }
        }
        public static void Draw()
        {
            foreach (Collider item in bounding)
            {
                if (item.Owner.Visible)
                {
                    item.Draw();
                }
            }
        }
    }
}
