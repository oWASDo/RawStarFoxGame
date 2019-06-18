using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfox
{
    public static class Variables
    {
        public static bool Hitted;
        public static bool Dead;
        public static int Life;
        public static bool MissileReady;
        public static float MotherShipHight;
        public static float MotherShipOffset;
        public static int DeadEnemyCount;

        static Variables()
        {
            MotherShipHight = -16;
            MotherShipOffset = 775f;
            DeadEnemyCount = 0;
        }
    }
}
