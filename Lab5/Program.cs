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
            int carForce = 5;

            Vehicle[] vehicles = new Vehicle[1];
            vehicles[0] = new Car();
            vehicles[0].force.x = carForce;
            vehicles[0].maxVelocity.x = 10;
            vehicles[0].maxAcceleration.x = 5;
            vehicles[0].drag.x = 2;

            stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            bSimulating = true;

            while (!bQuit)
            {
                Input.InputUpdate();

                if (Input.GetKey(InputKey.Q))
                {
                    bQuit = true;
                }

                //if (Input.GetKey(InputKey.F))
                //{
                //    vehicles[0].force.x = carForce;
                //}
                //else
                //{
                //    vehicles[0].force.x = 0;
                //}

                if (stopWatch.Elapsed.TotalSeconds > 0.33)
                {
                    Console.Clear();

                    Console.WriteLine("Press 'q' to quit, press 'f' to move vehicle");

                    Console.WriteLine(stopWatch.Elapsed.TotalSeconds);
                    Console.WriteLine(vehicles[0].force.x + " " + vehicles[0].velocity.x);

                    if (bSimulating)
                    {
                        Physics.Iterate(stopWatch.Elapsed.TotalSeconds, vehicles);
                    }

                    for (int i = 0; i < vehicles.Length; i++)
                    {
                        if (vehicles[i].position.x >= 65)
                        {
                            bSimulating = false;
                        }

                        //Rendering with array of ascii lines for each vehicle
                        for (int n = 0; n < vehicles[i].asciiMesh.Length; n++)
                        {
                            int length = vehicles[i].asciiMesh[n].Length;
                            Console.WriteLine(vehicles[i].asciiMesh[n].PadLeft(length + vehicles[i].position.x));
                        }

                        Console.WriteLine("-----------------------------------------------------------------------------");
                    }

                    stopWatch.Reset();
                    stopWatch.Start();
                }

                Input.InputReset();
            }
        }
    }
}
