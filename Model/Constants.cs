using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
    public class Constants
    {
        public long ID { get; set; }
        public double Price_A { get; set; }
        public double Price_B { get; set; }
        public double Price_C { get; set; }
        public double Price_D { get; set; }
        public double Price_Morning { get; set; }
        public double Price_Evening { get; set; }
        public double Price_Over { get; set; }
        public int Term { get; set; }
        public int TotalWeeks { get; set; }
        public int Duty1 { get; set; }
        public int Duty2 { get; set; }
        public int Duty3 { get; set; }
        public int Over_Span { get; set; }
        public int Over_Price { get; set; }
    }
}
