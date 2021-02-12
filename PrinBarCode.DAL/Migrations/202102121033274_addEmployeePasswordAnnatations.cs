namespace PrinBarCode.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmployeePasswordAnnatations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Employees", "Password", c => c.String(nullable: false, maxLength: 24));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Password", c => c.String(maxLength: 24));
            AlterColumn("dbo.Employees", "Name", c => c.String(maxLength: 100));
        }
    }
}
