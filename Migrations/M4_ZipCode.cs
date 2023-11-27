using FluentMigrator;

namespace Migrations
{
    [Migration(4)]
    public class M4_ZipCode : Migration
    {
        public override void Down()
        {
            Delete.Table("ZipCode").InSchema("videostore");
        }

        public override void Up()
        {
            Create.Table("ZipCode")
                .InSchema("videostore")
                .WithColumn("Code").AsString(255).PrimaryKey()
                .WithColumn("City").AsString(255).NotNullable()
                .WithColumn("State").AsString(255).NotNullable();
        }
    }
}
