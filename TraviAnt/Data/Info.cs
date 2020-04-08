using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraviAnt
{
    public static class Info
    {
        public static string ErrorMessage { get; set; }
        public static string ResponseBody { get; set; }
        public static ResourceField SelectedItem { get; set; }

        public static List<BuildQueue> Queue = new List<BuildQueue>();
        public static List<string> AttackUnits { get; set; }
        public static string LoginId { get; set; }
    }
}
