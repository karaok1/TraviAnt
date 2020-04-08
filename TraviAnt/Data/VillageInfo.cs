using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraviAnt
{
    public class VillageInfo
    {
        public Buildings Buildings { get; set; }

        public VillageInfo()
        {
            Buildings = new Buildings();
        }
    }
}
