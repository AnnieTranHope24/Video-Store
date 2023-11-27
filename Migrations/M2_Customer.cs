using FluentMigrator;

namespace Migrations
{
    [Migration(2)]
    public class M2_Customer : Migration
    {
        public override void Down()
        {
            Delete.Table("Customer")
                .InSchema("videostore");
        }

        public override void Up()
        {
            Create.Table("Customer")
                .InSchema("videostore")
                .WithColumn("Id").AsInt64().Identity().PrimaryKey()
                .WithColumn("Title").AsString(255).NotNullable()
                .WithColumn("First").AsString(255).NotNullable()
                .WithColumn("Middle").AsString(255).NotNullable()
                .WithColumn("Last").AsString(255).NotNullable()
                .WithColumn("Suffix").AsString(255).NotNullable()
                .WithColumn("EmailAddress").AsString(255).NotNullable()
                .WithColumn("StreetAddress").AsString(255).NotNullable()
                .WithColumn("Password").AsString(255).NotNullable()
                .WithColumn("Phone").AsString(255).NotNullable();
        }
    }
}
