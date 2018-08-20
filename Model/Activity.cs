using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
    public class Activity
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public virtual List<Teacher> Teachers { get; set; }
        public Time Time { get; set; }
        public virtual ActivityType Type { get; set; }
    }
    public class ActivityType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public virtual List<Activity> Activities { get; set; }
    }
}
