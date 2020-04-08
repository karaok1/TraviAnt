using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraviAnt
{
    public class Buildings
    {
        public Barracks Barracks { get; set; }
        public MainBuilding MainBuilding { get; set; }

        public Buildings()
        {
            Barracks = new Barracks();
            MainBuilding = new MainBuilding();
        }
    }
}
