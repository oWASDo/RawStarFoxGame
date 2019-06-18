using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starfox
{
    public class Timer
    {
        public float time;
        public float timeLimit;
        public bool IsActive { get; set; }

        public Timer(float timeLimit)
        {
            time = 0;
            this.timeLimit = timeLimit;
            IsActive = true;
        }

        public bool TimerToZero()
        {
            if (IsActive)
            {
                if (time >= timeLimit)
                {
                    time = 0;
                    return true;
                }
            }
            return false;
        }
        public bool TimerNoEnd()
        {
            if (IsActive)
            {
                if (time >= timeLimit)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
