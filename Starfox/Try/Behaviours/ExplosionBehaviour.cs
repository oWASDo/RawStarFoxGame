using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast3D;
using OpenTK;
using Aiv.Audio;

namespace Starfox
{
    public class ExplosionBehaviour : Behaviour
    {
        private AudioSource explosion;
        private Vector2 offset;
        private Vector2 size;
        float FPS;
        float time;
        private Vector2 limit;
        public ExplosionBehaviour(Actor owner) : base(owner)
        {
            offset = new Vector2(0, 0);
            size = new Vector2(120, 120);
            FPS = 30;
            time = 0;
            limit = new Vector2(360, 480);
            explosion = new AudioSource();
            explosion.Volume = 0.4f;
        }
        public override void Update()
        {
            if (!explosion.IsPlaying)
            {
                Random random = new Random(DateTime.Now.Second);

                int numbe = random.Next(0, 2);

                if (numbe == 0)
                    explosion.Play(SoundLibrary.GetSound("Explosion0"));
                else
                    explosion.Play(SoundLibrary.GetSound("Explosion1"));

            }
            time += Engine.DeltaTime;
            if (time >= 1 / FPS)
            {
                offset.X += size.X;
                if (offset.X > limit.X - size.X)
                {
                    offset.X = 0;
                    offset.Y += size.Y;
                }
                if (offset.Y > limit.Y - size.Y)
                {
                    offset.Y = 0;
                    Engine.CurrentLevel.Despawn(Owner);
                }
                time = 0;
            }
            SetTextureUV(offset, size);
        }
    }
}
