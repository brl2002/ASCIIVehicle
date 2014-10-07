using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    abstract class Vehicle
    {
        public Vector2 position;

        public Vector2 velocity;

        public Vector2 acceleration;

        public string[] asciiMesh { get; protected set; }
    }
}
