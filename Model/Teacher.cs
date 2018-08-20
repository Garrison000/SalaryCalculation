using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace Model
{
    public class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual List<Lesson> Lessons { get; set; }
        public double Value { get; set; }
        public double Salary { get; set; }
        public virtual List<Activity> Activities { get; set; }
    }
}
