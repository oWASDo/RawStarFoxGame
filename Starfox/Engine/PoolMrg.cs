using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfox
{
    public static class PoolMrg
    {
        private static List<Actor> actors;

        static PoolMrg()
        {
            actors = new List<Actor>();
        }

        public static void RegisterPool<T>(int number, Trasparecy trasp) where T : Actor, new()
        {
            for (int i = 0; i < number; i++)
            {
                T a = new T();
                a.IsActive = false;
                a.Visible = false;
                actors.Add(a);
                Engine.CurrentLevel.Spawn(a, trasp);
            }
        }
        public static void RegisterPool<T>(int number, Trasparecy trasp, Vector3 position) where T : Actor, new()
        {
            for (int i = 0; i < number; i++)
            {
                T a = new T();
                a.IsActive = false;
                a.Visible = false;
                a.SetPosition(position);
                actors.Add(a);
                Engine.CurrentLevel.Spawn(a, trasp);
            }
        }
        public static Actor GetActor(Type type)
        {
            foreach (Actor actor in actors)
            {
                if (actor.GetType() == type)
                {
                    if (!actor.IsActive && !actor.Visible)
                    {
                        actor.IsActive = true;
                        actor.Visible = true;
                        actor.OnCollide = false;
                        actor.CollideWith = null;
                        return actor;
                    }
                }
            }
            return null;
        }
    }
}
