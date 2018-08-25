using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
    public class SchoolClass
    {
        public long ID { get; set; }
        public int Grade { get; set; }//1~6表示1~6年级，7~9代表初一~初三
        public string Name { get; set; }
        public virtual List<Lesson> Lessons { get; set; }
    }
}
