using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    enum InputKey
    {
        Q,
        P,
        F,
        MAX
    }

    class Input
    {
        private static bool[] inputBuffers = new bool[(int)InputKey.MAX];

        public static void InputUpdate()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.Q:
                        inputBuffers[(int)InputKey.Q] = true;
                        break;

                    case ConsoleKey.P:
                        inputBuffers[(int)InputKey.P] = true;
                        break;

                    case ConsoleKey.F:
                        inputBuffers[(int)InputKey.F] = true;
                        break;
                }
            }
        }

        public static void InputReset()
        {
            for (int i = 0; i < inputBuffers.Length; i++)
            {
                inputBuffers[i] = false;
            }
        }

        public static bool GetKey(InputKey key)
        {
            return inputBuffers[(int)key];
        }
    }
}
