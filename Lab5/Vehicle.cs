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

        public string[] asciiMesh { get; private set; }

        /// <summary>
        /// Sets array of ascii lines as meshes that will be rendered for this vehicle
        /// </summary>
        /// <param name="asciiLines"></param>
        public virtual void SetMesh(params string[] asciiLines);
    }
}
