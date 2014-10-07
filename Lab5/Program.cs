using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Program
    {
        public static bool bPaused = false;

        public static bool bQuit = false;

        public static bool bSimulating = false;

        private static System.Diagnostics.Stopwatch stopWatch;

        static void Main(string[] args)
        {
            Vehicle[] vehicles = new Vehicle[1];
            vehicles[0] = new Car();
            vehicles[0].acceleration.x = 5;

            stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            while (!bQuit)
            {
                Console.WriteLine("Press 'q' to quit, or press any other keys to start vehicle simulation");

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Q)
                {
                    bQuit = true;
                }

                bSimulating = true;

                while (bSimulating)
                {
                    if (stopWatch.Elapsed.TotalSeconds > 0.33)
                    {
                        Console.Clear();
                        Console.WriteLine(stopWatch.Elapsed.TotalSeconds);

                        Physics.Iterate(stopWatch.Elapsed.TotalSeconds, vehicles);

                        for (int i = 0; i < vehicles.Length; i++)
                        {
                            if (vehicles[i].position.x >= 40)
                            {
                                bSimulating = false;
                            }

                            //Rendering with array of ascii lines for each vehicle
                            for (int n = 0; n < vehicles[i].asciiMesh.Length; n++)
                            {
                                int length = vehicles[i].asciiMesh[n].Length;
                                Console.WriteLine(vehicles[i].asciiMesh[n].PadLeft(length + vehicles[i].position.x));
                            }
                        }

                        stopWatch.Reset();
                        stopWatch.Start();
                    }
                }
            }
        }
    }
}
