using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    abstract class VehicleComponent
    {
        public float weight;

        public float forceAccumulator { get; protected set; }

        public float dragReduceFactor { get; protected set; }

        public abstract void ComputeValues();
    }
}
