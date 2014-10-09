using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Profiler
    {
        public static double physicsDelay = 0.0;

        public static double renderingDelay = 0.0;

        public static System.Diagnostics.Stopwatch physicsWatch = new System.Diagnostics.Stopwatch();

        public static System.Diagnostics.Stopwatch renderingWatch = new System.Diagnostics.Stopwatch();

        private static uint physicsCounter = 0;

        private static uint renderingCounter = 0;

        public static void TallyPhysicsTime()
        {
            physicsCounter++;
            physicsDelay = (physicsDelay + physicsWatch.Elapsed.TotalSeconds) / physicsCounter;
            physicsWatch.Reset();
            physicsWatch.Stop();
        }

        public static void TallyRenderingTime()
        {
            renderingCounter++;
            renderingDelay = (renderingDelay + renderingWatch.Elapsed.TotalSeconds) / renderingCounter;
            renderingWatch.Reset();
            renderingWatch.Stop();
        }

        public static void Reset()
        {
            physicsCounter = 0;
            renderingCounter = 0;
            physicsDelay = 0;
            renderingDelay = 0;

            Profiler.physicsWatch.Stop();
            Profiler.renderingWatch.Stop();

            Profiler.physicsWatch.Reset();
            Profiler.renderingWatch.Reset();
        }
    }
}
