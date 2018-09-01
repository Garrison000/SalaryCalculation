using Microsoft.VisualStudio.TestTools.UnitTesting;
using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Helper.Tests
{
    [TestClass()]
    public class LessonHelperTests
    {
        LessonHelper lessonHelper;
        [TestMethod()]
        public void InputLessonTest()
        {
            lessonHelper = LessonHelper.GetInstance();
            var result = lessonHelper.InputLesson("语文", "Dave", "小一（1）班", new Time { Order = 101, Term = (int)TimeType.Default, Week = (int)TimeType.Default }, -1, 1);
            if(!result.Succeeded)
            {
                Assert.Fail(string.Join(",",result.Info));
            }
            //Assert.Fail();
        }
    }
}