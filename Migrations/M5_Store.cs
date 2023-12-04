
using FluentMigrator;

namespace Migrations
{
    [Migration(5)]
    public class M5_Store : Migration
    {
        public override void Down()
        {
            Delete.Table("Store").InSchema("videostore");
        }

        public override void Up()
        {

        Create.Table("Store")
                .InSchema("videostore")
                .WithColumn("Id").AsInt64().Identity().PrimaryKey()
                .WithColumn("StreetAddress").AsString(255).NotNullable()
                .WithColumn("PhoneNumber").AsString(255).Nullable();
        }
    }
}