namespace PrinBarCode.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmployeePassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Password", c => c.String(maxLength: 24));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Password");
        }
    }
}
