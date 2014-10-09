using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Car : Vehicle
    {
        public Car()
        {
            position = new Vector2();
            velocity = new Vector2();
            maxVelocity = new Vector2();
            acceleration = new Vector2();
            maxAcceleration = new Vector2();
            force = new Vector2();
            currentForce = new Vector2();
            drag = new Vector2();

            asciiMesh = new string[3];
            asciiMesh[0] = "   _";
            asciiMesh[1] = "  /t]___";
            asciiMesh[2] = " (o_|__o)";
        }
    }
}
