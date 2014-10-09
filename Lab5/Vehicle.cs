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

        public Vector2 maxVelocity;

        public Vector2 acceleration;

        public Vector2 maxAcceleration;

        public Vector2 force;

        public Vector2 currentForce;

        public Vector2 drag;

        public List<VehicleComponent> components = new List<VehicleComponent>();

        public string[] asciiMesh { get; protected set; }

        public void Initialize()
        {
            foreach (VehicleComponent comp in components)
            {
                drag.x += (int)(comp.weight * 0.1f);

                comp.ComputeValues();

                force.x += (int)comp.forceAccumulator;
                drag.x -= (int)comp.dragReduceFactor;
            }
        }

        public void Accelrate()
        {
            currentForce.x = force.x;
        }

        public void Stop()
        {
            currentForce.x = 0;
        }
    }
}
