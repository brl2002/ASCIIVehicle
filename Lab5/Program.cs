using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    enum ProgramState
    {
        USER_SELECTION,
        INIT_SIMULATION,
        SIMULATING
    }

    class Program
    {
        public static bool bPaused = false;

        public static bool bQuit = false;

        public static bool bSimulating = false;

        private static System.Diagnostics.Stopwatch stopWatch;

        private static Player[] players = new Player[2];

        private static ProgramState state = ProgramState.USER_SELECTION;

        private static Player winner;

        static void GetUserInput()
        {
            int engineType = 0;
            int bodyType = 0;
            int maxSpeed = 0;

            Console.WriteLine("Choose Engine Component:");
            Console.WriteLine("1. Weight 30, Horse Power 675, Max Speed 14 m/s");
            Console.WriteLine("2. Weight 15, Horse Power 425, Max Speed 10 m/s");
            Console.WriteLine("3. Weight 18, Horse Power 500, Max Speed 12 m/s");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            while (keyInfo.Key != ConsoleKey.D1 &&
                keyInfo.Key != ConsoleKey.D2 &&
                keyInfo.Key != ConsoleKey.D3)
            {
                Console.Clear();

                Console.WriteLine("Choose Engine Component:");
                Console.WriteLine("1. Weight 30, Horse Power 675, Max Speed 14 m/s");
                Console.WriteLine("2. Weight 15, Horse Power 425, Max Speed 10 m/s");
                Console.WriteLine("3. Weight 18, Horse Power 500, Max Speed 12 m/s");

                keyInfo = Console.ReadKey(true);
            }

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    engineType = 1;
                    break;
                case ConsoleKey.D2:
                    engineType = 2;
                    break;
                case ConsoleKey.D3:
                    engineType = 3;
                    break;
            }

            Console.Clear();

            Console.WriteLine("Choose Body Component:");
            Console.WriteLine("1. Weight 8, Body Volume 50");
            Console.WriteLine("2. Weight 10, Body Volume 60");
            Console.WriteLine("3. Weight 15, Body Volume 40");
            
            keyInfo = Console.ReadKey(true);

            while (keyInfo.Key != ConsoleKey.D1 &&
                keyInfo.Key != ConsoleKey.D2 &&
                keyInfo.Key != ConsoleKey.D3)
            {
                Console.Clear();

                Console.WriteLine("Choose Body Component:");
                Console.WriteLine("1. Weight 8, Body Volume 50");
                Console.WriteLine("2. Weight 10, Body Volume 60");
                Console.WriteLine("3. Weight 15, Body Volume 40");

                keyInfo = Console.ReadKey(true);
            }

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    bodyType = 1;
                    break;
                case ConsoleKey.D2:
                    bodyType = 2;
                    break;
                case ConsoleKey.D3:
                    bodyType = 3;
                    break;
            }

            players[0] = new Player();
            players[0].vehicle = new Car();
            players[0].vehicle.maxAcceleration.x = 5;

            EngineComponent engine1 = new EngineComponent();
            switch (engineType)
            {
                case 1:
                    engine1.horsePower = 675;
                    engine1.weight = 30;
                    maxSpeed = 14;
                    break;
                case 2:
                    engine1.horsePower = 425;
                    engine1.weight = 15;
                    maxSpeed = 10;
                    break;
                case 3:
                    engine1.horsePower = 500;
                    engine1.weight = 18;
                    maxSpeed = 12;
                    break;
            }

            BodyComponent body1 = new BodyComponent();
            switch (bodyType)
            {
                case 1:
                    body1.bodyVolume = 50;
                    body1.weight = 8;
                    break;
                case 2:
                    body1.bodyVolume = 60;
                    body1.weight = 10;
                    break;
                case 3:
                    body1.bodyVolume = 40;
                    body1.weight = 15;
                    break;
            }

            players[0].vehicle.maxVelocity.x = maxSpeed;
            players[0].vehicle.components.Add(engine1);
            players[0].vehicle.components.Add(body1);
            players[0].vehicle.Initialize();

            players[1] = new Player();
            players[1].vehicle = new Boat();
            players[1].vehicle.maxVelocity.x = 12;
            players[1].vehicle.maxAcceleration.x = 7;

            EngineComponent engine2 = new EngineComponent();
            engine2.horsePower = 600;
            engine2.weight = 30;
            BodyComponent body2 = new BodyComponent();
            body2.bodyVolume = 60;
            body2.weight = 20;

            players[1].vehicle.components.Add(engine2);
            players[1].vehicle.components.Add(body2);
            players[1].vehicle.Initialize();

            state = ProgramState.INIT_SIMULATION;
        }

        static void Simulate()
        {
            Input.InputUpdate();

            if (Input.GetKey(InputKey.Q))
            {
                bQuit = true;
            }

            if (stopWatch.Elapsed.TotalSeconds > 0.33)
            {
                Console.Clear();

                Console.WriteLine("Press 'q' to quit, press 'f' to move vehicle");

                Console.WriteLine(stopWatch.Elapsed.TotalSeconds);

                Console.WriteLine(players[0].vehicle.currentForce.x.ToString() + " " + players[0].vehicle.drag.x.ToString() + " " + players[0].vehicle.acceleration.x.ToString() + " " + players[0].vehicle.velocity.x.ToString()
                    + " " + players[0].vehicle.position.x.ToString());

                Console.WriteLine("Physics Delay: " + String.Format("{0:F10}", Profiler.physicsDelay)
                    + " " + "Rendering Delay: " + String.Format("{0:F10}", Profiler.renderingDelay));

                if (Input.GetKey(InputKey.F))
                {
                    players[0].vehicle.Accelrate();
                }
                else
                {
                    players[0].vehicle.Stop();
                }

                Profiler.physicsWatch.Start();
                if (bSimulating)
                {
                    Physics.Iterate(stopWatch.Elapsed.TotalSeconds, players);
                }
                Profiler.TallyPhysicsTime();

                Profiler.renderingWatch.Start();
                for (int i = 0; i < players.Length; i++)
                {
                    if (players[i].vehicle.position.x >= 65)
                    {
                        bSimulating = false;

                        winner = players[i];
                    }

                    //Rendering with array of ascii lines for each vehicle
                    for (int n = 0; n < players[i].vehicle.asciiMesh.Length; n++)
                    {
                        int length = players[i].vehicle.asciiMesh[n].Length;
                        Console.WriteLine(players[i].vehicle.asciiMesh[n].PadLeft(length + players[i].vehicle.position.x));
                    }

                    Console.WriteLine("-----------------------------------------------------------------------------");
                }
                Profiler.TallyRenderingTime();

                if (!bSimulating)
                {
                    Console.WriteLine("Winner is, " + winner.vehicle.ToString());
                    Console.WriteLine("Press p to play again");

                    if (Input.GetKey(InputKey.P))
                    {
                        stopWatch.Stop();
                        stopWatch.Reset();

                        Profiler.Reset();

                        bSimulating = true;

                        state = ProgramState.USER_SELECTION;
                        Console.Clear();
                    }
                }

                stopWatch.Reset();
                stopWatch.Start();

                Input.InputReset();
            }
        }

        static void Main(string[] args)
        {
            stopWatch = new System.Diagnostics.Stopwatch();

            bSimulating = true;

            while (!bQuit)
            {
                switch (state)
                {
                    case ProgramState.USER_SELECTION:
                        {
                            GetUserInput();
                        }
                        break;
                    case ProgramState.INIT_SIMULATION:
                        {
                            stopWatch.Start();

                            players[1].vehicle.Accelrate();

                            state = ProgramState.SIMULATING;
                        }
                        break;
                    case ProgramState.SIMULATING:
                        {
                            Simulate();
                        }
                        break;
                }
            }
        }
    }
}
