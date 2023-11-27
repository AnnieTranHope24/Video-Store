using FluentMigrator;

namespace Migrations
{
    [Migration(3)]
    public class M3_Video : Migration
    {
        public override void Down()
        {
            Delete.Table("Videos")
                .InSchema("videostore");
        }

        public override void Up()
        {
            Create.Table("Videos")
                .InSchema("videostore")
                .WithColumn("Id").AsInt64().Identity().PrimaryKey()
                .WithColumn("NewArrival").AsBinary().NotNullable()
                .WithColumn("PurchaseDate").AsDateTime().NotNullable();
        }
    }
}
