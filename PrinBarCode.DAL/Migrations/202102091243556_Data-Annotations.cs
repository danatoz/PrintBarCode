namespace PrinBarCode.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EncryptedDates", "Jan", c => c.String(maxLength: 100));
            AlterColumn("dbo.EncryptedDates", "Feb", c => c.String(maxLength: 100));
            AlterColumn("dbo.EncryptedDates", "Mar", c => c.String(maxLength: 100));
            AlterColumn("dbo.EncryptedDates", "Apr", c => c.String(maxLength: 100));
            AlterColumn("dbo.EncryptedDates", "May", c => c.String(maxLength: 100));
            AlterColumn("dbo.EncryptedDates", "Jun", c => c.String(maxLength: 100));
            AlterColumn("dbo.EncryptedDates", "Jul", c => c.String(maxLength: 100));
            AlterColumn("dbo.EncryptedDates", "Aug", c => c.String(maxLength: 100));
            AlterColumn("dbo.EncryptedDates", "Sep", c => c.String(maxLength: 100));
            AlterColumn("dbo.EncryptedDates", "Oct", c => c.String(maxLength: 100));
            AlterColumn("dbo.EncryptedDates", "Nov", c => c.String(maxLength: 100));
            AlterColumn("dbo.EncryptedDates", "Dec", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EncryptedDates", "Dec", c => c.String());
            AlterColumn("dbo.EncryptedDates", "Nov", c => c.String());
            AlterColumn("dbo.EncryptedDates", "Oct", c => c.String());
            AlterColumn("dbo.EncryptedDates", "Sep", c => c.String());
            AlterColumn("dbo.EncryptedDates", "Aug", c => c.String());
            AlterColumn("dbo.EncryptedDates", "Jul", c => c.String());
            AlterColumn("dbo.EncryptedDates", "Jun", c => c.String());
            AlterColumn("dbo.EncryptedDates", "May", c => c.String());
            AlterColumn("dbo.EncryptedDates", "Apr", c => c.String());
            AlterColumn("dbo.EncryptedDates", "Mar", c => c.String());
            AlterColumn("dbo.EncryptedDates", "Feb", c => c.String());
            AlterColumn("dbo.EncryptedDates", "Jan", c => c.String());
        }
    }
}
