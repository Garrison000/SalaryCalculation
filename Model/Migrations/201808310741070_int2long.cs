namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class int2long : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LessonTypes", "TypeName", c => c.String());
            AddColumn("dbo.LessonTypes", "LessonName", c => c.String());
            AddColumn("dbo.LessonTypes", "Grade", c => c.Int(nullable: false));
            AddColumn("dbo.Constants", "Price_Mon1", c => c.Double(nullable: false));
            AddColumn("dbo.Constants", "Price_Mon2", c => c.Double(nullable: false));
            AlterColumn("dbo.LessonTypes", "DefaultValue", c => c.Double(nullable: false));
            DropColumn("dbo.LessonTypes", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LessonTypes", "Name", c => c.String());
            AlterColumn("dbo.LessonTypes", "DefaultValue", c => c.Int(nullable: false));
            DropColumn("dbo.Constants", "Price_Mon2");
            DropColumn("dbo.Constants", "Price_Mon1");
            DropColumn("dbo.LessonTypes", "Grade");
            DropColumn("dbo.LessonTypes", "LessonName");
            DropColumn("dbo.LessonTypes", "TypeName");
        }
    }
}
