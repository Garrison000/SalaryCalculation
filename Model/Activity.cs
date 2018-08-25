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
        public long ID { get; set; }
        public string Name { get; set; }
        public virtual List<Teacher> Teachers { get; set; }
        public Time Time { get; set; }
        public double Value { get; set; }
        public virtual ActivityType Type { get; set; }
    }
    public class ActivityType
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public double DefaultValue { get; set; }//课时
        public ActivityTypeEnum TypeEnum { get; set; }
        public virtual List<Activity> Activities { get; set; }
    }

    public enum ActivityTypeEnum
    {
        Monitoring,//监考
        Affairs,
        Library,
        ClassAdviser,
        News,
        Other
    }
}
