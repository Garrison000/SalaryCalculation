using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class NameType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public LessonTypeEnum LessonTypeEnum { get; set; }
    }
}
