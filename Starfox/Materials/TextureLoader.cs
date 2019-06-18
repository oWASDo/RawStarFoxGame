using Aiv.Fast2D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfox
{
    static class TextureLoader
    {
        private static FileStream stream;
        private static string file;

        static TextureLoader()
        {
            file = "Assets/TextureDec/";
        }

        public static Texture GetTex(string name)
        {
            stream = new FileStream(file + name, FileMode.Open);

            byte[] widthArr = new byte[sizeof(int)];
            stream.Read(widthArr, 0, widthArr.Length);
            int width = BitConverter.ToInt32(widthArr, 0);

            byte[] heigthArr = new byte[sizeof(int)];
            stream.Read(heigthArr, 0, heigthArr.Length);
            int heigth = BitConverter.ToInt32(heigthArr, 0);

            Texture tex = new Texture(width, heigth);

            byte[] toLoad = new byte[width * heigth * 4];
            stream.Read(toLoad, 0, toLoad.Length);

            stream.Close();
            tex.Update(toLoad);
            return tex;
        }
    }
}
