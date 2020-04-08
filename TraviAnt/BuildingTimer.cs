using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraviAnt
{
    class BuildingTimer : System.Timers.Timer
    {
        public BuildingTimer(double interval)
            : base(interval)
        {

        }

        public int Level { get; set; }
        public int ToLevel { get; set; }
        public double NextInterval { get; set; }
        public Dictionary<string, string> GetParams { get; set; }
    }
}
