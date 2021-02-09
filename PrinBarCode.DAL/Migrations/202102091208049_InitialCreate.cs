namespace PrinBarCode.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EncryptedDates",
                c => new
                    {
                        EncryptedDateId = c.Int(nullable: false, identity: true),
                        Jan = c.String(),
                        Feb = c.String(),
                        Mar = c.String(),
                        Apr = c.String(),
                        May = c.String(),
                        Jun = c.String(),
                        Jul = c.String(),
                        Aug = c.String(),
                        Sep = c.String(),
                        Oct = c.String(),
                        Nov = c.String(),
                        Dec = c.String(),
                    })
                .PrimaryKey(t => t.EncryptedDateId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EncryptedDates");
        }
    }
}
