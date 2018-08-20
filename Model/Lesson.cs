﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
    public class LessonType
    {
        public int ID { get; set; }
        public LessonTypeEnum Type { get; set; }
        public string Name { get; set; }
        public int DefaultValue { get; set; }
        public double Price { get; set; }
        public virtual List<Lesson> Lessons { get; set; }
    }
    public class Lesson
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public virtual Teacher Teacher { get; set; }
        public Time Time { get; set; }
        public virtual LessonType Type { get; set; }
        public virtual SchoolClass SchoolClass { get; set; }
        public double Value { get; set; }
        public bool Enabled { get; set; }
    }
    public enum LessonTypeEnum
    {
        A,
        B,
        C,
        D,
        Morning,
        Evening,
        Over,
        Other
    }
}
