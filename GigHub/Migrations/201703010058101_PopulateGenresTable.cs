namespace GigHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES (id,Name) VALUES (1, 'Jazz')");
            Sql("INSERT INTO GENRES (id,Name) VALUES (2, 'Techno')");
            Sql("INSERT INTO GENRES (id,Name) VALUES (3, 'Blues')");
            Sql("INSERT INTO GENRES (id,Name) VALUES (4, 'Rock')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM GENRES WHERE Id IN(1,2,3,4)");
        }
    }
}
