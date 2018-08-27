﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Excel = Microsoft.Office.Interop.Excel;

namespace Helper
{
    public class LessonHelper
    {
        private DatabaseContext context { get; set; }
        public int currentTerm
        {
            get
            {
                if(currentTerm==0)
                {
                    var constants = context.Constants.First();
                    currentTerm=constants.Term;
                }
                return currentTerm;
            }
            set
            {
                currentTerm = value;
            }
        }
        public int totalWeeks
        {
            get
            {
                if (totalWeeks == 0)
                {
                    var constants = context.Constants.First();
                    totalWeeks = constants.TotalWeeks;
                }
                return totalWeeks;
            }
            set
            {
                totalWeeks = value;
            }
        }
        private static LessonHelper helper { get; set; }

        /// <summary>
        /// 由该函数获取InputHelper的单例工厂类实例，请勿使用构造函数.
        /// </summary>
        /// <returns></returns>
        public static LessonHelper GetInstance()
        {
            if(helper==null)
            {
                helper = new LessonHelper();
            }
            return helper;
        }

        public LessonHelper()
        {
            helper.context = DatabaseContext.GetInstance();
            //名称类型对应表的初始化
        }
        
        public LessonResult InputLesson(string name,string teacherName, string @class, Time time, int term= (int)TimeType.Default, double value=0)
        {
            if(teacherName.Length<1||@class==null)
            {
                return LessonResult.Error("教师姓名出错，或班级输入不正确。");
            }
            var teacher = GetTeacher(teacherName);
            if(@class.Length<6)
            {
                return LessonResult.Error("班级字符串的长度不足6位，检查输入。");
            }
            if (term == (int)TimeType.Default)
                term = currentTerm;
            var schoolClass = GetSchoolClass(@class);
            if (time.Week ==(int)TimeType.Default)//没有指定哪一周的课程，对所有周都加入一次
            {
                for(int i=1;i<=totalWeeks;i++)
                {
                    var result = InputLesson(name, teacher, schoolClass, new Time { Order = time.Order, Week = i, Term = term }, term, value);
                    if(!result.Succeeded)
                    {
                        return result;
                    }
                }
                teacher.RegularValue += 1;
                return LessonResult.Success();
            }
            else if (time.Week == (int)TimeType.Sigle)
            {
                for(int i=1;i<=totalWeeks;i=i+2)
                {
                    var result = InputLesson(name, teacher, schoolClass, new Time { Order = time.Order, Week = i, Term = term }, term, value);
                    if (!result.Succeeded)
                    {
                        return result;
                    }
                }
                teacher.RegularValue += 0.5;
            }
            else if (time.Week == (int)TimeType.Double)
            {
                for (int i = 2; i <= totalWeeks; i = i + 2)
                {
                    var result = InputLesson(name, teacher, schoolClass, new Time { Order = time.Order, Week = i, Term = term }, term, value);
                    if (!result.Succeeded)
                    {
                        return result;
                    }
                }
                teacher.RegularValue += 0.5;
            }
            return InputLesson(name, teacher, schoolClass, time, term, value);
        }

        /// <summary>
        /// 最终的Input函数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="teacher"></param>
        /// <param name="schoolClass"></param>
        /// <param name="time"></param>
        /// <param name="term"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public LessonResult InputLesson(string name, Teacher teacher, SchoolClass schoolClass, Time time, int term= (int)TimeType.Default, double value=0)
        {
            var gettyperesult = GetLessonType(name, schoolClass.Grade);
            if(!gettyperesult.Succeeded)
            {
                return gettyperesult;
            }

            var type = gettyperesult.Object as LessonType;
            var lesson = new Lesson
            {
                Teacher = teacher,
                SchoolClass = schoolClass,
                Time = time,
                Name = name,
                Type = type,
                Value = value == 0 ? type.DefaultValue : value
            };
            context.Lessons.Add(lesson);
            Save();
            return LessonResult.Success();
        }
        
        /// <summary>
        /// 按照教师查找课程。
        /// </summary>
        /// <param name="t"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        public LessonResult FindLesson(Teacher t, int term = (int)TimeType.Default, int week = (int)TimeType.Default, int order = (int)TimeType.Default)
        {
            if (term == (int)TimeType.Default)
                term = currentTerm;
            if (t == null)
                return LessonResult.Error("找不到对应的教师。");
            Time time = new Time
            {
                Term = term,
                Order = order,
                Week = week
            };
            return FindLesson(t, time);
        }

        /// <summary>
        /// 按照教师和时间寻找课程。时间为默认时对该层级时间全部查询。
        /// </summary>
        /// <param name="t"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public LessonResult FindLesson(Teacher t, Time time)
        {
            if (t == null)
                return LessonResult.Error("找不到对应的教师。");
            if (time.Term == (int)TimeType.Default)
                time.Term = currentTerm;
            if (time.Week == (int)TimeType.None && time.Order == (int)TimeType.None)
                return LessonResult.Success(new List<Lesson>());
            if (time.Week == (int)TimeType.Default)
            {
                if (time.Order == (int)TimeType.Default)
                {
                    var lessons = t.Lessons.Where(o => o.Time.Term == time.Term);
                    return LessonResult.Success(lessons);
                }
                else
                {
                    var lessons = t.Lessons.Where(o => o.Time.Term == time.Term && o.Time.Order==time.Order);
                    return LessonResult.Success(lessons);
                }

            }
            else
            {
                if (time.Order == (int)TimeType.Default)
                {
                    var lessons = t.Lessons.Where(o => o.Time.Term == time.Term && o.Time.Week == time.Week);
                    return LessonResult.Success(lessons);
                }
                else
                {
                    var lessons = t.Lessons.Where(o => o.Time.Term == time.Term && o.Time.Week == time.Week && o.Time.Order == time.Order);
                    return LessonResult.Success(lessons);
                }
            }
        }

        /// <summary>
        /// 按照班级查找课程。
        /// </summary>
        /// <param name="c"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        public LessonResult FindLesson(SchoolClass c,int term = (int)TimeType.Default)
        {
            if (term == (int)TimeType.Default) term = currentTerm;
            if (c == null)
                return LessonResult.Error("找不到对应的班级。");
            var lessons = context.Lessons.Where(o => o.SchoolClass == c && o.Time.Term == term);
            return LessonResult.Success(lessons);
        }

        /// <summary>
        /// 在工资计算时无视某时间段的课程
        /// </summary>
        /// <param name="t"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public LessonResult DisableLesson(Teacher t, Time time)
        {
            var result = FindLesson(t, time);
            if (!result.Succeeded)
                return result;
            var lessons = result.Object as IQueryable<Lesson>;
            foreach (var lesson in lessons)
            {
                lesson.Enabled = false;
            }
            Save();
            return LessonResult.Success();
        }

        public LessonResult DisableLesson(Lesson l)
        {
            if (l == null)
                return LessonResult.Error("停用课程时没有找到对应的课程。");
            l.Enabled = false;
            Save();
            return LessonResult.Success();
        }

        public LessonResult EnableLesson(Teacher t, Time time)
        {
            var result = FindLesson(t, time);
            if (!result.Succeeded)
                return result;
            var lessons = result.Object as IQueryable<Lesson>;
            foreach (var lesson in lessons)
            {
                lesson.Enabled = true;
            }
            Save();
            return LessonResult.Success();
        }

        public LessonResult EnableLesson(Lesson l)
        {
            if (l == null)
                return LessonResult.Error("启用课程时没有找到对应的课程。");
            l.Enabled = true;
            Save();
            return LessonResult.Success();
        }

        public LessonResult ChangeLessonStatus(Lesson l)
        {
            if (l == null)
                return LessonResult.Error("改变课程状态时没有找到对应的课程。");
            l.Enabled = !l.Enabled;
            Save();
            return LessonResult.Success();
        }

        public Teacher GetTeacher(string teacherName)
        {
            var teacher = context.Teachers.FirstOrDefault(o => o.Name == teacherName);//以名字为索引。
            if(teacher==null)
            {
                teacher = CreateTeacher(teacherName);
            }
            return teacher;
        }

        public Teacher CreateTeacher(string teacherName)
        {
            var teacher = context.Teachers.FirstOrDefault(o => o.Name == teacherName);
            if(teacher==null)
            {
                teacher = new Teacher
                {
                    Name = teacherName
                };
                context.Teachers.Add(teacher);
                Save();
            }
            return teacher;
        }

        private SchoolClass GetSchoolClass(string name)
        {
            string substr = name.Substring(0, 2);
            int grade;
            switch (substr)
            {
                case "小一":
                    grade = 1;
                    break;
                case "小二":
                    grade = 2;
                    break;
                case "小三":
                    grade = 3;
                    break;
                case "小四":
                    grade = 4;
                    break;
                case "小五":
                    grade = 5;
                    break;
                case "小六":
                    grade = 6;
                    break;
                case "初一":
                    grade = 7;
                    break;
                case "初二":
                    grade = 8;
                    break;
                case "初三":
                    grade = 9;
                    break;
                default:
                    grade = -1;
                    break;
            }
            var schoolClass = context.Classes.FirstOrDefault(o => o.Name == name);
            if(schoolClass==null)
            {
                schoolClass = new SchoolClass
                {
                    Name = name,
                    Grade = grade
                };
                context.Classes.Add(schoolClass);
                Save();
            }
            return schoolClass;
        }


        /// <summary>
        /// 获取课程的所属类型
        /// </summary>
        /// <param name="name"></param>
        /// <param name="grade"></param>
        /// <returns></returns>
        public LessonResult GetLessonType(string name,int grade)
        {
            //先看看有多慢吧。
            var type = context.LessonTypes.FirstOrDefault(o => (o.LessonName == name && o.Grade == grade));
            if (type == null)
                return LessonResult.Error("LessonType对应表中找不到课程对应的类型。");
            if(type==null)
            {
                context.LessonTypes.Add(new LessonType
                {
                    DefaultValue = 1,//默认1课时
                    Price = GetPrice(type.Type),
                    LessonName = name,//单元测试一下这个tostring是什么样子的.
                    Type = type.Type
                });
                Save();
            }
            return LessonResult.Success(type);
        }

        public LessonResult GetTypeByEnum(LessonTypeEnum en)
        {
            var types = context.LessonTypes.Where(o => o.Type == en);
            return LessonResult.Success(types);
        }
        
        
        public LessonTypeEnum LetterToEnum(string letter)
        {
            switch (letter)
            {
                case "A":
                    return LessonTypeEnum.A;
                case "B":
                    return LessonTypeEnum.B;
                case "C":
                    return LessonTypeEnum.C;
                case "E":
                    return LessonTypeEnum.Evening;
                case "M":
                    return LessonTypeEnum.Morning;
                default:
                    return LessonTypeEnum.D;
            }
        }

        public double GetPrice(LessonTypeEnum type)
        {
            var constants = context.Constants.First();
            switch (type)
            {
                case LessonTypeEnum.A:
                    return constants.Price_A;
                case LessonTypeEnum.B:
                    return constants.Price_B;
                case LessonTypeEnum.C:
                    return constants.Price_C;
                case LessonTypeEnum.D:
                    return constants.Price_D;
                case LessonTypeEnum.Morning:
                    return constants.Price_Morning;
                case LessonTypeEnum.Evening:
                    return constants.Price_Evening;
                case LessonTypeEnum.Over:
                    return constants.Price_Over;
                default:
                    return 0;
            }
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
