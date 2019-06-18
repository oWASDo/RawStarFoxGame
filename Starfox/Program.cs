using Aiv.Fast2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast3D;
using OpenTK;

namespace Starfox
{
    public class Program
    {
        static void Main(string[] args)
        {
            Window window = new Window(1920, 1080, "StarFox", true, 64, 16);

            Engine.Init(window, 10);

            Engine.AddLevel(0, new Menu());

            Engine.AddLevel(1, new GameLevel());

            Engine.Run();
        }
    }
}
