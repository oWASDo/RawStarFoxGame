using Aiv.Fast2D;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfox
{
    public class Material
    {
        public Texture Texture;
        public float Shines;
        public bool RepeatedX;
        public bool RepeatedY;

        public Material(Texture texture, float shines = 0, bool repeatX = false, bool repeatY = false)
        {
            Texture = texture;
            Texture.SetRepeatX(repeatX);
            Texture.SetRepeatY(repeatY);
            RepeatedX = repeatX;
            RepeatedY = repeatY;
            Shines = shines;
        }
        public Material(string filename, float shines = 0, bool repeatX = false, bool repeatY = false)
        {
            Texture = TextureLoader.GetTex(filename);
            Texture.SetRepeatX(repeatX);
            Texture.SetRepeatY(repeatY);
            RepeatedX = repeatX;
            RepeatedY = repeatY;
            Shines = shines;
        }
    }
}
