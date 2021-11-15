namespace MidTermProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDataTypeToGradeInStudent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Grade", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Grade", c => c.Int(nullable: false));
        }
    }
}
