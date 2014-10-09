using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class BodyComponent : VehicleComponent
    {
        public float bodyVolume;

        public override void ComputeValues()
        {
            dragReduceFactor += bodyVolume * 0.001f;
        }
    }
}
