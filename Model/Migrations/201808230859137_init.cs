namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Double(nullable: false),
                        Type_ID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ActivityTypes", t => t.Type_ID, cascadeDelete: true)
                .Index(t => t.Type_ID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Double(nullable: false),
                        RegularValue = c.Double(nullable: false),
                        Salary = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Double(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        SchoolClass_ID = c.Long(nullable: false),
                        Type_ID = c.Long(nullable: false),
                        Teacher_ID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SchoolClasses", t => t.SchoolClass_ID, cascadeDelete: true)
                .ForeignKey("dbo.LessonTypes", t => t.Type_ID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.Teacher_ID, cascadeDelete: true)
                .Index(t => t.SchoolClass_ID)
                .Index(t => t.Type_ID)
                .Index(t => t.Teacher_ID);
            
            CreateTable(
                "dbo.SchoolClasses",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Grade = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LessonTypes",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Name = c.String(),
                        DefaultValue = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ActivityTypes",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        DefaultValue = c.Double(nullable: false),
                        TypeEnum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Constants",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Price_A = c.Double(nullable: false),
                        Price_B = c.Double(nullable: false),
                        Price_C = c.Double(nullable: false),
                        Price_D = c.Double(nullable: false),
                        Price_Morning = c.Double(nullable: false),
                        Price_Evening = c.Double(nullable: false),
                        Price_Over = c.Double(nullable: false),
                        Term = c.Int(nullable: false),
                        TotalWeeks = c.Int(nullable: false),
                        Duty1 = c.Int(nullable: false),
                        Duty2 = c.Int(nullable: false),
                        Duty3 = c.Int(nullable: false),
                        Over_Span = c.Int(nullable: false),
                        Over_Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.NameTypes",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Grade = c.Int(nullable: false),
                        LessonTypeEnum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TeacherActivities",
                c => new
                    {
                        Teacher_ID = c.Long(nullable: false),
                        Activity_ID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_ID, t.Activity_ID })
                .ForeignKey("dbo.Teachers", t => t.Teacher_ID, cascadeDelete: true)
                .ForeignKey("dbo.Activities", t => t.Activity_ID, cascadeDelete: true)
                .Index(t => t.Teacher_ID)
                .Index(t => t.Activity_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "Type_ID", "dbo.ActivityTypes");
            DropForeignKey("dbo.Lessons", "Teacher_ID", "dbo.Teachers");
            DropForeignKey("dbo.Lessons", "Type_ID", "dbo.LessonTypes");
            DropForeignKey("dbo.Lessons", "SchoolClass_ID", "dbo.SchoolClasses");
            DropForeignKey("dbo.TeacherActivities", "Activity_ID", "dbo.Activities");
            DropForeignKey("dbo.TeacherActivities", "Teacher_ID", "dbo.Teachers");
            DropIndex("dbo.TeacherActivities", new[] { "Activity_ID" });
            DropIndex("dbo.TeacherActivities", new[] { "Teacher_ID" });
            DropIndex("dbo.Lessons", new[] { "Teacher_ID" });
            DropIndex("dbo.Lessons", new[] { "Type_ID" });
            DropIndex("dbo.Lessons", new[] { "SchoolClass_ID" });
            DropIndex("dbo.Activities", new[] { "Type_ID" });
            DropTable("dbo.TeacherActivities");
            DropTable("dbo.NameTypes");
            DropTable("dbo.Constants");
            DropTable("dbo.ActivityTypes");
            DropTable("dbo.LessonTypes");
            DropTable("dbo.SchoolClasses");
            DropTable("dbo.Lessons");
            DropTable("dbo.Teachers");
            DropTable("dbo.Activities");
        }
    }
}
