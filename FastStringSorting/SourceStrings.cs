using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastStringSorting
{
    public static class SourceStrings
    {
        public static readonly string[] DefaultStrings = {
                                                "abb10.14-4aa" ,
                                                "abb10.03-4aa" ,
                                                "abb10-4aa" ,
                                                "abb12.04-4aa" ,
                                                "Bn4.03:9Ha",
                                                "Bn4.03:9H",
                                                "Bn4.03:9Hab",
                                                "Bn4.03:9Hb",
                                                "abb10.04aa" ,
                                                "Bn4.03Ha",
                                                "Bn4.02:9Ha",
                                                "Bn4.3:9Ha",
                                                "Bn403:9Ha",
                                                "Bn4.03:9ha",
                                                "abb9.04-4aa" ,
                                                "abc10.04-4aa" ,
                                                "Bn4.03:7Ha",
                                                "Bn4.03:10Ha",
                                                "abb10.04-4aa" ,
                                                "abb10.04-4ba" ,
                                                "abb10.04-3aa" ,
                                                "bn4.03:9Ha",
        };
        public static string[] Strings1 = new string[DefaultStrings.Length],
                                Strings2 = new string[DefaultStrings.Length];
    }
}
