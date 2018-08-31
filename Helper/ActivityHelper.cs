using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;

namespace Helper
{
    public class ActivityHelper
    {
        private DatabaseContext context { get; set; } 

        private LessonHelper lessonHelper { get; set; }

        public int currentTerm
        {
            get
            {
                if (currentTerm == 0)
                {
                    var constants = context.Constants.First();
                    currentTerm = constants.Term;
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

        private static ActivityHelper helper { get; set; }

        /// <summary>
        /// 由该函数获取ActivityHelper的单例工厂类实例，请勿使用构造函数.
        /// </summary>
        /// <returns></returns>
        public static ActivityHelper GetInstance()
        {
            if (helper == null)
            {
                helper = new ActivityHelper();
            }
            return helper;
        }

        public ActivityHelper()
        {
            helper.context = DatabaseContext.GetInstance();
            lessonHelper = LessonHelper.GetInstance();
            //名称类型对应表的初始化
        }
 
        public ActivityResult FindActivity(Teacher t, int term = (int)TimeType.Default, int week = (int)TimeType.Default, int order = (int)TimeType.Default)
        {
            if (term == (int)TimeType.Default)
                term = currentTerm;
            if (t == null)
                return ActivityResult.Error("找不到对应的教师。");
            Time time = new Time
            {
                Term = term,
                Order = order,
                Week = week
            };
            return FindActivity(t, time);
        }

        public ActivityResult FindActivity(Teacher t, Time time)
        {
            if (t == null)
                return ActivityResult.Error("找不到对应的教师。");
            if (time.Term == (int)TimeType.Default)
                time.Term = currentTerm;
            if (time.Week == (int)TimeType.Default)
            {
                if (time.Order == (int)TimeType.Default)
                {
                    var activities = t.Activities.Where(o => o.Time.Term == time.Term);
                    return ActivityResult.Success(activities);
                }
                else
                {
                    var activities = t.Activities.Where(o => o.Time.Term == time.Term && o.Time.Order == time.Order);
                    return ActivityResult.Success(activities);
                }

            }
            else
            {
                if (time.Order == (int)TimeType.Default)
                {
                    var activities = t.Activities.Where(o => o.Time.Term == time.Term && o.Time.Week == time.Week);
                    return ActivityResult.Success(activities);
                }
                else
                {
                    var activities = t.Activities.Where(o => o.Time.Term == time.Term && o.Time.Week == time.Week && o.Time.Order == time.Order);
                    return ActivityResult.Success(activities);
                }
            }
        }

        public ActivityResult AddActivity(string name, IQueryable<Teacher> teachers, Time time, ActivityType type)
        {
            if (teachers.Count() == 0)
                return ActivityResult.Error("活动没有教师。");
            if (time.Term == (int)TimeType.Default)
                time.Term = currentTerm;
            var activity = new Activity
            {
                Name = name,
                Teachers = new List<Teacher>(),
                Time = time,
                Type = type
            };
            //停掉对应时间的课
            foreach (var teacher in teachers)
            {
                lessonHelper.DisableLesson(teacher, time);
            }
            activity.Teachers.AddRange(teachers);
            context.Activities.Add(activity);
            Save();
            return ActivityResult.Success();
        }

        public ActivityResult AddIntoActivity(Activity activity, IQueryable<Teacher> teachers)
        {
            if (activity == null)
                return ActivityResult.Error("没有找到对应的活动。");
            foreach (var teacher in teachers)
            {
                lessonHelper.DisableLesson(teacher, activity.Time);
                teacher.Activities.Add(activity);
            }
            Save();
            return ActivityResult.Success();
        }

        public ActivityResult RemoveFromActivity(Activity activity, Teacher teacher)
        {
            if(activity==null||teacher==null)
            {
                return ActivityResult.Error("将教师从活动中移除失败，找不到对应的活动或教师。");
            }
            if(teacher.Activities.FirstOrDefault(o=>o.ID==activity.ID)==null)
            {
                return ActivityResult.Error("该教师尚未加入该活动。");
            }
            var t = context.Teachers.FirstOrDefault(o => o.ID == teacher.ID);
            if(t==null)
            {
                return ActivityResult.Error("将教师从活动中移除失败，数据库中找不到对应的教师。");
            }
            activity.Teachers.Remove(t);
            //测试用：
            var tindb = context.Teachers.FirstOrDefault(o => o.ID == teacher.ID);
            if(tindb.Activities.FirstOrDefault(o=>o.ID == activity.ID)!=null)
            {
                return ActivityResult.Error("EF多对多的删除方法有误。");
            }
            Save();
            return ActivityResult.Success();
        }

        public ActivityResult EditActivity(Teacher t, Activity activity, string name, double value, Time time)
        {
            if (t == null || activity == null)
                return ActivityResult.Error("找不到对应的教师或活动。");
            activity.Name = name;
            activity.Value = value;
            //先不加modified，稍后试加modified是什么效果。
            Save();
            return ActivityResult.Success(activity);
        }

        public ActivityResult DeleteActivity(Activity activity)
        {
            if (activity == null)
                return ActivityResult.Error("找不到对应的活动。");
            var teachers = activity.Teachers;
            foreach (var teacher in teachers)
            {
                if (!teacher.Activities.Any(o => o.Time.Term == activity.Time.Term && o.Time.Week == activity.Time.Week && o.Time.Order == activity.Time.Order))
                {
                    lessonHelper.EnableLesson(teacher, activity.Time);
                }
            }
            context.Activities.Remove(activity);
            Save();
            return ActivityResult.Success();
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
