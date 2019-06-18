using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Audio;

namespace Starfox
{
    public static class SoundLibrary
    {
        private static Dictionary<string, AudioClip> clips;


        static SoundLibrary()
        {
            clips = new Dictionary<string, AudioClip>();
        }

        public static void AddSound(AudioClip clip, string name)
        {
            foreach (string item in clips.Keys)
            {
                if (item == name) return;
            }
            clips.Add(name, clip);
        }
        public static AudioClip GetSound(string name)
        {
            return clips[name];
        }
        public static void Clear()
        {
            clips.Clear();
        }
    }
}
