using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Boat : Vehicle
    {
        public Boat()
        {
            position = new Vector2();
            velocity = new Vector2();
            maxVelocity = new Vector2();
            acceleration = new Vector2();
            maxAcceleration = new Vector2();
            force = new Vector2();
            drag = new Vector2();

            asciiMesh = new string[5];
            asciiMesh[0] = "~  +";
            asciiMesh[1] = "~ +++";
            asciiMesh[2] = "~/___]__~~";
            asciiMesh[3] = "~Q_____/~~";
            asciiMesh[4] = "~~~~~~~~~~";
        }
    }
}
