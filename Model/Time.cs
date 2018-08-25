using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public struct Time
    {
        public int Term { get; set; }
        public int Order { get; set; }
        public int Week { get; set; }
    }

    public enum TimeType
    {
        None = 0,
        Default = -1,
        Double = -2,
        Sigle = -3
    }
}
