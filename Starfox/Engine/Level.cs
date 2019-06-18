using Aiv.Fast2D;
using Aiv.Fast3D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Starfox
{
    public class Level
    {
        private List<Actor> actors;
        private List<Actor> actorsToAdd;
        private List<Actor> actorsToRemove;
        private List<Collider> colliders;

        public DirectionalLight Light;
        protected SkySphere skySphere;
        public DepthTexture shadowMap { get; private set; }

        public Level()
        {
            actors = new List<Actor>();
            actorsToAdd = new List<Actor>();
            actorsToRemove = new List<Actor>();
            Light = new DirectionalLight(Utils.EulerRotationToDirection(new Vector3(0, 0, 0)));
            shadowMap = new DepthTexture(1080, 1080, 16);
            colliders = new List<Collider>();

        }
        public virtual void Init()
        {



        }
        public virtual void Exit()
        {

        }
        public void Draw()
        {
            DrawShadow();
            foreach (Actor actor in actors)
            {
                if (actor.trasparancy == Trasparecy.NO)
                {
                    actor.Draw();
                }
            }
            DrawTrasparecy();
        }
        public void DrawTrasparecy()
        {
            List<float> distance = new List<float>();
            Dictionary<float, Actor> distanceDictionary = new Dictionary<float, Actor>();
            foreach (Actor actor in actors)
            {
                if (actor.trasparancy == Trasparecy.YES)
                {
                    float dis = (actor.Position - Engine.PerspectiveCamera.Position3).Length;
                    if (distance.Contains(dis))
                    {
                        dis += 0.0001f;
                    }
                    if (distance.Contains(dis))
                    {
                        dis -= 0.0002f;
                    }
                    if (distance.Contains(dis))
                    {
                        dis += 0.0003f;
                    }
                    distanceDictionary.Add(dis, actor);
                    distance.Add(dis);
                }
            }
            //distance.OrderBy(x => x);
            float[] array0 = distance.ToArray();
            float[] array1 = Tools.FloatOrder(array0);
            //float[] asd = Tools.FloatOrderByDescending(arrayDistance);
            for (int i = array0.Length - 1; i >= 0; i--)
            {
                distanceDictionary[array1[i]].Draw();
            }
            //for (int i = 0; i < asd.Length; i++)
            //{
            //    distanceDictionary[distance[i]].Draw();
            //}
            distance.Clear();
            distanceDictionary.Clear();
            //Dictionary<float, Actor> distances = new Dictionary<float, Actor>();
            //foreach (Actor act in actors)
            //{
            //    if (act.trasparancy == Trasparecy.YES)
            //    {
            //        Vector3 distance = act.Position - Engine.PerspectiveCamera.Position3;
            //        distances.Add(distance.Length, act);
            //        distances.OrderBy(x => x.Key);
            //    }
            //}
            //Actor[] acto = distances.Values.ToArray();
            //for (int i = acto.Length; i > 0; i--)
            //{
            //    distances[i].Draw();
            //}
            //for (int i = 0; i < int.Parse(number.ToString()); i++)
            //{
            //    distances[i].Draw();
            //}
            //foreach (Actor act in distances.Values)
            //{
            //    act.Draw();
            //}
            //distances.Clear();
        }

        private void DrawShadow()
        {
            if (Engine.DrawShadow)
            {
                Engine.RenderTo(shadowMap);
                foreach (Actor item in actors)
                {
                    item.DrawShadow();
                }
                Engine.RenderNull();
            }

        }
        public void Update()
        {
            MainBehaviour();
            AddActor();
            foreach (Actor actor in actors)
            {
                actor.Update();
            }
            RemoveActor();
        }
        public void Physx()
        {
            foreach (Collider item in colliders)
            {
                item.isCollide = false;
                item.Owner.OnCollide = false;
                item.CollidWith = null;
                item.Owner.CollideWith = null;
            }
            foreach (Collider collider0 in colliders)
            {
                foreach (Collider collider1 in colliders)
                {
                    if (collider0 == collider1)
                        continue;
                    if (collider0.Owner == collider1.Owner)
                        continue;
                    if (!collider0.IsActive || !collider1.IsActive)
                        continue;
                    if (!collider1.Owner.IsActive || !collider0.Owner.IsActive)
                        continue;

                    collider0.Collide(collider1);

                    //collider0.Collide(collider1);
                }
            }
        }
        public void DrawCollider()
        {
            if (Engine.DrawCollider)
            {
                foreach (Collider item in colliders)
                {
                    item.Draw();
                }
            }
        }
        public void AddColliders(Collider collider)
        {
            colliders.Add(collider);
        }


        private void AddActor()
        {
            foreach (Actor actor in actorsToAdd)
            {
                actors.Add(actor);
            }
            actorsToAdd.Clear();
        }
        private void RemoveActor()
        {
            foreach (Actor actor in actorsToRemove)
            {
                actors.Remove(actor);
                if (actor.colliders != null)
                {
                    foreach (Collider collider in actor.colliders)
                    {
                        PhysxMgr.Remove(collider);
                    }
                    actor.colliders.Clear();
                }
            }
            actorsToRemove.Clear();

        }

        public virtual void MainBehaviour()
        {
        }

        public void Spawn(Actor actor, Trasparecy trasparency)
        {
            actor.trasparancy = trasparency;
            actorsToAdd.Add(actor);
        }

        public void Despawn(Actor actor)
        {
            if (actor.colliders != null)
            {
                foreach (Collider item in actor.colliders)
                {
                    colliders.Remove(item);
                }
            }
            actorsToRemove.Add(actor);
        }

        public Actor GetActor(Type type)
        {
            foreach (Actor item in actors)
            {
                if (type == item.GetType())
                    return item;
            }
            return null;
        }
        public Actor[] GetActors(Type type)
        {
            List<Actor> a = new List<Actor>();
            foreach (Actor item in actors)
            {
                if (type == item.GetType())
                {
                    a.Add(item);
                }
            }
            return a.ToArray();
        }


        public void Clear()
        {
            actors.Clear();
            actorsToAdd.Clear();
            actorsToRemove.Clear();
            colliders.Clear();
        }
    }
}
