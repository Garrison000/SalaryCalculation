using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Helper
{
    public class LessonResult
    {
        public bool Succeeded { get; set; }
        public string[] Info { get; set; }
        public object Object { get; set; }
        public static LessonResult Error(params string[] error)
        {
            return new LessonResult
            {
                Succeeded = false,
                Info = error
            };
        }
        public static LessonResult Success()
        {
            return new LessonResult
            {
                Succeeded = true
            };
        }
        public static LessonResult Success(object obj)
        {
            return new LessonResult
            {
                Succeeded = true,
                Object = obj
            };
        }
    }
}
