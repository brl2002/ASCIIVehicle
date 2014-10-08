﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Physics
    {
        private static Physics instance;

        public static Physics Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Physics();
                }

                return instance;
            }
        }

        private Physics()
        {
        }

        public void Iterate(double deltaTime, Vehicle[] vehicles)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                //Acceleration accumulated based on force generated by vehicle subtracted by drag, which is resultant force, experienced by the same vehicle
                vehicles[i].acceleration.x += (int)((vehicles[i].force.x - vehicles[i].drag.x) * deltaTime * 1.5f);

                //Updating final velocity due to accelration for next frame
                vehicles[i].velocity.x += (int)(vehicles[i].acceleration.x * deltaTime);

                //Clamp acceleration to max accelration value
                if (vehicles[i].acceleration.x > vehicles[i].maxAcceleration.x)
                {
                    vehicles[i].acceleration.x = vehicles[i].maxAcceleration.x;
                }
                else if (vehicles[i].acceleration.x < 0)
                {
                    vehicles[i].acceleration.x = 0;
                }

                //Clamp acceleration to max acceleration value
                if (vehicles[i].velocity.x > vehicles[i].maxVelocity.x)
                {
                    vehicles[i].velocity.x = vehicles[i].maxVelocity.x;
                }
                else if (vehicles[i].velocity.x < 0)
                {
                    vehicles[i].velocity.x = 0;
                }

                //Updating position based on equation to solve for distance travelled for a given time, acceleration, and initial velocity
                vehicles[i].position.x += (int)(vehicles[i].velocity.x * deltaTime + vehicles[i].acceleration.x * 0.5 * deltaTime * deltaTime);
            }
        }
    }
}
