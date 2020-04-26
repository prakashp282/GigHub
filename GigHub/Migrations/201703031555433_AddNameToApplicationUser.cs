namespace GigHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddNameToApplicationUser : DbMigration
    {
        public override void Up()
        {
            //specified length because by convention string can be nullable
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
