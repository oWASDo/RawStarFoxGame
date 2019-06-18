using Aiv.Fast2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Aiv.Fast3D;

namespace Starfox
{
    public static class Engine
    {
        private static Window window;
        private static Dictionary<int, Level> levels;
        private static int levelChange;
        private static bool changeLevel;

        private static int currentLevelIndex;
        public static bool DrawCollider;
        public static bool DrawShadow;
        public static float deltaTimeMultiplier;

        public static float ZFar => window.ZFar;
        public static float ZNear => window.ZNear;
        public static float AspectRatio => window.aspectRatio;
        //public static float FOV=> window.

        public static Level CurrentLevel
        {
            get
            {
                return levels[currentLevelIndex];
            }
        }
        public static Camera Camera
        {
            get
            {
                return window.CurrentCamera;
            }
        }
        public static PerspectiveCamera PerspectiveCamera
        {
            get
            {
                return Camera as PerspectiveCamera;
            }
        }
        public static float DeltaTime => window.deltaTime * deltaTimeMultiplier;

        public static Vector2 MousePosition => window.mousePosition;
        public static bool MouseLeft => window.mouseLeft;
        public static bool MouseRight => window.mouseRight;
        public static bool MouseMiddle => window.mouseMiddle;
        public static bool isOpened => window.IsOpened;
        public static bool Opened
        {
            get
            {
                return window.opened;
            }
            set
            {
                window.opened = value;
            }
        }

        public static void Init(Window newWindow, float OrtoSize)
        {
            window = newWindow;
            window.EnableDepthTest();
            window.SetVSync(true);
            window.SetDefaultOrthographicSize(OrtoSize);
            levels = new Dictionary<int, Level>();
            currentLevelIndex = 0;
            DrawCollider = false;
            DrawShadow = true;
            deltaTimeMultiplier = 1;
            changeLevel = false;
        }
        public static void Run()
        {
            levels[currentLevelIndex].Init();

            while (window.IsOpened)
            {
                try { Console.Clear(); }
                catch (Exception) { }
                
                levels[currentLevelIndex].Update();

                levels[currentLevelIndex].Physx();

                levels[currentLevelIndex].Draw();

                levels[currentLevelIndex].DrawCollider();

                Switch();

                window.Update();
            }
        }
        public static void AddLevel(int index, Level level)
        {
            levels.Add(index, level);
        }
        public static bool GetKey(KeyCode key)
        {
            return window.GetKey(key);
        }
        public static void ChangeLevel(int index)
        {
            changeLevel = true;
            levelChange = index;
        }
        public static void Switch()
        {
            if (changeLevel)
            {
                levels[currentLevelIndex].Exit();
                MaterialLibrary.Clear();
                levels[currentLevelIndex].Clear();
                PhysxMgr.Clear();
                currentLevelIndex = levelChange;
                levels[currentLevelIndex].Init();
                changeLevel = false;
            }
            
        }

        public static void RenderTo(RenderTexture texture, bool clear = true, float orthoSize = 0)
        {
            window.RenderTo(texture, clear, orthoSize);
        }
        public static void RenderNull()
        {
            window.RenderTo(null);
        }
        public static void SetCamera(Camera camera)
        {
            window.SetCamera(camera);
        }
        public static void SetCamera(PerspectiveCamera camera)
        {
            window.SetCamera(camera);
        }
        public static void SetClearColor(Vector4 color)
        {
            window.SetClearColor(color);
        }
    }
}
