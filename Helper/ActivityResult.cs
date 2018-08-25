using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class ActivityResult
    {
        public bool Succeeded { get; set; }
        public string[] Info { get; set; }
        public object Object { get; set; }
        public static ActivityResult Error(params string[] error)
        {
            return new ActivityResult
            {
                Succeeded = false,
                Info = error
            };
        }
        public static ActivityResult Success()
        {
            return new ActivityResult
            {
                Succeeded = true
            };
        }
        public static ActivityResult Success(object obj)
        {
            return new ActivityResult
            {
                Succeeded = true,
                Object = obj
            };
        }
    }
}
