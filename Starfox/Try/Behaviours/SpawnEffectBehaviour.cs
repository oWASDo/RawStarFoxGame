using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfox
{
    public class SpawnEffectBehaviour : Behaviour
    {
        private Aiv.Audio.AudioSource teleport;
        private bool plaing;
        private Vector2 offset;
        private Vector2 size;
        private Vector2 limit;
        private const float FPS = 40;
        private float time = 0;
        public SpawnEffectBehaviour(Actor owner) : base(owner)
        {
            offset = Vector2.Zero;
            size = new Vector2(92, 92);
            limit = new Vector2(736, 736);
            teleport = new Aiv.Audio.AudioSource();
            teleport.Volume = 0.2f;
            plaing = false;
        }

        public override void Update()
        {
            if (!plaing && !teleport.IsPlaying)
            {
                teleport.Play((SoundLibrary.GetSound("Teleport")));
                plaing = true;
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
