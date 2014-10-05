using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Physics
    {
        public void Iterate(double deltaTime, Vehicle[] vehicles)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                //Updating position based on equation to solve for distance travelled for a given time, acceleration, and initial velocity
                vehicles[i].position = vehicles[i].velocity * deltaTime + vehicles[i].acceleration * 0.5f * deltaTime * deltaTime;

                //Updating final velocity due to accelration for next frame
                vehicles[i].velocity = vehicles[i].velocity + vehicles[i].acceleration * deltaTime;
            }
        }
    }
}
